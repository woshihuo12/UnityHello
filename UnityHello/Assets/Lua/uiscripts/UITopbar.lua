-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成

require "uiscripts/UINotice"

UITopbar = class(UISession)

function UITopbar:init(sessionData)
    self._base.init(self, sessionData)
    self.sessionID = UISessionID.UITopbar
end

function UITopbar:OnPostLoad(go)
    self.gameObject = go
    self.transform = go.transform

    local luaBehaviour = go:GetComponent("LuaBehaviour")
    local leftBtn = self.transform:Find("leftBtn").gameObject
    luaBehaviour:AddClick(leftBtn, function()
        UIManager:Instance():ShowSession(UISessionID.UINotice,
        UINotice(UISessionData(false, UISessionType.PopUp, UIShowMode.DoNothing)),
        UIShowParam(false, false, "UINotice"))
    end )
end

function UITopbar:OnPreDestroy(go)
    print("UITopBar:OnPreDestroy" .. go.name)
end
-- endregion
