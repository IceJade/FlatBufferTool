// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace LF.Table
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DRui : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static DRui GetRootAsDRui(ByteBuffer _bb) { return GetRootAsDRui(_bb, new DRui()); }
  public static DRui GetRootAsDRui(ByteBuffer _bb, DRui obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DRui __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

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
  public string UIGroupName { get { int o = __p.__offset(8); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetUIGroupNameBytes() { return __p.__vector_as_span<byte>(8, 1); }
#else
  public ArraySegment<byte>? GetUIGroupNameBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public byte[] GetUIGroupNameArray() { return __p.__vector_as_array<byte>(8); }
  public int Priority { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public bool IsPauseCoveredUI { get { int o = __p.__offset(12); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }
  public bool IsMultipleInstance { get { int o = __p.__offset(14); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }
  public bool IsLocked { get { int o = __p.__offset(16); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }
  public bool IsRefreshOnReopenning { get { int o = __p.__offset(18); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }
  public bool IsFullScreen { get { int o = __p.__offset(20); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }
  public bool IsCaptureSceneScreenshot { get { int o = __p.__offset(22); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }

  public static Offset<LF.Table.DRui> CreateDRui(FlatBufferBuilder builder,
      StringOffset idOffset = default(StringOffset),
      StringOffset AssetNameOffset = default(StringOffset),
      StringOffset UIGroupNameOffset = default(StringOffset),
      int Priority = 0,
      bool IsPauseCoveredUI = false,
      bool IsMultipleInstance = false,
      bool IsLocked = false,
      bool IsRefreshOnReopenning = false,
      bool IsFullScreen = false,
      bool IsCaptureSceneScreenshot = false) {
    builder.StartTable(10);
    DRui.AddPriority(builder, Priority);
    DRui.AddUIGroupName(builder, UIGroupNameOffset);
    DRui.AddAssetName(builder, AssetNameOffset);
    DRui.AddId(builder, idOffset);
    DRui.AddIsCaptureSceneScreenshot(builder, IsCaptureSceneScreenshot);
    DRui.AddIsFullScreen(builder, IsFullScreen);
    DRui.AddIsRefreshOnReopenning(builder, IsRefreshOnReopenning);
    DRui.AddIsLocked(builder, IsLocked);
    DRui.AddIsMultipleInstance(builder, IsMultipleInstance);
    DRui.AddIsPauseCoveredUI(builder, IsPauseCoveredUI);
    return DRui.EndDRui(builder);
  }

  public static void StartDRui(FlatBufferBuilder builder) { builder.StartTable(10); }
  public static void AddId(FlatBufferBuilder builder, StringOffset idOffset) { builder.AddOffset(0, idOffset.Value, 0); }
  public static void AddAssetName(FlatBufferBuilder builder, StringOffset AssetNameOffset) { builder.AddOffset(1, AssetNameOffset.Value, 0); }
  public static void AddUIGroupName(FlatBufferBuilder builder, StringOffset UIGroupNameOffset) { builder.AddOffset(2, UIGroupNameOffset.Value, 0); }
  public static void AddPriority(FlatBufferBuilder builder, int Priority) { builder.AddInt(3, Priority, 0); }
  public static void AddIsPauseCoveredUI(FlatBufferBuilder builder, bool IsPauseCoveredUI) { builder.AddBool(4, IsPauseCoveredUI, false); }
  public static void AddIsMultipleInstance(FlatBufferBuilder builder, bool IsMultipleInstance) { builder.AddBool(5, IsMultipleInstance, false); }
  public static void AddIsLocked(FlatBufferBuilder builder, bool IsLocked) { builder.AddBool(6, IsLocked, false); }
  public static void AddIsRefreshOnReopenning(FlatBufferBuilder builder, bool IsRefreshOnReopenning) { builder.AddBool(7, IsRefreshOnReopenning, false); }
  public static void AddIsFullScreen(FlatBufferBuilder builder, bool IsFullScreen) { builder.AddBool(8, IsFullScreen, false); }
  public static void AddIsCaptureSceneScreenshot(FlatBufferBuilder builder, bool IsCaptureSceneScreenshot) { builder.AddBool(9, IsCaptureSceneScreenshot, false); }
  public static Offset<LF.Table.DRui> EndDRui(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<LF.Table.DRui>(o);
  }
};

public struct Table_ui : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static Table_ui GetRootAsTable_ui(ByteBuffer _bb) { return GetRootAsTable_ui(_bb, new Table_ui()); }
  public static Table_ui GetRootAsTable_ui(ByteBuffer _bb, Table_ui obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Table_ui __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public LF.Table.DRui? Data(int j) { int o = __p.__offset(4); return o != 0 ? (LF.Table.DRui?)(new LF.Table.DRui()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DataLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<LF.Table.Table_ui> CreateTable_ui(FlatBufferBuilder builder,
      VectorOffset dataOffset = default(VectorOffset)) {
    builder.StartTable(1);
    Table_ui.AddData(builder, dataOffset);
    return Table_ui.EndTable_ui(builder);
  }

  public static void StartTable_ui(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddData(FlatBufferBuilder builder, VectorOffset dataOffset) { builder.AddOffset(0, dataOffset.Value, 0); }
  public static VectorOffset CreateDataVector(FlatBufferBuilder builder, Offset<LF.Table.DRui>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDataVectorBlock(FlatBufferBuilder builder, Offset<LF.Table.DRui>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartDataVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<LF.Table.Table_ui> EndTable_ui(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<LF.Table.Table_ui>(o);
  }
  public static void FinishTable_uiBuffer(FlatBufferBuilder builder, Offset<LF.Table.Table_ui> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedTable_uiBuffer(FlatBufferBuilder builder, Offset<LF.Table.Table_ui> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}
