Namespace PropertyFiltering

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

'#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.propertyGridControl1 = New DevExpress.XtraVerticalGrid.PropertyGridControl()
            CType((Me.propertyGridControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' propertyGridControl1
            ' 
            Me.propertyGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.propertyGridControl1.Location = New System.Drawing.Point(0, 0)
            Me.propertyGridControl1.Name = "propertyGridControl1"
            Me.propertyGridControl1.Size = New System.Drawing.Size(620, 384)
            Me.propertyGridControl1.TabIndex = 0
            AddHandler Me.propertyGridControl1.CustomPropertyDescriptors, New DevExpress.XtraVerticalGrid.Events.CustomPropertyDescriptorsEventHandler(AddressOf Me.propertyGridControl1_CustomPropertyDescriptors)
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(620, 384)
            Me.Controls.Add(Me.propertyGridControl1)
            Me.Name = "Form1"
            Me.Text = "Filtered PropertyGridControl's properties"
            CType((Me.propertyGridControl1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

'#End Region
        Private propertyGridControl1 As DevExpress.XtraVerticalGrid.PropertyGridControl
    End Class
End Namespace
