-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成
ui_session_type =
{
    -- 背景层
    background = 1,
    -- 普通界面(UIMainMenu等)
    normal = 2,
    -- 固定窗口(UITopBar等)
    fixed = 3,
    -- 弹窗
    popup = 4,
    -- 游戏中需显示到弹窗上的
    above_popup = 5,
    -- 新手指引
    tutorial = 6,
    -- 新手指引上的比如跑马灯新闻
    above_tutorial = 7,
}

ui_common_handler = class()
function ui_common_handler:init(before_handler, after_handler)
    self.before_handler = before_handler
    self.after_handler = after_handler
end

ui_anim_handler = class()
function ui_anim_handler:init(before_handler, reset_handler, after_handler)
    self.before_handler = before_handler
    self.reset_handler = reset_handler
    self.after_handler = after_handler
end

-- 界面状态数据
ui_session_data = class()
function ui_session_data:init(session_type, prefab_name)
    self.session_type = session_type
    self.prefab_name = prefab_name
end

ui_session = class()
function ui_session:init(session_data)
    -- 如果需要可以添加一个BoxCollider屏蔽事件
    self.is_lock = false
    self.is_shown = false
    -- 当前界面ID
    self.session_id = ui_session_id.invalid
    self.session_data = session_data
end

-- 界面被加载后
function ui_session:on_post_load()
end

-- 界面被销毁前 
function ui_session:on_pre_destroy()
end

-- 重置窗口
function ui_session:reset_window()
end

-- 显示窗口
function ui_session:show_session()
    self.is_lock = false
    self.is_shown = true
    if not tolua.isnull(self.gameObject) then
        self.gameObject:SetActive(true)
    end
end

-- 显示动画
function ui_session:enter_anim(done_handler)
end

-- 退出动画
function ui_session:quit_anim(done_handler)
end

-- 重置动画
function ui_session:reset_anim(done_handler)
end

-- 隐藏窗口
function ui_session:hide_session_directly()
    self.is_lock = true
    self.is_shown = false
    if not tolua.isnull(self.gameObject) then
        self.gameObject:SetActive(false)
    end
end

function ui_session:hide_session(uicommmon_handler)
    if uicommmon_handler and uicommmon_handler.before_handler then
        uicommmon_handler.before_handler()
    end
    self.is_lock = true
    self.is_shown = false
    if not tolua.isnull(self.gameObject) then
        self.gameObject:SetActive(false)
    end
    if uicommmon_handler and uicommmon_handler.after_handler then
        uicommmon_handler.after_handler()
    end
end

function ui_session:destroy_session(uicommmon_handler)
    if uicommmon_handler and uiCommmonHandler.before_handler then
        uicommmon_handler.before_handler()
    end

    self:on_pre_destroy()

    UObject.Destroy(self.gameObject)

    if uicommmon_handler and uicommmon_handler.after_handler then
        uicommmon_handler.after_handler()
    end
end

function ui_session:get_session_id()
    return self.session_id;
end
-- endregion
