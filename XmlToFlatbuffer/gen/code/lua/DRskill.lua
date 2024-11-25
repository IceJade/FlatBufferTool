-- automatically generated by the FlatBuffers compiler, do not modify

-- namespace: Table

local flatbuffers = require('flatbuffers')

local DRskill = {} -- the module
local DRskill_mt = {} -- the class metatable

function DRskill.New()
    local o = {}
    setmetatable(o, {__index = DRskill_mt})
    return o
end
function DRskill.GetRootAsDRskill(buf, offset)
    local n = flatbuffers.N.UOffsetT:Unpack(buf, offset)
    local o = DRskill.New()
    o:Init(buf, n + offset)
    return o
end
function DRskill_mt:Init(buf, pos)
    self.view = flatbuffers.view.New(buf, pos)
end
function DRskill_mt:Id()
    local o = self.view:Offset(4)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRskill_mt:Level()
    local o = self.view:Offset(6)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRskill_mt:TypeArea()
    local o = self.view:Offset(8)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRskill_mt:ObjectNum()
    local o = self.view:Offset(10)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRskill_mt:Effect(j)
    local o = self.view:Offset(12)
    if o ~= 0 then
        local a = self.view:Vector(o)
        return self.view:String(a + ((j-1) * 4))
    end
    return ''
end
function DRskill_mt:EffectLength()
    local o = self.view:Offset(12)
    if o ~= 0 then
        return self.view:VectorLen(o)
    end
    return 0
end
function DRskill_mt:EffectNum(j)
    local o = self.view:Offset(14)
    if o ~= 0 then
        local a = self.view:Vector(o)
        return self.view:String(a + ((j-1) * 4))
    end
    return ''
end
function DRskill_mt:EffectNumLength()
    local o = self.view:Offset(14)
    if o ~= 0 then
        return self.view:VectorLen(o)
    end
    return 0
end
function DRskill_mt:Type()
    local o = self.view:Offset(16)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRskill_mt:TypePara()
    local o = self.view:Offset(18)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRskill_mt:ShowType()
    local o = self.view:Offset(20)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRskill_mt:Name()
    local o = self.view:Offset(22)
    if o ~= 0 then
        return self.view:String(o + self.view.pos)
    end
end
function DRskill_mt:Des()
    local o = self.view:Offset(24)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRskill_mt:Icon()
    local o = self.view:Offset(26)
    if o ~= 0 then
        return self.view:String(o + self.view.pos)
    end
end
function DRskill_mt:ObjectAlies()
    local o = self.view:Offset(28)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRskill_mt:Times()
    local o = self.view:Offset(30)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRskill_mt:Condition()
    local o = self.view:Offset(32)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRskill_mt:EffectType()
    local o = self.view:Offset(34)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRskill_mt:CdTime(j)
    local o = self.view:Offset(36)
    if o ~= 0 then
        local a = self.view:Vector(o)
        return self.view:Get(flatbuffers.N.Int32, a + ((j-1) * 4))
    end
    return 0
end
function DRskill_mt:CdTimeLength()
    local o = self.view:Offset(36)
    if o ~= 0 then
        return self.view:VectorLen(o)
    end
    return 0
end
function DRskill_mt:ShortDes()
    local o = self.view:Offset(38)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRskill_mt:ActivateType()
    local o = self.view:Offset(40)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRskill_mt:HideEffect(j)
    local o = self.view:Offset(42)
    if o ~= 0 then
        local a = self.view:Vector(o)
        return self.view:Get(flatbuffers.N.Int32, a + ((j-1) * 4))
    end
    return 0
end
function DRskill_mt:HideEffectLength()
    local o = self.view:Offset(42)
    if o ~= 0 then
        return self.view:VectorLen(o)
    end
    return 0
end
function DRskill.Start(builder) builder:StartObject(20) end
function DRskill.AddId(builder, id) builder:PrependInt32Slot(0, id, 0) end
function DRskill.AddLevel(builder, level) builder:PrependInt32Slot(1, level, 0) end
function DRskill.AddTypeArea(builder, typeArea) builder:PrependInt32Slot(2, typeArea, 0) end
function DRskill.AddObjectNum(builder, objectNum) builder:PrependInt32Slot(3, objectNum, 0) end
function DRskill.AddEffect(builder, effect) builder:PrependUOffsetTRelativeSlot(4, effect, 0) end
function DRskill.StartEffectVector(builder, numElems) return builder:StartVector(4, numElems, 4) end
function DRskill.AddEffectNum(builder, effectNum) builder:PrependUOffsetTRelativeSlot(5, effectNum, 0) end
function DRskill.StartEffectNumVector(builder, numElems) return builder:StartVector(4, numElems, 4) end
function DRskill.AddType(builder, type) builder:PrependInt32Slot(6, type, 0) end
function DRskill.AddTypePara(builder, typePara) builder:PrependInt32Slot(7, typePara, 0) end
function DRskill.AddShowType(builder, showType) builder:PrependInt32Slot(8, showType, 0) end
function DRskill.AddName(builder, name) builder:PrependUOffsetTRelativeSlot(9, name, 0) end
function DRskill.AddDes(builder, des) builder:PrependInt32Slot(10, des, 0) end
function DRskill.AddIcon(builder, icon) builder:PrependUOffsetTRelativeSlot(11, icon, 0) end
function DRskill.AddObjectAlies(builder, objectAlies) builder:PrependInt32Slot(12, objectAlies, 0) end
function DRskill.AddTimes(builder, times) builder:PrependInt32Slot(13, times, 0) end
function DRskill.AddCondition(builder, condition) builder:PrependInt32Slot(14, condition, 0) end
function DRskill.AddEffectType(builder, effectType) builder:PrependInt32Slot(15, effectType, 0) end
function DRskill.AddCdTime(builder, cdTime) builder:PrependUOffsetTRelativeSlot(16, cdTime, 0) end
function DRskill.StartCdTimeVector(builder, numElems) return builder:StartVector(4, numElems, 4) end
function DRskill.AddShortDes(builder, ShortDes) builder:PrependInt32Slot(17, ShortDes, 0) end
function DRskill.AddActivateType(builder, activateType) builder:PrependInt32Slot(18, activateType, 0) end
function DRskill.AddHideEffect(builder, hideEffect) builder:PrependUOffsetTRelativeSlot(19, hideEffect, 0) end
function DRskill.StartHideEffectVector(builder, numElems) return builder:StartVector(4, numElems, 4) end
function DRskill.End(builder) return builder:EndObject() end

return DRskill -- return the module