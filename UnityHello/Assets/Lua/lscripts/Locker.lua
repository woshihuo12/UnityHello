Locker = {}

function Locker:new(o)
	o = o or {}
	setmetatable(o, self)
	self.__index = self

	o.lockKeys = {}

	return o
end

function Locker:lock(lockKey)
	if(self.lockKeys[lockKey] == nil) then
		self.lockKeys[lockKey] = true
	end
end

function Locker:unLock(lockKey)
	if(self.lockKeys[lockKey] ~= nil) then
		self.lockKeys[lockKey] = nil
	end
end

function Locker:isLock(lockKey)
	return self.lockKeys[lockKey] ~= nil
end

function Locker:hasLock()
	for k, v in pairs(self.lockKeys) do
		if(k ~= nil) then
			return true
		end
	end
	return false
end

