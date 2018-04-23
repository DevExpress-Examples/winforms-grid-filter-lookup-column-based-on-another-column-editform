Imports Microsoft.VisualBasic
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
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub btnSingle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSingle.Click
			Dim frm As New FormSingleSource()
			frm.Show()
		End Sub

		Private Sub btnDiff_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDiff.Click
			Dim frm As New FormDifferentSources()
			frm.Show()
		End Sub
	End Class
End Namespace
