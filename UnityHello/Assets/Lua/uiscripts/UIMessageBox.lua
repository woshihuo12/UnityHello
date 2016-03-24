-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成

local Text = UnityEngine.UI.Text

UIMessageBox = class(UISession)

function UIMessageBox.Show(args)
    UIManager:Instance():ShowSession(UISessionID.UIMessageBox,
    UIMessageBox(UISessionData(false, UISessionType.PopUp, UIShowMode.DoNothing)),
    UIShowParam(true, false, "UIMessageBox", args))
end

function UIMessageBox.Close()
    UIManager:Instance():DestroySession(UISessionID.UIMessageBox)
end

function UIMessageBox:init(sessionData)
    self._base.init(self, sessionData)
    self.sessionID = UISessionID.UIMessageBox
end

function UIMessageBox:OnPostLoad()
    self.contentTr = self.transform:Find("content")
    local closeBtnGo = self.contentTr:Find("btnClose").gameObject
    self.luaBehaviour:AddClick(closeBtnGo, function()
        UIMessageBox.Close()
    end )
    self.contentLb = self.contentTr:Find("desc"):GetComponent(typeof(Text))

    self.leftBtnGo = self.contentTr:Find("btnLeft").gameObject
    self.leftBtnTxt = self.leftBtnGo.transform:Find("txt"):GetComponent(typeof(Text))

    self.centerBtnGo = self.contentTr:Find("btnCenter").gameObject
    self.centerBtnTxt = self.centerBtnGo.transform:Find("txt"):GetComponent(typeof(Text))

    self.rightBtnGo = self.contentTr:Find("btnRight").gameObject
    self.rightBtnTxt = self.rightBtnGo.transform:Find("txt"):GetComponent(typeof(Text))
end

function UIMessageBox:_onEnterBtn1(args)
    self.centerBtnGo:SetActive(true)
    if args.centerBtnHandler then
        self.luaBehaviour:AddClick(self.centerBtnGo, function()
            args.centerBtnHandler()
        end )
    end

    if args.contentStr then
        self.contentLb.text = args.contentStr
    end

    if args.centerBtnStr then
        self.centerBtnTxt.text = args.centerBtnStr
    end
end

function UIMessageBox:_onEnterBtn2(args)
    self.leftBtnGo:SetActive(true)
    self.rightBtnGo:SetActive(true)
    if args.leftBtnHandler then
        self.luaBehaviour:AddClick(self.leftBtnGo, function()
            args.leftBtnHandler()
        end )
    end

    if args.rightBtnHandler then
        self.luaBehaviour:AddClick(self.rightBtnGo, function()
            args.rightBtnHandler()
        end )
    end

    if args.contentStr then
        self.contentLb.text = args.contentStr
    end

    if args.leftBtnStr then
        self.leftBtnTxt.text = args.leftBtnStr
    end

    if args.rightBtnStr then
        self.rightBtnTxt.text = args.rightBtnStr
    end
end

function UIMessageBox:_onEnterBtn3(args)
    self.leftBtnGo:SetActive(true)
    self.centerBtnGo:SetActive(true)
    self.rightBtnGo:SetActive(true)

    if args.centerBtnHandler then
        self.luaBehaviour:AddClick(self.centerBtnGo, function()
            args.centerBtnHandler()
        end )
    end

    if args.leftBtnHandler then
        self.luaBehaviour:AddClick(self.leftBtnGo, function()
            args.leftBtnHandler()
        end )
    end

    if args.rightBtnHandler then
        self.luaBehaviour:AddClick(self.rightBtnGo, function()
            args.rightBtnHandler()
        end )
    end

    if args.contentStr then
        self.contentLb.text = args.contentStr
    end

    if args.centerBtnStr then
        self.centerBtnTxt.text = args.centerBtnStr
    end

    if args.leftBtnStr then
        self.leftBtnTxt.text = args.leftBtnStr
    end

    if args.rightBtnStr then
        self.rightBtnTxt.text = args.rightBtnStr
    end
end

function UIMessageBox:ResetWindow(showParam)
    self.contentLb.text = ""
    self.leftBtnTxt.text = ""
    self.centerBtnTxt.text = ""
    self.rightBtnTxt.text = ""

    self.leftBtnGo:SetActive(false)
    self.centerBtnGo:SetActive(false)
    self.rightBtnGo:SetActive(false)

    if showParam and showParam.args then
        if showParam.btnNum == 2 then
            self:_onEnterBtn2(showParam.args)
        elseif showParam.btnNum == 3 then
            self:_onEnterBtn3(showParam.args)
        else
            self:_onEnterBtn1(showParam.args)
        end
    end

    PlayOpenWindowAnim(self.contentTr, {
        beforeHandler = function()
            print("before handler")
        end,
        afterHandler = function()
            print("after handler")
        end
    } )
end

function UIMessageBox:OnPreDestroy()
    print("UIMessageBox:OnPreDestroy" .. self.gameObject.name)
end
-- endregion
