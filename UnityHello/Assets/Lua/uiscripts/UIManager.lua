-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成

UIManager = class()
function UIManager:init()
    -- 所有已加载的 Session
    self.allSessions = { }
    -- 当前正在显示的 Session
    self.shownSessions = { }
    -- 普通窗口用来导航用到的堆栈
    self.backSequence = Stack:Create()
    -- 弹出窗口用来导航用到的堆栈
    self.popUpBackSequence = Stack:Create()
    -- 管理器级的锁定操作
    self.isLocked = false

    self.uiLayer = UGameObject.Find("UILayer").transform

    assert(not tolua.isnull(self.uiLayer), "UILayer is cannot find~~~~~~")
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

            uiSession:OnPostLoad()
            self.allSessions[sessionID] = uiSession

            uiSession:ResetWindow(showSessionData)

            -- 导航系统数据更新
            self:RefreshBackSequenceData(uiSession)

            self:RealShowSession(sessionID, uiSession)
            -- 是否清空当前导航信息(回到主菜单)
            if uiSession.sessionData.isStartWindow or
                (showSessionData ~= nil and showSessionData.isForceClearBackSeqData) then
                self:ClearBackSequence()
            end

            if doneHandler then
                doneHandler()
            end
        end )
    else
        if showSessionData ~= nil and showSessionData.isForceResetWindow then
            cacheSession:ResetWindow()
        end

        -- 导航系统数据更新
        RefreshBackSequenceData(cacheSession)

        self:RealShowSession(sessionID, cacheSession)
        -- 是否清空当前导航信息(回到主菜单)
        if cacheSession.sessionData.isStartWindow or
            (showSessionData ~= nil and showSessionData.isForceClearBackSeqData) then
            self:ClearBackSequence()
        end

        if doneHandler then
            doneHandler()
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

function UIManager:ChangeChildLayer(go, layer)
    go.layer = layer
    local tmpTr = go.transform
    for i = 0, tmpTr.childCount - 1 do
        local child = tmpTr:GetChild(i)
        child.gameObject.layer = layer
        self:ChangeChildLayer(child, layer)
    end
end

function UIManager:CreateLayerRoot(goName, sortOrder)
    local tmpGo = UGameObject(goName)

    local rtTransform = tmpGo:AddComponent(typeof(UnityEngine.RectTransform))

    rtTransform:SetParent(self.uiLayer, false)

    self:ChangeChildLayer(tmpGo, LayerMask.NameToLayer("UI"))

    rtTransform.anchorMin = Vector2.zero
    rtTransform.anchorMax = Vector2.one

    rtTransform.offsetMax = Vector2.zero
    rtTransform.offsetMin = Vector2.zero

    local tmpCanvas = tmpGo:AddComponent(typeof(UnityEngine.Canvas))
    tmpCanvas.overrideSorting = true
    tmpCanvas.sortingOrder = sortOrder
    tmpGo:AddComponent(typeof(UnityEngine.UI.GraphicRaycaster))

    return rtTransform
end

function UIManager:GetSessionRoot(sessionType)

    if sessionType == UISessionType.BackGround then
        if not self.backGroundRoot then
            self.backGroundRoot = self:CreateLayerRoot("BackGroundRoot", 2)
        end
        return self.backGroundRoot
    elseif sessionType == UISessionType.Normal then
        if not self.normalRoot then
            self.normalRoot = self:CreateLayerRoot("NormalRoot", 10)
        end
        return self.normalRoot
    elseif sessionType == UISessionType.Fixed then
        if not self.fixedRoot then
            self.fixedRoot = self:CreateLayerRoot("FixedRoot", 250)
        end
        return self.fixedRoot
    elseif sessionType == UISessionType.PopUp then
        if not self.popUpRoot then
            self.popUpRoot = self:CreateLayerRoot("PopUpRoot", 500)
        end
        return self.popUpRoot
    elseif sessionType == UISessionType.AbovePopUp then
        if not self.abovePopUpRoot then
            self.abovePopUpRoot = self:CreateLayerRoot("AbovePopUpRoot", 750)
        end
        return self.abovePopUpRoot
    elseif sessionType == UISessionType.Tutorial then
        if not self.tutorialRoot then
            self.tutorialRoot = self:CreateLayerRoot("TutorialRoot", 1000)
        end
        return self.tutorialRoot
    elseif sessionType == UISessionType.AboveTutorial then
        if not self.aboveTutorialRoot then
            self.aboveTutorialRoot = self:CreateLayerRoot("AboveTutorialRoot", 1250)
        end
        return self.aboveTutorialRoot
    else
        return self.uiLayer
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

function UIManager:DestroySession(sessionID, uicommonHandler)
    if not self.allSessions[sessionID] then
        return
    end
    if self.shownSessions[sessionID] then
        self.shownSessions[sessionID] = nil
    end
    self.allSessions[sessionID]:DestroySession(uicommonHandler)
    self.allSessions[sessionID] = nil
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
        v:DestroySession()
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
