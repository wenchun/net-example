Imports System.Reflection

Public Interface IPlugin
    Sub Initialize(ByVal sender As Object, ByVal param As Object)
End Interface

Public Class PluginFactory
    ' �ϥγ����W�٤�諸�覡�M�����O
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


    ' ���J assembly �ëإߨ� export �� plugin form ����
    Public Shared Function CreatePlugin(ByVal dllName As String, ByVal className As String, ByVal owner As Object, ByVal param As Object) As IPlugin
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
            Throw New Exception("�L�k�إߵ�������! �L�����O: " + className)
        End If

        aPluginType = aType.GetInterface("IPlugin", True)
        If (aPluginType Is Nothing) Then
            Throw New Exception("Form ���O������@ IPlugin �����C")
        End If

        aObj = Activator.CreateInstance(aType)

        aPlugin = DirectCast(aObj, IPlugin)
        aPlugin.Initialize(owner, param)
        Return aPlugin
    End Function

End Class
