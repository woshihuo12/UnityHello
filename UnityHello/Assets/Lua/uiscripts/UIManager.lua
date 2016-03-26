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

function UIManager:ShowPopUp(sessionID, uiSession, isCloseCur, args, uiCommonHandler)

    if self.shownSessions[sessionID] ~= nil then
        return
    end

    local sessionData = uiSession.sessionData
    if not sessionData then return end

    if sessionData.sessionType ~= UISessionType.PopUp then
        return
    end

    if isCloseCur then
        local curTopPopSession = self.popUpBackSequence:Peek()
        if curTopPopSession then
            local curTopPopId = curTopPopSession:GetSessionID()
            if curTopPopId == sessionID then
                return
            else
                self.shownSessions[curTopPopId]:DestroySession()
                self.shownSessions[curTopPopId] = nil
                self.allSessions[curTopPopId] = nil
                self.popUpBackSequence:Pop()
            end
        end
    end

    if uiCommonHandler and uiCommonHandler.beforeHandler then
        uiCommonHandler.beforeHandler()
    end

    GameResFactory.Instance():GetUIPrefab(sessionData.prefabName, self:GetSessionRoot(UISessionType.PopUp),
    function(go)
        uiSession:OnPostLoad()
        self.allSessions[sessionID] = uiSession

        uiSession:ResetWindow(args)
        uiSession:ShowSession()
        uiSession:EnterAnim()

        self.shownSessions[sessionID] = uiSession
        self.popUpBackSequence:Push(uiSession)

        if uiCommonHandler and uiCommonHandler.afterHandler then
            uiCommonHandler.afterHandler()
        end
    end )
end

-- 关闭栈顶弹窗
function UIManager:ClosePopUp(uiCommonHandler)
    local topPopSession = self.popUpBackSequence:Peek()
    if not topPopSession then
        return
    end

    local topPopSessionID = topPopSession:GetSessionID()
    topPopSession:QuitAnim( function()
        topPopSession:DestroySession()
        self.shownSessions[topPopSessionID] = nil
        self.allSessions[topPopSessionID] = nil
        self.popUpBackSequence:Pop()
    end )
end

function UIManager:CloseCurrentSession()
    -- 关闭当前界面
    if self.currentSession then
        local curSessionID = self.currentSession:GetSessionID()
        if not curSessionID then return end

        local curTopSession = self.backSequence:Peek()
        local curTopSessionID = curTopSession:GetSessionID()
        self:DestroySession(curTopSessionID, uicommonHandler)
        if curSessionID == curTopSessionID then
            self.backSequence:Pop()
        end
    end
end

function UIManager:ShowSession(sessionID, uiSession, args, doneHandler)
    if self.shownSessions[sessionID] ~= nil then
        return
    end

    local sessionData = uiSession.sessionData
    if not sessionData then return end

    if sessionData.sessionType == UISessionType.PopUp then
        return
    end

    self:CloseCurrentSession()

    GameResFactory.Instance():GetUIPrefab(sessionData.prefabName, self:GetSessionRoot(sessionData.sessionType),
    function(go)
        uiSession:OnPostLoad()
        self.allSessions[sessionID] = uiSession

        uiSession:ResetWindow(args)
        uiSession:ShowSession()
        self.shownSessions[sessionID] = uiSession

        self.lastSession = self.currentSession
        self.currentSession = uiSession

        self.backSequence:Push(sessionID)

        if doneHandler then
            doneHandler()
        end
    end )
end

local function CoShowSessionDelay(self, delayTime, sessionID, uiSession, prefabName, args)
    coroutine.wait(delayTime)
    self:ShowSession(sessionID, uiSession, prefabName, args)
end

function UIManager:ShowSessionDelay(delayTime, sessionID, uiSession, prefabName, args)
    coroutine.start(CoShowSessionDelay, self, delayTime, sessionID, uiSession, prefabName, args)
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
    if not self.currentSession then
        return false
    end
    if self.backSequence:Getn() == 0 then
        -- 如果当前BackSequenceData 不存在返回数据
        -- 检测lastSession
        local preSessionId = self.lastSession and self.lastSession:GetSessionID() or UISessionID.Invaild
        if preSessionId ~= UISessionID.Invaild then
            self:CloseCurrentSession()
            self:ShowSession(preSessionId, self.lastSession)
            return true
        else
            return false
        end
    else
        local backSession = self.backSequence:Peek()
        if backSession then
            self:CloseCurrentSession()
            self:ShowSession(backSession:GetSessionID(), backSession)
        else
            return false
        end
    end
end

function UIManager:GoBack(preGoBackHandler)
    if not preGoBackHandler then
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

function UIManager:ClearPopUpBackSequence()
    self.popUpBackSequence:Clear()
end

function UIManager:ClearAllSession()
    for _, v in pairs(self.allSessions) do
        v:DestroySession()
    end
    self.allSessions = { }
    self.shownSessions = { }
    self.backSequence:Clear()
    self.popUpBackSequence:Clear()
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
