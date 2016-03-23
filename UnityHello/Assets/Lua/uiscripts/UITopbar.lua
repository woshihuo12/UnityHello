-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成

require "uiscripts/UIMessageBox"

UITopbar = class(UISession)

function UITopbar:init(sessionData)
    self._base.init(self, sessionData)
    self.sessionID = UISessionID.UITopbar
end

function UITopbar:OnPostLoad()
    local leftBtn = self.transform:Find("leftBtn").gameObject
    self.luaBehaviour:AddClick(leftBtn, function()
        --        UIManager:Instance():ShowSession(UISessionID.UINotice,
        --        UINotice(UISessionData(false, UISessionType.PopUp, UIShowMode.DoNothing)),
        --        UIShowParam(false, false, "UINotice"))
        print("hello world.")
    end )

    local ll = leftBtn.transform:Find("txt"):GetComponent("Text")
    ll.text = "mmmmm"
end

function UITopbar:OnPreDestroy()
    print("UITopBar:OnPreDestroy" .. self.gameObject.name)
end
-- endregion
