-- automatically generated by the FlatBuffers compiler, do not modify

-- namespace: Table

local flatbuffers = require('flatbuffers')

local Table_heroes_levelup = {} -- the module
local Table_heroes_levelup_mt = {} -- the class metatable

function Table_heroes_levelup.New()
    local o = {}
    setmetatable(o, {__index = Table_heroes_levelup_mt})
    return o
end
function Table_heroes_levelup.GetRootAsTable_heroes_levelup(buf, offset)
    local n = flatbuffers.N.UOffsetT:Unpack(buf, offset)
    local o = Table_heroes_levelup.New()
    o:Init(buf, n + offset)
    return o
end
function Table_heroes_levelup_mt:Init(buf, pos)
    self.view = flatbuffers.view.New(buf, pos)
end
function Table_heroes_levelup_mt:Data(j)
    local o = self.view:Offset(4)
    if o ~= 0 then
        local x = self.view:Vector(o)
        x = x + ((j-1) * 4)
        x = self.view:Indirect(x)
        local obj = require('LF.Table.DRheroes_levelup').New()
        obj:Init(self.view.bytes, x)
        return obj
    end
end
function Table_heroes_levelup_mt:DataLength()
    local o = self.view:Offset(4)
    if o ~= 0 then
        return self.view:VectorLen(o)
    end
    return 0
end
function Table_heroes_levelup.Start(builder) builder:StartObject(1) end
function Table_heroes_levelup.AddData(builder, data) builder:PrependUOffsetTRelativeSlot(0, data, 0) end
function Table_heroes_levelup.StartDataVector(builder, numElems) return builder:StartVector(4, numElems, 4) end
function Table_heroes_levelup.End(builder) return builder:EndObject() end

return Table_heroes_levelup -- return the module