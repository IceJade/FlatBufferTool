// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace LF.Table
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DRpve : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static DRpve GetRootAsDRpve(ByteBuffer _bb) { return GetRootAsDRpve(_bb, new DRpve()); }
  public static DRpve GetRootAsDRpve(ByteBuffer _bb, DRpve obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DRpve __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Area { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Level { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int RewardShow(int j) { int o = __p.__offset(10); return o != 0 ? __p.bb.GetInt(__p.__vector(o) + j * 4) : (int)0; }
  public int RewardShowLength { get { int o = __p.__offset(10); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<int> GetRewardShowBytes() { return __p.__vector_as_span<int>(10, 4); }
#else
  public ArraySegment<byte>? GetRewardShowBytes() { return __p.__vector_as_arraysegment(10); }
#endif
  public int[] GetRewardShowArray() { return __p.__vector_as_array<int>(10); }
  public string BattleGround { get { int o = __p.__offset(12); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetBattleGroundBytes() { return __p.__vector_as_span<byte>(12, 1); }
#else
  public ArraySegment<byte>? GetBattleGroundBytes() { return __p.__vector_as_arraysegment(12); }
#endif
  public byte[] GetBattleGroundArray() { return __p.__vector_as_array<byte>(12); }
  public int ArmyShow { get { int o = __p.__offset(14); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int RoutePointId { get { int o = __p.__offset(16); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int ExploreMax { get { int o = __p.__offset(18); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }

  public static Offset<LF.Table.DRpve> CreateDRpve(FlatBufferBuilder builder,
      int id = 0,
      int area = 0,
      int level = 0,
      VectorOffset reward_showOffset = default(VectorOffset),
      StringOffset battle_groundOffset = default(StringOffset),
      int army_show = 0,
      int route_point_id = 0,
      int explore_max = 0) {
    builder.StartTable(8);
    DRpve.AddExploreMax(builder, explore_max);
    DRpve.AddRoutePointId(builder, route_point_id);
    DRpve.AddArmyShow(builder, army_show);
    DRpve.AddBattleGround(builder, battle_groundOffset);
    DRpve.AddRewardShow(builder, reward_showOffset);
    DRpve.AddLevel(builder, level);
    DRpve.AddArea(builder, area);
    DRpve.AddId(builder, id);
    return DRpve.EndDRpve(builder);
  }

  public static void StartDRpve(FlatBufferBuilder builder) { builder.StartTable(8); }
  public static void AddId(FlatBufferBuilder builder, int id) { builder.AddInt(0, id, 0); }
  public static void AddArea(FlatBufferBuilder builder, int area) { builder.AddInt(1, area, 0); }
  public static void AddLevel(FlatBufferBuilder builder, int level) { builder.AddInt(2, level, 0); }
  public static void AddRewardShow(FlatBufferBuilder builder, VectorOffset rewardShowOffset) { builder.AddOffset(3, rewardShowOffset.Value, 0); }
  public static VectorOffset CreateRewardShowVector(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddInt(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateRewardShowVectorBlock(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartRewardShowVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddBattleGround(FlatBufferBuilder builder, StringOffset battleGroundOffset) { builder.AddOffset(4, battleGroundOffset.Value, 0); }
  public static void AddArmyShow(FlatBufferBuilder builder, int armyShow) { builder.AddInt(5, armyShow, 0); }
  public static void AddRoutePointId(FlatBufferBuilder builder, int routePointId) { builder.AddInt(6, routePointId, 0); }
  public static void AddExploreMax(FlatBufferBuilder builder, int exploreMax) { builder.AddInt(7, exploreMax, 0); }
  public static Offset<LF.Table.DRpve> EndDRpve(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<LF.Table.DRpve>(o);
  }
};

public struct Table_pve : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static Table_pve GetRootAsTable_pve(ByteBuffer _bb) { return GetRootAsTable_pve(_bb, new Table_pve()); }
  public static Table_pve GetRootAsTable_pve(ByteBuffer _bb, Table_pve obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Table_pve __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public LF.Table.DRpve? Data(int j) { int o = __p.__offset(4); return o != 0 ? (LF.Table.DRpve?)(new LF.Table.DRpve()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DataLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<LF.Table.Table_pve> CreateTable_pve(FlatBufferBuilder builder,
      VectorOffset dataOffset = default(VectorOffset)) {
    builder.StartTable(1);
    Table_pve.AddData(builder, dataOffset);
    return Table_pve.EndTable_pve(builder);
  }

  public static void StartTable_pve(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddData(FlatBufferBuilder builder, VectorOffset dataOffset) { builder.AddOffset(0, dataOffset.Value, 0); }
  public static VectorOffset CreateDataVector(FlatBufferBuilder builder, Offset<LF.Table.DRpve>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDataVectorBlock(FlatBufferBuilder builder, Offset<LF.Table.DRpve>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartDataVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<LF.Table.Table_pve> EndTable_pve(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<LF.Table.Table_pve>(o);
  }
  public static void FinishTable_pveBuffer(FlatBufferBuilder builder, Offset<LF.Table.Table_pve> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedTable_pveBuffer(FlatBufferBuilder builder, Offset<LF.Table.Table_pve> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}