Module Module1
  Sub Main()
    Dim x As Double, res As Double
    x = 12.5
    res = Add(x, 46.5)
    System.Console.Write("The result is ")
    System.Console.WriteLine(res)
  End Sub

  Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
    Add = n1 + n2
  End Function
End Module