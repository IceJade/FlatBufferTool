// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace LF.Table
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DRactivityCenter : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static DRactivityCenter GetRootAsDRactivityCenter(ByteBuffer _bb) { return GetRootAsDRactivityCenter(_bb, new DRactivityCenter()); }
  public static DRactivityCenter GetRootAsDRactivityCenter(ByteBuffer _bb, DRactivityCenter obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DRactivityCenter __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Type { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int SubActivityType { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string LuaPath { get { int o = __p.__offset(10); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetLuaPathBytes() { return __p.__vector_as_span<byte>(10, 1); }
#else
  public ArraySegment<byte>? GetLuaPathBytes() { return __p.__vector_as_arraysegment(10); }
#endif
  public byte[] GetLuaPathArray() { return __p.__vector_as_array<byte>(10); }
  public string ResUrl { get { int o = __p.__offset(12); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetResUrlBytes() { return __p.__vector_as_span<byte>(12, 1); }
#else
  public ArraySegment<byte>? GetResUrlBytes() { return __p.__vector_as_arraysegment(12); }
#endif
  public byte[] GetResUrlArray() { return __p.__vector_as_array<byte>(12); }

  public static Offset<LF.Table.DRactivityCenter> CreateDRactivityCenter(FlatBufferBuilder builder,
      int id = 0,
      int type = 0,
      int subActivityType = 0,
      StringOffset luaPathOffset = default(StringOffset),
      StringOffset resUrlOffset = default(StringOffset)) {
    builder.StartTable(5);
    DRactivityCenter.AddResUrl(builder, resUrlOffset);
    DRactivityCenter.AddLuaPath(builder, luaPathOffset);
    DRactivityCenter.AddSubActivityType(builder, subActivityType);
    DRactivityCenter.AddType(builder, type);
    DRactivityCenter.AddId(builder, id);
    return DRactivityCenter.EndDRactivityCenter(builder);
  }

  public static void StartDRactivityCenter(FlatBufferBuilder builder) { builder.StartTable(5); }
  public static void AddId(FlatBufferBuilder builder, int id) { builder.AddInt(0, id, 0); }
  public static void AddType(FlatBufferBuilder builder, int type) { builder.AddInt(1, type, 0); }
  public static void AddSubActivityType(FlatBufferBuilder builder, int subActivityType) { builder.AddInt(2, subActivityType, 0); }
  public static void AddLuaPath(FlatBufferBuilder builder, StringOffset luaPathOffset) { builder.AddOffset(3, luaPathOffset.Value, 0); }
  public static void AddResUrl(FlatBufferBuilder builder, StringOffset resUrlOffset) { builder.AddOffset(4, resUrlOffset.Value, 0); }
  public static Offset<LF.Table.DRactivityCenter> EndDRactivityCenter(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<LF.Table.DRactivityCenter>(o);
  }
};

public struct Table_activityCenter : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static Table_activityCenter GetRootAsTable_activityCenter(ByteBuffer _bb) { return GetRootAsTable_activityCenter(_bb, new Table_activityCenter()); }
  public static Table_activityCenter GetRootAsTable_activityCenter(ByteBuffer _bb, Table_activityCenter obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Table_activityCenter __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public LF.Table.DRactivityCenter? Data(int j) { int o = __p.__offset(4); return o != 0 ? (LF.Table.DRactivityCenter?)(new LF.Table.DRactivityCenter()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DataLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<LF.Table.Table_activityCenter> CreateTable_activityCenter(FlatBufferBuilder builder,
      VectorOffset dataOffset = default(VectorOffset)) {
    builder.StartTable(1);
    Table_activityCenter.AddData(builder, dataOffset);
    return Table_activityCenter.EndTable_activityCenter(builder);
  }

  public static void StartTable_activityCenter(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddData(FlatBufferBuilder builder, VectorOffset dataOffset) { builder.AddOffset(0, dataOffset.Value, 0); }
  public static VectorOffset CreateDataVector(FlatBufferBuilder builder, Offset<LF.Table.DRactivityCenter>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDataVectorBlock(FlatBufferBuilder builder, Offset<LF.Table.DRactivityCenter>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartDataVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<LF.Table.Table_activityCenter> EndTable_activityCenter(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<LF.Table.Table_activityCenter>(o);
  }
  public static void FinishTable_activityCenterBuffer(FlatBufferBuilder builder, Offset<LF.Table.Table_activityCenter> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedTable_activityCenterBuffer(FlatBufferBuilder builder, Offset<LF.Table.Table_activityCenter> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}
