-- 加载常用模块
require "common/init"

StringTable = require "globalization/zh/StringTable"

require "uiscripts/init"

require "uiscripts/UITopbar"

UGameObject = UnityEngine.GameObject
UObject = UnityEngine.Object

-- 主入口函数。从这里开始lua逻辑
function Main()
    UIManager:Instance():ShowSession(UISessionID.UITopbar,
    UITopbar(UISessionData(UISessionType.Fixed, UIShowMode.DoNothing)),
    "UITopbar")
end

-- 场景切换通知
function OnLevelWasLoaded(level)

end