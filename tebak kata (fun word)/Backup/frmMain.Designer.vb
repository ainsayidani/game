<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnMulaiBaru = New System.Windows.Forms.Button
        Me.btnData = New System.Windows.Forms.Button
        Me.lblKesempatan = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnMulaiBaru
        '
        Me.btnMulaiBaru.Location = New System.Drawing.Point(355, 6)
        Me.btnMulaiBaru.Name = "btnMulaiBaru"
        Me.btnMulaiBaru.Size = New System.Drawing.Size(82, 31)
        Me.btnMulaiBaru.TabIndex = 1
        Me.btnMulaiBaru.Text = "Mulai Baru"
        Me.btnMulaiBaru.UseVisualStyleBackColor = True
        '
        'btnData
        '
        Me.btnData.Location = New System.Drawing.Point(443, 6)
        Me.btnData.Name = "btnData"
        Me.btnData.Size = New System.Drawing.Size(82, 31)
        Me.btnData.TabIndex = 2
        Me.btnData.Text = "Edit Data"
        Me.btnData.UseVisualStyleBackColor = True
        '
        'lblKesempatan
        '
        Me.lblKesempatan.AutoSize = True
        Me.lblKesempatan.Location = New System.Drawing.Point(12, 15)
        Me.lblKesempatan.Name = "lblKesempatan"
        Me.lblKesempatan.Size = New System.Drawing.Size(39, 13)
        Me.lblKesempatan.TabIndex = 0
        Me.lblKesempatan.Text = "Label1"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(537, 112)
        Me.Controls.Add(Me.lblKesempatan)
        Me.Controls.Add(Me.btnData)
        Me.Controls.Add(Me.btnMulaiBaru)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tebak Kata"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnMulaiBaru As System.Windows.Forms.Button
    Friend WithEvents btnData As System.Windows.Forms.Button
    Friend WithEvents lblKesempatan As System.Windows.Forms.Label

End Class
