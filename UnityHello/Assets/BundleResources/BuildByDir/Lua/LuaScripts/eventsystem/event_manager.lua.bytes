local event_manager = class("event_manager")

function event_manager:initialize()
    self._events_map = { }
end

function event_manager:add_event_listener(event_type, listener)
    local tmp_event = self._events_map[event_type]
    if not tmp_event then
        self._events_map[event_type] = event(event_type)
        tmp_event = self._events_map[event_type]
    end
    if tmp_event then
        tmp_event:Add(listener)
    end
end

function event_manager:remove_event_listener(event_type, listener)
    local tmp_event = self._events_map[event_type]
    if tmp_event then
        tmp_event:Remove(listener)
    end
end

function event_manager:remove_all_event_listener(event_type)
    local tmp_event = self._events_map[event_type]
    if tmp_event then
        tmp_event:Clear()
    end
end

function event_manager:trigger_event(event_type, ...)
    local tmp_event = self._events_map[event_type]
    if tmp_event then
        -- local args = { ... }
        tmp_event( ... )
    end
end

return event_manager