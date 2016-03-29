-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成

ui_manager = class()
function ui_manager:init()
    -- 所有已加载的 Session
    self._all_sessions = { }
    -- 当前正在显示的 Session
    self._shown_sessions = { }
    -- 普通窗口用来导航用到的堆栈
    self._back_sequence = stack:create()
    -- 弹出窗口用来导航用到的堆栈
    self._popup_back_sequence = stack:create()
    -- 管理器级的锁定操作
    self.is_locked = false

    local ui_layer_go = UGameObject.Find("UILayer")
    self.ui_layer = ui_layer_go.transform
    UObject.DontDestroyOnLoad(ui_layer_go);

    assert(not tolua.isnull(self.ui_layer), "UILayer is cannot find~~~~~~")
end

function ui_manager:instance()
    if self._instance == nil then
        self._instance = ui_manager()
    end

    return self._instance
end

function ui_manager:reset()
    self._all_sessions = { }
    self._shown_sessions = { }
    self._back_sequence:clear()
    self._popup_back_sequence:clear()
end

function ui_manager:show_popup(ui_session, is_close_cur, args, uicommon_handler)
    if not ui_session then return end
    local session_id = ui_session:get_session_id()

    if self._shown_sessions[session_id] ~= nil then
        return
    end

    local session_data = ui_session.session_data
    if not session_data then return end

    if session_data.session_type ~= ui_session_type.popup then
        return
    end

    if is_close_cur then
        local cur_top_popsession = self._popup_back_sequence:peek()
        if cur_top_popsession then
            local cur_toppop_id = cur_top_popsession:get_session_id()
            if cur_toppop_id == session_id then
                return
            else
                self._shown_sessions[cur_toppop_id]:destroy_session()
                self._shown_sessions[cur_toppop_id] = nil
                self._all_sessions[cur_toppop_id] = nil
                self._popup_back_sequence:pop()
            end
        end
    end

    if uicommon_handler and uicommon_handler.before_handler then
        uicommon_handler.before_handler()
    end

    GameResFactory.Instance():GetUIPrefab(session_data.prefab_name, self:get_session_root(ui_session_type.popup),
    function(go)
        ui_session:on_post_load()
        self._all_sessions[session_id] = ui_session

        ui_session:reset_window(args)
        ui_session:show_session()
        ui_session:enter_anim()

        self._shown_sessions[session_id] = ui_session
        self._popup_back_sequence:push(ui_session)

        if uicommon_handler and uicommon_handler.after_handler then
            uicommon_handler.afterHandler()
        end
    end )
end

-- 关闭栈顶弹窗
function ui_manager:close_popup(uicommon_handler)
    local top_pop_session = self._popup_back_sequence:peek()
    if not top_pop_session then
        return
    end

    local top_pop_session_id = top_pop_session:get_session_id()
    top_pop_session:quit_anim( function()
        top_pop_session:destroy_session()
        self._shown_sessions[top_pop_session_id] = nil
        self._all_sessions[top_pop_session_id] = nil
        self._popup_back_sequence:pop()
    end )
end

function ui_manager:close_current_session()
    -- 关闭当前界面
    if self.current_session then
        local cur_session_id = self.current_session:get_session_id()
        if not cur_session_id then return end

        local cur_top_session = self._back_sequence:peek()
        local cur_top_session_id = cur_top_session:get_session_id()
        self:destroy_session(cur_top_session_id)
        if cur_session_id == cur_top_session_id then
            self._back_sequence:pop()
        end
    end
end

function ui_manager:show_session(ui_session, args, done_handler)
    if not ui_session then return end
    local session_id = ui_session:get_session_id()

    if self._shown_sessions[session_id] ~= nil then
        return
    end

    local session_data = ui_session.session_data
    if not session_data then return end

    if session_data.session_type == ui_session_type.popup then
        return
    end

    self:close_current_session()

    GameResFactory.Instance():GetUIPrefab(session_data.prefab_name, self:get_session_root(session_data.session_type),
    function(go)
        ui_session:on_post_load()
        self._all_sessions[session_id] = ui_session

        ui_session:reset_window(args)
        ui_session:show_session()
        ui_session:enter_anim()

        self._shown_sessions[session_id] = ui_session

        self.last_session = self.current_session
        self.current_session = ui_session

        self._back_sequence:push(ui_session)

        if done_handler then
            done_handler()
        end
    end )
end

local function co_show_session_delay(self, delay_time, ui_session, args)
    coroutine.wait(delay_time)
    self:show_session(ui_session, args)
end

function ui_manager:show_session_delay(delay_time, ui_session, args)
    coroutine.start(co_show_session_delay, self, delay_time, ui_session, args)
end

function ui_manager:change_child_layer(go, layer)
    go.layer = layer
    local tmp_tr = go.transform
    for i = 0, tmp_tr.childCount - 1 do
        local child = tmp_tr:GetChild(i)
        child.gameObject.layer = layer
        self:change_child_layer(child, layer)
    end
end

function ui_manager:create_layer_root(go_name, sort_order)
    local tmp_go = UGameObject(go_name)

    local rt_transform = tmp_go:AddComponent(typeof(UnityEngine.RectTransform))

    rt_transform:SetParent(self.ui_layer, false)

    self:change_child_layer(tmp_go, LayerMask.NameToLayer("UI"))

    rt_transform.anchorMin = Vector2.zero
    rt_transform.anchorMax = Vector2.one

    rt_transform.offsetMax = Vector2.zero
    rt_transform.offsetMin = Vector2.zero

    local tmp_canvas = tmp_go:AddComponent(typeof(UnityEngine.Canvas))
    tmp_canvas.overrideSorting = true
    tmp_canvas.sortingOrder = sort_order
    tmp_go:AddComponent(typeof(UnityEngine.UI.GraphicRaycaster))

    return rt_transform
end

function ui_manager:get_session_root(session_type)

    if session_type == ui_session_type.background then
        if not self.background_root then
            self.background_root = self:create_layer_root("BackGroundRoot", 2)
        end
        return self.background_root
    elseif session_type == ui_session_type.normal then
        if not self.normal_root then
            self.normal_root = self:create_layer_root("NormalRoot", 10)
        end
        return self.normal_root
    elseif session_type == ui_session_type.fixed then
        if not self.fixed_root then
            self.fixed_root = self:create_layer_root("FixedRoot", 250)
        end
        return self.fixed_root
    elseif session_type == ui_session_type.popup then
        if not self.popup_root then
            self.popup_root = self:create_layer_root("PopUpRoot", 500)
        end
        return self.popup_root
    elseif session_type == ui_session_type.above_popup then
        if not self.above_popup_root then
            self.above_popup_root = self:create_layer_root("AbovePopUpRoot", 750)
        end
        return self.above_popup_root
    elseif session_type == ui_session_type.tutorial then
        if not self.tutorial_root then
            self.tutorial_root = self:create_layer_root("TutorialRoot", 1000)
        end
        return self.tutorial_root
    elseif session_type == ui_session_type.above_tutorial then
        if not self.above_tutorial_root then
            self.above_tutorial_root = self:create_layer_root("AboveTutorialRoot", 1250)
        end
        return self.above_tutorial_root
    else
        return self.ui_layer
    end
end

function ui_manager:hide_session(session_id, uicommon_handler)
    if self._shown_sessions[session_id] == nil then
        return
    end
    self._shown_sessions[session_id]:hide_session(uicommon_handler)
    self._shown_sessions[session_id] = nil
end

function ui_manager:destroy_session(session_id, uicommon_handler)
    if not self._all_sessions[session_id] then
        return
    end
    if self._shown_sessions[session_id] then
        self._shown_sessions[session_id] = nil
    end
    self._all_sessions[session_id]:destroy_session(uicommon_handler)
    self._all_sessions[session_id] = nil
end

function ui_manager:do_go_back()
    if not self.current_session then return false end

    if self._back_sequence:getn() == 0 then
        -- 如果当前BackSequenceData 不存在返回数据
        -- 检测lastSession
        local pre_session_id = self.last_session and self.last_session:get_session_id() or ui_session_id.invalid
        if pre_session_id ~= ui_session_id.invalid then
            self:close_current_session()
            self:show_session(self.last_session)
            return true
        else
            return false
        end
    else
        local back_session = self._back_sequence:peek()
        if back_session then
            self:close_current_session()
            self:show_session(back_session)
        else
            return false
        end
    end
end

function ui_manager:go_back(pre_goback_handler)
    if not pre_goback_handler then
        local need_return = pre_goback_handler()
        if not need_return then
            return false
        end
    end
    return self:do_go_back()
end

function ui_manager:clear_back_sequence()
    self._back_sequence:clear()
end

function ui_manager:clear_popup_back_sequence()
    self._popup_back_sequence:clear()
end

function ui_manager:clear_all_session()
    for _, v in pairs(self._all_sessions) do
        v:destroy_session()
    end
    self._all_sessions = { }
    self._shown_sessions = { }
    self._back_sequence:clear()
    self._popup_back_sequence:clear()
end

function ui_manager:hide_all_shown_sessions(include_fixed)
    if not include_fixed then
        for k, v in pairs(self._shown_sessions) do
            if v.session_data.session_type ~= ui_session_type.fixed then
                v:hide_session_directly()
                self._shown_sessions[k] = nil
            end
        end
    else
        for _, v in pairs(self._shown_sessions) do
            v:hide_session_directly()
        end
        self._shown_sessions = { }
    end
end

-- endregion
