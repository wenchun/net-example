編譯與執行

使用記事本編輯 Hello.cs 和 Hello2.cs 的程式碼。
欲編譯時，先執行 Visual Studio.NET Tools 的 Visual Studio.NET Command Prompt，或者直接開啟 DOS 視窗，並執行 vsvars32.bat 以設定編譯時所需的環境變數。

DOS 視窗環境設定好之後，輸入：

  csc hello.cs
  csc /target:winexe hello2.cs
  
即可產生 hello.exe 與 hello2.exe。  


學習重點

  - 如何動態建立控制項。
  - 如何在按鈕的 Click 委派型別中加入一個自訂的事件處理常式（處理按鈕按下的事件）。
  - 如何編譯原始碼。


Written by Huanlin Tsai. Sep-8-2002.