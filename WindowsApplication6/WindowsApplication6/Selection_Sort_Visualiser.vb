Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Text.RegularExpressions

Public Class Selection_Sort_Visualiser
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles sort.Click
        sort.Enabled = False
        RadioButton1.Checked = False
        TextBox3.Clear()
        If TextBox1.Text = "" Then
            MessageBox.Show("Please enter array size!", "Warning!")
            sort.Enabled = True
            Exit Sub
        End If

        If TextBox2.Text = "" Then
            MessageBox.Show("Entered array is EMPTY!", "Warning")
            sort.Enabled = True
            Exit Sub
        End If
        If ascending.Checked = False And descending.Checked = False Then
            MessageBox.Show("Please select an order in which array is to be sorted!", "Warning")
            sort.Enabled = True
            Exit Sub
        End If
        ' *** ONE MORE PART, HOW TO RESTRICT USER FROM ENTERING MORE THAN N ENTERIES IN TEXTBOX
        ' *** MORE THAN N ENTERIES OR LESS THAN N ENTERIES --> SHOW A YES/NO QUESTION - TO BE DONE
        ' *** make dialog boxes reponsive
        ' *** limit array size and input size
        ' *** ctrl+V wali cheez dekh rha hun
        Dim numCheck As Decimal = CDec(TextBox1.Text)
        Dim n As Integer = 0
        
        
        ' First stored the textbox input in a string array
        Dim trim_string As String
        trim_string = Trim(TextBox2.Text)
        Dim pattern As String = "\s+"
        Dim regex As Regex = New Regex(pattern)
        Dim stringarr() As String = regex.Split(trim_string, trim_string.Length, 0)
        ' Converted the string array into a integer array
        Dim enteredNum(stringarr.Length - 1) As Decimal
        Dim btnArray(stringarr.Length - 1) As System.Windows.Forms.Button
        For i As Integer = 0 To stringarr.Length - 1
            btnArray(i) = New System.Windows.Forms.Button
        Next i
        For i As Decimal = 0 To stringarr.Length - 1
            Try
                enteredNum(i) = stringarr(i)
                If enteredNum(i) > 2147483647 Or enteredNum(i) < -2147483649 Then
                    MessageBox.Show("You can only enter decimal numbers in the range -2147483648 to 2147483648", "Warning!")
                    TextBox2.Clear()
                    sort.Enabled = True
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning")
            End Try
        Next
        For i As Decimal = 0 To stringarr.Length - 1
            Me.graph.Series("Graph").Points.AddXY(i, enteredNum(i))
        Next
        Dim a As Integer = (MyBase.Size.Width - (90 * stringarr.Length) + 150) / 2
        Dim l As Integer = (90 * stringarr.Length)
        graph.Location = New System.Drawing.Point(a, 414)
        graph.Size = New System.Drawing.Size(l, 375)
        graph.Visible = True

        Dim xPos As Integer = (MyBase.Size.Width - (43 * stringarr.Length)) / 2
        Dim yPos As Integer = 370
        While (n < stringarr.Length And RadioButton1.Checked = False)
            With (btnArray(n))
                .Tag = n + 1 ' Tag of button
                .Width = 43 ' Width of button
                .Height = 43 ' Height of button
                .Top = yPos  ' y coordinate of button
                .Left = xPos  ' x coordinate of button
                .Text = enteredNum(n)
                ' Add buttons to Form:            
                Me.Controls.Add(btnArray(n))
                xPos = xPos + .Width ' Left of next button
                n += 1
            End With
        End While
        ' Code checks which radio button is selected and sorts accordingly
        For i = 0 To enteredNum.Length - 2
            If ascending.Checked = True Then
                descending.Enabled = False
            Else
                ascending.Enabled = False
            End If
            Delay(0.45)
            graph.Series("Graph").Points(i).Color = Color.Red
            btnArray(i).BackColor = Color.Red
            Dim minIndex As Integer = i
            Dim mincheck As Integer = i
            Delay(0.45)
            If RadioButton1.Checked = True Then
                Exit For
            End If
            For j = i + 1 To enteredNum.Length - 1
                Delay(0.42)
                graph.Series("Graph").Points(j).Color = Color.LightSkyBlue
                btnArray(j).BackColor = Color.LightSkyBlue
                If enteredNum(j) < enteredNum(minIndex) And ascending.Checked = True Then
                    Delay(0.45)
                    graph.Series("Graph").Points(j).Color = Color.Yellow
                    btnArray(j).BackColor = Color.Yellow
                    minIndex = j
                ElseIf enteredNum(j) > enteredNum(minIndex) And descending.Checked = True Then
                    Delay(0.45)
                    graph.Series("Graph").Points(j).Color = Color.Yellow
                    btnArray(j).BackColor = Color.Yellow
                    minIndex = j
                Else
                    Delay(0.45)
                    graph.Series("Graph").Points(j).Color = Color.Silver
                    btnArray(j).BackColor = Color.Silver
                End If
                If mincheck = minIndex Then
                ElseIf mincheck > i Then
                    graph.Series("Graph").Points(mincheck).Color = Color.Silver
                    btnArray(mincheck).BackColor = Color.Silver
                End If
                If RadioButton1.Checked = True Then
                    Exit For
                End If
                mincheck = minIndex
            Next
            Dim temp As Decimal = enteredNum(i)
            If minIndex = i Then
                graph.Series("Graph").Points(i).Color = Color.LightGreen
                btnArray(i).BackColor = Color.LightGreen
            Else
                If RadioButton1.Checked = False Then
                    Dim tmpbtnArray(1) As System.Windows.Forms.Button
                    tmpbtnArray(0) = New System.Windows.Forms.Button
                    tmpbtnArray(1) = New System.Windows.Forms.Button
                    Dim x As Integer = 0
                    While (x < 2)
                        With (tmpbtnArray(x))
                            .Tag = n + 1 ' Tag of button
                            .Width = 43 ' Width of button
                            .Height = 43 ' Height of button
                            If x = 0 Then
                                .Top = btnArray(i).Top - 43 ' y coordinate of button
                                .Left = btnArray(i).Left ' x coordinate of button
                                .Text = btnArray(i).Text
                            Else
                                .Top = btnArray(minIndex).Top - 43 ' y coordinate of button
                                .Left = btnArray(minIndex).Left ' x coordinate of button
                                .Text = btnArray(minIndex).Text
                            End If
                            ' Add buttons to Form:            
                            Me.Controls.Add(tmpbtnArray(x))
                            x += 1
                        End With
                    End While
                    x = 0
                    tmpbtnArray(0).BackColor = Color.Red
                    tmpbtnArray(1).BackColor = Color.Yellow
                    For k As Integer = btnArray(i).Left To btnArray(minIndex).Left
                        Delay(0.03)
                        Me.Controls.Remove(tmpbtnArray(0))
                        Me.Controls.Remove(tmpbtnArray(1))
                       If RadioButton1.Checked = True Then
                            Exit For
                        End If
                        Me.Controls.Add(tmpbtnArray(0))
                        Me.Controls.Add(tmpbtnArray(1))
                        tmpbtnArray(0).Left = k
                        tmpbtnArray(1).Left = btnArray(minIndex).Left - k + btnArray(i).Left
                        k += 5
                    Next
                    If RadioButton1.Checked = True Then
                        Exit For
                    Else
                        enteredNum(i) = enteredNum(minIndex)
                        enteredNum(minIndex) = temp
                        Delay(0.45)
                        graph.Series("Graph").Points.ElementAt(i).SetValueY(enteredNum(i))
                        graph.Series("Graph").Points.ElementAt(minIndex).SetValueY(temp)
                        btnArray(i).Text = enteredNum(i)
                        btnArray(minIndex).Text = temp
                    End If
                    While (x < 2)
                        With (tmpbtnArray(x))                       'remove buttons from Form:            
                            Me.Controls.Remove(tmpbtnArray(x))
                            x += 1
                        End With
                    End While
                End If
                If RadioButton1.Checked = True Then
                    Exit For
                Else
                    graph.Series("Graph").Points(minIndex).Color = Color.Silver
                    graph.Series("Graph").Points(i).Color = Color.LightGreen
                    btnArray(minIndex).BackColor = Color.Silver
                    btnArray(i).BackColor = Color.LightGreen
                    Delay(0.45)
                End If
            End If
        Next
        btnArray(stringarr.Length - 1).BackColor = Color.LightGreen
        graph.Series("Graph").Points(stringarr.Length - 1).Color = Color.LightGreen
        If RadioButton1.Checked = True Then
        Else
            Delay(5) 'The time array stays in picture
        End If
        ' Sorted the string array according to our integer array
        For i As Integer = 0 To enteredNum.Length - 1
            stringarr(i) = enteredNum(i)
        Next
        Dim txtOutput As String = ""
        txtOutput = Join(stringarr, " ")
        TextBox3.Text = txtOutput
        If RadioButton1.Checked = True Then
            TextBox3.Text = ""
        End If
        n = 0
        While (n < stringarr.Length)
            With (btnArray(n))
                'remove buttons from Form:            
                Me.Controls.Remove(btnArray(n))
                n += 1
            End With
        End While
        graph.Series("Graph").Points.Clear()
        graph.Visible = False
        ascending.Enabled = True
        descending.Enabled = True
        sort.Enabled = True
    End Sub

    ' Reset is both radio button as well as normal button
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles reset.Click
        RadioButton1.Checked = True
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
    End Sub

    ' Checking whether the size of input array is actually a positive integer or not
    ' Overflow has to be done next - STILL NOT DONE
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Asc(e.KeyChar) = 8 And (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) Then
            e.Handled = True
            MessageBox.Show("You can only input integer here!", "Warning!")
        End If
        ' checking bounding limitations of textbox 1
        If Not (String.IsNullOrEmpty(TextBox1.Text)) Then
            If CDec(TextBox1.Text) > 2147483647 And Not Asc(e.KeyChar) = 8 Then
                MessageBox.Show("You can only sort less than 2147483647 numbers", "Warning!")
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBox2.KeyPress
        ' Checking if textbox1 is empty before filling textbox2
        If String.IsNullOrEmpty(TextBox1.Text) Then
            MessageBox.Show("First fill the amount of numbers you want to sort", "Warning!")
            TextBox2.Clear()
        End If

        ' Allowing the key press to be only integers, Ctrl+C/V/X/A/Z/-/+ , Backspace, Whitespace
        If (Asc(e.KeyChar) < 3 And Asc(e.KeyChar) <> 1) Or (Asc(e.KeyChar) > 3 And Asc(e.KeyChar) < 8) Or (Asc(e.KeyChar) > 8 And Asc(e.KeyChar) < 22) Or Asc(e.KeyChar) = 23 Or (Asc(e.KeyChar) > 24 And Asc(e.KeyChar) < 32 And Asc(e.KeyChar) <> 26) Or (Asc(e.KeyChar) > 32 And Asc(e.KeyChar) < 45 And Asc(e.KeyChar) <> 43) Or Asc(e.KeyChar) = 47 Or Asc(e.KeyChar) > 57 Then
            e.Handled = True
            MessageBox.Show("You can only input space separated decimals here!", "Warning!")
        End If
        ' checking bounding limitations of textbox 1
        If Not (String.IsNullOrEmpty(TextBox1.Text)) Then
            If CDec(TextBox1.Text) > 2147483647 Then
                MessageBox.Show("You can only sort less than 2147483647 numbers", "Warning!")
                TextBox1.Clear()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ascending.Checked = True
    End Sub

    Sub Delay(ByVal dblSecs As Double)
        Const onesec As Double = 1.0# / (1440.0# * 60.0#)
        Dim dblwaittil As Date
        Now.AddSeconds(onesec)
        dblwaittil = Now.AddSeconds(onesec).AddSeconds(dblSecs)
        Do Until Now > dblwaittil
            Application.DoEvents()
        Loop
    End Sub

    Public Function RemoveWhiteSpaces(ByVal text As String) As String
        Dim result As String = String.Empty
        Dim textCharArr As Char() = Text.ToCharArray
        Dim prevChar As Char = " "c ' white space character
        For i As Integer = 0 To textCharArr.Length - 1
            Dim currentChar = textCharArr(i)
            If Not (prevChar = " "c AndAlso currentChar = prevChar) Then
                result += currentChar
            End If
            prevChar = currentChar ' update for next cycle
        Next
        Return result
    End Function

    ' If by mistake radio button is clicked, then also clear things done by reset button
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            reset.PerformClick()
        End If
    End Sub

    Private Sub Chart1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        reset.PerformClick()
        Delay(1)
        Me.Close()
    End Sub
End Class