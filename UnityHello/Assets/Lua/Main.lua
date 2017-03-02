-- 加载常用模块
require("init")

-- 主入口函数。从这里开始lua逻辑
function Main()					
    fw_facade:instance():send_msg_command(noti_const.START_UP)

	create_lua_behavior(Globals.Instance.gameObject, {a = 1}, "hh")
	create_lua_behavior(Globals.Instance.gameObject, {a = 2}, "hh")
end

-- 场景切换通知
function OnLevelWasLoaded(level)
	collectgarbage("collect")
	Time.timeSinceLevelLoad = 0
end