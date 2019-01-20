Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Text.RegularExpressions

Public Class Form1
    Public MaxValue As Integer = 2147483647
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles sort.Click
        'sort.Enabled = False                I COMMENTED IT NAVEEN, YOUR CODE HAD IT UNCOMMENTED

        TextBox3.Clear()
        ' *** ONE MORE PART, HOW TO RESTRICT USER FROM ENTERING MORE THAN N ENTERIES IN TEXTBOX
        ' *** MORE THAN N ENTERIES OR LESS THAN N ENTERIES --> SHOW A YES/NO QUESTION - TO BE DONE
        ' *** See how many decimal digits are allowed, kaafi jyada daal di to problem in code
        ' *** Array ki limit dekhni hai, visualisation wali array ki
        ' *** Decide what ranges of number we will sort
        ' *** RESPONSIVE WINDOW
        ' *** control + V se I can input characters in first two check boxes
        ' *** PUCHNA HAI STRING SORT KARNI HAI YA ARRAY
        Dim numCheck As Decimal = CDec(TextBox1.Text)
        Dim n As Integer = 0

        ' before pressing sort button, fill out the first two entries
        If String.IsNullOrEmpty(TextBox1.Text) Or String.IsNullOrEmpty(TextBox2.Text) Then
            MessageBox.Show("First fill the required enteries before sorting", "Warning!")
            Exit Sub
        End If

        ' also before pressing sort, check man if whether ascending or desceding is selected
        If Not (RadioButton1.Checked) And Not (RadioButton2.Checked) Then
            MessageBox.Show("Choose a method to sort, ascending or descending", "Warning!")
        End If


        ' First stored the textbox input in a string array
        Dim trim_string As String
        trim_string = Trim(TextBox2.Text)
        Dim pattern As String = "\s+"
        Dim regex As Regex = New Regex(pattern)
        Dim stringarr() As String = regex.Split(trim_string, trim_string.Length, 0)


        ' Converted the string array into a integer array
        Dim enteredNum(stringarr.Length - 1) As Decimal
        Dim btnArray(stringarr.Length - 1) As System.Windows.Forms.Button
        For i As Decimal = 0 To stringarr.Length - 1
            enteredNum(i) = stringarr(i)
            If enteredNum(i) > 2147483647 Or enteredNum(i) < -2147483649 Then
                MessageBox.Show("You can only enter decimal numbers in the range -2147483648 to 2147483648", "Warning!")
                TextBox2.Clear()
                Exit Sub
            End If
        Next
        For i As Integer = 0 To stringarr.Length - 1
            btnArray(i) = New System.Windows.Forms.Button
        Next i


        Dim xPos As Integer = 423
        Dim yPos As Integer = 510
        While (n < stringarr.Length)
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
        If RadioButton1.Checked Then
            For i = 0 To enteredNum.Length - 2
                Delay(0.45)
                btnArray(i).BackColor = Color.Red
                Dim minIndex As Integer = i
                Dim mincheck As Integer = i
                For j = i + 1 To enteredNum.Length - 1
                    Delay(0.45)
                    btnArray(j).BackColor = Color.LightSkyBlue
                    If enteredNum(j) < enteredNum(minIndex) Then
                        Delay(0.45)
                        btnArray(j).BackColor = Color.Yellow
                        minIndex = j
                    Else
                        Delay(0.45)
                        btnArray(j).BackColor = Color.White
                    End If
                    If mincheck = minIndex Then
                    ElseIf mincheck > i Then
                        btnArray(mincheck).BackColor = Color.White
                    End If
                    mincheck = minIndex
                Next
                Dim temp As Decimal = enteredNum(i)
                If minIndex = i Then
                Else

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
                                .Top = btnArray(i).Top + 43 ' y coordinate of button
                                .Left = btnArray(i).Left ' x coordinate of button
                                .Text = btnArray(i).Text
                            Else
                                .Top = btnArray(minIndex).Top + 43 ' y coordinate of button
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

                        Delay(0.05)
                        Me.Controls.Remove(tmpbtnArray(0))
                        Me.Controls.Remove(tmpbtnArray(1))
                        tmpbtnArray(0).Left = k
                        tmpbtnArray(1).Left = btnArray(minIndex).Left - k + btnArray(i).Left
                        Me.Controls.Add(tmpbtnArray(0))
                        Me.Controls.Add(tmpbtnArray(1))
                        k += 5
                    Next
                    enteredNum(i) = enteredNum(minIndex)
                    enteredNum(minIndex) = temp
                    Delay(0.45)
                    btnArray(i).Text = enteredNum(i)
                    btnArray(minIndex).Text = temp
                    While (x < 2)
                        With (tmpbtnArray(x))                       'remove buttons from Form:            
                            Me.Controls.Remove(tmpbtnArray(x))
                            x += 1
                        End With
                    End While
                    btnArray(minIndex).BackColor = Color.White
                    btnArray(i).BackColor = Color.LightGreen
                    Delay(0.45)
                End If
            Next
            btnArray(stringarr.Length - 1).BackColor = Color.LightGreen
            Delay(2)
            ' Sorted the string array according to our integer array
            For i As Integer = 0 To enteredNum.Length - 1
                stringarr(i) = enteredNum(i)
            Next
            Dim txtOutput As String = ""
            txtOutput = Join(stringarr, " ")
            TextBox3.Text = txtOutput
        End If

        ' Code checks which radio button is selected and sorts accordingly
        If RadioButton2.Checked Then
            For i As Integer = 0 To enteredNum.Length - 2
                Delay(0.45)
                btnArray(i).BackColor = Color.Red
                Dim mincheck As Integer = i
                Dim maxIndex As Integer = i
                For j As Integer = i + 1 To enteredNum.Length - 1
                    Delay(0.45)
                    btnArray(j).BackColor = Color.LightSkyBlue
                    If enteredNum(j) > enteredNum(maxIndex) Then
                        Delay(0.45)
                        btnArray(j).BackColor = Color.Yellow
                        maxIndex = j
                    Else
                        Delay(0.45)
                        btnArray(j).BackColor = Color.White
                    End If
                    If mincheck = maxIndex Then
                    ElseIf mincheck > i Then
                        btnArray(mincheck).BackColor = Color.White
                    End If
                    mincheck = maxIndex
                Next
                Dim temp As Decimal = enteredNum(i)
                If maxIndex = i Then
                Else
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
                                .Top = btnArray(i).Top + 43 ' y coordinate of button
                                .Left = btnArray(i).Left ' x coordinate of button
                                .Text = btnArray(i).Text
                            Else
                                .Top = btnArray(maxIndex).Top + 43 ' y coordinate of button
                                .Left = btnArray(maxIndex).Left ' x coordinate of button
                                .Text = btnArray(maxIndex).Text
                            End If
                            ' Add buttons to Form:            
                            Me.Controls.Add(tmpbtnArray(x))
                            x += 1
                        End With
                    End While
                    x = 0
                    tmpbtnArray(0).BackColor = Color.Red
                    tmpbtnArray(1).BackColor = Color.Yellow
                    For k As Integer = btnArray(i).Left To btnArray(maxIndex).Left

                        Delay(0.05)
                        Me.Controls.Remove(tmpbtnArray(0))
                        Me.Controls.Remove(tmpbtnArray(1))
                        tmpbtnArray(0).Left = k
                        tmpbtnArray(1).Left = btnArray(maxIndex).Left - k + btnArray(i).Left
                        Me.Controls.Add(tmpbtnArray(0))
                        Me.Controls.Add(tmpbtnArray(1))
                        k += 5
                    Next
                    enteredNum(i) = enteredNum(maxIndex)
                    enteredNum(maxIndex) = temp
                    Delay(0.45)
                    While (x < 2)
                        With (tmpbtnArray(x))                       'remove buttons from Form:            
                            Me.Controls.Remove(tmpbtnArray(x))
                            x += 1
                        End With
                    End While
                    btnArray(i).Text = enteredNum(i)
                    btnArray(maxIndex).Text = temp
                    btnArray(maxIndex).BackColor = Color.White
                    btnArray(i).BackColor = Color.LightGreen
                    Delay(0.45)
                End If
            Next
            btnArray(stringarr.Length - 1).BackColor = Color.LightGreen
            Delay(2)
            ' Sorted the string array according to our integer array
            For i As Integer = 0 To enteredNum.Length - 1
                stringarr(i) = enteredNum(i)
            Next
            Dim txtOutput As String = ""
            txtOutput = Join(stringarr, " ")
            TextBox3.Text = txtOutput
        End If
        n = 0
        While (n < stringarr.Length)
            With (btnArray(n))
                'remove buttons from Form:            
                Me.Controls.Remove(btnArray(n))
                n += 1
            End With
        End While
        sort.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles reset.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
    End Sub

    ' Allowing the key press to be only integers, Ctrl+C/V/X/A/Z/+ , Backspace
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If (Asc(e.KeyChar) < 3 And Asc(e.KeyChar) <> 1) Or (Asc(e.KeyChar) > 3 And Asc(e.KeyChar) < 8) Or (Asc(e.KeyChar) > 8 And Asc(e.KeyChar) < 22) Or Asc(e.KeyChar) = 23 Or (Asc(e.KeyChar) > 24 And Asc(e.KeyChar) < 48 And Asc(e.KeyChar) <> 26 And Asc(e.KeyChar) <> 43) Or Asc(e.KeyChar) > 57 Then
            e.Handled = True
            MessageBox.Show("You can only input integer here!", "Warning!")
        End If
    End Sub

    ' Error handling module
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
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
End Class

