Module Module1

    Sub Main()
        Dim i = 0
        Dim j = 10
        Dim k = IIf(i <> 0, j \ i, 0)
        Dim l = If(i <> 0, j \ i, 0)

        Dim x As Integer?
        Dim y = IIf(x.HasValue, x, 0)
        Dim z = If(x, 0)
    End Sub

End Module
