-- 加载常用模块
require("init")

-- 主入口函数。从这里开始lua逻辑
function Main()	
	print("main started")				
    fw_facade:instance():send_msg_command(noti_const.START_UP)
end

-- 场景切换通知
function OnLevelWasLoaded(level)
	collectgarbage("collect")
	Time.timeSinceLevelLoad = 0
end