-- 加载常用模块
require "init"

local network_manager = require "manager/network_manager"
local ui_topbar = require "uiscripts/ui_topbar"
local ui_mainmenu_scene = require "uiscripts/ui_mainmenu_scene"

-- 主入口函数。从这里开始lua逻辑
function Main()
    UNetworkManager:SetLuaTable(network_manager())
    ui_topbar.show_me()
    ui_mainmenu_scene.show_me()
end

-- 场景切换通知
function OnLevelWasLoaded(level)
	Time.timeSinceLevelLoad = 0
end