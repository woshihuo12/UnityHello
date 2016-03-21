-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成

require "uiscripts/ui_notice"

ui_topbar = class(UISession)

function ui_topbar:init(sessionData)
    self._base.init(self, sessionData)
    self.sessionID = UISessionID.EUISID_TopBar
end

function ui_topbar:OnPostLoad(go)
    self.gameObject = go
    self.transform = go.transform

    local luaBehaviour = go:GetComponent("LuaBehaviour")
    local leftBtn = self.transform:Find("leftBtn").gameObject
    luaBehaviour:AddClick(leftBtn, function()
        UIManager:Instance():ShowSession(UISessionID.EUISID_Notice,
        ui_notice(UISessionData(false, UISessionType.EUIST_PopUp, UISessionShowMode.EUISSM_DoNothing)),
        UIShowSessionData(false, false, "ui_notice"))
    end )
end

function ui_topbar:OnPreDestroy(go)
    print("UITopBar:OnPreDestroy" .. go.name)
end
-- endregion
