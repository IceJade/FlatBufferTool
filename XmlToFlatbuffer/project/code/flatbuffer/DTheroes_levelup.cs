// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace Chanto.Table
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DRheroes_levelup : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static DRheroes_levelup GetRootAsDRheroes_levelup(ByteBuffer _bb) { return GetRootAsDRheroes_levelup(_bb, new DRheroes_levelup()); }
  public static DRheroes_levelup GetRootAsDRheroes_levelup(ByteBuffer _bb, DRheroes_levelup obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DRheroes_levelup __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Exp { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Diamond { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }

  public static Offset<LF.Table.DRheroes_levelup> CreateDRheroes_levelup(FlatBufferBuilder builder,
      int id = 0,
      int exp = 0,
      int diamond = 0) {
    builder.StartTable(3);
    DRheroes_levelup.AddDiamond(builder, diamond);
    DRheroes_levelup.AddExp(builder, exp);
    DRheroes_levelup.AddId(builder, id);
    return DRheroes_levelup.EndDRheroes_levelup(builder);
  }

  public static void StartDRheroes_levelup(FlatBufferBuilder builder) { builder.StartTable(3); }
  public static void AddId(FlatBufferBuilder builder, int id) { builder.AddInt(0, id, 0); }
  public static void AddExp(FlatBufferBuilder builder, int exp) { builder.AddInt(1, exp, 0); }
  public static void AddDiamond(FlatBufferBuilder builder, int diamond) { builder.AddInt(2, diamond, 0); }
  public static Offset<LF.Table.DRheroes_levelup> EndDRheroes_levelup(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<LF.Table.DRheroes_levelup>(o);
  }
};

public struct Table_heroes_levelup : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static Table_heroes_levelup GetRootAsTable_heroes_levelup(ByteBuffer _bb) { return GetRootAsTable_heroes_levelup(_bb, new Table_heroes_levelup()); }
  public static Table_heroes_levelup GetRootAsTable_heroes_levelup(ByteBuffer _bb, Table_heroes_levelup obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Table_heroes_levelup __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public LF.Table.DRheroes_levelup? Data(int j) { int o = __p.__offset(4); return o != 0 ? (LF.Table.DRheroes_levelup?)(new LF.Table.DRheroes_levelup()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DataLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<LF.Table.Table_heroes_levelup> CreateTable_heroes_levelup(FlatBufferBuilder builder,
      VectorOffset dataOffset = default(VectorOffset)) {
    builder.StartTable(1);
    Table_heroes_levelup.AddData(builder, dataOffset);
    return Table_heroes_levelup.EndTable_heroes_levelup(builder);
  }

  public static void StartTable_heroes_levelup(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddData(FlatBufferBuilder builder, VectorOffset dataOffset) { builder.AddOffset(0, dataOffset.Value, 0); }
  public static VectorOffset CreateDataVector(FlatBufferBuilder builder, Offset<LF.Table.DRheroes_levelup>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDataVectorBlock(FlatBufferBuilder builder, Offset<LF.Table.DRheroes_levelup>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartDataVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<LF.Table.Table_heroes_levelup> EndTable_heroes_levelup(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<LF.Table.Table_heroes_levelup>(o);
  }
  public static void FinishTable_heroes_levelupBuffer(FlatBufferBuilder builder, Offset<LF.Table.Table_heroes_levelup> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedTable_heroes_levelupBuffer(FlatBufferBuilder builder, Offset<LF.Table.Table_heroes_levelup> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}
