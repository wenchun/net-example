Public Interface IAnimal
	Sub Speak()
	Property Name() As String
End Interface

Class Dog
	Implements IAnimal	 '��J���o��|�������ͤ�������@

	Public Property Name() As String Implements IAnimal.Name
		Get

		End Get
		Set(ByVal Value As String)

		End Set
	End Property

	Public Sub Speak() Implements IAnimal.Speak

	End Sub
End Class