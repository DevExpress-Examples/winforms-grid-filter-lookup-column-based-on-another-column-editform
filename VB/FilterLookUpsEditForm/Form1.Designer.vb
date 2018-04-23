Imports Microsoft.VisualBasic
Imports System
Namespace FilterLookUpsEditForm
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.btnSingle = New DevExpress.XtraEditors.SimpleButton()
			Me.btnDiff = New DevExpress.XtraEditors.SimpleButton()
			Me.SuspendLayout()
			' 
			' btnSingle
			' 
			Me.btnSingle.Location = New System.Drawing.Point(36, 118)
			Me.btnSingle.Name = "btnSingle"
			Me.btnSingle.Size = New System.Drawing.Size(141, 90)
			Me.btnSingle.TabIndex = 0
			Me.btnSingle.Text = "Single data source"
'			Me.btnSingle.Click += New System.EventHandler(Me.btnSingle_Click);
			' 
			' btnDiff
			' 
			Me.btnDiff.Location = New System.Drawing.Point(235, 118)
			Me.btnDiff.Name = "btnDiff"
			Me.btnDiff.Size = New System.Drawing.Size(141, 90)
			Me.btnDiff.TabIndex = 1
			Me.btnDiff.Text = "Different data sources"
'			Me.btnDiff.Click += New System.EventHandler(Me.btnDiff_Click);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(413, 343)
			Me.Controls.Add(Me.btnDiff)
			Me.Controls.Add(Me.btnSingle)
			Me.Name = "Form1"
			Me.Text = "Filter LookUps"
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents btnSingle As DevExpress.XtraEditors.SimpleButton
		Private WithEvents btnDiff As DevExpress.XtraEditors.SimpleButton

	End Class
End Namespace

