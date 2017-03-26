local behavior_tree_root = class("behavior_tree_root")

function behavior_tree_root:initialize()    
end

function behavior_tree_root:proc(the_owner)
    if self.root == nil then
        return false
    end

    return self.root:proc(the_owner)
end

function behavior_tree_root:add_child(root)
    self.root = root
end

return behavior_tree_root