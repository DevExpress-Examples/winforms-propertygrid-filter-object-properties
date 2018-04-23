Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraVerticalGrid.Events

Namespace PropertyFiltering
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			Me.propertyGridControl1.SelectedObject = Me.propertyGridControl1
			Me.propertyGridControl1.GetRowByFieldName("Size").Expanded = True
			Me.propertyGridControl1.GetRowByFieldName("Location").Expanded = True
		End Sub

		Private Sub propertyGridControl1_CustomPropertyDescriptors(ByVal sender As Object, ByVal e As CustomPropertyDescriptorsEventArgs) Handles propertyGridControl1.CustomPropertyDescriptors
			' Provide properties to be displayed at the root level
			If e.Context.PropertyDescriptor Is Nothing Then
				Dim filteredCollection As New PropertyDescriptorCollection(Nothing)
				AddIfPropertyExist(e.Properties, filteredCollection, "Dock")
				AddIfPropertyExist(e.Properties, filteredCollection, "Size")
				AddIfPropertyExist(e.Properties, filteredCollection, "Location")
				AddIfPropertyExist(e.Properties, filteredCollection, "NonexistentProperty")
				e.Properties = filteredCollection
			End If
			'Provide nested properties for the Size property
			If e.Context.PropertyDescriptor IsNot Nothing AndAlso e.Context.PropertyDescriptor.Name = "Size" Then
				Dim filteredCollection As New PropertyDescriptorCollection(Nothing)
				AddIfPropertyExist(e.Properties, filteredCollection, "Height")
				e.Properties = filteredCollection
			End If
		End Sub
		Private Sub AddIfPropertyExist(ByVal sourceCollection As PropertyDescriptorCollection, ByVal targetCollection As PropertyDescriptorCollection, ByVal name As String)
			Dim foundPropertyDescriptor As PropertyDescriptor = sourceCollection(name)
			If foundPropertyDescriptor Is Nothing Then
				Return
			End If
			targetCollection.Add(foundPropertyDescriptor)
		End Sub
	End Class
End Namespace
