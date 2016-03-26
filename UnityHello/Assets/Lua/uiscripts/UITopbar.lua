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
        print("hello world")
        UIMessageBox.Show( {
            contentStr = "你好，范特西",
            btnNum = 1,
            centerBtnStr = StringTable.GetText("okTxt"),
            centerBtnHandler = function()
                print("hello world.")
            end
        } )
    end )
end

function UITopbar:OnPreDestroy()
    print("UITopBar:OnPreDestroy" .. self.gameObject.name)
end
-- endregion
