EUIType =
{
	EUT_Normal = 1,
	EUT_Fixed = 2,
	EUT_PopUp = 3,
	EUT_None = 4
}

UIManager = {}

function UIManager:new(o)
	o = o or {}
	setmetatable(o, self)
	self.__index = self

	self.uiSessions = {}

	return o
end

function UIManager:Instance()
	if self.instance == nil then
		self.instance = self:new()
	end
	return self.instance
end

function UIManager:LayerParent()
 	return UILayer.Instance().mLayerParent
end

function UIManager:ShowUI(uiName, parent, callBack)
	GameResFactory.Instance():GetUIPrefab(uiName, parent, function(go)
		self.uiSessions[uiName] = UINoticeSession:new()
		self.uiSessions[uiName]:Awake(go)
		self.uiSessions[uiName]:Active()
		self.uiSessions[uiName]:Refresh()
		self.uiSessions[uiName]:Hide()
	end)
end

function UIManager:HideUI()
	
end