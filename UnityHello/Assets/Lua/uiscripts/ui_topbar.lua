-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成

require "uiscripts/ui_messagebox"

ui_topbar = class(ui_session)

function ui_topbar.show_me()
    local sd = ui_session_data(ui_session_type.fixed, ui_session_id.ui_topbar)
    ui_manager:instance():show_session(ui_topbar(sd))
end

function ui_topbar:init(session_data)
    self._base.init(self, session_data)
    self.session_id = ui_session_id.ui_topbar
end

function ui_topbar:on_post_load()

    local left_btn = self.transform:Find("leftBtn").gameObject

    self.lua_behaviour:AddClick(left_btn, function(go)
        ui_messagebox.show( {
            content_str = "你好，范特西",
            btn_num = 1,
            center_btn_str = string_table.get_text("okTxt"),
            center_btn_handler = function()
                print("hello world.")
            end
        } )
    end )

    local right_btn = self.transform:Find("rightBtn").gameObject
    local right_btn_sp = right_btn:GetComponent(typeof(UImage))

    self.lua_behaviour:AddClick(right_btn, function(go)
         right_btn_sp.sprite = GameResFactory.Instance():GetResSprite("redBtn")
    end )
end

function ui_topbar:on_pre_destroy()
    print("ui_topbar:on_pre_destroy" .. self.gameObject.name)
end
-- endregion
