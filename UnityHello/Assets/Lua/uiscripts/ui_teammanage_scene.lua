-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成
local class = require("common/middleclass")

local ui_teammanage_scene = class("ui_teammanage_scene", ui_session)

function ui_teammanage_scene.show_me()
    local sd = ui_session_data(ui_session_type.NORMAL, ui_session_id.UI_TEAMMANAGE_SCENE)
    local ui_manager = fw_facade:instance():get_mgr(mgr_name.UI_MGR)
    if ui_manager ~= nil then
        ui_manager:instance():show_session(ui_teammanage_scene(sd))
    end
end

function ui_teammanage_scene:initialize(session_data)
    -- self._base.init(self, session_data)
    ui_session.initialize(self, session_data)
    self.session_id = ui_session_id.UI_TEAMMANAGE_SCENE
end

function ui_teammanage_scene:on_post_load()
end

function ui_teammanage_scene:on_pre_destroy()

end

return ui_teammanage_scene