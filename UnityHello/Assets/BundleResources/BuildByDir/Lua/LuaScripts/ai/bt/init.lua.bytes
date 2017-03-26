local composite_node = require("ai/bt/composite_node")

-- 遇到一个child执行返回true 停止迭代，本node也向父节点返回true
-- 所有child返回false，本node向父节点返回false
selector_node = class("selector_node", composite_node)

function selector_node:initialize()
    composite_node.initialize(self)
end

function selector_node:proc(the_owner)
    for i,v in ipairs(self.children) do
        if v:proc(the_owner) then
            return true
        end
    end
    return false
end

-- 遇到一个child执行返回false 停止迭代，本node也向父节点返回false
-- 所有child返回true，本node向父节点返回true
sequence_node = class("sequence_node", composite_node)
function sequence_node:initialize()
    composite_node.initialize(self)
end

function sequence_node:proc(the_owner)
    for i,v in ipairs(self.children) do
        if v:proc(the_owner) == false then
            return false
        end
    end

    return true
end