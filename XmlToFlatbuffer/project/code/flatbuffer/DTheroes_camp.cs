// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace LF.Table
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DRheroes_camp : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static DRheroes_camp GetRootAsDRheroes_camp(ByteBuffer _bb) { return GetRootAsDRheroes_camp(_bb, new DRheroes_camp()); }
  public static DRheroes_camp GetRootAsDRheroes_camp(ByteBuffer _bb, DRheroes_camp obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DRheroes_camp __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string Name { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetNameBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetNameBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetNameArray() { return __p.__vector_as_array<byte>(6); }
  public string Des { get { int o = __p.__offset(8); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetDesBytes() { return __p.__vector_as_span<byte>(8, 1); }
#else
  public ArraySegment<byte>? GetDesBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public byte[] GetDesArray() { return __p.__vector_as_array<byte>(8); }
  public string KindIcon1 { get { int o = __p.__offset(10); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetKindIcon1Bytes() { return __p.__vector_as_span<byte>(10, 1); }
#else
  public ArraySegment<byte>? GetKindIcon1Bytes() { return __p.__vector_as_arraysegment(10); }
#endif
  public byte[] GetKindIcon1Array() { return __p.__vector_as_array<byte>(10); }
  public string KindIcon2 { get { int o = __p.__offset(12); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetKindIcon2Bytes() { return __p.__vector_as_span<byte>(12, 1); }
#else
  public ArraySegment<byte>? GetKindIcon2Bytes() { return __p.__vector_as_arraysegment(12); }
#endif
  public byte[] GetKindIcon2Array() { return __p.__vector_as_array<byte>(12); }
  public string KindIcon3 { get { int o = __p.__offset(14); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetKindIcon3Bytes() { return __p.__vector_as_span<byte>(14, 1); }
#else
  public ArraySegment<byte>? GetKindIcon3Bytes() { return __p.__vector_as_arraysegment(14); }
#endif
  public byte[] GetKindIcon3Array() { return __p.__vector_as_array<byte>(14); }
  public string Icon { get { int o = __p.__offset(16); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetIconBytes() { return __p.__vector_as_span<byte>(16, 1); }
#else
  public ArraySegment<byte>? GetIconBytes() { return __p.__vector_as_arraysegment(16); }
#endif
  public byte[] GetIconArray() { return __p.__vector_as_array<byte>(16); }
  public string CampScene { get { int o = __p.__offset(18); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetCampSceneBytes() { return __p.__vector_as_span<byte>(18, 1); }
#else
  public ArraySegment<byte>? GetCampSceneBytes() { return __p.__vector_as_arraysegment(18); }
#endif
  public byte[] GetCampSceneArray() { return __p.__vector_as_array<byte>(18); }
  public string ResultIcon { get { int o = __p.__offset(20); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetResultIconBytes() { return __p.__vector_as_span<byte>(20, 1); }
#else
  public ArraySegment<byte>? GetResultIconBytes() { return __p.__vector_as_arraysegment(20); }
#endif
  public byte[] GetResultIconArray() { return __p.__vector_as_array<byte>(20); }
  public int Against { get { int o = __p.__offset(22); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string BigIcon { get { int o = __p.__offset(24); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetBigIconBytes() { return __p.__vector_as_span<byte>(24, 1); }
#else
  public ArraySegment<byte>? GetBigIconBytes() { return __p.__vector_as_arraysegment(24); }
#endif
  public byte[] GetBigIconArray() { return __p.__vector_as_array<byte>(24); }
  public string KindIcon4 { get { int o = __p.__offset(26); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetKindIcon4Bytes() { return __p.__vector_as_span<byte>(26, 1); }
#else
  public ArraySegment<byte>? GetKindIcon4Bytes() { return __p.__vector_as_arraysegment(26); }
#endif
  public byte[] GetKindIcon4Array() { return __p.__vector_as_array<byte>(26); }
  public string CampIcon { get { int o = __p.__offset(28); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetCampIconBytes() { return __p.__vector_as_span<byte>(28, 1); }
#else
  public ArraySegment<byte>? GetCampIconBytes() { return __p.__vector_as_arraysegment(28); }
#endif
  public byte[] GetCampIconArray() { return __p.__vector_as_array<byte>(28); }
  public string NormalIcon { get { int o = __p.__offset(30); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetNormalIconBytes() { return __p.__vector_as_span<byte>(30, 1); }
#else
  public ArraySegment<byte>? GetNormalIconBytes() { return __p.__vector_as_arraysegment(30); }
#endif
  public byte[] GetNormalIconArray() { return __p.__vector_as_array<byte>(30); }
  public string ListIcon { get { int o = __p.__offset(32); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetListIconBytes() { return __p.__vector_as_span<byte>(32, 1); }
#else
  public ArraySegment<byte>? GetListIconBytes() { return __p.__vector_as_arraysegment(32); }
#endif
  public byte[] GetListIconArray() { return __p.__vector_as_array<byte>(32); }
  public int Order { get { int o = __p.__offset(34); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string IconColor { get { int o = __p.__offset(36); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetIconColorBytes() { return __p.__vector_as_span<byte>(36, 1); }
#else
  public ArraySegment<byte>? GetIconColorBytes() { return __p.__vector_as_arraysegment(36); }
#endif
  public byte[] GetIconColorArray() { return __p.__vector_as_array<byte>(36); }
  public int RestraintDes { get { int o = __p.__offset(38); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string Effect(int j) { int o = __p.__offset(40); return o != 0 ? __p.__string(__p.__vector(o) + j * 4) : null; }
  public int EffectLength { get { int o = __p.__offset(40); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<LF.Table.DRheroes_camp> CreateDRheroes_camp(FlatBufferBuilder builder,
      int id = 0,
      StringOffset nameOffset = default(StringOffset),
      StringOffset desOffset = default(StringOffset),
      StringOffset kind_icon1Offset = default(StringOffset),
      StringOffset kind_icon2Offset = default(StringOffset),
      StringOffset kind_icon3Offset = default(StringOffset),
      StringOffset iconOffset = default(StringOffset),
      StringOffset camp_sceneOffset = default(StringOffset),
      StringOffset result_iconOffset = default(StringOffset),
      int against = 0,
      StringOffset big_iconOffset = default(StringOffset),
      StringOffset kind_icon4Offset = default(StringOffset),
      StringOffset camp_iconOffset = default(StringOffset),
      StringOffset normal_iconOffset = default(StringOffset),
      StringOffset list_iconOffset = default(StringOffset),
      int order = 0,
      StringOffset icon_colorOffset = default(StringOffset),
      int restraint_des = 0,
      VectorOffset effectOffset = default(VectorOffset)) {
    builder.StartTable(19);
    DRheroes_camp.AddEffect(builder, effectOffset);
    DRheroes_camp.AddRestraintDes(builder, restraint_des);
    DRheroes_camp.AddIconColor(builder, icon_colorOffset);
    DRheroes_camp.AddOrder(builder, order);
    DRheroes_camp.AddListIcon(builder, list_iconOffset);
    DRheroes_camp.AddNormalIcon(builder, normal_iconOffset);
    DRheroes_camp.AddCampIcon(builder, camp_iconOffset);
    DRheroes_camp.AddKindIcon4(builder, kind_icon4Offset);
    DRheroes_camp.AddBigIcon(builder, big_iconOffset);
    DRheroes_camp.AddAgainst(builder, against);
    DRheroes_camp.AddResultIcon(builder, result_iconOffset);
    DRheroes_camp.AddCampScene(builder, camp_sceneOffset);
    DRheroes_camp.AddIcon(builder, iconOffset);
    DRheroes_camp.AddKindIcon3(builder, kind_icon3Offset);
    DRheroes_camp.AddKindIcon2(builder, kind_icon2Offset);
    DRheroes_camp.AddKindIcon1(builder, kind_icon1Offset);
    DRheroes_camp.AddDes(builder, desOffset);
    DRheroes_camp.AddName(builder, nameOffset);
    DRheroes_camp.AddId(builder, id);
    return DRheroes_camp.EndDRheroes_camp(builder);
  }

  public static void StartDRheroes_camp(FlatBufferBuilder builder) { builder.StartTable(19); }
  public static void AddId(FlatBufferBuilder builder, int id) { builder.AddInt(0, id, 0); }
  public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset) { builder.AddOffset(1, nameOffset.Value, 0); }
  public static void AddDes(FlatBufferBuilder builder, StringOffset desOffset) { builder.AddOffset(2, desOffset.Value, 0); }
  public static void AddKindIcon1(FlatBufferBuilder builder, StringOffset kindIcon1Offset) { builder.AddOffset(3, kindIcon1Offset.Value, 0); }
  public static void AddKindIcon2(FlatBufferBuilder builder, StringOffset kindIcon2Offset) { builder.AddOffset(4, kindIcon2Offset.Value, 0); }
  public static void AddKindIcon3(FlatBufferBuilder builder, StringOffset kindIcon3Offset) { builder.AddOffset(5, kindIcon3Offset.Value, 0); }
  public static void AddIcon(FlatBufferBuilder builder, StringOffset iconOffset) { builder.AddOffset(6, iconOffset.Value, 0); }
  public static void AddCampScene(FlatBufferBuilder builder, StringOffset campSceneOffset) { builder.AddOffset(7, campSceneOffset.Value, 0); }
  public static void AddResultIcon(FlatBufferBuilder builder, StringOffset resultIconOffset) { builder.AddOffset(8, resultIconOffset.Value, 0); }
  public static void AddAgainst(FlatBufferBuilder builder, int against) { builder.AddInt(9, against, 0); }
  public static void AddBigIcon(FlatBufferBuilder builder, StringOffset bigIconOffset) { builder.AddOffset(10, bigIconOffset.Value, 0); }
  public static void AddKindIcon4(FlatBufferBuilder builder, StringOffset kindIcon4Offset) { builder.AddOffset(11, kindIcon4Offset.Value, 0); }
  public static void AddCampIcon(FlatBufferBuilder builder, StringOffset campIconOffset) { builder.AddOffset(12, campIconOffset.Value, 0); }
  public static void AddNormalIcon(FlatBufferBuilder builder, StringOffset normalIconOffset) { builder.AddOffset(13, normalIconOffset.Value, 0); }
  public static void AddListIcon(FlatBufferBuilder builder, StringOffset listIconOffset) { builder.AddOffset(14, listIconOffset.Value, 0); }
  public static void AddOrder(FlatBufferBuilder builder, int order) { builder.AddInt(15, order, 0); }
  public static void AddIconColor(FlatBufferBuilder builder, StringOffset iconColorOffset) { builder.AddOffset(16, iconColorOffset.Value, 0); }
  public static void AddRestraintDes(FlatBufferBuilder builder, int restraintDes) { builder.AddInt(17, restraintDes, 0); }
  public static void AddEffect(FlatBufferBuilder builder, VectorOffset effectOffset) { builder.AddOffset(18, effectOffset.Value, 0); }
  public static VectorOffset CreateEffectVector(FlatBufferBuilder builder, StringOffset[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateEffectVectorBlock(FlatBufferBuilder builder, StringOffset[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartEffectVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<LF.Table.DRheroes_camp> EndDRheroes_camp(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<LF.Table.DRheroes_camp>(o);
  }
};

public struct Table_heroes_camp : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static Table_heroes_camp GetRootAsTable_heroes_camp(ByteBuffer _bb) { return GetRootAsTable_heroes_camp(_bb, new Table_heroes_camp()); }
  public static Table_heroes_camp GetRootAsTable_heroes_camp(ByteBuffer _bb, Table_heroes_camp obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Table_heroes_camp __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public LF.Table.DRheroes_camp? Data(int j) { int o = __p.__offset(4); return o != 0 ? (LF.Table.DRheroes_camp?)(new LF.Table.DRheroes_camp()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DataLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<LF.Table.Table_heroes_camp> CreateTable_heroes_camp(FlatBufferBuilder builder,
      VectorOffset dataOffset = default(VectorOffset)) {
    builder.StartTable(1);
    Table_heroes_camp.AddData(builder, dataOffset);
    return Table_heroes_camp.EndTable_heroes_camp(builder);
  }

  public static void StartTable_heroes_camp(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddData(FlatBufferBuilder builder, VectorOffset dataOffset) { builder.AddOffset(0, dataOffset.Value, 0); }
  public static VectorOffset CreateDataVector(FlatBufferBuilder builder, Offset<LF.Table.DRheroes_camp>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDataVectorBlock(FlatBufferBuilder builder, Offset<LF.Table.DRheroes_camp>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartDataVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<LF.Table.Table_heroes_camp> EndTable_heroes_camp(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<LF.Table.Table_heroes_camp>(o);
  }
  public static void FinishTable_heroes_campBuffer(FlatBufferBuilder builder, Offset<LF.Table.Table_heroes_camp> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedTable_heroes_campBuffer(FlatBufferBuilder builder, Offset<LF.Table.Table_heroes_camp> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}
