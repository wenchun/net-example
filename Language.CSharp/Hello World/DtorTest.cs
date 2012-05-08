/*
  此範例只包含了一個解構元的宣告，
  目的在展示 C# 編譯後的 IL code，
  其實只是去呼叫 Finalize() 而已。
  
  編譯： csc DtorTest.cs

  執行 ildasm DtorTest.exe 以觀察
  反組譯之後的 Finalize() 方法。
    
  Written by Huanlin Tsai.  Oct-11-2002.
*/
using System;

class DtorTest
{
  ~DtorTest()
  {
  }   
   
  public static void Main()
  {
  }
}