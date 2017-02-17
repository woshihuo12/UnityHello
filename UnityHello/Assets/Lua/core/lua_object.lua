--lua_object类 类似unity3d的GameObject类。它的核心功能是添加组件和向组件发送消息。
local components = {}
local lua_object = class("lua_object")

local function load_component(name)
    if components[name] == nil then
        components[name] = require("components/" .. name)
    end
    return components[name]
end

local function get_component_name(path)
    local _, b, name = string.find(path, "[%.,%/]*(%a+_*%a+)$")
    return name
end

function lua_object:initialize(name)
    self.name = name or "lua_object"
    self.components = {}
    self.updatecomponents = {}
    self.active = true
    self.parent = nil
    self.is_disposed = false
end

function lua_object:add_component(arg)
    local name = get_component_name(arg)
    if self.components[name] then
        return self.components[name]
    end
    local cmp = load_component(arg)
    assert(cmp, "component " .. name .. " does not exist!")
    
    local loadedcmp = cmp(self)
    self.components[name] = loadedcmp
    loadedcmp.name = name
    if loadedcmp.start then
        loadedcmp:start()
    end
    
    if loadedcmp.on_update then
        if not self.updatecomponents then
            self.updatecomponents = {}
        end
        self.updatecomponents[name] = loadedcmp
    end
    
    return loadedcmp
end

function lua_object:remove_component(name)
    local cmp = self.components[name]
    if cmp and cmp.remove then
        cmp:remove()
    end
    
    self.components[name] = nil
    self.updatecomponents[name] = nil
end

function lua_object:dispose()
    table.clear(self.components)
    table.clear(self.updatecomponents)
    self.active = false
    self.is_disposed = true
end

function lua_object:register_event(event, method, ...)
    if self.event_fun == nil then
        self.event_fun = {}
    end
    
    local event_call = self.event_fun[event]
    if event_call == nil then
        event_call = {}
        self.event_fun[event] = event_call
    end
    
    event_call[method] = {...}
end

function lua_object:call_event(event)
    if self.event_fun == nil then
        return
    end
    
    local event_call = self.event_fun[event]
    if event_call and not self.is_disposed then
        local t
        for k, v in pairs(event_call) do
            t = type(k)
            if t == "string" then
                local fn = self[k]
                if fn then
                    fn(self, unpack(v))
                elseif t == "function" then
                    k(self, unpack(v))
                end
            end
        end
    end
    self.event_fun[event] = nil
end

function lua_object:send_message(method, ...)
    local cmps = self.components
    local fn
    
    fn = self[method]
    if type(fn) == "function" then
        fn(self, ...)
    end
    
    if cmps then
        for k, v in pairs(cmps) do
            fn = v[method]
            if type(fn) == "function" then
                fn(v, ...)
            end
        end
    end
end

function lua_object:__tostring()
    return string.format("lua_object.name = %s", self.name)
end

return lua_object