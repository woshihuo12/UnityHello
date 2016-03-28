-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成

local Text = UnityEngine.UI.Text

ui_messagebox = class(ui_session)

function ui_messagebox.show(args)
    ui_manager:instance():show_popup(ui_messagebox(ui_session_data(ui_session_type.popup, ui_session_id.ui_messagebox)), true, args)
end

function ui_messagebox.close()
    ui_manager:instance():close_popup()
end

function ui_messagebox:init(sessionData)
    self._base.init(self, sessionData)
    self.session_id = ui_session_id.ui_messagebox
end

function ui_messagebox:on_post_load()
    self.content_tr = self.transform:Find("content")
    local close_btn_go = self.content_tr:Find("btnClose").gameObject
    self.lua_behaviour:AddClick(close_btn_go, function()
        ui_messagebox.close()
    end )
    self.content_lb = self.content_tr:Find("desc"):GetComponent(typeof(Text))

    self.left_btn_go = self.content_tr:Find("btnLeft").gameObject
    self.left_btn_txt = self.left_btn_go.transform:Find("txt"):GetComponent(typeof(Text))

    self.center_btn_go = self.content_tr:Find("btnCenter").gameObject
    self.center_btn_txt = self.center_btn_go.transform:Find("txt"):GetComponent(typeof(Text))

    self.right_btn_go = self.content_tr:Find("btnRight").gameObject
    self.right_btn_txt = self.right_btn_go.transform:Find("txt"):GetComponent(typeof(Text))
end

function ui_messagebox:_on_enter_btn1(args)
    self.center_btn_go:SetActive(true)
    if args.center_btn_handler then
        self.lua_behaviour:AddClick(self.center_btn_go, function()
            args.center_btn_handler()
        end )
    end

    if args.content_str then
        self.content_lb.text = args.content_str
    end

    if args.center_btn_str then
        self.center_btn_txt.text = args.center_btn_str
    end
end

function ui_messagebox:_on_enter_btn2(args)
    self.left_btn_go:SetActive(true)
    self.right_btn_go:SetActive(true)
    if args.left_btn_handler then
        self.lua_behaviour:AddClick(self.left_btn_go, function()
            args.left_btn_handler()
        end )
    end

    if args.right_btn_handler then
        self.lua_behaviour:AddClick(self.right_btn_go, function()
            args.right_btn_handler()
        end )
    end

    if args.content_str then
        self.content_lb.text = args.content_str
    end

    if args.left_btn_str then
        self.left_btn_txt.text = args.left_btn_str
    end

    if args.right_btn_str then
        self.right_btn_txt.text = args.right_btn_str
    end
end

function ui_messagebox:_on_enter_btn3(args)
    self.left_btn_go:SetActive(true)
    self.center_btn_go:SetActive(true)
    self.right_btn_go:SetActive(true)

    if args.center_btn_handler then
        self.lua_behaviour:AddClick(self.center_btn_go, function()
            args.center_btn_handler()
        end )
    end

    if args.left_btn_handler then
        self.lua_behaviour:AddClick(self.left_btn_go, function()
            args.left_btn_handler()
        end )
    end

    if args.right_btn_handler then
        self.lua_behaviour:AddClick(self.right_btn_go, function()
            args.right_btn_handler()
        end )
    end

    if args.content_str then
        self.content_lb.text = args.content_str
    end

    if args.center_btn_str then
        self.center_btn_txt.text = args.center_btn_str
    end

    if args.left_btn_str then
        self.left_btn_txt.text = args.left_btn_str
    end

    if args.right_btn_str then
        self.right_btn_txt.text = args.right_btn_str
    end
end

function ui_messagebox:reset_window(args)
    self.content_lb.text = ""
    self.left_btn_txt.text = ""
    self.center_btn_txt.text = ""
    self.right_btn_txt.text = ""

    self.left_btn_go:SetActive(false)
    self.center_btn_go:SetActive(false)
    self.right_btn_go:SetActive(false)

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
    play_open_window_anim(self.content_tr, {
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
    self.content_tr.localScale = Vector3.zero
end

function ui_messagebox:quit_anim(done_handler)
    if done_handler then
        done_handler()
    end
end

function ui_messagebox:on_pre_destroy()
    print("ui_messagebox:on_pre_destroy" .. self.gameObject.name)
end
-- endregion
