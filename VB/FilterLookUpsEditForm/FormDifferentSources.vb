Imports Microsoft.VisualBasic
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace FilterLookUpsEditForm
	Partial Public Class FormDifferentSources
		Inherits Form
		Public Sub New()
			InitializeComponent()
			gridControl1.DataSource = GetData(10)

			Dim ritem As New RepositoryItemLookUpEdit() ' for Type column
			ritem.DataSource = GetLookData()
			ritem.ValueMember = "ID"
			ritem.DisplayMember = "Type"

			ritemFruits.ValueMember = "ID"
			ritemFruits.DisplayMember = "Fruit"
			ritemFruits.DataSource = GetFruits()

			ritemVegetables.ValueMember = "ID"
			ritemVegetables.DisplayMember = "Vegetable"
			ritemVegetables.DataSource = GetVegetables()

			gridView1.Columns("Type").ColumnEdit = ritem
			gridView1.Columns("Value").ColumnEdit = ritemVegetables

			gridView1.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace
			AddHandler gridView1.CustomRowCellEdit, AddressOf gridView1_CustomRowCellEdit
			AddHandler gridView1.EditFormPrepared, AddressOf gridView1_EditFormPrepared
		End Sub

		Private ritemVegetables As New RepositoryItemLookUpEdit()
		Private ritemFruits As New RepositoryItemLookUpEdit()

		Private filteredLookUp As LookUpEdit
		Private baseLookUp As LookUpEdit
		Private Sub gridView1_EditFormPrepared(ByVal sender As Object, ByVal e As EditFormPreparedEventArgs)
			baseLookUp = TryCast(e.BindableControls("Type"), LookUpEdit)
			filteredLookUp = TryCast(e.BindableControls("Value"), LookUpEdit)
			If baseLookUp IsNot Nothing AndAlso filteredLookUp IsNot Nothing Then
				RemoveHandler baseLookUp.EditValueChanged, AddressOf baseLookUp_EditValueChanged
				AddHandler baseLookUp.EditValueChanged, AddressOf baseLookUp_EditValueChanged
			End If
		End Sub

		Private Sub baseLookUp_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim type As String = baseLookUp.EditValue.ToString()
			If type = "0" Then
				filteredLookUp.Properties.Assign(ritemVegetables)
			End If
			If type = "1" Then
				filteredLookUp.Properties.Assign(ritemFruits)
			End If
		End Sub


		Private Sub gridView1_CustomRowCellEdit(ByVal sender As Object, ByVal e As CustomRowCellEditEventArgs)
			If e.Column.FieldName = "Value" Then
				Dim view As GridView = TryCast(sender, GridView)
				Dim type As String = view.GetRowCellValue(e.RowHandle, "Type").ToString()
				If type = "0" Then
					e.RepositoryItem = ritemVegetables
				End If
				If type = "1" Then
					e.RepositoryItem = ritemFruits
				End If
			End If
		End Sub

		#Region "Data"
		Private Function GetLookData() As DataTable ' for LookUpEdit from the Type column
			Dim dt As New DataTable()
			dt.Columns.Add("ID", GetType(Integer))
			dt.Columns.Add("Type", GetType(String))
			dt.Rows.Add(0, "Vegetable")
			dt.Rows.Add(1, "Fruit")
			Return dt
		End Function

		Private Function GetVegetables() As DataTable
			Dim dt As New DataTable()
			dt.Columns.Add("ID", GetType(Integer))
			dt.Columns.Add("Vegetable", GetType(String))
			dt.Rows.Add(0, "Tomato")
			dt.Rows.Add(1, "Onion")
			dt.Rows.Add(2, "Pepper")
			dt.Rows.Add(3, "Cucumber")
			dt.Rows.Add(4, "Pumpkin")
			Return dt
		End Function

		Private Function GetFruits() As DataTable
			Dim dt As New DataTable()
			dt.Columns.Add("ID", GetType(Integer))
			dt.Columns.Add("Fruit", GetType(String))
			dt.Rows.Add(0, "Apple")
			dt.Rows.Add(1, "Banana")
			dt.Rows.Add(2, "Orange")
			dt.Rows.Add(3, "Peach")
			dt.Rows.Add(4, "Mango")
			Return dt
		End Function

		Private Function GetData(ByVal rows As Integer) As DataTable ' for GridControl
			Dim dt As New DataTable()
			dt.Columns.Add("Type", GetType(Integer))
			dt.Columns.Add("Value", GetType(Integer))
			For i As Integer = 0 To rows - 1
				dt.Rows.Add(i Mod 2, i Mod 5)
			Next i
			Return dt
		End Function
		#End Region
	End Class
End Namespace
