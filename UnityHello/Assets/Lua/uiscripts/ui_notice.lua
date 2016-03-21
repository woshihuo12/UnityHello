--region *.lua
--Date
--此文件由[BabeLua]插件自动生成

ui_notice = class(UISession)

function ui_notice:OnPostLoad(go)
    print("UINotice:OnPostLoad" .. go.name)
end

--endregion
