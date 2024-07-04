-- automatically generated by the FlatBuffers compiler, do not modify

-- namespace: Table

local flatbuffers = require('flatbuffers')

local DRvip = {} -- the module
local DRvip_mt = {} -- the class metatable

function DRvip.New()
    local o = {}
    setmetatable(o, {__index = DRvip_mt})
    return o
end
function DRvip.GetRootAsDRvip(buf, offset)
    local n = flatbuffers.N.UOffsetT:Unpack(buf, offset)
    local o = DRvip.New()
    o:Init(buf, n + offset)
    return o
end
function DRvip_mt:Init(buf, pos)
    self.view = flatbuffers.view.New(buf, pos)
end
function DRvip_mt:Id()
    local o = self.view:Offset(4)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRvip_mt:Point()
    local o = self.view:Offset(6)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRvip_mt:Icon()
    local o = self.view:Offset(8)
    if o ~= 0 then
        return self.view:String(o + self.view.pos)
    end
end
function DRvip_mt:Reward1(j)
    local o = self.view:Offset(10)
    if o ~= 0 then
        local a = self.view:Vector(o)
        return self.view:String(a + ((j-1) * 4))
    end
    return ''
end
function DRvip_mt:Reward1Length()
    local o = self.view:Offset(10)
    if o ~= 0 then
        return self.view:VectorLen(o)
    end
    return 0
end
function DRvip_mt:Reward2()
    local o = self.view:Offset(12)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRvip_mt:Display(j)
    local o = self.view:Offset(14)
    if o ~= 0 then
        local a = self.view:Vector(o)
        return self.view:Get(flatbuffers.N.Int32, a + ((j-1) * 4))
    end
    return 0
end
function DRvip_mt:DisplayLength()
    local o = self.view:Offset(14)
    if o ~= 0 then
        return self.view:VectorLen(o)
    end
    return 0
end
function DRvip_mt:Effect(j)
    local o = self.view:Offset(16)
    if o ~= 0 then
        local a = self.view:Vector(o)
        return self.view:String(a + ((j-1) * 4))
    end
    return ''
end
function DRvip_mt:EffectLength()
    local o = self.view:Offset(16)
    if o ~= 0 then
        return self.view:VectorLen(o)
    end
    return 0
end
function DRvip.Start(builder) builder:StartObject(7) end
function DRvip.AddId(builder, id) builder:PrependInt32Slot(0, id, 0) end
function DRvip.AddPoint(builder, point) builder:PrependInt32Slot(1, point, 0) end
function DRvip.AddIcon(builder, icon) builder:PrependUOffsetTRelativeSlot(2, icon, 0) end
function DRvip.AddReward1(builder, reward1) builder:PrependUOffsetTRelativeSlot(3, reward1, 0) end
function DRvip.StartReward1Vector(builder, numElems) return builder:StartVector(4, numElems, 4) end
function DRvip.AddReward2(builder, reward2) builder:PrependInt32Slot(4, reward2, 0) end
function DRvip.AddDisplay(builder, display) builder:PrependUOffsetTRelativeSlot(5, display, 0) end
function DRvip.StartDisplayVector(builder, numElems) return builder:StartVector(4, numElems, 4) end
function DRvip.AddEffect(builder, effect) builder:PrependUOffsetTRelativeSlot(6, effect, 0) end
function DRvip.StartEffectVector(builder, numElems) return builder:StartVector(4, numElems, 4) end
function DRvip.End(builder) return builder:EndObject() end

return DRvip -- return the module