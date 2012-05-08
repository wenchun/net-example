Imports System.Reflection

Public Class InitParam
    Public StrParam As String
End Class

Public Interface IPlugin
    Sub Initialize(ByVal sender As Object, ByVal initParam As InitParam)
End Interface

Public Class PluginFactory
    ' 使用部分名稱比對的方式尋找類別
    Public Shared Function FindClass(ByVal asm As [Assembly], ByVal className As String) As System.Type
        Dim aTypes() As System.Type
        Dim aType As System.Type
        aTypes = asm.GetTypes()
        For Each aType In aTypes
            If className.IndexOf(aType.Name) >= 0 Then
                Return aType
            End If
        Next        
        Return Nothing
    End Function


    ' 載入 assembly 並建立其 export 的 plugin form 物件
    Public Shared Function CreatePlugin(ByVal dllName As String, ByVal className As String, ByVal owner As Object, ByVal initParam As InitParam) As IPlugin
        Dim anAsm As [Assembly]
        Dim aType As Type
        Dim aPluginType As Type
        Dim aObj As System.Object
        Dim aPlugin As IPlugin

        anAsm = [Assembly].LoadFrom(dllName)
        If className.IndexOf("."c) >= 0 Then
            ' Get Type object via full qualified class name, no exception, ignore case
            aType = anAsm.GetType(className, False, True)
        Else
            aType = FindClass(anAsm, className)
        End If
        If (aType Is Nothing) Then
            Throw New Exception("無法建立視窗物件! 無此類別: " + className)
        End If

        aPluginType = aType.GetInterface("IPlugin", True)
        If (aPluginType Is Nothing) Then
            Throw New Exception("Form 類別必須實作 IPlugin 介面。")
        End If

        aObj = Activator.CreateInstance(aType)

        aPlugin = DirectCast(aObj, IPlugin) '這行會失敗！因為 IPlugin 是以原始碼共享的方式使用於兩個專案。
        aPlugin.Initialize(owner, initParam)
        Return aPlugin
    End Function

End Class
