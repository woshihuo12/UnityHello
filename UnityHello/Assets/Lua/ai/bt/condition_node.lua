-- 条件判断节点
local condition_node = class("condition_node")

function condition_node:initialize()
end

function condition_node:proc(the_owner)
    return false
end

return condition_node