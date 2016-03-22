-- 加载常用模块
require "common/init"
require "uiscripts/init"

require "uiscripts/UITopbar"

UObject = UnityEngine.Object

-- 主入口函数。从这里开始lua逻辑
function Main()
    UIManager:Instance():ShowSession(UISessionID.UITopbar,
    UITopbar(UISessionData(false, UISessionType.Fixed, UIShowMode.DoNothing)),
    UIShowParam(false, false, "UITopbar"))
end

-- 场景切换通知
function OnLevelWasLoaded(level)

end