Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraVerticalGrid.Events

Namespace PropertyFiltering

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
            propertyGridControl1.SelectedObject = propertyGridControl1
            propertyGridControl1.GetRowByFieldName("Size").Expanded = True
            propertyGridControl1.GetRowByFieldName("Location").Expanded = True
        End Sub

        Private Sub propertyGridControl1_CustomPropertyDescriptors(ByVal sender As Object, ByVal e As CustomPropertyDescriptorsEventArgs)
            ' Provide properties to be displayed at the root level
            If e.Context.PropertyDescriptor Is Nothing Then
                Dim filteredCollection As PropertyDescriptorCollection = New PropertyDescriptorCollection(Nothing)
                AddIfPropertyExist(e.Properties, filteredCollection, "Dock")
                AddIfPropertyExist(e.Properties, filteredCollection, "Size")
                AddIfPropertyExist(e.Properties, filteredCollection, "Location")
                AddIfPropertyExist(e.Properties, filteredCollection, "NonexistentProperty")
                e.Properties = filteredCollection
            End If

            'Provide nested properties for the Size property
            If e.Context.PropertyDescriptor IsNot Nothing AndAlso Equals(e.Context.PropertyDescriptor.Name, "Size") Then
                Dim filteredCollection As PropertyDescriptorCollection = New PropertyDescriptorCollection(Nothing)
                AddIfPropertyExist(e.Properties, filteredCollection, "Height")
                e.Properties = filteredCollection
            End If
        End Sub

        Private Sub AddIfPropertyExist(ByVal sourceCollection As PropertyDescriptorCollection, ByVal targetCollection As PropertyDescriptorCollection, ByVal name As String)
            Dim foundPropertyDescriptor As PropertyDescriptor = sourceCollection(name)
            If foundPropertyDescriptor Is Nothing Then Return
            targetCollection.Add(foundPropertyDescriptor)
        End Sub
    End Class
End Namespace
