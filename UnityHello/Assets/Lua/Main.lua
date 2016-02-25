require "lscripts/UISession"
require "lscripts/UIManager"

--主入口函数。从这里开始lua逻辑
function Main()					
	-- print(UILayer.Instance().mLayerParent)
	UIManager:Instance():ShowUI("ui_notice", UIManager:Instance():LayerParent(), function(go)
		
	end)
end
	
--逻辑update
function Update(deltaTime, unscaledDeltaTime)
	Time:SetDeltaTime(deltaTime, unscaledDeltaTime)				
	UpdateBeat()			
end

function LateUpdate()	
	LateUpdateBeat()	
	CoUpdateBeat()	
	Time:SetFrameCount()		
end

--物理update
function FixedUpdate(fixedDeltaTime)
	Time:SetFixedDelta(fixedDeltaTime)
	FixedUpdateBeat()
end
