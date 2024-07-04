// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace LF.Table
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DRprefab : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static DRprefab GetRootAsDRprefab(ByteBuffer _bb) { return GetRootAsDRprefab(_bb, new DRprefab()); }
  public static DRprefab GetRootAsDRprefab(ByteBuffer _bb, DRprefab obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DRprefab __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string Id { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetIdBytes() { return __p.__vector_as_span<byte>(4, 1); }
#else
  public ArraySegment<byte>? GetIdBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public byte[] GetIdArray() { return __p.__vector_as_array<byte>(4); }
  public string AssetName { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetAssetNameBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetAssetNameBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetAssetNameArray() { return __p.__vector_as_array<byte>(6); }
  public string DefaultPrefab { get { int o = __p.__offset(8); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetDefaultPrefabBytes() { return __p.__vector_as_span<byte>(8, 1); }
#else
  public ArraySegment<byte>? GetDefaultPrefabBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public byte[] GetDefaultPrefabArray() { return __p.__vector_as_array<byte>(8); }
  public string Prefabs(int j) { int o = __p.__offset(10); return o != 0 ? __p.__string(__p.__vector(o) + j * 4) : null; }
  public int PrefabsLength { get { int o = __p.__offset(10); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<LF.Table.DRprefab> CreateDRprefab(FlatBufferBuilder builder,
      StringOffset idOffset = default(StringOffset),
      StringOffset AssetNameOffset = default(StringOffset),
      StringOffset DefaultPrefabOffset = default(StringOffset),
      VectorOffset PrefabsOffset = default(VectorOffset)) {
    builder.StartTable(4);
    DRprefab.AddPrefabs(builder, PrefabsOffset);
    DRprefab.AddDefaultPrefab(builder, DefaultPrefabOffset);
    DRprefab.AddAssetName(builder, AssetNameOffset);
    DRprefab.AddId(builder, idOffset);
    return DRprefab.EndDRprefab(builder);
  }

  public static void StartDRprefab(FlatBufferBuilder builder) { builder.StartTable(4); }
  public static void AddId(FlatBufferBuilder builder, StringOffset idOffset) { builder.AddOffset(0, idOffset.Value, 0); }
  public static void AddAssetName(FlatBufferBuilder builder, StringOffset AssetNameOffset) { builder.AddOffset(1, AssetNameOffset.Value, 0); }
  public static void AddDefaultPrefab(FlatBufferBuilder builder, StringOffset DefaultPrefabOffset) { builder.AddOffset(2, DefaultPrefabOffset.Value, 0); }
  public static void AddPrefabs(FlatBufferBuilder builder, VectorOffset PrefabsOffset) { builder.AddOffset(3, PrefabsOffset.Value, 0); }
  public static VectorOffset CreatePrefabsVector(FlatBufferBuilder builder, StringOffset[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreatePrefabsVectorBlock(FlatBufferBuilder builder, StringOffset[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartPrefabsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<LF.Table.DRprefab> EndDRprefab(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<LF.Table.DRprefab>(o);
  }
};

public struct Table_prefab : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static Table_prefab GetRootAsTable_prefab(ByteBuffer _bb) { return GetRootAsTable_prefab(_bb, new Table_prefab()); }
  public static Table_prefab GetRootAsTable_prefab(ByteBuffer _bb, Table_prefab obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Table_prefab __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public LF.Table.DRprefab? Data(int j) { int o = __p.__offset(4); return o != 0 ? (LF.Table.DRprefab?)(new LF.Table.DRprefab()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DataLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<LF.Table.Table_prefab> CreateTable_prefab(FlatBufferBuilder builder,
      VectorOffset dataOffset = default(VectorOffset)) {
    builder.StartTable(1);
    Table_prefab.AddData(builder, dataOffset);
    return Table_prefab.EndTable_prefab(builder);
  }

  public static void StartTable_prefab(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddData(FlatBufferBuilder builder, VectorOffset dataOffset) { builder.AddOffset(0, dataOffset.Value, 0); }
  public static VectorOffset CreateDataVector(FlatBufferBuilder builder, Offset<LF.Table.DRprefab>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDataVectorBlock(FlatBufferBuilder builder, Offset<LF.Table.DRprefab>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartDataVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<LF.Table.Table_prefab> EndTable_prefab(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<LF.Table.Table_prefab>(o);
  }
  public static void FinishTable_prefabBuffer(FlatBufferBuilder builder, Offset<LF.Table.Table_prefab> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedTable_prefabBuffer(FlatBufferBuilder builder, Offset<LF.Table.Table_prefab> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}
