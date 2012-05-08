Imports System.Reflection

Public Interface IPlugin
    Sub Initialize(ByVal sender As Object, ByVal param As InitParam)
    Property RetValue() As Object
End Interface

'��l�ưѼ����O
Public Class InitParam
    Private m_StrValue As String        '�ΨӦs��²�檺�r��Ѽ�
    Private m_KeyValues As Hashtable    '�ΨӦs�� key=value ���Ѽ�

    Sub New()
        m_StrValue = ""
        m_KeyValues = New Hashtable
    End Sub

    Property StrValue() As String
        Get
            Return m_StrValue
        End Get
        Set(ByVal value As String)
            m_StrValue = value
        End Set
    End Property

    ReadOnly Property KeyValues() As Hashtable
        Get
            Return m_KeyValues
        End Get
    End Property

    Default Property Value(ByVal key As String) As Object
        Get
            Return m_KeyValues.Item(key)
        End Get
        Set(ByVal value As Object)
            m_KeyValues.Item(key) = value
        End Set
    End Property
End Class

'Plugin �u�t���O
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
    Public Shared Function CreatePlugin(ByVal dllName As String, ByVal className As String, ByVal owner As Object, ByVal param As InitParam) As IPlugin
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
