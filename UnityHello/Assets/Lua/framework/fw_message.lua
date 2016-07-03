--region *.lua
--Date
--此文件由[BabeLua]插件自动生成
local class = require("common/middleclass")

fw_message = class("fw_message")

function fw_message:initialize(nm, bd)
    self.name = nm or "empty_name"
    self.body = bd
end

--endregion
