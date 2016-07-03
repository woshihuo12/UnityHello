-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成
local class = require("common/middleclass")

local ui_messagebox = class("ui_messagebox", ui_session)

function ui_messagebox.show(args)
    local ui_manager = fw_facade:instance():get_mgr(mgr_name.UI_MGR)
    if ui_manager ~= nil then
        ui_manager:instance():show_popup(ui_messagebox(ui_session_data(ui_session_type.POPUP, ui_session_id.UI_MESSAGEBOX)), true, args)
    end
end

function ui_messagebox.close()
    local ui_manager = fw_facade:instance():get_mgr(mgr_name.UI_MGR)
    if ui_manager ~= nil then
        ui_manager:instance():close_popup()
    end
end

function ui_messagebox:initialize(sessionData)
    ui_session.initialize(self, sessionData)
    self.session_id = ui_session_id.UI_MESSAGEBOX
end

function ui_messagebox:on_post_load()
    self._content_tr = self.transform:Find("content")
    local close_btn_go = self._content_tr:Find("btnClose").gameObject
    self.lua_behaviour:AddClick(close_btn_go, function()
        ui_messagebox.close()
    end )
    self._content_lb = self._content_tr:Find("desc"):GetComponent(typeof(UText))

    self._left_btn_go = self._content_tr:Find("btnLeft").gameObject
    self._left_btn_txt = self._left_btn_go.transform:Find("txt"):GetComponent(typeof(UText))

    self._center_btn_go = self._content_tr:Find("btnCenter").gameObject
    self._center_btn_txt = self._center_btn_go.transform:Find("txt"):GetComponent(typeof(UText))

    self._right_btn_go = self._content_tr:Find("btnRight").gameObject
    self._right_btn_txt = self._right_btn_go.transform:Find("txt"):GetComponent(typeof(UText))
end

function ui_messagebox:_on_enter_btn1(args)
    self._center_btn_go:SetActive(true)
    if args.center_btn_handler then
        self.lua_behaviour:AddClick(self._center_btn_go, function()
            args.center_btn_handler()
        end )
    end

    if args.content_str then
        self._content_lb.text = args.content_str
    end

    if args.center_btn_str then
        self._center_btn_txt.text = args.center_btn_str
    end
end

function ui_messagebox:_on_enter_btn2(args)
    self._left_btn_go:SetActive(true)
    self._right_btn_go:SetActive(true)
    if args.left_btn_handler then
        self.lua_behaviour:AddClick(self._left_btn_go, function()
            args.left_btn_handler()
        end )
    end

    if args.right_btn_handler then
        self.lua_behaviour:AddClick(self._right_btn_go, function()
            args.right_btn_handler()
        end )
    end

    if args.content_str then
        self._content_lb.text = args.content_str
    end

    if args.left_btn_str then
        self._left_btn_txt.text = args.left_btn_str
    end

    if args.right_btn_str then
        self._right_btn_txt.text = args.right_btn_str
    end
end

function ui_messagebox:_on_enter_btn3(args)
    self._left_btn_go:SetActive(true)
    self._center_btn_go:SetActive(true)
    self._right_btn_go:SetActive(true)

    if args.center_btn_handler then
        self.lua_behaviour:AddClick(self._center_btn_go, function()
            args.center_btn_handler()
        end )
    end

    if args.left_btn_handler then
        self.lua_behaviour:AddClick(self._left_btn_go, function()
            args.left_btn_handler()
        end )
    end

    if args.right_btn_handler then
        self.lua_behaviour:AddClick(self._right_btn_go, function()
            args.right_btn_handler()
        end )
    end

    if args.content_str then
        self._content_lb.text = args.content_str
    end

    if args.center_btn_str then
        self._center_btn_txt.text = args.center_btn_str
    end

    if args.left_btn_str then
        self._left_btn_txt.text = args.left_btn_str
    end

    if args.right_btn_str then
        self._right_btn_txt.text = args.right_btn_str
    end
end

function ui_messagebox:reset_window(args)
    self._content_lb.text = ""
    self._left_btn_txt.text = ""
    self._center_btn_txt.text = ""
    self._right_btn_txt.text = ""

    self._left_btn_go:SetActive(false)
    self._center_btn_go:SetActive(false)
    self._right_btn_go:SetActive(false)

    if args then
        if args.btn_num == 2 then
            self:_on_enter_btn2(args)
        elseif args.btn_num == 3 then
            self:_on_enter_btn3(args)
        else
            self:_on_enter_btn1(args)
        end
    end
end

function ui_messagebox:enter_anim(done_handler)
    self:reset_anim()
    play_open_window_anim(self._content_tr, {
        before_handler = function()
            print("before handler")
        end,
        after_handler = function()
            print("after handler")
            if done_handler then
                done_handler()
            end
        end
    } )
end

function ui_messagebox:reset_anim(done_handler)
    self._content_tr.localScale = Vector3.zero
end

function ui_messagebox:quit_anim(done_handler)
    if done_handler then
        done_handler()
    end
end

function ui_messagebox:on_pre_destroy()
    print("ui_messagebox:on_pre_destroy" .. self.gameObject.name)
end

return ui_messagebox