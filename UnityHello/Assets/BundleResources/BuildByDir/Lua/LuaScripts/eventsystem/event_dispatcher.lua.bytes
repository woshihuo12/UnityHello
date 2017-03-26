local event_manager = require("eventsystem/event_manager")

event_dispatcher = class("event_dispatcher")
function event_dispatcher:initialize()
    self.ui_event_manager = event_manager()
end

function event_dispatcher.instance()
    if event_dispatcher._instance == nil then
        event_dispatcher._instance = event_dispatcher()
    end

    return event_dispatcher._instance
end
