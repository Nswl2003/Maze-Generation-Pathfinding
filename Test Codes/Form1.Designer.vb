<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GenerateButton = New System.Windows.Forms.Button()
        Me.SolveButton = New System.Windows.Forms.Button()
        Me.DjikButton = New System.Windows.Forms.Button()
        Me.aStarButton = New System.Windows.Forms.Button()
        Me.HelpBox = New System.Windows.Forms.TextBox()
        Me.ResetSizeButton = New System.Windows.Forms.Button()
        Me.BFSButton = New System.Windows.Forms.Button()
        Me.ClearCheckPts = New System.Windows.Forms.Button()
        Me.DFSButton = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.PictureBox1.Location = New System.Drawing.Point(193, 48)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(420, 420)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'GenerateButton
        '
        Me.GenerateButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GenerateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GenerateButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GenerateButton.Location = New System.Drawing.Point(12, 48)
        Me.GenerateButton.Name = "GenerateButton"
        Me.GenerateButton.Size = New System.Drawing.Size(80, 30)
        Me.GenerateButton.TabIndex = 1
        Me.GenerateButton.Text = "Generate"
        Me.GenerateButton.UseVisualStyleBackColor = False
        '
        'SolveButton
        '
        Me.SolveButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SolveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SolveButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.SolveButton.Location = New System.Drawing.Point(12, 84)
        Me.SolveButton.Name = "SolveButton"
        Me.SolveButton.Size = New System.Drawing.Size(80, 30)
        Me.SolveButton.TabIndex = 3
        Me.SolveButton.Text = "Solve"
        Me.SolveButton.UseVisualStyleBackColor = False
        '
        'DjikButton
        '
        Me.DjikButton.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DjikButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DjikButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DjikButton.Location = New System.Drawing.Point(12, 132)
        Me.DjikButton.Name = "DjikButton"
        Me.DjikButton.Size = New System.Drawing.Size(80, 23)
        Me.DjikButton.TabIndex = 4
        Me.DjikButton.Text = "Djikstra"
        Me.DjikButton.UseVisualStyleBackColor = False
        '
        'aStarButton
        '
        Me.aStarButton.BackColor = System.Drawing.SystemColors.ControlLight
        Me.aStarButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.aStarButton.Location = New System.Drawing.Point(12, 161)
        Me.aStarButton.Name = "aStarButton"
        Me.aStarButton.Size = New System.Drawing.Size(80, 23)
        Me.aStarButton.TabIndex = 5
        Me.aStarButton.Text = "A* Search"
        Me.aStarButton.UseVisualStyleBackColor = False
        '
        'HelpBox
        '
        Me.HelpBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.HelpBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HelpBox.Enabled = False
        Me.HelpBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpBox.Location = New System.Drawing.Point(12, 261)
        Me.HelpBox.Multiline = True
        Me.HelpBox.Name = "HelpBox"
        Me.HelpBox.ReadOnly = True
        Me.HelpBox.Size = New System.Drawing.Size(80, 135)
        Me.HelpBox.TabIndex = 6
        '
        'ResetSizeButton
        '
        Me.ResetSizeButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ResetSizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ResetSizeButton.Location = New System.Drawing.Point(12, 12)
        Me.ResetSizeButton.Name = "ResetSizeButton"
        Me.ResetSizeButton.Size = New System.Drawing.Size(80, 30)
        Me.ResetSizeButton.TabIndex = 7
        Me.ResetSizeButton.Text = "Reset Size"
        Me.ResetSizeButton.UseVisualStyleBackColor = False
        '
        'BFSButton
        '
        Me.BFSButton.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BFSButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BFSButton.Location = New System.Drawing.Point(12, 190)
        Me.BFSButton.Name = "BFSButton"
        Me.BFSButton.Size = New System.Drawing.Size(80, 23)
        Me.BFSButton.TabIndex = 8
        Me.BFSButton.Text = "Breadth First"
        Me.BFSButton.UseVisualStyleBackColor = False
        '
        'ClearCheckPts
        '
        Me.ClearCheckPts.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClearCheckPts.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ClearCheckPts.Location = New System.Drawing.Point(12, 402)
        Me.ClearCheckPts.Name = "ClearCheckPts"
        Me.ClearCheckPts.Size = New System.Drawing.Size(80, 47)
        Me.ClearCheckPts.TabIndex = 9
        Me.ClearCheckPts.Text = "Clear Checkpoints/Path"
        Me.ClearCheckPts.UseVisualStyleBackColor = False
        '
        'DFSButton
        '
        Me.DFSButton.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DFSButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DFSButton.Location = New System.Drawing.Point(12, 219)
        Me.DFSButton.Name = "DFSButton"
        Me.DFSButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DFSButton.Size = New System.Drawing.Size(80, 23)
        Me.DFSButton.TabIndex = 10
        Me.DFSButton.Text = "Depth First"
        Me.DFSButton.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.DFSButton)
        Me.Controls.Add(Me.ClearCheckPts)
        Me.Controls.Add(Me.BFSButton)
        Me.Controls.Add(Me.ResetSizeButton)
        Me.Controls.Add(Me.HelpBox)
        Me.Controls.Add(Me.aStarButton)
        Me.Controls.Add(Me.DjikButton)
        Me.Controls.Add(Me.SolveButton)
        Me.Controls.Add(Me.GenerateButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.Lime
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents GenerateButton As Windows.Forms.Button
    Friend WithEvents SolveButton As Windows.Forms.Button
    Friend WithEvents DjikButton As Windows.Forms.Button
    Friend WithEvents aStarButton As Windows.Forms.Button
    Friend WithEvents HelpBox As Windows.Forms.TextBox
    Friend WithEvents ResetSizeButton As Windows.Forms.Button
    Friend WithEvents BFSButton As Windows.Forms.Button
    Friend WithEvents ClearCheckPts As Windows.Forms.Button
    Friend WithEvents DFSButton As Windows.Forms.Button
End Class
