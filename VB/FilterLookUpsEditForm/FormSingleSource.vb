Imports Microsoft.VisualBasic
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms

Namespace FilterLookUpsEditForm
	Partial Public Class FormSingleSource
		Inherits Form
		Public Sub New()
			InitializeComponent()
			gridControl1.DataSource = GetData(10)

			Dim ritem As New RepositoryItemLookUpEdit() ' for Type column
			ritem.DataSource = GetLookData()
			ritem.ValueMember = "ID"
			ritem.DisplayMember = "ProductType"

			ritemProducts.ValueMember = "ID"
			ritemProducts.DisplayMember = "Name"
			originalData = GetLookUpDataForFiltering()
			ritemProducts.DataSource = originalData

			gridView1.Columns("ProductType").ColumnEdit = ritem
			gridView1.Columns("Name").ColumnEdit = ritemProducts

			gridView1.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace
			AddHandler gridView1.EditFormPrepared, AddressOf gridView1_EditFormPrepared
		End Sub

		Private ritemProducts As New RepositoryItemLookUpEdit()

		Private filteredLookUp As LookUpEdit
		Private baseLookUp As LookUpEdit
		Private clone As DataView = Nothing
		Private originalData As DataTable = Nothing
		Private Sub gridView1_EditFormPrepared(ByVal sender As Object, ByVal e As EditFormPreparedEventArgs)
			baseLookUp = TryCast(e.BindableControls("ProductType"), LookUpEdit)
			filteredLookUp = TryCast(e.BindableControls("Name"), LookUpEdit)
			If baseLookUp IsNot Nothing AndAlso filteredLookUp IsNot Nothing Then
				RemoveHandler filteredLookUp.Enter, AddressOf filteredLookUp_Enter
				AddHandler filteredLookUp.Enter, AddressOf filteredLookUp_Enter
				RemoveHandler filteredLookUp.Leave, AddressOf filteredLookUp_Leave
				AddHandler filteredLookUp.Leave, AddressOf filteredLookUp_Leave
			End If
		End Sub

		Private Sub filteredLookUp_Leave(ByVal sender As Object, ByVal e As EventArgs)
			filteredLookUp.Properties.DataSource = originalData
			If clone IsNot Nothing Then
				clone.Dispose()
				clone = Nothing
			End If
		End Sub
		Private Sub filteredLookUp_Enter(ByVal sender As Object, ByVal e As EventArgs)
			Dim table As DataTable = TryCast(filteredLookUp.Properties.DataSource, DataTable)
			clone = New DataView(table)
			Dim country As String = baseLookUp.Properties.GetDisplayValueByKeyValue(baseLookUp.EditValue).ToString()
			clone.RowFilter = String.Format("[ProductType] = '{0}'", country)
			filteredLookUp.Properties.DataSource = clone
		End Sub

		#Region "Data"
		Private Function GetLookData() As DataTable ' for LookUpEdit from the Type column
			Dim dt As New DataTable()
			dt.Columns.Add("ID", GetType(Integer))
			dt.Columns.Add("ProductType", GetType(String))
			dt.Rows.Add(0, "Vegetable")
			dt.Rows.Add(1, "Fruit")
			Return dt
		End Function

		Private Function GetLookUpDataForFiltering() As DataTable
			Dim dt As New DataTable()
			dt.Columns.Add("ID", GetType(Integer))
			dt.Columns.Add("ProductType", GetType(String))
			dt.Columns.Add("Name", GetType(String))
			dt.Rows.Add(0, "Fruit", "Apple")
			dt.Rows.Add(1, "Vegetable", "Tomato")
			dt.Rows.Add(2, "Fruit", "Banana")
			dt.Rows.Add(3, "Fruit", "Orange")
			dt.Rows.Add(4, "Vegetable", "Onion")
			dt.Rows.Add(5, "Vegetable", "Pepper")
			dt.Rows.Add(6, "Vegetable", "Cucumber")
			dt.Rows.Add(7, "Fruit", "Peach")
			dt.Rows.Add(8, "Vegetable", "Pumpkin")
			dt.Rows.Add(9, "Fruit", "Mango")
			Return dt
		End Function

		Private Function GetData(ByVal rows As Integer) As DataTable ' for GridControl
			Dim dt As New DataTable()
			dt.Columns.Add("ProductType", GetType(Integer))
			dt.Columns.Add("Name", GetType(Integer))
			For i As Integer = 0 To rows - 1
				dt.Rows.Add(1, 0)
			Next i
			Return dt
		End Function
		#End Region
	End Class
End Namespace
