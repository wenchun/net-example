DynaAssembly2 範例說明
by Huan-Lin Tsai. Apr-12-2005


  - 改進自 DynaAssembly1。
  - Plugin.vb 加入初始化參數類別 InitParam，提供 StrValue 和 KeyValues 兩個屬性。
  - Plugin 介面加入 RetValue 屬性，可以讓實作的表單類別提供傳回值。
  - PluginForm 加入 Init 事件，可以在 design-time 利用 VS.NET 產生事件
    處理常式，比較方便。
  - 示範開啟 plugin form 時如何傳入參數值，以及接收 form 的傳回值。  
    
  
注意：

  - Main 專案的 PluginIntf 組件參考的 CopyLocal = False。
  - 專案的 dependencies: Main depends on PluginIntf。  