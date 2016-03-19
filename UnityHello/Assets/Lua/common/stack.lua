-- region *.lua
-- Date
-- 此文件由[BabeLua]插件自动生成

Stack = { }

function Stack:Create()
    local t = { }
    t._et = { }

    function t:Push(...)
        if ... then
            local targs = { ...}
            for _, v in ipairs(targs) do
                table.insert(self._et, v)
            end
        end
    end

    function t:Pop(num)
        local num = num or 1
        local entries = { }
        for i = 1, num do
            if #self._et ~= 0 then
                table.insert(entries, self._et[#self._et])
                table.remove(self._et)
            else
                break
            end
        end
        return unpack(entries)
    end

    function t:Peek()
        if #self._et ~= 0 then
            return self._et[#self._et]
        end
        return nil
    end

    function t:Clear()
        while #self._et ~= 0 do
            table.remove(self._et)
        end
    end

    function t:Getn()
        return #self._et
    end

    function t:List()
        for i, v in pairs(self._et) do
            print(i, v)
        end
    end

    return t
end

-- endregion
