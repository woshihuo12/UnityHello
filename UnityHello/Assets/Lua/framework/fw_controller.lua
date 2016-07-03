-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成
local class = require("common/middleclass")

local fw_controller = class("fw_controller")

function fw_controller:initialize()
    self.command_map = { }
end

function fw_controller:instance()
    if self._instance == nil then
        self._instance = fw_controller()
    end
    return self._instance
end

function fw_controller:register_command(cmd_name, cmd)
    if self.command_map[cmd_name] ~= nil then
        self.command_map[cmd_name] = nil
    end
    self.command_map[cmd_name] = cmd
end

function fw_controller:execute_command(msg)
    local cmd = self.command_map[msg.name]
    if cmd ~= nil then
        cmd:execute(msg)
    end
end

function fw_controller:remove_command(cmd_name)
    if self.command_map[cmd_name] ~= nil then
        self.command_map[cmd_name] = nil
    end
end

function fw_controller:has_command(cmd_name)
    return self.command_map[cmd_name] ~= nil
end

return fw_controller

-- endregion
