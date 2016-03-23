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
    self.backSequence:Clear()
end

function UIManager:ShowSession(sessionID, uiSession, showSessionData, doneHandler)

    if self.shownSessions[sessionID] ~= nil then
        return
    end

    local cacheSession = self.allSessions[sessionID]
    if not cacheSession then
        local parentRt = self:GetSessionRoot(uiSession.sessionData.sessionType)
        GameResFactory.Instance():GetUIPrefab(showSessionData.prefabName, parentRt,
        function(go)
            if not uiSession then
                error("ui session id:" .. sessionID .. " is null.")
                return
            end

            uiSession:OnPostLoad(go)
            self.allSessions[sessionID] = uiSession

            uiSession:ResetWindow()

            -- 导航系统数据更新
            self:RefreshBackSequenceData(uiSession)

            self:RealShowSession(sessionID, uiSession)
            -- 是否清空当前导航信息(回到主菜单)
            if uiSession.sessionData.isStartWindow or
                (showSessionData ~= nil and showSessionData.isForceClearBackSeqData) then
                self:ClearBackSequence()
            end
        end )
    else
        if showSessionData ~= nil and showSessionData.isForceResetWindow then
            cacheSession:ResetWindow()
        end

        -- 导航系统数据更新
        RefreshBackSequenceData(cacheSession)

        self:RealShowSession(sessionID, uiSession)
        -- 是否清空当前导航信息(回到主菜单)
        if uiSession.sessionData.isStartWindow or
            (showSessionData ~= nil and showSessionData.isForceClearBackSeqData) then
            self:ClearBackSequence()
        end
    end
end

local function CoShowSessionDelay(self, delayTime, sessionID, uiSession, showSessionData)
    coroutine.wait(delayTime)
    self:ShowSession(sessionID, uiSession, showSessionData)
end

function UIManager:ShowSessionDelay(delayTime, sessionID, uiSession, showSessionData)
    coroutine.start(CoShowSessionDelay, self, delayTime, sessionID, uiSession, showSessionData)
end

function UIManager:GetSessionRoot(sessionType)
    if sessionType == UISessionType.Fixed then
        return UIRoot.Instance().mFixedRootRt
    elseif sessionType == UISessionType.Normal then
        return UIRoot.Instance().mNormalRootRt
    elseif sessionType == UISessionType.PopUp then
        return UIRoot.Instance().mPopupRootRt
    else
        return UIRoot.Instance().mNormalRootRt
    end
end

function UIManager:_InternalShowSession(sessionID, uiSession, showSessionData, doneHandler)
    if self.shownSessions[sessionID] ~= nil then
        return
    end

    local cacheSession = self.allSessions[sessionID]
    if not cacheSession then
        local parentRt = self:GetSessionRoot(uiSession.sessionData.sessionType)
        GameResFactory.Instance():GetUIPrefab(showSessionData.prefabName, parentRt,
        function(go)
            if not uiSession then
                error("ui session id:" .. sessionID .. " is null.")
                return
            end

            uiSession:OnPostLoad(go)
            self.allSessions[sessionID] = uiSession

            uiSession:ResetWindow()

            -- 导航系统数据更新
            self:RefreshBackSequenceData(uiSession)

            if doneHandler ~= nil then
                doneHandler(uiSession)
            end
        end )
    else
        if showSessionData ~= nil and showSessionData.isForceResetWindow then
            cacheSession:ResetWindow()
        end

        -- 导航系统数据更新
        RefreshBackSequenceData(cacheSession)

        if doneHandler ~= nil then
            doneHandler(cacheSession)
        end
    end
end

function UIManager:RefreshBackSequenceData(uiSession)
    local sessionData = uiSession.sessionData
    if uiSession:IsNeedRefreshBackSeqData() then
        local dealBackSeq = true
        if self.curShownNormalSession ~= nil then
            if self.curShownNormalSession.sessionData.sessionShowMode == UIShowMode.NoNeedBack then
                dealBackSeq = false
                self:HideSession(uiSession:GetSessionID())
            end
        end

        if dealBackSeq and table.nums(self.shownSessions) > 0 then

            local newPushList = { }

            for k, v in pairs(self.shownSessions) do
                local needToHide = true
                if sessionData.sessionShowMode == UIShowMode.NeedBack
                    or v.sessionData.sessionType == UISessionType.Fixed then
                    needToHide = false
                end

                if needToHide then
                    -- HideOther类型 直接隐藏其他窗口
                    v:HideSessionDirectly();
                    self.shownSessions[k] = nil
                end

                if v:CanAddedToBackSeq() then
                    table.insert(newPushList, v:GetSessionID())
                end
            end

            if #newPushList > 0 then
                local backData = UIBackSequenceData(uiSession, newPushList)
                self.backSequence:Push(backData)
            end
        end
    elseif sessionData.sessionShowMode == UIShowMode.NoNeedBack then
        self:HideAllShownSessions(true)
    end

    self:CheckBackSequenceData(uiSession);
end

-- 直接打开窗口
function UIManager:ShowSessionForBack(sessionID)
    if self.shownSessions[sessionID] ~= nil then
        return
    end

    local uiSession = self.allSessions[sessionID]
    if uiSession ~= nil then
        uiSession:ShowSession()
        self.shownSessions[sessionID] = uiSession;
    end
end

--  如果当前存在BackSequence数据
--  1.栈顶界面不是当前要显示的界面需要清空BackSequence(导航被重置)
--  2.栈顶界面是当前显示界面,如果类型为(NeedBack)则需要显示所有backShowTargets界面
function UIManager:CheckBackSequenceData(uiSession)
    local sessionData = uiSession.sessionData
    if uiSession:IsNeedRefreshBackSeqData() then
        if self.backSequence:Getn() > 0 then
            local backData = self.backSequence:Peek()
            if backData ~= nil then
                -- 栈顶不是即将显示界面(导航序列被打断)
                if backData.hideTargetSession:GetSessionID() ~= uiSession:GetSessionID() then
                    self:CheckBackSequenceData()
                else
                    -- NeedBack类型要将backShowTargets界面显示
                    if sessionData.sessionShowMode == UIShowMode.NeedBack
                        and backData.backShowTargets ~= nil then
                        for i, v in ipairs(backData.backShowTargets) do
                            -- 保证最上面为currentShownWindow
                            if i == #backData.backShowTargets then
                                self.lastShownNormalSession = self.curShownNormalSession
                                self.curShownNormalSession = self.allSessions[v]
                            end
                            self:ShowSessionForBack(v)
                        end
                    end
                end
            end
        end
    end
end

function UIManager:RealShowSession(sessionID, uiSession)
    uiSession:ShowSession()
    self.shownSessions[sessionID] = uiSession
    if uiSession.sessionData.sessionType == UISessionType.Normal then
        self.lastShownNormalSession = self.curShownNormalSession
        self.curShownNormalSession = uiSession
    end
end


function UIManager:HideSession(sessionID, uicommonHandler)
    if self.shownSessions[sessionID] == nil then
        return
    end

    self.shownSessions[sessionID]:HideSession(uicommonHandler)
    self.shownSessions[sessionID] = nil
end

function UIManager:DoGoBack()
    if self.backSequence:Getn() == 0 then
        -- 如果当前BackSequenceData 不存在返回数据
        -- 检测当前Window的preWindowId是否指向上一级合法菜单
        if not self.curShownNormalSession then
            return false
        end

        local preSessionId = self.curShownNormalSession.preSessionID
        if preSessionId ~= UISessionID.Invaild then
            self:HideSession(self.curShownNormalSession:GetSessionID(),
            UICommonHandler(nil, function()
                self:ShowSession(preSessionId, nil)
            end ))
        end

        return false
    end

    local backData = self.backSequence:Peek()
    if backData ~= nil and backData.hideTargetSession ~= nil then
        local hideID = backData.hideTargetSession:GetSessionID()
        if self.shownSessions[hideID] ~= nil then
            self:HideSession(hideID,
            UICommonHandler(nil,
            function()
                if backData.backShowTargets ~= nil then
                    for i, v in ipairs(backData.backShowTargets) do
                        self:ShowSessionForBack(v)
                        if i == #backData.backShowTargets then
                            self.lastShownNormalSession = self.curShownNormalSession
                            self.curShownNormalSession = self.allSessions[v]
                        end
                    end
                end
                self.backSequence:Pop()
            end ))
        else
            return false
        end
    end

    return true
end

function UIManager:GoBack(preGoBackHandler)
    if preGoBackHandler ~= nil then
        local needReturn = preGoBackHandler()
        if not needReturn then
            return false
        end
    end

    return self:DoGoBack()
end

function UIManager:ClearBackSequence()
    self.backSequence:Clear()
end

function UIManager:ClearAllSession()
    for _, v in pairs(self.allSessions) do
        v.DestroySession()
    end
    self.allSessions = { }
    self.shownSessions = { }
    self.backSequence:Clear()
end

function UIManager:HideAllShownSessions(includeFixed)
    if not includeFixed then
        for k, v in pairs(self.shownSessions) do
            if v.sessionData.sessionType ~= UISessionType.Fixed then
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
