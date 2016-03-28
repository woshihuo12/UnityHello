-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成

require "uiscripts/ui_messagebox"

ui_topbar = class(UISession)

function ui_topbar.ShowMe()
    UIManager:Instance():ShowSession(ui_topbar(UISessionData(UISessionType.Fixed, ui_session_id.ui_topbar)))
end

function ui_topbar:init(sessionData)
    self._base.init(self, sessionData)
    self.sessionID = ui_session_id.ui_topbar
end

function ui_topbar:OnPostLoad()
    local leftBtn = self.transform:Find("leftBtn").gameObject
    self.luaBehaviour:AddClick(leftBtn, function()
        print("hello world")
        ui_messagebox.Show( {
            contentStr = "你好，范特西",
            btnNum = 1,
            centerBtnStr = StringTable.GetText("okTxt"),
            centerBtnHandler = function()
                print("hello world.")
            end
        } )
    end )
end

function ui_topbar:OnPreDestroy()
    print("UITopBar:OnPreDestroy" .. self.gameObject.name)
end
-- endregion
