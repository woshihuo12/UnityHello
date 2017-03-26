local network_manager = class("network_manager")

function network_manager:instance()
    if self._instance == nil then
        self._instance = network_manager()
    end
    return self._instance
end

function network_manager:on_init()
    print("network_manager.on_init")
end

function network_manager:on_unload()
    print("network_manager.on_unload")
end

function network_manager.on_socket_data(key, data)
end

return network_manager