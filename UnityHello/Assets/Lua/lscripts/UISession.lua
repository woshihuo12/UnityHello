UISession = {}

function UISession:new(o)
	o = o or {}
	setmetatable(o, self)
	self.__index = self
	return o
end



-- When Instance UI Ony Once.
function UISession:Awake(go)

end

-- Active this UI
function UISession:Active()

end

-- Show UI Refresh Eachtime.
function UISession:Refresh()
	
end

-- Only Deactive UI wont clear Data.
function UISession:Hide()
	
end