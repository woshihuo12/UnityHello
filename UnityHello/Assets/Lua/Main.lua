-- 加载常用模块
require "common/init"
require "uiscripts/init"

require "uiscripts/UINotice"

UObject = UnityEngine.Object

-- 主入口函数。从这里开始lua逻辑
function Main()
    print("hello world")
    UIManager:Instance():ShowSessionDelay(3,
    UISessionID.EUISID_Notice,
    UINotice(UISessionData(true, UISessionType.EUIST_PopUp, UISessionShowMode.EUISSM_HideOther)),
    UIShowSessionData(true, true, "ui_notice"))
end

-- 场景切换通知
function OnLevelWasLoaded(level)

end