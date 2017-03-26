-- 装饰节点
local decorator_node = class("decorator_node")

function decorator_node:initialize()
end

function decorator_node:proc(the_owner)
    if self.child == nil then
        return false
    end

    return self.child:proc(the_owner)
end

function decorator_node:proxy(_child)
    self.child = _child
end

return decorator_node