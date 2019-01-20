<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Selection_Sort_Visualiser
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Selection_Sort_Visualiser))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.sort = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.reset = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ascending = New System.Windows.Forms.RadioButton()
        Me.descending = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.graph = New System.Windows.Forms.DataVisualization.Charting.Chart()
        CType(Me.graph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label1.Name = "Label1"
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.MenuText
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.Name = "TextBox1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label2.Name = "Label2"
        '
        'TextBox2
        '
        Me.TextBox2.ForeColor = System.Drawing.SystemColors.MenuText
        resources.ApplyResources(Me.TextBox2, "TextBox2")
        Me.TextBox2.Name = "TextBox2"
        '
        'sort
        '
        Me.sort.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.sort.ForeColor = System.Drawing.SystemColors.MenuText
        resources.ApplyResources(Me.sort, "sort")
        Me.sort.Name = "sort"
        Me.sort.UseVisualStyleBackColor = True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label3.Name = "Label3"
        '
        'TextBox3
        '
        resources.ApplyResources(Me.TextBox3, "TextBox3")
        Me.TextBox3.ForeColor = System.Drawing.SystemColors.MenuText
        Me.TextBox3.Name = "TextBox3"
        '
        'reset
        '
        Me.reset.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.reset.ForeColor = System.Drawing.SystemColors.MenuText
        resources.ApplyResources(Me.reset, "reset")
        Me.reset.Name = "reset"
        Me.reset.UseVisualStyleBackColor = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label4.Name = "Label4"
        '
        'ascending
        '
        resources.ApplyResources(Me.ascending, "ascending")
        Me.ascending.BackColor = System.Drawing.Color.Transparent
        Me.ascending.ForeColor = System.Drawing.SystemColors.MenuText
        Me.ascending.Name = "ascending"
        Me.ascending.UseVisualStyleBackColor = False
        '
        'descending
        '
        resources.ApplyResources(Me.descending, "descending")
        Me.descending.BackColor = System.Drawing.Color.Transparent
        Me.descending.ForeColor = System.Drawing.SystemColors.MenuText
        Me.descending.Name = "descending"
        Me.descending.UseVisualStyleBackColor = False
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Name = "Label5"
        '
        'RadioButton1
        '
        resources.ApplyResources(Me.RadioButton1, "RadioButton1")
        Me.RadioButton1.BackColor = System.Drawing.SystemColors.Control
        Me.RadioButton1.Checked = True
        Me.RadioButton1.ForeColor = System.Drawing.SystemColors.Control
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.UseVisualStyleBackColor = False
        '
        'ExitButton
        '
        resources.ApplyResources(Me.ExitButton, "ExitButton")
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'graph
        '
        Me.graph.BackColor = System.Drawing.Color.Transparent
        ChartArea1.Name = "ChartArea1"
        Me.graph.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.graph.Legends.Add(Legend1)
        resources.ApplyResources(Me.graph, "graph")
        Me.graph.Name = "graph"
        Series1.ChartArea = "ChartArea1"
        Series1.Color = System.Drawing.Color.Silver
        Series1.Legend = "Legend1"
        Series1.Name = "Graph"
        Series1.ShadowColor = System.Drawing.Color.Silver
        Me.graph.Series.Add(Series1)
        '
        'Selection_Sort_Visualiser
        '
        Me.AcceptButton = Me.sort
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.reset
        Me.Controls.Add(Me.graph)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.descending)
        Me.Controls.Add(Me.ascending)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.reset)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.sort)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.SystemColors.InfoText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Selection_Sort_Visualiser"
        Me.TransparencyKey = System.Drawing.Color.LavenderBlush
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.graph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents sort As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents reset As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ascending As System.Windows.Forms.RadioButton
    Friend WithEvents descending As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents graph As System.Windows.Forms.DataVisualization.Charting.Chart

End Class
