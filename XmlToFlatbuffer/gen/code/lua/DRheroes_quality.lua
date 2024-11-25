-- automatically generated by the FlatBuffers compiler, do not modify

-- namespace: Table

local flatbuffers = require('flatbuffers')

local DRheroes_quality = {} -- the module
local DRheroes_quality_mt = {} -- the class metatable

function DRheroes_quality.New()
    local o = {}
    setmetatable(o, {__index = DRheroes_quality_mt})
    return o
end
function DRheroes_quality.GetRootAsDRheroes_quality(buf, offset)
    local n = flatbuffers.N.UOffsetT:Unpack(buf, offset)
    local o = DRheroes_quality.New()
    o:Init(buf, n + offset)
    return o
end
function DRheroes_quality_mt:Init(buf, pos)
    self.view = flatbuffers.view.New(buf, pos)
end
function DRheroes_quality_mt:Id()
    local o = self.view:Offset(4)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRheroes_quality_mt:Pic()
    local o = self.view:Offset(6)
    if o ~= 0 then
        return self.view:String(o + self.view.pos)
    end
end
function DRheroes_quality_mt:Level()
    local o = self.view:Offset(8)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRheroes_quality_mt:LvAdd(j)
    local o = self.view:Offset(10)
    if o ~= 0 then
        local a = self.view:Vector(o)
        return self.view:Get(flatbuffers.N.Int32, a + ((j-1) * 4))
    end
    return 0
end
function DRheroes_quality_mt:LvAddLength()
    local o = self.view:Offset(10)
    if o ~= 0 then
        return self.view:VectorLen(o)
    end
    return 0
end
function DRheroes_quality_mt:Type()
    local o = self.view:Offset(12)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRheroes_quality_mt:Consume(j)
    local o = self.view:Offset(14)
    if o ~= 0 then
        local a = self.view:Vector(o)
        return self.view:Get(flatbuffers.N.Int32, a + ((j-1) * 4))
    end
    return 0
end
function DRheroes_quality_mt:ConsumeLength()
    local o = self.view:Offset(14)
    if o ~= 0 then
        return self.view:VectorLen(o)
    end
    return 0
end
function DRheroes_quality_mt:RobotConsume(j)
    local o = self.view:Offset(16)
    if o ~= 0 then
        local a = self.view:Vector(o)
        return self.view:Get(flatbuffers.N.Int32, a + ((j-1) * 4))
    end
    return 0
end
function DRheroes_quality_mt:RobotConsumeLength()
    local o = self.view:Offset(16)
    if o ~= 0 then
        return self.view:VectorLen(o)
    end
    return 0
end
function DRheroes_quality_mt:Name()
    local o = self.view:Offset(18)
    if o ~= 0 then
        return self.view:String(o + self.view.pos)
    end
end
function DRheroes_quality_mt:Color()
    local o = self.view:Offset(20)
    if o ~= 0 then
        return self.view:String(o + self.view.pos)
    end
end
function DRheroes_quality_mt:Pic2()
    local o = self.view:Offset(22)
    if o ~= 0 then
        return self.view:String(o + self.view.pos)
    end
end
function DRheroes_quality_mt:Pic3()
    local o = self.view:Offset(24)
    if o ~= 0 then
        return self.view:String(o + self.view.pos)
    end
end
function DRheroes_quality_mt:PicColor()
    local o = self.view:Offset(26)
    if o ~= 0 then
        return self.view:String(o + self.view.pos)
    end
end
function DRheroes_quality_mt:Pic4()
    local o = self.view:Offset(28)
    if o ~= 0 then
        return self.view:String(o + self.view.pos)
    end
end
function DRheroes_quality_mt:LevelGrowth()
    local o = self.view:Offset(30)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRheroes_quality_mt:Star()
    local o = self.view:Offset(32)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRheroes_quality_mt:LimitType()
    local o = self.view:Offset(34)
    if o ~= 0 then
        return self.view:Get(flatbuffers.N.Int32, o + self.view.pos)
    end
    return 0
end
function DRheroes_quality.Start(builder) builder:StartObject(16) end
function DRheroes_quality.AddId(builder, id) builder:PrependInt32Slot(0, id, 0) end
function DRheroes_quality.AddPic(builder, pic) builder:PrependUOffsetTRelativeSlot(1, pic, 0) end
function DRheroes_quality.AddLevel(builder, level) builder:PrependInt32Slot(2, level, 0) end
function DRheroes_quality.AddLvAdd(builder, lvAdd) builder:PrependUOffsetTRelativeSlot(3, lvAdd, 0) end
function DRheroes_quality.StartLvAddVector(builder, numElems) return builder:StartVector(4, numElems, 4) end
function DRheroes_quality.AddType(builder, type) builder:PrependInt32Slot(4, type, 0) end
function DRheroes_quality.AddConsume(builder, consume) builder:PrependUOffsetTRelativeSlot(5, consume, 0) end
function DRheroes_quality.StartConsumeVector(builder, numElems) return builder:StartVector(4, numElems, 4) end
function DRheroes_quality.AddRobotConsume(builder, robotConsume) builder:PrependUOffsetTRelativeSlot(6, robotConsume, 0) end
function DRheroes_quality.StartRobotConsumeVector(builder, numElems) return builder:StartVector(4, numElems, 4) end
function DRheroes_quality.AddName(builder, name) builder:PrependUOffsetTRelativeSlot(7, name, 0) end
function DRheroes_quality.AddColor(builder, color) builder:PrependUOffsetTRelativeSlot(8, color, 0) end
function DRheroes_quality.AddPic2(builder, pic2) builder:PrependUOffsetTRelativeSlot(9, pic2, 0) end
function DRheroes_quality.AddPic3(builder, pic3) builder:PrependUOffsetTRelativeSlot(10, pic3, 0) end
function DRheroes_quality.AddPicColor(builder, picColor) builder:PrependUOffsetTRelativeSlot(11, picColor, 0) end
function DRheroes_quality.AddPic4(builder, pic4) builder:PrependUOffsetTRelativeSlot(12, pic4, 0) end
function DRheroes_quality.AddLevelGrowth(builder, levelGrowth) builder:PrependInt32Slot(13, levelGrowth, 0) end
function DRheroes_quality.AddStar(builder, star) builder:PrependInt32Slot(14, star, 0) end
function DRheroes_quality.AddLimitType(builder, limitType) builder:PrependInt32Slot(15, limitType, 0) end
function DRheroes_quality.End(builder) return builder:EndObject() end

return DRheroes_quality -- return the module