-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成

simple_state_machine = class()

simple_state_machine.VERSION = "2.2.0"
-- the event transitioned successfully from one state to another
simple_state_machine.SUCCEEDED = 1
-- the event was successfull but no state transition was necessary
simple_state_machine.NOTRANSITION = 2
-- the event was cancelled by the caller in a beforeEvent callback
simple_state_machine.CANCELLED = 3
-- the event is asynchronous and the caller is in control of when the transition occurs
simple_state_machine.PENDING = 4
-- the event was failure
simple_state_machine.FAILURE = 5
-- caller tried to fire an event that was innapropriate in the current state
simple_state_machine.INVALID_TRANSITION_ERROR = "INVALID_TRANSITION_ERROR"
-- caller tried to fire an event while an async transition was still pending
simple_state_machine.PENDING_TRANSITION_ERROR = "PENDING_TRANSITION_ERROR"
-- caller provided callback function threw an exception
simple_state_machine.INVALID_CALLBACK_ERROR = "INVALID_CALLBACK_ERROR"

simple_state_machine.WILDCARD = "*"
simple_state_machine.ASYNC = "ASYNC"

function simple_state_machine:init()
end

function simple_state_machine:SetupState(cfg)
    assert(type(cfg) == "table", "simple_state_machine:SetupState() - invalid config")

    -- cfg.initial allow for a simple string,
    -- or an table with { state = "foo", event = "setup", defer = true|false }
    if type(cfg.initial) == "string" then
        self.initial_ = { state = cfg.initial }
    else
        self.initial_ = cfg.initial
    end

    self.terminal_ = cfg.terminal or cfg.final
    self.events_ = cfg.events or { }
    self.callbacks_ = cfg.callbacks or { }
    self.map_ = { }
    self.current_ = "none"
    self.inTransition_ = false

    if self.initial_ then
        self.initial_.event = self.initial_.event or "startup"
        self:addEvent_( { name = self.initial_.event, from = "none", to = self.initial_.state })
    end

    for _, event in ipairs(self.events_) do
        self:addEvent_(event)
    end

    if self.initial_ and not self.initial_.defer then
        self:doEvent(self.initial_.event)
    end

    return self.target_
end

function simple_state_machine:IsReady()
    return self.current_ ~= "none"
end

function simple_state_machine:GetState()
    return self.current_
end

function simple_state_machine:IsState(state)
    if type(state) == "table" then
        for _, s in ipairs(state) do
            if s == self.current_ then
                return true
            end
        end
        return false
    else
        return self.current_ == state
    end
end

function simple_state_machine:CanDoEvent(eventName)
    return not self.inTransition_ and
    (self.map_[eventName][self.current_] ~= nil or self.map_[eventName][simple_state_machine.WILDCARD] ~= nil)
end

function simple_state_machine:CannotDoEvent(eventName)
    return not self:CanDoEvent(eventName)
end

function simple_state_machine:IsFinishedState()
    return self:IsState(self.terminal_)
end

function simple_state_machine:DoEventForce(name, ...)
    local from = self.current_
    local map = self.map_[name]
    local to =(map[from] or map[simple_state_machine.WILDCARD]) or from
    local args = { ...}

    local event = {
        name = name,
        from = from,
        to = to,
        args = args
    }

    if self.inTransition_ then
        self.inTransition_ = false
    end

    self:beforeEvent_(event)

    if from == to then
        self:afterEvent_(event)
        return simple_state_machine.NOTRANSITION
    end

    self.current_ = to
    self:enterState_(event)
    self:changeState_(event)
    self:afterEvent_(event)
    return simple_state_machine.SUCCEEDED
end

function simple_state_machine:DoEvent(name, ...)
    assert(self.map_[name] ~= nil, string.format("simple_state_machine:DoEvent() - invalid event %s", tostring(name)))

    local from = self.current_
    local map = self.map_[name]
    local to =(map[from] or map[simple_state_machine.WILDCARD]) or from
    local args = { ...}

    local event = {
        name = name,
        from = from,
        to = to,
        args = args,
    }

    if self.inTransition_ then
        self:onError_(event, simple_state_machine.PENDING_TRANSITION_ERROR,
        "event " .. name .. " inappropriate because previous transition did not complete")
        return simple_state_machine.FAILURE
    end

    if self:CannotDoEvent(name) then
        self:onError_(event, simple_state_machine.INVALID_TRANSITION_ERROR,
        "event " .. name .. " inappropriate in current state " .. self.current_)
        return simple_state_machine.FAILURE
    end

    if self:beforeEvent_(event) == false then
        return simple_state_machine.CANCELLED
    end

    if from == to then
        self:afterEvent_(event)
        return simple_state_machine.NOTRANSITION
    end

    event.transition = function()
        self.inTransition_ = false
        self.current_ = to
        -- this method should only ever be called once
        self:enterState_(event)
        self:changeState_(event)
        self:afterEvent_(event)
        return simple_state_machine.SUCCEEDED
    end

    event.cancel = function()
        -- provide a way for caller to cancel async transition if desired
        event.transition = nil
        self:afterEvent_(event)
    end

    self.inTransition_ = true
    local leave = self:leaveState_(event)
    if leave == false then
        event.transition = nil
        event.cancel = nil
        self.inTransition_ = false
        return simple_state_machine.CANCELLED
    elseif string.upper(tostring(leave)) == simple_state_machine.ASYNC then
        return simple_state_machine.PENDING
    else
        -- need to check in case user manually called transition()
        -- but forgot to return StateMachine.ASYNC
        if event.transition then
            return event.transition()
        else
            self.inTransition_ = false
        end
    end
end

function simple_state_machine:addEvent_(event)
    local from = { }
    if type(event.from) == "table" then
        for _, name in ipairs(event.from) do
            from[name] = true
        end
    elseif event.from then
        from[event.from] = true
    else
        -- allow "wildcard" transition if "from" is not specified
        from[simple_state_machine.WILDCARD] = true
    end

    self.map_[event.name] = self.map_[event.name] or { }
    local map = self.map_[event.name]
    for fromName, _ in pairs(from) do
        map[fromName] = event.to or fromName
    end
end

local function doCallback_(callback, event)
    if callback then
        return callback(event)
    end
end

function simple_state_machine:beforeAnyEvent_(event)
    return doCallback_(self.callbacks_["onbeforeevent"], event)
end

function simple_state_machine:afterAnyEvent_(event)
    return doCallback_(self.callbacks_["onafterevent"], event)
end

function simple_state_machine:leaveAnyState_(event)
    return doCallback_(self.callbacks_["onleavestate"], event)
end

function simple_state_machine:enterAnyState_(event)
    return doCallback_(self.callbacks_["onenterstate"] or self.callbacks_["onstate"], event)
end

function simple_state_machine:changeState_(event)
    return doCallback_(self.callbacks_["onchangestate"], event)
end

function simple_state_machine:beforeThisEvent_(event)
    return doCallback_(self.callbacks_["onbefore" .. event.name], event)
end

function simple_state_machine:afterThisEvent_(event)
    return doCallback_(self.callbacks_["onafter" .. event.name] or self.callbacks_["on" .. event.name], event)
end

function simple_state_machine:leaveThisState_(event)
    return doCallback_(self.callbacks_["onleave" .. event.from], event)
end

function simple_state_machine:enterThisState_(event)
    return doCallback_(self.callbacks_["onenter" .. event.to] or self.callbacks_["on" .. event.to], event)
end

function simple_state_machine:beforeEvent_(event)
    if self:beforeThisEvent_(event) == false or self:beforeAnyEvent_(event) == false then
        return false
    end
end

function simple_state_machine:afterEvent_(event)
    self:afterThisEvent_(event)
    self:afterAnyEvent_(event)
end

function simple_state_machine:leaveState_(event, transition)
    local specific = self:leaveThisState_(event, transition)
    local general = self:leaveAnyState_(event, transition)
    if specific == false or general == false then
        return false
    elseif string.upper(tostring(specific)) == simple_state_machine.ASYNC
        or string.upper(tostring(general)) == simple_state_machine.ASYNC then
        return simple_state_machine.ASYNC
    end
end

function simple_state_machine:enterState_(event)
    self:enterThisState_(event)
    self:enterAnyState_(event)
end

function simple_state_machine:onError_(event, error, message)
    print("%s [simple_state_machine] ERROR: error %s, event %s, from %s to %s", tostring(self.target_), tostring(error), event.name, event.from, event.to)
    print(message)
end

-- endregion
