-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成
UISessionType =
{
    -- 背景层
    BackGround = 1,
    -- 普通界面(UIMainMenu等)
    Normal = 2,
    -- 固定窗口(UITopBar等)
    Fixed = 3,
    -- 弹窗
    PopUp = 4,
    -- 游戏中需显示到弹窗上的
    AbovePopUp = 5,
    -- 新手指引
    Tutorial = 6,
    -- 新手指引上的比如跑马灯新闻
    AboveTutorial = 7,
}

UICommonHandler = class()
function UICommonHandler:init(beforeHandler, afterHandler)
    self.beforeHandler = beforeHandler
    self.afterHandler = afterHandler
end

UIAnimHandler = class()
function UIAnimHandler:init(beforeHandler, resetHandler, afterHandler)
    self.beforeHandler = beforeHandler
    self.resetHandler = resetHandler
    self.afterHandler = afterHandler
end

-- 界面状态数据
UISessionData = class()
function UISessionData:init(sessionType, prefabName)
    self.sessionType = sessionType
    self.prefabName = prefabName
end

UIShowParam = class()
-- Reset窗口
-- Clear导航信息
-- Prefab名字
-- Object 数据
function UIShowParam:init(prefabName, args)
    self.args = args
end

UISession = class()
function UISession:init(sessionData)
    -- 如果需要可以添加一个BoxCollider屏蔽事件
    self.isLock = false
    self.isShown = false
    -- 当前界面ID
    self.sessionID = UISessionID.Invaild
    -- 指向上一级界面ID(BackSequence无内容，返回上一级)
    self.preSessionID = UISessionID.Invaild
    self.sessionData = sessionData
end

-- 界面被加载后
function UISession:OnPostLoad()
end

-- 界面被销毁前 
function UISession:OnPreDestroy()
end

-- 重置窗口
function UISession:ResetWindow()
end

-- 显示窗口
function UISession:ShowSession()
    self.isLock = false
    self.isShown = true
    if not tolua.isnull(self.gameObject) then
        self.gameObject:SetActive(true)
    end
end

-- 显示动画
function UISession:EnterAnim(doneHandler)
end

-- 退出动画
function UISession:QuitAnim(doneHandler)
end

-- 重置动画
function UISession:ResetAnim(doneHandler)
end

-- 隐藏窗口
function UISession:HideSessionDirectly()
    self.isLock = true
    self.isShown = false
    if not tolua.isnull(self.gameObject) then
        self.gameObject:SetActive(false)
    end
end

function UISession:HideSession(uiCommmonHandler)
    if uiCommmonHandler and uiCommmonHandler.beforeHandler then
        uiCommmonHandler.beforeHandler()
    end
    self.isLock = true
    self.isShown = false
    if not tolua.isnull(self.gameObject) then
        self.gameObject:SetActive(false)
    end
    if uiCommmonHandler and uiCommmonHandler.afterHandler then
        uiCommmonHandler.afterHandler()
    end
end

function UISession:DestroySession(uiCommmonHandler)
    if uiCommmonHandler and uiCommmonHandler.beforeHandler then
        uiCommmonHandler.beforeHandler()
    end

    self:OnPreDestroy()

    UObject.Destroy(self.gameObject)

    if uiCommmonHandler and uiCommmonHandler.afterHandler then
        uiCommmonHandler.afterHandler()
    end
end

function UISession:GetSessionID()
    return self.sessionID;
end
-- endregion
