-- 加载常用模块
require "common/init"

UObject = UnityEngine.Object

--主入口函数。从这里开始lua逻辑
function Main()					
    print("hello main")
end

--场景切换通知
function OnLevelWasLoaded(level)

end