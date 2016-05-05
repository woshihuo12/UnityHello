-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成
local person_pb = require "protol/person_pb"
local ui_messagebox = require "uiscripts/ui_messagebox"
local ui_teammanage_scene = require "uiscripts/ui_teammanage_scene"

local ui_mainmenu_cellbtn = class(ui_session)
function ui_mainmenu_cellbtn:init()

end

function ui_mainmenu_cellbtn:refresh()

end

local ui_mainmenu_scene = class(ui_session)

function ui_mainmenu_scene.show_me()
    local sd = ui_session_data(ui_session_type.NORMAL, ui_session_id.UI_MAINMENU_SCENE, true)
    local ui_manager = fw_facade:instance():get_mgr(mgr_name.UI_MGR)
    if ui_manager ~= nil then
        ui_manager:instance():show_session(ui_mainmenu_scene(sd))
    end
end

function ui_mainmenu_scene:init(session_data)
    self._base.init(self, session_data)
    self.session_id = ui_session_id.UI_MAINMENU_SCENE
end

function ui_mainmenu_scene:_load_cellbtn_prefab()
    GameResFactory.Instance():GetUIPrefab("ui_mainmenu_cellbtn", self._loop_scroll_rect.transform,
    ui_mainmenu_cellbtn(),
    function(go)
        self._loop_scroll_rect.InitInStart = false
        self._loop_scroll_rect.TotalCount = 100
        self._loop_scroll_rect:Init(go)
    end )
end

function ui_mainmenu_scene:on_post_load()
    self._loop_scroll_rect = self.transform:Find("contentPanel"):GetComponent(typeof(UnityEngine.UI.LoopVerticalScrollRect))
    self:_load_cellbtn_prefab()

    self._center_txt = self.transform:Find("centerTxt"):GetComponent(typeof(UText))

    local btn1 = self.transform:Find("btn1").gameObject

    self.lua_behaviour:AddClick(btn1, function(go)
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

                local buffer = ByteBuffer.New()
                buffer:WriteInt()
                buffer:WriteBuffer(self.pb_data)

                UNetworkManager:SendMessage(buffer)

                if self._cd_timer then
                    self._cd_timer:Stop()
                end
            end,
            right_btn_str = string_table.get_text("noTxt"),
            right_btn_handler = function()
                local msg = person_pb.Person()
                msg:ParseFromString(self.pb_data)
                print('person_pb decoder: ' .. tostring(msg.phones[2].num))
                for _, v in ipairs(msg.phones) do
                    print(v.num)
                    print(v.type)
                end

            end
        } )
    end )

    local btn2 = self.transform:Find("btn2").gameObject
    local right_btn_sp = btn2:GetComponent(typeof(UImage))

    self.lua_behaviour:AddClick(btn2, function(go)
        right_btn_sp.sprite = GameResFactory.Instance():GetResSprite("redBtn")

        event_dispatcher:instance().ui_event_manager:trigger_event(event_define.UI_EVENT_TEST)
    end )

    local btn3 = self.transform:Find("btn3").gameObject
    self.lua_behaviour:AddClick(btn3, function(go)
        ui_teammanage_scene.show_me()
    end )
end

function ui_mainmenu_scene:reset_window(args)
    self._center_txt.text = ""
    self._cd_time = 60
    self._cd_timer = Timer.New( function()
        self._center_txt.text = tostring(self._cd_time)
        self._cd_time = self._cd_time > 0 and self._cd_time - 1 or 0
    end , 1, -1, false)

    event_dispatcher:instance().ui_event_manager:add_event_listener(event_define.UI_EVENT_TEST, function()
        self._cd_timer:Start()
    end )
end

function ui_mainmenu_scene:on_pre_destroy()

end

return ui_mainmenu_scene
-- endregion
