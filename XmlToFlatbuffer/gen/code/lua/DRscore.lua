-- automatically generated by the FlatBuffers compiler, do not modify

-- namespace: Table

local flatbuffers = require('flatbuffers')

local DRscore = {} -- the module
local DRscore_mt = {} -- the class metatable

function DRscore.New()
    local o = {}
    setmetatable(o, {__index = DRscore_mt})
    return o
end
function DRscore.GetRootAsDRscore(buf, offset)
    local n = flatbuffers.N.UOffsetT:Unpack(buf, offset)
    local o = DRscore.New()
    o:Init(buf, n + offset)
    return o
end
function DRscore_mt:Init(buf, pos)
    self.view = flatbuffers.view.New(buf, pos)
end
function DRscore_mt:Id()
    local o = self.view:Offset(4)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRscore_mt:Type()
    local o = self.view:Offset(6)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRscore_mt:Name()
    local o = self.view:Offset(8)
    if o ~= 0 then
        return self.view:String(o + self.view.pos)
    end
end
function DRscore_mt:Points()
    local o = self.view:Offset(10)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRscore_mt:SeasonType()
    local o = self.view:Offset(12)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRscore_mt:Value(j)
    local o = self.view:Offset(14)
    if o ~= 0 then
        local a = self.view:Vector(o)
        return self.view:String(a + ((j-1) * 4))
    end
    return ''
end
function DRscore_mt:ValueLength()
    local o = self.view:Offset(14)
    if o ~= 0 then
        return self.view:VectorLen(o)
    end
    return 0
end
function DRscore_mt:Group(j)
    local o = self.view:Offset(16)
    if o ~= 0 then
        local a = self.view:Vector(o)
        return self.view:Get(flatbuffers.N.Int32, a + ((j-1) * 4))
    end
    return 0
end
function DRscore_mt:GroupLength()
    local o = self.view:Offset(16)
    if o ~= 0 then
        return self.view:VectorLen(o)
    end
    return 0
end
function DRscore_mt:Tips(j)
    local o = self.view:Offset(18)
    if o ~= 0 then
        local a = self.view:Vector(o)
        return self.view:Get(flatbuffers.N.Int32, a + ((j-1) * 4))
    end
    return 0
end
function DRscore_mt:TipsLength()
    local o = self.view:Offset(18)
    if o ~= 0 then
        return self.view:VectorLen(o)
    end
    return 0
end
function DRscore.Start(builder) builder:StartObject(8) end
function DRscore.AddId(builder, id) builder:PrependInt32Slot(0, id, 0) end
function DRscore.AddType(builder, type) builder:PrependInt32Slot(1, type, 0) end
function DRscore.AddName(builder, name) builder:PrependUOffsetTRelativeSlot(2, name, 0) end
function DRscore.AddPoints(builder, points) builder:PrependInt32Slot(3, points, 0) end
function DRscore.AddSeasonType(builder, seasonType) builder:PrependInt32Slot(4, seasonType, 0) end
function DRscore.AddValue(builder, value) builder:PrependUOffsetTRelativeSlot(5, value, 0) end
function DRscore.StartValueVector(builder, numElems) return builder:StartVector(4, numElems, 4) end
function DRscore.AddGroup(builder, group) builder:PrependUOffsetTRelativeSlot(6, group, 0) end
function DRscore.StartGroupVector(builder, numElems) return builder:StartVector(4, numElems, 4) end
function DRscore.AddTips(builder, tips) builder:PrependUOffsetTRelativeSlot(7, tips, 0) end
function DRscore.StartTipsVector(builder, numElems) return builder:StartVector(4, numElems, 4) end
function DRscore.End(builder) return builder:EndObject() end

return DRscore -- return the module