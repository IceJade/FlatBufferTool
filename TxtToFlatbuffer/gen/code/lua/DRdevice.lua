-- automatically generated by the FlatBuffers compiler, do not modify

-- namespace: Table

local flatbuffers = require('flatbuffers')

local DRdevice = {} -- the module
local DRdevice_mt = {} -- the class metatable

function DRdevice.New()
    local o = {}
    setmetatable(o, {__index = DRdevice_mt})
    return o
end
function DRdevice.GetRootAsDRdevice(buf, offset)
    local n = flatbuffers.N.UOffsetT:Unpack(buf, offset)
    local o = DRdevice.New()
    o:Init(buf, n + offset)
    return o
end
function DRdevice_mt:Init(buf, pos)
    self.view = flatbuffers.view.New(buf, pos)
end
function DRdevice_mt:Id()
    local o = self.view:Offset(4)
    if o ~= 0 then
        return self.view:String(o + self.view.pos)
    end
end
function DRdevice_mt:ModeType()
    local o = self.view:Offset(6)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int16, o + self.view.pos)
    end
    return 0
end
function DRdevice_mt:RenderLevel()
    local o = self.view:Offset(8)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int16, o + self.view.pos)
    end
    return 0
end
function DRdevice.Start(builder) builder:StartObject(3) end
function DRdevice.AddId(builder, Id) builder:PrependUOffsetTRelativeSlot(0, Id, 0) end
function DRdevice.AddModeType(builder, ModeType) builder:PrependInt16Slot(1, ModeType, 0) end
function DRdevice.AddRenderLevel(builder, RenderLevel) builder:PrependInt16Slot(2, RenderLevel, 0) end
function DRdevice.End(builder) return builder:EndObject() end

return DRdevice -- return the module