-- automatically generated by the FlatBuffers compiler, do not modify

-- namespace: Table

local flatbuffers = require('flatbuffers')

local Table_device = {} -- the module
local Table_device_mt = {} -- the class metatable

function Table_device.New()
    local o = {}
    setmetatable(o, {__index = Table_device_mt})
    return o
end
function Table_device.GetRootAsTable_device(buf, offset)
    local n = flatbuffers.N.UOffsetT:Unpack(buf, offset)
    local o = Table_device.New()
    o:Init(buf, n + offset)
    return o
end
function Table_device_mt:Init(buf, pos)
    self.view = flatbuffers.view.New(buf, pos)
end
function Table_device_mt:Data(j)
    local o = self.view:Offset(4)
    if o ~= 0 then
        local x = self.view:Vector(o)
        x = x + ((j-1) * 4)
        x = self.view:Indirect(x)
        local obj = require('LF.Table.DRdevice').New()
        obj:Init(self.view.bytes, x)
        return obj
    end
end
function Table_device_mt:DataLength()
    local o = self.view:Offset(4)
    if o ~= 0 then
        return self.view:VectorLen(o)
    end
    return 0
end
function Table_device.Start(builder) builder:StartObject(1) end
function Table_device.AddData(builder, data) builder:PrependUOffsetTRelativeSlot(0, data, 0) end
function Table_device.StartDataVector(builder, numElems) return builder:StartVector(4, numElems, 4) end
function Table_device.End(builder) return builder:EndObject() end

return Table_device -- return the module