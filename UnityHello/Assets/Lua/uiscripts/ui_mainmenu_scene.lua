-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成

local ui_mainmenu_cellbtn = class(ui_session)
function ui_mainmenu_cellbtn:init()

end

function ui_mainmenu_cellbtn:refresh()

end

local ui_mainmenu_scene = class(ui_session)

function ui_mainmenu_scene.show_me()
    local sd = ui_session_data(ui_session_type.NORMAL, ui_session_id.UI_MAINMENU_SCENE)
    ui_manager:instance():show_session(ui_mainmenu_scene(sd))
end

function ui_mainmenu_scene:init(session_data)
    self._base.init(self, session_data)
    self.session_id = ui_session_id.UI_MAINMENU_SCENE
end

function ui_mainmenu_scene:_load_cellbtn_prefab()
    GameResFactory.Instance():GetUIPrefab("ui_mainmenu_cellbtn", self._loop_scroll_rect.transform,
    ui_mainmenu_cellbtn(),
    function(go)
         self._loop_scroll_rect.TotalCount = 10
         self._loop_scroll_rect:Init(go) 
    end )
end

function ui_mainmenu_scene:on_post_load()
    self._loop_scroll_rect = self.transform:Find("contentPanel"):GetComponent(typeof(UnityEngine.UI.LoopVerticalScrollRect))
--    self:_load_cellbtn_prefab()
end

function ui_mainmenu_scene:reset_window(args)
end

function ui_mainmenu_scene:on_pre_destroy()

end

return ui_mainmenu_scene
-- endregion
