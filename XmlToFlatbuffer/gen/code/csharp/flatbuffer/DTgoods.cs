// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace LF.Table
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DRgoods : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static DRgoods GetRootAsDRgoods(ByteBuffer _bb) { return GetRootAsDRgoods(_bb, new DRgoods()); }
  public static DRgoods GetRootAsDRgoods(ByteBuffer _bb, DRgoods obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DRgoods __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string Name { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetNameBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetNameBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetNameArray() { return __p.__vector_as_array<byte>(6); }
  public string Description { get { int o = __p.__offset(8); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetDescriptionBytes() { return __p.__vector_as_span<byte>(8, 1); }
#else
  public ArraySegment<byte>? GetDescriptionBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public byte[] GetDescriptionArray() { return __p.__vector_as_array<byte>(8); }
  public string Icon { get { int o = __p.__offset(10); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetIconBytes() { return __p.__vector_as_span<byte>(10, 1); }
#else
  public ArraySegment<byte>? GetIconBytes() { return __p.__vector_as_arraysegment(10); }
#endif
  public byte[] GetIconArray() { return __p.__vector_as_array<byte>(10); }
  public int Type { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Color { get { int o = __p.__offset(14); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Lv { get { int o = __p.__offset(16); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int LvLimit { get { int o = __p.__offset(18); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Page { get { int o = __p.__offset(20); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Pages { get { int o = __p.__offset(22); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int PackTabType { get { int o = __p.__offset(24); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Use { get { int o = __p.__offset(26); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int OrderNum { get { int o = __p.__offset(28); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int StoreOrder { get { int o = __p.__offset(30); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Price { get { int o = __p.__offset(32); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int PriceHot { get { int o = __p.__offset(34); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int IsGift { get { int o = __p.__offset(36); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string Sales(int j) { int o = __p.__offset(38); return o != 0 ? __p.__string(__p.__vector(o) + j * 4) : null; }
  public int SalesLength { get { int o = __p.__offset(38); return o != 0 ? __p.__vector_len(o) : 0; } }
  public int AllianceOrder { get { int o = __p.__offset(40); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int PriceAll { get { int o = __p.__offset(42); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Type2 { get { int o = __p.__offset(44); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Useall { get { int o = __p.__offset(46); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string Para1 { get { int o = __p.__offset(48); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetPara1Bytes() { return __p.__vector_as_span<byte>(48, 1); }
#else
  public ArraySegment<byte>? GetPara1Bytes() { return __p.__vector_as_arraysegment(48); }
#endif
  public byte[] GetPara1Array() { return __p.__vector_as_array<byte>(48); }
  public string NameValue(int j) { int o = __p.__offset(50); return o != 0 ? __p.__string(__p.__vector(o) + j * 4) : null; }
  public int NameValueLength { get { int o = __p.__offset(50); return o != 0 ? __p.__vector_len(o) : 0; } }
  public string Para { get { int o = __p.__offset(52); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetParaBytes() { return __p.__vector_as_span<byte>(52, 1); }
#else
  public ArraySegment<byte>? GetParaBytes() { return __p.__vector_as_arraysegment(52); }
#endif
  public byte[] GetParaArray() { return __p.__vector_as_array<byte>(52); }
  public string Para3 { get { int o = __p.__offset(54); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetPara3Bytes() { return __p.__vector_as_span<byte>(54, 1); }
#else
  public ArraySegment<byte>? GetPara3Bytes() { return __p.__vector_as_arraysegment(54); }
#endif
  public byte[] GetPara3Array() { return __p.__vector_as_array<byte>(54); }
  public int Pagehot { get { int o = __p.__offset(56); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int SaveLoc { get { int o = __p.__offset(58); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int GroupNum { get { int o = __p.__offset(60); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Weight { get { int o = __p.__offset(62); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int DesPara { get { int o = __p.__offset(64); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int IsShow { get { int o = __p.__offset(66); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string Para2 { get { int o = __p.__offset(68); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetPara2Bytes() { return __p.__vector_as_span<byte>(68, 1); }
#else
  public ArraySegment<byte>? GetPara2Bytes() { return __p.__vector_as_arraysegment(68); }
#endif
  public byte[] GetPara2Array() { return __p.__vector_as_array<byte>(68); }
  public string IconLoc(int j) { int o = __p.__offset(70); return o != 0 ? __p.__string(__p.__vector(o) + j * 4) : null; }
  public int IconLocLength { get { int o = __p.__offset(70); return o != 0 ? __p.__vector_len(o) : 0; } }
  public string Para4 { get { int o = __p.__offset(72); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetPara4Bytes() { return __p.__vector_as_span<byte>(72, 1); }
#else
  public ArraySegment<byte>? GetPara4Bytes() { return __p.__vector_as_arraysegment(72); }
#endif
  public byte[] GetPara4Array() { return __p.__vector_as_array<byte>(72); }
  public int Heroid { get { int o = __p.__offset(74); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int DenyBuy { get { int o = __p.__offset(76); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int AutoOpen { get { int o = __p.__offset(78); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int GoTo(int j) { int o = __p.__offset(80); return o != 0 ? __p.bb.GetInt(__p.__vector(o) + j * 4) : (int)0; }
  public int GoToLength { get { int o = __p.__offset(80); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<int> GetGoToBytes() { return __p.__vector_as_span<int>(80, 4); }
#else
  public ArraySegment<byte>? GetGoToBytes() { return __p.__vector_as_arraysegment(80); }
#endif
  public int[] GetGoToArray() { return __p.__vector_as_array<int>(80); }
  public string Para5 { get { int o = __p.__offset(82); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetPara5Bytes() { return __p.__vector_as_span<byte>(82, 1); }
#else
  public ArraySegment<byte>? GetPara5Bytes() { return __p.__vector_as_arraysegment(82); }
#endif
  public byte[] GetPara5Array() { return __p.__vector_as_array<byte>(82); }
  public int NotGift { get { int o = __p.__offset(84); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int OpenEffect { get { int o = __p.__offset(86); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int AllianceLvLimit { get { int o = __p.__offset(88); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string Rate(int j) { int o = __p.__offset(90); return o != 0 ? __p.__string(__p.__vector(o) + j * 4) : null; }
  public int RateLength { get { int o = __p.__offset(90); return o != 0 ? __p.__vector_len(o) : 0; } }
  public int RecycleGoods(int j) { int o = __p.__offset(92); return o != 0 ? __p.bb.GetInt(__p.__vector(o) + j * 4) : (int)0; }
  public int RecycleGoodsLength { get { int o = __p.__offset(92); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<int> GetRecycleGoodsBytes() { return __p.__vector_as_span<int>(92, 4); }
#else
  public ArraySegment<byte>? GetRecycleGoodsBytes() { return __p.__vector_as_arraysegment(92); }
#endif
  public int[] GetRecycleGoodsArray() { return __p.__vector_as_array<int>(92); }
  public int BuyTimesLimit { get { int o = __p.__offset(94); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Usemax { get { int o = __p.__offset(96); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int UseCondition { get { int o = __p.__offset(98); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Bauxite { get { int o = __p.__offset(100); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int RecyclingAllianceScore { get { int o = __p.__offset(102); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int IsSend { get { int o = __p.__offset(104); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }

  public static Offset<LF.Table.DRgoods> CreateDRgoods(FlatBufferBuilder builder,
      int id = 0,
      StringOffset nameOffset = default(StringOffset),
      StringOffset descriptionOffset = default(StringOffset),
      StringOffset iconOffset = default(StringOffset),
      int type = 0,
      int color = 0,
      int lv = 0,
      int lv_limit = 0,
      int page = 0,
      int pages = 0,
      int pack_tab_type = 0,
      int use = 0,
      int order_num = 0,
      int store_order = 0,
      int price = 0,
      int price_hot = 0,
      int is_gift = 0,
      VectorOffset salesOffset = default(VectorOffset),
      int alliance_order = 0,
      int price_all = 0,
      int type2 = 0,
      int useall = 0,
      StringOffset para1Offset = default(StringOffset),
      VectorOffset name_valueOffset = default(VectorOffset),
      StringOffset paraOffset = default(StringOffset),
      StringOffset para3Offset = default(StringOffset),
      int pagehot = 0,
      int save_loc = 0,
      int group_num = 0,
      int weight = 0,
      int des_para = 0,
      int is_show = 0,
      StringOffset para2Offset = default(StringOffset),
      VectorOffset icon_locOffset = default(VectorOffset),
      StringOffset para4Offset = default(StringOffset),
      int heroid = 0,
      int denyBuy = 0,
      int auto_open = 0,
      VectorOffset go_toOffset = default(VectorOffset),
      StringOffset para5Offset = default(StringOffset),
      int not_gift = 0,
      int open_effect = 0,
      int alliance_lv_limit = 0,
      VectorOffset rateOffset = default(VectorOffset),
      VectorOffset recycleGoodsOffset = default(VectorOffset),
      int buy_times_limit = 0,
      int usemax = 0,
      int use_condition = 0,
      int bauxite = 0,
      int recycling_alliance_score = 0,
      int is_send = 0) {
    builder.StartTable(51);
    DRgoods.AddIsSend(builder, is_send);
    DRgoods.AddRecyclingAllianceScore(builder, recycling_alliance_score);
    DRgoods.AddBauxite(builder, bauxite);
    DRgoods.AddUseCondition(builder, use_condition);
    DRgoods.AddUsemax(builder, usemax);
    DRgoods.AddBuyTimesLimit(builder, buy_times_limit);
    DRgoods.AddRecycleGoods(builder, recycleGoodsOffset);
    DRgoods.AddRate(builder, rateOffset);
    DRgoods.AddAllianceLvLimit(builder, alliance_lv_limit);
    DRgoods.AddOpenEffect(builder, open_effect);
    DRgoods.AddNotGift(builder, not_gift);
    DRgoods.AddPara5(builder, para5Offset);
    DRgoods.AddGoTo(builder, go_toOffset);
    DRgoods.AddAutoOpen(builder, auto_open);
    DRgoods.AddDenyBuy(builder, denyBuy);
    DRgoods.AddHeroid(builder, heroid);
    DRgoods.AddPara4(builder, para4Offset);
    DRgoods.AddIconLoc(builder, icon_locOffset);
    DRgoods.AddPara2(builder, para2Offset);
    DRgoods.AddIsShow(builder, is_show);
    DRgoods.AddDesPara(builder, des_para);
    DRgoods.AddWeight(builder, weight);
    DRgoods.AddGroupNum(builder, group_num);
    DRgoods.AddSaveLoc(builder, save_loc);
    DRgoods.AddPagehot(builder, pagehot);
    DRgoods.AddPara3(builder, para3Offset);
    DRgoods.AddPara(builder, paraOffset);
    DRgoods.AddNameValue(builder, name_valueOffset);
    DRgoods.AddPara1(builder, para1Offset);
    DRgoods.AddUseall(builder, useall);
    DRgoods.AddType2(builder, type2);
    DRgoods.AddPriceAll(builder, price_all);
    DRgoods.AddAllianceOrder(builder, alliance_order);
    DRgoods.AddSales(builder, salesOffset);
    DRgoods.AddIsGift(builder, is_gift);
    DRgoods.AddPriceHot(builder, price_hot);
    DRgoods.AddPrice(builder, price);
    DRgoods.AddStoreOrder(builder, store_order);
    DRgoods.AddOrderNum(builder, order_num);
    DRgoods.AddUse(builder, use);
    DRgoods.AddPackTabType(builder, pack_tab_type);
    DRgoods.AddPages(builder, pages);
    DRgoods.AddPage(builder, page);
    DRgoods.AddLvLimit(builder, lv_limit);
    DRgoods.AddLv(builder, lv);
    DRgoods.AddColor(builder, color);
    DRgoods.AddType(builder, type);
    DRgoods.AddIcon(builder, iconOffset);
    DRgoods.AddDescription(builder, descriptionOffset);
    DRgoods.AddName(builder, nameOffset);
    DRgoods.AddId(builder, id);
    return DRgoods.EndDRgoods(builder);
  }

  public static void StartDRgoods(FlatBufferBuilder builder) { builder.StartTable(51); }
  public static void AddId(FlatBufferBuilder builder, int id) { builder.AddInt(0, id, 0); }
  public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset) { builder.AddOffset(1, nameOffset.Value, 0); }
  public static void AddDescription(FlatBufferBuilder builder, StringOffset descriptionOffset) { builder.AddOffset(2, descriptionOffset.Value, 0); }
  public static void AddIcon(FlatBufferBuilder builder, StringOffset iconOffset) { builder.AddOffset(3, iconOffset.Value, 0); }
  public static void AddType(FlatBufferBuilder builder, int type) { builder.AddInt(4, type, 0); }
  public static void AddColor(FlatBufferBuilder builder, int color) { builder.AddInt(5, color, 0); }
  public static void AddLv(FlatBufferBuilder builder, int lv) { builder.AddInt(6, lv, 0); }
  public static void AddLvLimit(FlatBufferBuilder builder, int lvLimit) { builder.AddInt(7, lvLimit, 0); }
  public static void AddPage(FlatBufferBuilder builder, int page) { builder.AddInt(8, page, 0); }
  public static void AddPages(FlatBufferBuilder builder, int pages) { builder.AddInt(9, pages, 0); }
  public static void AddPackTabType(FlatBufferBuilder builder, int packTabType) { builder.AddInt(10, packTabType, 0); }
  public static void AddUse(FlatBufferBuilder builder, int use) { builder.AddInt(11, use, 0); }
  public static void AddOrderNum(FlatBufferBuilder builder, int orderNum) { builder.AddInt(12, orderNum, 0); }
  public static void AddStoreOrder(FlatBufferBuilder builder, int storeOrder) { builder.AddInt(13, storeOrder, 0); }
  public static void AddPrice(FlatBufferBuilder builder, int price) { builder.AddInt(14, price, 0); }
  public static void AddPriceHot(FlatBufferBuilder builder, int priceHot) { builder.AddInt(15, priceHot, 0); }
  public static void AddIsGift(FlatBufferBuilder builder, int isGift) { builder.AddInt(16, isGift, 0); }
  public static void AddSales(FlatBufferBuilder builder, VectorOffset salesOffset) { builder.AddOffset(17, salesOffset.Value, 0); }
  public static VectorOffset CreateSalesVector(FlatBufferBuilder builder, StringOffset[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateSalesVectorBlock(FlatBufferBuilder builder, StringOffset[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartSalesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddAllianceOrder(FlatBufferBuilder builder, int allianceOrder) { builder.AddInt(18, allianceOrder, 0); }
  public static void AddPriceAll(FlatBufferBuilder builder, int priceAll) { builder.AddInt(19, priceAll, 0); }
  public static void AddType2(FlatBufferBuilder builder, int type2) { builder.AddInt(20, type2, 0); }
  public static void AddUseall(FlatBufferBuilder builder, int useall) { builder.AddInt(21, useall, 0); }
  public static void AddPara1(FlatBufferBuilder builder, StringOffset para1Offset) { builder.AddOffset(22, para1Offset.Value, 0); }
  public static void AddNameValue(FlatBufferBuilder builder, VectorOffset nameValueOffset) { builder.AddOffset(23, nameValueOffset.Value, 0); }
  public static VectorOffset CreateNameValueVector(FlatBufferBuilder builder, StringOffset[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateNameValueVectorBlock(FlatBufferBuilder builder, StringOffset[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartNameValueVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddPara(FlatBufferBuilder builder, StringOffset paraOffset) { builder.AddOffset(24, paraOffset.Value, 0); }
  public static void AddPara3(FlatBufferBuilder builder, StringOffset para3Offset) { builder.AddOffset(25, para3Offset.Value, 0); }
  public static void AddPagehot(FlatBufferBuilder builder, int pagehot) { builder.AddInt(26, pagehot, 0); }
  public static void AddSaveLoc(FlatBufferBuilder builder, int saveLoc) { builder.AddInt(27, saveLoc, 0); }
  public static void AddGroupNum(FlatBufferBuilder builder, int groupNum) { builder.AddInt(28, groupNum, 0); }
  public static void AddWeight(FlatBufferBuilder builder, int weight) { builder.AddInt(29, weight, 0); }
  public static void AddDesPara(FlatBufferBuilder builder, int desPara) { builder.AddInt(30, desPara, 0); }
  public static void AddIsShow(FlatBufferBuilder builder, int isShow) { builder.AddInt(31, isShow, 0); }
  public static void AddPara2(FlatBufferBuilder builder, StringOffset para2Offset) { builder.AddOffset(32, para2Offset.Value, 0); }
  public static void AddIconLoc(FlatBufferBuilder builder, VectorOffset iconLocOffset) { builder.AddOffset(33, iconLocOffset.Value, 0); }
  public static VectorOffset CreateIconLocVector(FlatBufferBuilder builder, StringOffset[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateIconLocVectorBlock(FlatBufferBuilder builder, StringOffset[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartIconLocVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddPara4(FlatBufferBuilder builder, StringOffset para4Offset) { builder.AddOffset(34, para4Offset.Value, 0); }
  public static void AddHeroid(FlatBufferBuilder builder, int heroid) { builder.AddInt(35, heroid, 0); }
  public static void AddDenyBuy(FlatBufferBuilder builder, int denyBuy) { builder.AddInt(36, denyBuy, 0); }
  public static void AddAutoOpen(FlatBufferBuilder builder, int autoOpen) { builder.AddInt(37, autoOpen, 0); }
  public static void AddGoTo(FlatBufferBuilder builder, VectorOffset goToOffset) { builder.AddOffset(38, goToOffset.Value, 0); }
  public static VectorOffset CreateGoToVector(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddInt(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateGoToVectorBlock(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartGoToVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddPara5(FlatBufferBuilder builder, StringOffset para5Offset) { builder.AddOffset(39, para5Offset.Value, 0); }
  public static void AddNotGift(FlatBufferBuilder builder, int notGift) { builder.AddInt(40, notGift, 0); }
  public static void AddOpenEffect(FlatBufferBuilder builder, int openEffect) { builder.AddInt(41, openEffect, 0); }
  public static void AddAllianceLvLimit(FlatBufferBuilder builder, int allianceLvLimit) { builder.AddInt(42, allianceLvLimit, 0); }
  public static void AddRate(FlatBufferBuilder builder, VectorOffset rateOffset) { builder.AddOffset(43, rateOffset.Value, 0); }
  public static VectorOffset CreateRateVector(FlatBufferBuilder builder, StringOffset[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateRateVectorBlock(FlatBufferBuilder builder, StringOffset[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartRateVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddRecycleGoods(FlatBufferBuilder builder, VectorOffset recycleGoodsOffset) { builder.AddOffset(44, recycleGoodsOffset.Value, 0); }
  public static VectorOffset CreateRecycleGoodsVector(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddInt(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateRecycleGoodsVectorBlock(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartRecycleGoodsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddBuyTimesLimit(FlatBufferBuilder builder, int buyTimesLimit) { builder.AddInt(45, buyTimesLimit, 0); }
  public static void AddUsemax(FlatBufferBuilder builder, int usemax) { builder.AddInt(46, usemax, 0); }
  public static void AddUseCondition(FlatBufferBuilder builder, int useCondition) { builder.AddInt(47, useCondition, 0); }
  public static void AddBauxite(FlatBufferBuilder builder, int bauxite) { builder.AddInt(48, bauxite, 0); }
  public static void AddRecyclingAllianceScore(FlatBufferBuilder builder, int recyclingAllianceScore) { builder.AddInt(49, recyclingAllianceScore, 0); }
  public static void AddIsSend(FlatBufferBuilder builder, int isSend) { builder.AddInt(50, isSend, 0); }
  public static Offset<LF.Table.DRgoods> EndDRgoods(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<LF.Table.DRgoods>(o);
  }
};

public struct Table_goods : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static Table_goods GetRootAsTable_goods(ByteBuffer _bb) { return GetRootAsTable_goods(_bb, new Table_goods()); }
  public static Table_goods GetRootAsTable_goods(ByteBuffer _bb, Table_goods obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Table_goods __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public LF.Table.DRgoods? Data(int j) { int o = __p.__offset(4); return o != 0 ? (LF.Table.DRgoods?)(new LF.Table.DRgoods()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DataLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<LF.Table.Table_goods> CreateTable_goods(FlatBufferBuilder builder,
      VectorOffset dataOffset = default(VectorOffset)) {
    builder.StartTable(1);
    Table_goods.AddData(builder, dataOffset);
    return Table_goods.EndTable_goods(builder);
  }

  public static void StartTable_goods(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddData(FlatBufferBuilder builder, VectorOffset dataOffset) { builder.AddOffset(0, dataOffset.Value, 0); }
  public static VectorOffset CreateDataVector(FlatBufferBuilder builder, Offset<LF.Table.DRgoods>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDataVectorBlock(FlatBufferBuilder builder, Offset<LF.Table.DRgoods>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartDataVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<LF.Table.Table_goods> EndTable_goods(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<LF.Table.Table_goods>(o);
  }
  public static void FinishTable_goodsBuffer(FlatBufferBuilder builder, Offset<LF.Table.Table_goods> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedTable_goodsBuffer(FlatBufferBuilder builder, Offset<LF.Table.Table_goods> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}
