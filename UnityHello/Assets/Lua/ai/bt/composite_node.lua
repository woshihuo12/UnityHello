-- 复合节点

local composite_node = class("composite_node")

function composite_node:initialize()
    self.children = {}
end

function composite_node:proc(the_owner)
    return true
end

function composite_node:add_child(_node)
    self.children[#self.children + 1] = _node
end

function composite_node:del_child(_node)
    table.removebyvalue(self.children, _node, false)
end

function composite_node:clear_children()
    self.children = {}
end

return composite_node