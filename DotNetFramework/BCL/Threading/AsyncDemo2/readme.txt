AsyncDemo2 by Huan-Lin Tsai. Jul-5-2005.

此範例程式修改自 AsyncDemo1，主要是讓 Worker 類別內建非同步呼叫機制，
也就是提供 BeginWork() 和 EndWork() 方法，並且使用正確安全的方法在 
completion callback method 裡面更新 UI。
