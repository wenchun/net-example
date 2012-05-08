Imports System.Data.SqlClient

Public Class Form1
	Inherits System.Windows.Forms.Form

	Dim bm As BindingManagerBase


#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

	End Sub

	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If Not (components Is Nothing) Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
	Friend WithEvents SqlDataAdapter1 As System.Data.SqlClient.SqlDataAdapter
	Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
	Friend WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
	Friend WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
	Friend WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
	Friend WithEvents EmpDataSet1 As CrudDemo.EmpDataSet
	Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
	Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
	Friend WithEvents tbbDelete As System.Windows.Forms.ToolBarButton
	Friend WithEvents tbbQuery As System.Windows.Forms.ToolBarButton
	Friend WithEvents tbbFirst As System.Windows.Forms.ToolBarButton
	Friend WithEvents tbbPrev As System.Windows.Forms.ToolBarButton
	Friend WithEvents tbbNext As System.Windows.Forms.ToolBarButton
	Friend WithEvents tbbLast As System.Windows.Forms.ToolBarButton
	Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
	Friend WithEvents tbbSave As System.Windows.Forms.ToolBarButton
	Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
		Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
		Me.SqlDataAdapter1 = New System.Data.SqlClient.SqlDataAdapter
		Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand
		Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand
		Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand
		Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand
		Me.EmpDataSet1 = New CrudDemo.EmpDataSet
		Me.DataGrid1 = New System.Windows.Forms.DataGrid
		Me.ToolBar1 = New System.Windows.Forms.ToolBar
		Me.tbbQuery = New System.Windows.Forms.ToolBarButton
		Me.tbbFirst = New System.Windows.Forms.ToolBarButton
		Me.tbbPrev = New System.Windows.Forms.ToolBarButton
		Me.tbbNext = New System.Windows.Forms.ToolBarButton
		Me.tbbLast = New System.Windows.Forms.ToolBarButton
		Me.tbbSave = New System.Windows.Forms.ToolBarButton
		Me.tbbDelete = New System.Windows.Forms.ToolBarButton
		Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
		Me.TextBox1 = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.TextBox2 = New System.Windows.Forms.TextBox
		Me.Label3 = New System.Windows.Forms.Label
		Me.TextBox3 = New System.Windows.Forms.TextBox
		Me.Label4 = New System.Windows.Forms.Label
		Me.TextBox4 = New System.Windows.Forms.TextBox
		Me.Label5 = New System.Windows.Forms.Label
		Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
		Me.Panel1 = New System.Windows.Forms.Panel
		CType(Me.EmpDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'SqlConnection1
		'
		Me.SqlConnection1.ConnectionString = "workstation id=""MICHAEL-I"";packet size=4096;user id=sa;data source=""127.0.0.1"";pe" & _
		"rsist security info=False;initial catalog=Northwind"
		'
		'SqlDataAdapter1
		'
		Me.SqlDataAdapter1.DeleteCommand = Me.SqlDeleteCommand1
		Me.SqlDataAdapter1.InsertCommand = Me.SqlInsertCommand1
		Me.SqlDataAdapter1.SelectCommand = Me.SqlSelectCommand1
		Me.SqlDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Employees", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("EmployeeID", "EmployeeID"), New System.Data.Common.DataColumnMapping("LastName", "LastName"), New System.Data.Common.DataColumnMapping("FirstName", "FirstName"), New System.Data.Common.DataColumnMapping("Title", "Title"), New System.Data.Common.DataColumnMapping("TitleOfCourtesy", "TitleOfCourtesy"), New System.Data.Common.DataColumnMapping("BirthDate", "BirthDate"), New System.Data.Common.DataColumnMapping("HireDate", "HireDate"), New System.Data.Common.DataColumnMapping("Address", "Address"), New System.Data.Common.DataColumnMapping("City", "City"), New System.Data.Common.DataColumnMapping("Region", "Region"), New System.Data.Common.DataColumnMapping("PostalCode", "PostalCode"), New System.Data.Common.DataColumnMapping("Country", "Country"), New System.Data.Common.DataColumnMapping("HomePhone", "HomePhone"), New System.Data.Common.DataColumnMapping("Extension", "Extension"), New System.Data.Common.DataColumnMapping("Photo", "Photo"), New System.Data.Common.DataColumnMapping("Notes", "Notes"), New System.Data.Common.DataColumnMapping("ReportsTo", "ReportsTo"), New System.Data.Common.DataColumnMapping("PhotoPath", "PhotoPath")})})
		Me.SqlDataAdapter1.UpdateCommand = Me.SqlUpdateCommand1
		'
		'SqlDeleteCommand1
		'
		Me.SqlDeleteCommand1.CommandText = "DELETE FROM Employees WHERE (EmployeeID = @Original_EmployeeID) AND (Address = @O" & _
		"riginal_Address OR @Original_Address IS NULL AND Address IS NULL) AND (BirthDate" & _
		" = @Original_BirthDate OR @Original_BirthDate IS NULL AND BirthDate IS NULL) AND" & _
		" (City = @Original_City OR @Original_City IS NULL AND City IS NULL) AND (Country" & _
		" = @Original_Country OR @Original_Country IS NULL AND Country IS NULL) AND (Exte" & _
		"nsion = @Original_Extension OR @Original_Extension IS NULL AND Extension IS NULL" & _
		") AND (FirstName = @Original_FirstName) AND (HireDate = @Original_HireDate OR @O" & _
		"riginal_HireDate IS NULL AND HireDate IS NULL) AND (HomePhone = @Original_HomePh" & _
		"one OR @Original_HomePhone IS NULL AND HomePhone IS NULL) AND (LastName = @Origi" & _
		"nal_LastName) AND (PhotoPath = @Original_PhotoPath OR @Original_PhotoPath IS NUL" & _
		"L AND PhotoPath IS NULL) AND (PostalCode = @Original_PostalCode OR @Original_Pos" & _
		"talCode IS NULL AND PostalCode IS NULL) AND (Region = @Original_Region OR @Origi" & _
		"nal_Region IS NULL AND Region IS NULL) AND (ReportsTo = @Original_ReportsTo OR @" & _
		"Original_ReportsTo IS NULL AND ReportsTo IS NULL) AND (Title = @Original_Title O" & _
		"R @Original_Title IS NULL AND Title IS NULL) AND (TitleOfCourtesy = @Original_Ti" & _
		"tleOfCourtesy OR @Original_TitleOfCourtesy IS NULL AND TitleOfCourtesy IS NULL)"
		Me.SqlDeleteCommand1.Connection = Me.SqlConnection1
		Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Address", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Address", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_BirthDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "BirthDate", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Country", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Extension", System.Data.SqlDbType.NVarChar, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Extension", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_FirstName", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FirstName", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_HireDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "HireDate", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_HomePhone", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "HomePhone", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_LastName", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "LastName", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_PhotoPath", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PhotoPath", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_PostalCode", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PostalCode", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Region", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Region", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ReportsTo", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ReportsTo", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Title", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Title", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TitleOfCourtesy", System.Data.SqlDbType.NVarChar, 25, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TitleOfCourtesy", System.Data.DataRowVersion.Original, Nothing))
		'
		'SqlInsertCommand1
		'
		Me.SqlInsertCommand1.CommandText = "INSERT INTO Employees(LastName, FirstName, Title, TitleOfCourtesy, BirthDate, Hir" & _
		"eDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, " & _
		"Notes, ReportsTo, PhotoPath) VALUES (@LastName, @FirstName, @Title, @TitleOfCour" & _
		"tesy, @BirthDate, @HireDate, @Address, @City, @Region, @PostalCode, @Country, @H" & _
		"omePhone, @Extension, @Photo, @Notes, @ReportsTo, @PhotoPath); SELECT EmployeeID" & _
		", LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, Cit" & _
		"y, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, P" & _
		"hotoPath FROM Employees WHERE (EmployeeID = @@IDENTITY)"
		Me.SqlInsertCommand1.Connection = Me.SqlConnection1
		Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 20, "LastName"))
		Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 10, "FirstName"))
		Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Title", System.Data.SqlDbType.NVarChar, 30, "Title"))
		Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TitleOfCourtesy", System.Data.SqlDbType.NVarChar, 25, "TitleOfCourtesy"))
		Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BirthDate", System.Data.SqlDbType.DateTime, 8, "BirthDate"))
		Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@HireDate", System.Data.SqlDbType.DateTime, 8, "HireDate"))
		Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 60, "Address"))
		Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@City", System.Data.SqlDbType.NVarChar, 15, "City"))
		Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Region", System.Data.SqlDbType.NVarChar, 15, "Region"))
		Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PostalCode", System.Data.SqlDbType.NVarChar, 10, "PostalCode"))
		Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Country", System.Data.SqlDbType.NVarChar, 15, "Country"))
		Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@HomePhone", System.Data.SqlDbType.NVarChar, 24, "HomePhone"))
		Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Extension", System.Data.SqlDbType.NVarChar, 4, "Extension"))
		Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Photo", System.Data.SqlDbType.VarBinary, 2147483647, "Photo"))
		Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Notes", System.Data.SqlDbType.NVarChar, 1073741823, "Notes"))
		Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ReportsTo", System.Data.SqlDbType.Int, 4, "ReportsTo"))
		Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PhotoPath", System.Data.SqlDbType.NVarChar, 255, "PhotoPath"))
		'
		'SqlSelectCommand1
		'
		Me.SqlSelectCommand1.CommandText = "SELECT EmployeeID, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDa" & _
		"te, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Not" & _
		"es, ReportsTo, PhotoPath FROM Employees"
		Me.SqlSelectCommand1.Connection = Me.SqlConnection1
		'
		'SqlUpdateCommand1
		'
		Me.SqlUpdateCommand1.CommandText = "UPDATE Employees SET LastName = @LastName, FirstName = @FirstName, Title = @Title" & _
		", TitleOfCourtesy = @TitleOfCourtesy, BirthDate = @BirthDate, HireDate = @HireDa" & _
		"te, Address = @Address, City = @City, Region = @Region, PostalCode = @PostalCode" & _
		", Country = @Country, HomePhone = @HomePhone, Extension = @Extension, Photo = @P" & _
		"hoto, Notes = @Notes, ReportsTo = @ReportsTo, PhotoPath = @PhotoPath WHERE (Empl" & _
		"oyeeID = @Original_EmployeeID) AND (Address = @Original_Address OR @Original_Add" & _
		"ress IS NULL AND Address IS NULL) AND (BirthDate = @Original_BirthDate OR @Origi" & _
		"nal_BirthDate IS NULL AND BirthDate IS NULL) AND (City = @Original_City OR @Orig" & _
		"inal_City IS NULL AND City IS NULL) AND (Country = @Original_Country OR @Origina" & _
		"l_Country IS NULL AND Country IS NULL) AND (Extension = @Original_Extension OR @" & _
		"Original_Extension IS NULL AND Extension IS NULL) AND (FirstName = @Original_Fir" & _
		"stName) AND (HireDate = @Original_HireDate OR @Original_HireDate IS NULL AND Hir" & _
		"eDate IS NULL) AND (HomePhone = @Original_HomePhone OR @Original_HomePhone IS NU" & _
		"LL AND HomePhone IS NULL) AND (LastName = @Original_LastName) AND (PhotoPath = @" & _
		"Original_PhotoPath OR @Original_PhotoPath IS NULL AND PhotoPath IS NULL) AND (Po" & _
		"stalCode = @Original_PostalCode OR @Original_PostalCode IS NULL AND PostalCode I" & _
		"S NULL) AND (Region = @Original_Region OR @Original_Region IS NULL AND Region IS" & _
		" NULL) AND (ReportsTo = @Original_ReportsTo OR @Original_ReportsTo IS NULL AND R" & _
		"eportsTo IS NULL) AND (Title = @Original_Title OR @Original_Title IS NULL AND Ti" & _
		"tle IS NULL) AND (TitleOfCourtesy = @Original_TitleOfCourtesy OR @Original_Title" & _
		"OfCourtesy IS NULL AND TitleOfCourtesy IS NULL); SELECT EmployeeID, LastName, Fi" & _
		"rstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, Pos" & _
		"talCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath FROM " & _
		"Employees WHERE (EmployeeID = @EmployeeID)"
		Me.SqlUpdateCommand1.Connection = Me.SqlConnection1
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 20, "LastName"))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 10, "FirstName"))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Title", System.Data.SqlDbType.NVarChar, 30, "Title"))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TitleOfCourtesy", System.Data.SqlDbType.NVarChar, 25, "TitleOfCourtesy"))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BirthDate", System.Data.SqlDbType.DateTime, 8, "BirthDate"))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@HireDate", System.Data.SqlDbType.DateTime, 8, "HireDate"))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 60, "Address"))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@City", System.Data.SqlDbType.NVarChar, 15, "City"))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Region", System.Data.SqlDbType.NVarChar, 15, "Region"))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PostalCode", System.Data.SqlDbType.NVarChar, 10, "PostalCode"))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Country", System.Data.SqlDbType.NVarChar, 15, "Country"))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@HomePhone", System.Data.SqlDbType.NVarChar, 24, "HomePhone"))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Extension", System.Data.SqlDbType.NVarChar, 4, "Extension"))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Photo", System.Data.SqlDbType.VarBinary, 2147483647, "Photo"))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Notes", System.Data.SqlDbType.NVarChar, 1073741823, "Notes"))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ReportsTo", System.Data.SqlDbType.Int, 4, "ReportsTo"))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PhotoPath", System.Data.SqlDbType.NVarChar, 255, "PhotoPath"))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Address", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Address", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_BirthDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "BirthDate", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Country", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Extension", System.Data.SqlDbType.NVarChar, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Extension", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_FirstName", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FirstName", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_HireDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "HireDate", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_HomePhone", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "HomePhone", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_LastName", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "LastName", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_PhotoPath", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PhotoPath", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_PostalCode", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PostalCode", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Region", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Region", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ReportsTo", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ReportsTo", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Title", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Title", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TitleOfCourtesy", System.Data.SqlDbType.NVarChar, 25, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TitleOfCourtesy", System.Data.DataRowVersion.Original, Nothing))
		Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, "EmployeeID"))
		'
		'EmpDataSet1
		'
		Me.EmpDataSet1.DataSetName = "EmpDataSet"
		Me.EmpDataSet1.Locale = New System.Globalization.CultureInfo("zh-TW")
		'
		'DataGrid1
		'
		Me.DataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender
		Me.DataGrid1.BackColor = System.Drawing.Color.WhiteSmoke
		Me.DataGrid1.BackgroundColor = System.Drawing.Color.LightGray
		Me.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.DataGrid1.CaptionBackColor = System.Drawing.Color.LightSteelBlue
		Me.DataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue
		Me.DataGrid1.CaptionText = "員工資料"
		Me.DataGrid1.DataMember = ""
		Me.DataGrid1.DataSource = Me.EmpDataSet1.Employees
		Me.DataGrid1.FlatMode = True
		Me.DataGrid1.Font = New System.Drawing.Font("Tahoma", 8.0!)
		Me.DataGrid1.ForeColor = System.Drawing.Color.MidnightBlue
		Me.DataGrid1.GridLineColor = System.Drawing.Color.Gainsboro
		Me.DataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
		Me.DataGrid1.HeaderBackColor = System.Drawing.Color.MidnightBlue
		Me.DataGrid1.HeaderFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.DataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke
		Me.DataGrid1.LinkColor = System.Drawing.Color.Teal
		Me.DataGrid1.Location = New System.Drawing.Point(16, 192)
		Me.DataGrid1.Name = "DataGrid1"
		Me.DataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro
		Me.DataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
		Me.DataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue
		Me.DataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke
		Me.DataGrid1.Size = New System.Drawing.Size(688, 264)
		Me.DataGrid1.TabIndex = 0
		'
		'ToolBar1
		'
		Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbbQuery, Me.tbbFirst, Me.tbbPrev, Me.tbbNext, Me.tbbLast, Me.tbbSave, Me.tbbDelete})
		Me.ToolBar1.DropDownArrows = True
		Me.ToolBar1.ImageList = Me.ImageList1
		Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
		Me.ToolBar1.Name = "ToolBar1"
		Me.ToolBar1.ShowToolTips = True
		Me.ToolBar1.Size = New System.Drawing.Size(720, 44)
		Me.ToolBar1.TabIndex = 1
		'
		'tbbQuery
		'
		Me.tbbQuery.ImageIndex = 3
		Me.tbbQuery.Text = "查詢"
		'
		'tbbFirst
		'
		Me.tbbFirst.ImageIndex = 4
		Me.tbbFirst.Text = "首筆"
		'
		'tbbPrev
		'
		Me.tbbPrev.ImageIndex = 5
		Me.tbbPrev.Text = "上筆"
		'
		'tbbNext
		'
		Me.tbbNext.ImageIndex = 6
		Me.tbbNext.Text = "下筆"
		'
		'tbbLast
		'
		Me.tbbLast.ImageIndex = 7
		Me.tbbLast.Text = "尾筆"
		'
		'tbbSave
		'
		Me.tbbSave.ImageIndex = 2
		Me.tbbSave.Text = "儲存"
		'
		'tbbDelete
		'
		Me.tbbDelete.ImageIndex = 1
		Me.tbbDelete.Text = "刪除"
		'
		'ImageList1
		'
		Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
		Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.ImageList1.TransparentColor = System.Drawing.Color.Purple
		'
		'TextBox1
		'
		Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpDataSet1, "Employees.員工編號"))
		Me.TextBox1.Location = New System.Drawing.Point(88, 16)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.TabIndex = 2
		Me.TextBox1.Text = "TextBox1"
		'
		'Label1
		'
		Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Label1.Location = New System.Drawing.Point(8, 16)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(72, 23)
		Me.Label1.TabIndex = 3
		Me.Label1.Text = "員工編號"
		'
		'Label2
		'
		Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Label2.Location = New System.Drawing.Point(216, 16)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(72, 23)
		Me.Label2.TabIndex = 5
		Me.Label2.Text = "Last Name"
		'
		'TextBox2
		'
		Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpDataSet1, "Employees.LastName"))
		Me.TextBox2.Location = New System.Drawing.Point(296, 16)
		Me.TextBox2.Name = "TextBox2"
		Me.TextBox2.Size = New System.Drawing.Size(136, 25)
		Me.TextBox2.TabIndex = 4
		Me.TextBox2.Text = "TextBox2"
		'
		'Label3
		'
		Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Label3.Location = New System.Drawing.Point(456, 16)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(72, 23)
		Me.Label3.TabIndex = 7
		Me.Label3.Text = "First Name"
		'
		'TextBox3
		'
		Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpDataSet1, "Employees.FirstName"))
		Me.TextBox3.Location = New System.Drawing.Point(536, 16)
		Me.TextBox3.Name = "TextBox3"
		Me.TextBox3.Size = New System.Drawing.Size(120, 25)
		Me.TextBox3.TabIndex = 6
		Me.TextBox3.Text = "TextBox3"
		'
		'Label4
		'
		Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Label4.Location = New System.Drawing.Point(8, 56)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(72, 23)
		Me.Label4.TabIndex = 9
		Me.Label4.Text = "職稱"
		'
		'TextBox4
		'
		Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpDataSet1, "Employees.職稱"))
		Me.TextBox4.Location = New System.Drawing.Point(88, 56)
		Me.TextBox4.Name = "TextBox4"
		Me.TextBox4.TabIndex = 8
		Me.TextBox4.Text = "TextBox4"
		'
		'Label5
		'
		Me.Label5.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Label5.Location = New System.Drawing.Point(216, 56)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(72, 23)
		Me.Label5.TabIndex = 11
		Me.Label5.Text = "出生日期"
		'
		'DateTimePicker1
		'
		Me.DateTimePicker1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmpDataSet1, "Employees.出生日期"))
		Me.DateTimePicker1.Location = New System.Drawing.Point(296, 56)
		Me.DateTimePicker1.Name = "DateTimePicker1"
		Me.DateTimePicker1.Size = New System.Drawing.Size(136, 25)
		Me.DateTimePicker1.TabIndex = 12
		'
		'Panel1
		'
		Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
		Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Panel1.Controls.Add(Me.TextBox2)
		Me.Panel1.Controls.Add(Me.TextBox1)
		Me.Panel1.Controls.Add(Me.Label3)
		Me.Panel1.Controls.Add(Me.TextBox3)
		Me.Panel1.Controls.Add(Me.Label1)
		Me.Panel1.Controls.Add(Me.DateTimePicker1)
		Me.Panel1.Controls.Add(Me.TextBox4)
		Me.Panel1.Controls.Add(Me.Label5)
		Me.Panel1.Controls.Add(Me.Label4)
		Me.Panel1.Controls.Add(Me.Label2)
		Me.Panel1.Location = New System.Drawing.Point(8, 64)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(696, 104)
		Me.Panel1.TabIndex = 13
		'
		'Form1
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(6, 18)
		Me.ClientSize = New System.Drawing.Size(720, 477)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.ToolBar1)
		Me.Controls.Add(Me.DataGrid1)
		Me.Font = New System.Drawing.Font("PMingLiU", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
		Me.Name = "Form1"
		Me.Text = "員工基本資料維護"
		CType(Me.EmpDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		SqlDataAdapter1.Fill(EmpDataSet1, "Employees")

		bm = Me.BindingContext(EmpDataSet1, "Employees")
		DataGrid1.SetDataBinding(EmpDataSet1, "Employees")
	End Sub

	Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick		
		Select Case e.Button.Text
			Case "查詢"
				Dim aForm As QueryForm = New QueryForm
				If aForm.ShowDialog() = DialogResult.OK Then
					'把查詢的 code 寫在這裡
				End If
			Case "儲存"
				bm.EndCurrentEdit()
				SqlDataAdapter1.Update(EmpDataSet1)
			Case "刪除"
				If MessageBox.Show("確定要刪除這筆記錄?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
					bm.RemoveAt(bm.Position)
					SqlDataAdapter1.Update(EmpDataSet1)
				End If
			Case "上筆"
				bm.Position -= 1
			Case "下筆"
				bm.Position += 1
			Case "首筆"
				bm.Position = 0
			Case "尾筆"
				bm.Position = bm.Count - 1
		End Select
	End Sub
End Class
