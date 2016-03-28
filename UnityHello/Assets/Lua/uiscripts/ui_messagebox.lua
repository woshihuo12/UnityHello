-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成

local Text = UnityEngine.UI.Text

ui_messagebox = class(UISession)

function ui_messagebox.Show(args)
    UIManager:Instance():ShowPopUp(ui_messagebox(UISessionData(UISessionType.PopUp, ui_session_id.ui_messagebox)), true, args)
end

function ui_messagebox.Close()
    UIManager:Instance():ClosePopUp()
end

function ui_messagebox:init(sessionData)
    self._base.init(self, sessionData)
    self.sessionID = ui_session_id.ui_messagebox
end

function ui_messagebox:OnPostLoad()
    self.contentTr = self.transform:Find("content")
    local closeBtnGo = self.contentTr:Find("btnClose").gameObject
    self.luaBehaviour:AddClick(closeBtnGo, function()
        ui_messagebox.Close()
    end )
    self.contentLb = self.contentTr:Find("desc"):GetComponent(typeof(Text))

    self.leftBtnGo = self.contentTr:Find("btnLeft").gameObject
    self.leftBtnTxt = self.leftBtnGo.transform:Find("txt"):GetComponent(typeof(Text))

    self.centerBtnGo = self.contentTr:Find("btnCenter").gameObject
    self.centerBtnTxt = self.centerBtnGo.transform:Find("txt"):GetComponent(typeof(Text))

    self.rightBtnGo = self.contentTr:Find("btnRight").gameObject
    self.rightBtnTxt = self.rightBtnGo.transform:Find("txt"):GetComponent(typeof(Text))
end

function ui_messagebox:_onEnterBtn1(args)
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

function ui_messagebox:_onEnterBtn2(args)
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

function ui_messagebox:_onEnterBtn3(args)
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

function ui_messagebox:ResetWindow(args)
    self.contentLb.text = ""
    self.leftBtnTxt.text = ""
    self.centerBtnTxt.text = ""
    self.rightBtnTxt.text = ""

    self.leftBtnGo:SetActive(false)
    self.centerBtnGo:SetActive(false)
    self.rightBtnGo:SetActive(false)

    if args then
        if args.btnNum == 2 then
            self:_onEnterBtn2(args)
        elseif args.btnNum == 3 then
            self:_onEnterBtn3(args)
        else
            self:_onEnterBtn1(args)
        end
    end
end

function ui_messagebox:EnterAnim(doneHandler)
    self:ResetAnim()
    play_open_window_anim(self.contentTr, {
        beforeHandler = function()
            print("before handler")
        end,
        afterHandler = function()
            print("after handler")
            if doneHandler then
                doneHandler()
            end
        end
    } )
end

function ui_messagebox:ResetAnim(doneHandler)
    self.contentTr.localScale = Vector3.zero
end

function ui_messagebox:QuitAnim(doneHandler)
    if doneHandler then
        doneHandler()
    end
end

function ui_messagebox:OnPreDestroy()
    print("UIMessageBox:OnPreDestroy" .. self.gameObject.name)
end
-- endregion
