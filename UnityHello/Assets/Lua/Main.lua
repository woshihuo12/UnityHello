-- 加载常用模块
require "common/init"
require "uiscripts/init"

require "uiscripts/ui_topbar"

UObject = UnityEngine.Object

-- 主入口函数。从这里开始lua逻辑
function Main()
    print("hello world")
    local topBar = ui_topbar(UISessionData(false, UISessionType.EUIST_Fixed, UISessionShowMode.EUISSM_DoNothing))
    UIManager:Instance():ShowSession(UISessionID.EUISID_TopBar,
    topBar,
    UIShowSessionData(false, false, "ui_topbar"))
end

-- 场景切换通知
function OnLevelWasLoaded(level)

end