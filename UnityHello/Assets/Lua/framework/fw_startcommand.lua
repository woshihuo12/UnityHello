local network_manager = require "manager/network_manager"
local ui_manager = require "uiscripts/ui_manager"
local fw_command = require "framework/fw_command"
local ui_topbar = require "uiscripts/ui_topbar"
local ui_mainmenu_scene = require "uiscripts/ui_mainmenu_scene"

local fw_startcommand = class("fw_startcommand", fw_command)
function fw_startcommand:initialize()
end

function fw_startcommand:execute(msg)
    print("fw_startcommand")
    fw_facade:instance():add_mgr(mgr_name.NET_MGR, network_manager:instance())
    UNetworkManager:SetLuaTable(network_manager())
    fw_facade:instance():add_mgr(mgr_name.UI_MGR, ui_manager:instance())
    ui_topbar.show_me()
    ui_mainmenu_scene.show_me()
end

return fw_startcommand
