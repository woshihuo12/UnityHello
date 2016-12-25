local ui_topbar = class("ui_topbar", ui_session)

function ui_topbar.show_me()
    local sd = ui_session_data(ui_session_type.FIXED, ui_session_id.UI_TOPBAR)

    local ui_manager = fw_facade:instance():get_mgr(mgr_name.UI_MGR)
    if ui_manager ~= nil then
        ui_manager:instance():show_session(ui_topbar(sd))
    end
end

function ui_topbar:initialize(session_data)
    -- self._base.init(self, session_data)
    ui_session.initialize(self, session_data)
    self.session_id = ui_session_id.UI_TOPBAR
end

function ui_topbar:on_post_load()
    local left_btn = self.transform:Find("leftBtn").gameObject
    self.lua_behaviour:AddClick(left_btn, function(go)
        local ui_manager = fw_facade:instance():get_mgr(mgr_name.UI_MGR)
        if ui_manager ~= nil then
            ui_manager:instance():go_back()
        end
    end )
end

function ui_topbar:reset_window(args)

end

function ui_topbar:on_pre_destroy()
    print("ui_topbar:on_pre_destroy" .. self.gameObject.name)
end

return ui_topbar