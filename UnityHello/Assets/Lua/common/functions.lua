-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成

function table.nums(t)
    local count = 0
    for k, v in pairs(t) do
        count = count + 1
    end
    return count
end

-- start --

--------------------------------
-- 从表格中删除指定值，返回删除的值的个数
-- @function [parent=#table] removebyvalue
-- @param table array 表格
-- @param mixed value 要删除的值
-- @param boolean removeall 是否删除所有相同的值
-- @return integer#integer 

--[[--

从表格中删除指定值，返回删除的值的个数

~~~ lua

local array = {"a", "b", "c", "c"}
print(table.removebyvalue(array, "c", true)) -- 输出 2

~~~

]]

-- end --
function table.removebyvalue(array, value, removeall)
    local c, i, max = 0, 1, #array
    while i <= max do
        if array[i] == value then
            table.remove(array, i)
            c = c + 1
            i = i - 1
            max = max - 1
            if not removeall then break end
        end
        i = i + 1
    end
    return c
end


function play_open_window_anim(trans, ui_animhandler)
    if ui_animhandler and ui_animhandler.beforehandler then
        ui_animhandler.beforehandler()
    end
    trans.localScale = Vector3.zero
    local ltDescr = LeanTween.scale(trans, Vector3.one, 0.2):setEase(LeanTweenType.easeOutBack)
    if ltDescr and ui_animhandler and ui_animhandler.afterhandler then
        ltDescr:setOnComplete(System.Action(ui_animhandler.afterhandler))
    end
end
-- endregion
