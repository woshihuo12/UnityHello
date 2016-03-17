-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成

UIManager = class()
function UIManager:init()
    -- 所有 Session
    self.allSessions = { }
    -- 当前正在显示的 Session
    self.shownSessions = { }
    self.backSequence = Stack:Create()

    --  是否等待关闭结束
    --  开启:等待界面关闭结束,处理后续逻辑
    --  关闭:不等待界面关闭结束，处理后续逻辑
    self.isNeedWaitHideOver = false

end

function UIManager:Instance()
    if self.instance == nil then
        self.instance = UIManager()
    end
    return self.instance
end

function UIManager:Reset()
    self.allSessions = { }
    self.shownSessions = { }
    self.backSequence:clear()
end

function UIManager:GetSession(sessionID)
    return self.allSessions[sessionID]
end

function UIManager:ShowSession(sessionID, showSessionData)
end

function UIManager:ShowSessionDelay(delayTime, sessionID, showSessionData)
    coroutine.wait(delayTime)
    self:ShowSession(sessionID, showSessionData)
end

function UIManager:ReadyToShowSession(sessionID, showSessionData)

end

function UIManager:RealShowSession(uiSession, sessionID)
    uiSession:ShowSession()
    self.shownSessions[sessionID] = uiSession
    if uiSession.sessionData.sessionType == UISessionType.EUIST_Normal then
        self.lastShownNormalSession = self.curShownNormalSession
        self.curShownNormalSession = uiSession
    end
end


function UIManager:HideSession(sessionID, completeHandler)
    if self.shownSessions[sessionID] == nil then
        return
    end
    if not self.isNeedWaitHideOver then
        if completeHandler ~= nil then
            completeHandler()
        end
        self.shownSessions[sessionID]:HideSession()
        self.shownSessions[sessionID] = nil
    else
        if completeHandler ~= nil then
            self.shownSessions[sessionID]:HideSession( function()
                completeHandler()
                self.shownSessions[sessionID] = nil
            end )
        else
            self.shownSessions[sessionID]:HideSession()
            self.shownSessions[sessionID] = nil
        end
    end
end

function UIManager:DoGoBack()

end


function UIManager:ClearBackSequence()
    self.backSequence:clear()
end

function UIManager:ClearAllSession()
    for _, v in pairs(self.allSessions) do
        v.DestroySession()
    end
    self.allSessions = { }
    self.shownSessions = { }
    self.backSequence:clear()
end

function UIManager:HideAllShownSessions(includeFixed)
    if not includeFixed then
        for k, v in pairs(self.shownSessions) do
            if v.sessionData.sessionType ~= UISessionType.EUIST_Fixed then
                v:HideSessionDirectly()
                self.shownSessions[k] = nil
            end
        end
    else
        for _, v in pairs(self.shownSessions) do
            v:HideSessionDirectly()
        end
        self.shownSessions = { }
    end
end

-- endregion
