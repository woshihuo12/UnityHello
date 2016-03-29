-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成

local person_pb = require "protol/person_pb"

require "uiscripts/ui_messagebox"

ui_topbar = class(ui_session)

function ui_topbar.show_me()
    local sd = ui_session_data(ui_session_type.FIXED, ui_session_id.UI_TOPBAR)
    ui_manager:instance():show_session(ui_topbar(sd))
end

function ui_topbar:init(session_data)
    self._base.init(self, session_data)
    self.session_id = ui_session_id.UI_TOPBAR
end

function ui_topbar:on_post_load()
    self._center_txt = self.transform:Find("centerTxt"):GetComponent(typeof(UText))

    local left_btn = self.transform:Find("leftBtn").gameObject

    self.lua_behaviour:AddClick(left_btn, function(go)
        --        ui_messagebox.show( {
        --            content_str = "你好，范特西",
        --            btn_num = 1,
        --            center_btn_str = string_table.get_text("okTxt"),
        --            center_btn_handler = function()
        --                print("hello world.")
        --            end
        --        } )
        ui_messagebox.show( {
            content_str = "你好，范特西",
            btn_num = 2,
            left_btn_str = string_table.get_text("okTxt"),
            left_btn_handler = function()
                local msg = person_pb.Person()
                msg.id = 1024
                msg.name = 'foo'
                msg.email = 'bar'

                --                local tmp_phtone = msg.Extensions[person_pb.Phone.phones]:add()

                --                tmp_phtone.num = "12306"
                --                tmp_phtone.type = person_pb.Phone.HOME
                local tmp_phtone = msg.phones:add()
                tmp_phtone.num = "12306"
                tmp_phtone.type = person_pb.Phone.HOME

                tmp_phtone = msg.phones:add()
                tmp_phtone.num = "12308"
                tmp_phtone.type = person_pb.Phone.MOBILE

                self.pb_data = msg:SerializeToString()
                print(self.pb_data)
            end,
            right_btn_str = string_table.get_text("noTxt"),
            right_btn_handler = function()
                local msg = person_pb.Person()
                msg:ParseFromString(self.pb_data)
                print('person_pb decoder: ' .. tostring(msg.phones[2].num))
            end
        } )
    end )

    local right_btn = self.transform:Find("rightBtn").gameObject
    local right_btn_sp = right_btn:GetComponent(typeof(UImage))

    self.lua_behaviour:AddClick(right_btn, function(go)
        right_btn_sp.sprite = GameResFactory.Instance():GetResSprite("redBtn")
        if self._cd_timer then
            self._cd_timer:Stop()
        end
    end )
end

function ui_topbar:reset_window(args)
    self._center_txt.text = ""
    self._cd_time = 60
    self._cd_timer = Timer.New( function()
        self._center_txt.text = tostring(self._cd_time)
        self._cd_time = self._cd_time > 0 and self._cd_time - 1 or 0
    end , 1, -1, false)
    self._cd_timer:Start()
end

function ui_topbar:on_pre_destroy()
    print("ui_topbar:on_pre_destroy" .. self.gameObject.name)
end
-- endregion
