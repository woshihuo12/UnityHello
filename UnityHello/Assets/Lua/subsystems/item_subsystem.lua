local item_subsystem = class("item_subsystem")

function item_subsystem.instance()
    if item_subsystem._instance == nil then
        item_subsystem._instance = item_subsystem()
    end
    return item_subsystem._instance
end

function item_subsystem:initialize()
    self.item_datas = {}
end

function item_subsystem:init_data(data)
end

function item_subsystem:get_item(uid)
    return self.item_datas[uid]
end

return item_subsystem