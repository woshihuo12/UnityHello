-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成

UIMessageBox = class(UISession)

function UIMessageBox.Show(args)
    UIManager:Instance():ShowSession(UISessionID.UIMessageBox,
    UIMessageBox(UISessionData(false, UISessionType.PopUp, UIShowMode.DoNothing)),
    UIShowParam(true, false, "UIMessageBox"))
end

function UIMessageBox:init(sessionData)
    self._base.init(self, sessionData)
    self.sessionID = UISessionID.UIMessageBox
end

function UIMessageBox:OnPostLoad()
    local contentTr = self.transform:Find("content")
    local closeBtnGo = contentTr:Find("btnClose").gameObject
    self.luaBehaviour:AddClick(closeBtnGo, function()

    end )

    self.contentLb = contentTr:Find("desc"):GetComponent(typeof(Text))

    self.leftBtnGo = contentTr:Find("btnLeft").gameObject
    self.leftBtnTxt = self.leftBtnGo.transform:Find("txt"):GetComponent(typeof(Text))
    self.luaBehaviour:AddClick(self.leftBtnGo, function()
        print("left Btn Click!")
    end )

    self.centerBtnGo = contentTr:Find("btnCenter").gameObject
    self.centerBtnTxt = self.centerBtnGo.transform:Find("txt"):GetComponent(typeof(Text))
    self.luaBehaviour:AddClick(self.centerBtnGo, function()
        print("center Btn Click!")
    end )

    self.rightBtnGo = contentTr:Find("btnRight").gameObject
    self.rightBtnTxt = self.rightBtnGo.transform:Find("txt"):GetComponent(typeof(Text))
    self.luaBehaviour:AddClick(self.rightBtnGo, function()
        print("right Btn Click!")
    end )
end

function UIMessageBox:ResetWindow()
    self.contentLb.text = ""
    self.leftBtnTxt.text = ""
    self.rightBtnTxt.text = ""
end

function UIMessageBox:OnPreDestroy()
    print("UIMessageBox:OnPreDestroy" .. self.gameObject.name)
end
-- endregion
