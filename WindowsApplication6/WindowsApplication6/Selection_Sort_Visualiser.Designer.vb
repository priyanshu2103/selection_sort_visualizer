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
        Me.components = New System.ComponentModel.Container()
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
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.graph = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Alphabatically = New System.Windows.Forms.Button()
        Me.Lexicographically = New System.Windows.Forms.Button()
        Me.Numerical = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.play_pause = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.graph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
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
        Me.sort.BackColor = System.Drawing.Color.Cyan
        Me.sort.Cursor = System.Windows.Forms.Cursors.Hand
        Me.sort.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.sort, "sort")
        Me.sort.ForeColor = System.Drawing.SystemColors.MenuText
        Me.sort.Name = "sort"
        Me.sort.UseVisualStyleBackColor = False
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
        Me.TextBox3.ReadOnly = True
        '
        'reset
        '
        Me.reset.BackColor = System.Drawing.Color.Chartreuse
        Me.reset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.reset.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.reset, "reset")
        Me.reset.ForeColor = System.Drawing.SystemColors.MenuText
        Me.reset.Name = "reset"
        Me.reset.UseVisualStyleBackColor = False
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
        Me.ascending.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ascending.ForeColor = System.Drawing.SystemColors.MenuText
        Me.ascending.Name = "ascending"
        Me.ascending.UseVisualStyleBackColor = False
        '
        'descending
        '
        resources.ApplyResources(Me.descending, "descending")
        Me.descending.BackColor = System.Drawing.Color.Transparent
        Me.descending.Cursor = System.Windows.Forms.Cursors.Hand
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
        'ExitButton
        '
        Me.ExitButton.BackColor = System.Drawing.Color.Tomato
        Me.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.ExitButton, "ExitButton")
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.UseVisualStyleBackColor = False
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
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.ForeColor = System.Drawing.Color.SlateBlue
        Me.Label6.Name = "Label6"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Orange
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.MenuText
        Me.Panel1.Controls.Add(Me.Alphabatically)
        Me.Panel1.Controls.Add(Me.Lexicographically)
        Me.Panel1.Controls.Add(Me.Numerical)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'Alphabatically
        '
        Me.Alphabatically.BackColor = System.Drawing.Color.LightSlateGray
        Me.Alphabatically.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Alphabatically, "Alphabatically")
        Me.Alphabatically.Name = "Alphabatically"
        Me.Alphabatically.UseVisualStyleBackColor = False
        '
        'Lexicographically
        '
        Me.Lexicographically.BackColor = System.Drawing.Color.IndianRed
        Me.Lexicographically.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Lexicographically, "Lexicographically")
        Me.Lexicographically.Name = "Lexicographically"
        Me.Lexicographically.UseVisualStyleBackColor = False
        '
        'Numerical
        '
        Me.Numerical.BackColor = System.Drawing.Color.DarkKhaki
        Me.Numerical.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Numerical, "Numerical")
        Me.Numerical.Name = "Numerical"
        Me.Numerical.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Name = "Label8"
        '
        'play_pause
        '
        resources.ApplyResources(Me.play_pause, "play_pause")
        Me.play_pause.Name = "play_pause"
        Me.play_pause.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        resources.ApplyResources(Me.LinkLabel1, "LinkLabel1")
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.TabStop = True
        '
        'LinkLabel2
        '
        resources.ApplyResources(Me.LinkLabel2, "LinkLabel2")
        Me.LinkLabel2.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.TabStop = True
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Name = "Label11"
        '
        'TextBox4
        '
        resources.ApplyResources(Me.TextBox4, "TextBox4")
        Me.TextBox4.Name = "TextBox4"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Name = "Label7"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'Selection_Sort_Visualiser
        '
        Me.AcceptButton = Me.sort
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.reset
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.play_pause)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.graph)
        Me.Controls.Add(Me.ExitButton)
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
        Me.Panel1.ResumeLayout(False)
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
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents graph As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Lexicographically As System.Windows.Forms.Button
    Friend WithEvents Alphabatically As System.Windows.Forms.Button
    Friend WithEvents Numerical As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents play_pause As System.Windows.Forms.Button
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label

End Class
