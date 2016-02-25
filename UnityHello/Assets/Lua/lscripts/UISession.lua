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


UINoticeSession = UISession:new()

-- When Instance UI Ony Once.
function UINoticeSession:Awake(go)
	print(go)
end

-- Active this UI
function UINoticeSession:Active()
	print("UINoticeSession:Active")
end

-- Show UI Refresh Eachtime.
function UINoticeSession:Refresh()
	print("UINoticeSession:Refresh")
end

-- Only Deactive UI wont clear Data.
function UINoticeSession:Hide()
	print("UINoticeSession:Hide")
end