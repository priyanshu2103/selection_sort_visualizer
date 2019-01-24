﻿' *** ONE LIMITATION - If click on the type of sorting and don't click that type of sort button again, those three options won't disappear. We couldn't 
'     fix that due to lack of time


Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports System.IO

Public Class Selection_Sort_Visualiser
    Private SaveFileDialog1 As SaveFileDialog
    Private OpenFileDialog1 As OpenFileDialog
    Dim play As Boolean = True
    Dim Resetbtn As Boolean = False
    Dim Numb As Boolean = False
    Dim Alpha As Boolean = False
    Dim Lexi As Boolean = False
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles sort.Click
        TextBox4.Text = ""
        TextBox4.Visible = False
        ' First stored the textbox input in a string array
        Dim trim_string As String
        trim_string = Trim(TextBox2.Text)
        Dim pattern As String = "\s+"
        Dim regex As Regex = New Regex(pattern)  ' trimming the array for white spaces
        Dim stringarr() As String = regex.Split(trim_string, trim_string.Length, 0)
        'checking the size of string array
        Try
            Dim num As Decimal = CDec(TextBox1.Text)
            If stringarr.Length > num Then
                MessageBox.Show("More number of elements than array size", "Warning!")
                sort.Enabled = True
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Please, enter valid input ", "Warning")
            sort.Enabled = True
            Exit Sub
        End Try
        sort.Enabled = False
        Resetbtn = False
        TextBox3.Clear() 'clear output box

        ' before pressing sort button, fill out the first two entries
        If TextBox1.Text = "" Or CInt(TextBox1.Text) > 100 Then
            MessageBox.Show("Please enter valid array size!", "Warning!")
            sort.Enabled = True
            Exit Sub
        End If
        ' before pressing sort button, fill out the first two entries
        If TextBox2.Text = "" Then
            MessageBox.Show("Entered array is EMPTY!", "Warning")
            sort.Enabled = True
            Exit Sub
        End If
        ' also before pressing sort, check man if whether ascending or desceding is selected
        If ascending.Checked = False And descending.Checked = False Then
            MessageBox.Show("Please select an order in which array is to be sorted!", "Warning")
            sort.Enabled = True
            Exit Sub
        End If

        ' checking if the input of 1st checkbox is valid or not
        Try
            Dim checker_string As String = TextBox1.Text
            For i As Integer = 0 To checker_string.Length - 1
                If AscW(checker_string(i)) < 48 Or AscW(checker_string(i)) > 57 Then
                    MessageBox.Show("You can only enter integers!!", "Warning!")
                    TextBox1.Clear()
                    sort.Enabled = True
                    Exit Sub
                End If
            Next
        Catch ex As Exception
        End Try
        sort_novis() ' for output box
        TextBox4.Visible = False
        ' if more than 17 entries, no visualisation and only sorting
        Dim numCheck As Decimal = CDec(TextBox1.Text)
        'if user doesn't want visualisation
        If numCheck > 17 Or Visualisation_check.Checked = False Then
            sort_novis()
            Exit Sub
        End If
        ' if user has not entered numerical sorting, we will switch to other module of Lexicographical alpha sort
        If Lexi = True Or Alpha = True Then
            Lexi_Alpha_sort()
            Exit Sub
        End If
        Dim n As Integer = 0
        ' Converted the string array into a integer array
        Dim enteredNum(stringarr.Length - 1) As Decimal
        For i As Decimal = 0 To stringarr.Length - 1
            ' limiting the numbers in the range -999 to +999 for visualisation, so checking this part
            Try
                enteredNum(i) = stringarr(i)
                If enteredNum(i) > 999 Or enteredNum(i) < -999 Then
                    MessageBox.Show("No visualisation, Numbers exceed visualisation range", "Warning!")
                    sort_novis()
                    sort.Enabled = True
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show("Please, enter valid input ", "Warning")
                sort.Enabled = True
                Exit Sub
            End Try
        Next
        Dim btnArray(stringarr.Length - 1) As System.Windows.Forms.Button
        For i As Integer = 0 To stringarr.Length - 1   ' making the button array and initialising it
            btnArray(i) = New System.Windows.Forms.Button
        Next i
        ' adding the entries of values in graph
        For i As Decimal = 0 To stringarr.Length - 1
            Me.graph.Series("Graph").Points.AddXY(i, enteredNum(i))
        Next
        Dim a As Integer = (MyBase.Size.Width - (90 * stringarr.Length) + 150) / 2  ' these two lines set the base for the graph
        Dim l As Integer = (90 * stringarr.Length)
        graph.Location = New System.Drawing.Point(Min(a, 500), 414)
        graph.Size = New System.Drawing.Size(max(l, 500), 375)    ' max used here because even if size of graph is small, we have a minimum size of graph
        graph.Visible = True

        Dim xPos As Integer = (MyBase.Size.Width - (43 * stringarr.Length)) / 2  ' these two lines set the location for making the button array
        Dim yPos As Integer = 370
        While (n < stringarr.Length And Resetbtn = False)
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
        ' location of the play and pause buttons
        play_pause.Top = yPos + 10
        play_pause.Left = xPos + 20
        play_pause.Text = "Pause"
        play_pause.Visible = True
        ' Code checks which radio button is selected and sorts accordingly
        For i = 0 To enteredNum.Length - 2
            If ascending.Checked = True Then
                descending.Enabled = False
            Else
                ascending.Enabled = False
            End If
            Delay(0.45)
            Label6.Text = ("Selected " + CStr(enteredNum(i)))   ' this is the label which tells us about the elements that are currently being compared
            graph.Series("Graph").Points(i).Color = Color.Red
            btnArray(i).BackColor = Color.Red    ' current element is coloured red
            Dim minIndex As Integer = i
            Dim mincheck As Integer = i    ' mincheck variable is assigned so that while comparing the array, if we find one smallest element and then find another smaller element, this mincheck helps in changing colour
            Delay(0.45)   ' this delay is for changing colour
            If play = False Then
                pausetill()
            End If
            If Resetbtn = True Then
                Exit For
            End If
            Label6.Visible = True
            For j = i + 1 To enteredNum.Length - 1
                Delay(0.42)
                Label6.Text = ("Comparing " + CStr(enteredNum(i)) + " with " + CStr(enteredNum(j)))
                graph.Series("Graph").Points(j).Color = Color.LightSkyBlue ' selecting for comparison
                btnArray(j).BackColor = Color.LightSkyBlue
                If play = False Then
                    pausetill()
                End If
                ' comparing the buttons and changing the colour... light silver means processed button but not the smallest, yellow is smallest element in that pass
                If enteredNum(j) < enteredNum(minIndex) And ascending.Checked = True Then
                    Delay(0.45)
                    Label6.Text = ("Smaller Element Found " + CStr(enteredNum(j)))
                    graph.Series("Graph").Points(j).Color = Color.Yellow   ' changing the colour in graph
                    btnArray(j).BackColor = Color.Yellow
                    minIndex = j
                ElseIf enteredNum(j) > enteredNum(minIndex) And descending.Checked = True Then
                    Delay(0.45)
                    Label6.Text = ("Larger Element Found " + CStr(enteredNum(j)))
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
                    If play = False Then
                        pausetill()
                    End If
                    graph.Series("Graph").Points(mincheck).Color = Color.Silver 'if more smaller or larger one found change color back to silver for ascending and descending repectively
                    btnArray(mincheck).BackColor = Color.Silver
                End If
                If play = False Then 'play or pause comparision
                    pausetill()
                End If
                If Resetbtn = True Then
                    Exit For
                End If
                mincheck = minIndex
            Next
            Dim temp As Decimal = enteredNum(i)
            If play = False Then
                pausetill()
            End If
            ' this is for changing the color in graph
            If minIndex = i Then
                graph.Series("Graph").Points(i).Color = Color.LightGreen
                btnArray(i).BackColor = Color.LightGreen
            Else
                ' for showing the swapping, we are making to extra buttons 
                If Resetbtn = False Then
                    Dim tmpbtnArray(1) As System.Windows.Forms.Button
                    tmpbtnArray(0) = New System.Windows.Forms.Button
                    tmpbtnArray(1) = New System.Windows.Forms.Button
                    Dim x As Integer = 0
                    If play = False Then
                        pausetill()
                    End If
                    While (x < 2)
                        With (tmpbtnArray(x))
                            .Tag = n + 1 ' Tag of button
                            .Width = 43 ' Width of button
                            .Height = 43 ' Height of button
                            If x = 0 Then
                                .Top = btnArray(i).Top - 43 ' y coordinate of button
                                .Left = btnArray(i).Left ' x coordinate of button
                                .Text = btnArray(i).Text  ' we made the buttons above the numbers that need to be swapped and added the data on the buttons
                            Else
                                .Top = btnArray(minIndex).Top - 43 ' y coordinate of button
                                .Left = btnArray(minIndex).Left ' x coordinate of button
                                .Text = btnArray(minIndex).Text  ' we made the buttons above the numbers that need to be swapped and added the data on the buttons
                            End If
                            ' Add buttons to Form:            
                            Me.Controls.Add(tmpbtnArray(x))
                            x += 1
                        End With
                    End While
                    x = 0
                    ' changing the color of buttons
                    tmpbtnArray(0).BackColor = Color.Red
                    tmpbtnArray(1).BackColor = Color.Yellow
                    Label6.Text = ("Swapping " + CStr(enteredNum(i)) + " And " + CStr(enteredNum(minIndex)))
                    For k As Integer = btnArray(i).Left To btnArray(minIndex).Left
                        Delay(0.03)
                        If play = False Then 'play pause swapping
                            pausetill()
                        End If
                        Me.Controls.Remove(tmpbtnArray(0))
                        Me.Controls.Remove(tmpbtnArray(1))
                        If Resetbtn = True Then
                            Exit For
                        End If
                        Me.Controls.Add(tmpbtnArray(0))
                        Me.Controls.Add(tmpbtnArray(1))
                        If play = False Then
                            pausetill()
                        End If
                        tmpbtnArray(0).Left = k
                        tmpbtnArray(1).Left = btnArray(minIndex).Left - k + btnArray(i).Left
                        k += 5
                    Next
                    If play = False Then
                        pausetill()
                    End If
                    If Resetbtn = True Then
                        Exit For
                    Else
                        'swapping values
                        enteredNum(i) = enteredNum(minIndex)
                        enteredNum(minIndex) = temp
                        Delay(0.45)
                        graph.Series("Graph").Points.ElementAt(i).SetValueY(enteredNum(i))
                        graph.Series("Graph").Points.ElementAt(minIndex).SetValueY(temp)
                        btnArray(i).Text = enteredNum(i)
                        btnArray(minIndex).Text = temp
                        Label6.Text = ("Swapping done")
                    End If
                    While (x < 2)
                        With (tmpbtnArray(x))                       'remove buttons from Form:            
                            Me.Controls.Remove(tmpbtnArray(x))
                            x += 1
                        End With
                    End While
                End If
                If play = False Then
                    pausetill()
                End If
                If Resetbtn = True Then
                    Exit For
                Else
                    'colour of final element
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
        Label6.Text = ("Array Sorted")
        If play = False Then
            pausetill()
        End If
        If Resetbtn = True Then
        Else
            Delay(3) 'The time array stays in picture
        End If
        ' Sorted the string array according to our integer array
        For i As Integer = 0 To enteredNum.Length - 1
            stringarr(i) = enteredNum(i)
        Next
        Dim txtOutput As String = ""
        txtOutput = Join(stringarr, " ")
        TextBox3.Text = txtOutput
        If Resetbtn = True Then
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
        graph.Series("Graph").Points.Clear() 'clearing graph
        Label6.Visible = False
        graph.Visible = False
        ascending.Enabled = True
        descending.Enabled = True
        sort.Enabled = True
        play_pause.Visible = False
    End Sub
    Sub Lexi_Alpha_sort()
        'making input acceptable
        Dim n As Integer = 0
        Dim trim_string As String
        trim_string = Trim(TextBox2.Text)
        Dim pattern As String = "\s+"
        Dim regex As Regex = New Regex(pattern)
        Dim stringarr() As String = regex.Split(trim_string, trim_string.Length, 0)
        Dim xPos As Integer = (MyBase.Size.Width - (59 * stringarr.Length)) / 2
        Dim yPos As Integer = 470
        'if no visualiastion is selected
        For i As Integer = 0 To stringarr.Length - 1
            If stringarr(i).Length > 5 Or Visualisation_check.Checked = False Then
                MessageBox.Show("No Visualisation, Strings of length more than 5", "Warning!")
                sort_novis()
                sort.Enabled = True
                Exit Sub
            End If
        Next i
        Dim btnArray(stringarr.Length - 1) As System.Windows.Forms.Button 'declaring button array
        For i As Integer = 0 To stringarr.Length - 1
            btnArray(i) = New System.Windows.Forms.Button 'initialing button array
        Next i
        While (n < stringarr.Length And Resetbtn = False)
            With (btnArray(n))
                .Tag = n + 1 ' Tag of button
                .Width = 59 ' Width of button
                .Height = 59 ' Height of button
                .Top = yPos  ' y coordinate of button
                .Left = xPos  ' x coordinate of button
                .Text = stringarr(n)
                ' Add buttons to Form:            
                Me.Controls.Add(btnArray(n))
                xPos = xPos + .Width ' Left of next button
                n += 1
            End With
        End While
        'play pause location
        play_pause.Top = yPos + 10
        play_pause.Left = xPos + 20
        play_pause.Text = "Pause"
        play_pause.Visible = True
        ' Code checks which radio button is selected and sorts accordingly
        For i = 0 To stringarr.Length - 2
            If ascending.Checked = True Then
                descending.Enabled = False
            Else
                ascending.Enabled = False
            End If
            Delay(0.45)
            Label6.Text = ("Selected " + CStr(stringarr(i)))
            btnArray(i).BackColor = Color.Red
            Dim minIndex As Integer = i
            Dim mincheck As Integer = i
            Delay(0.45)
            If Resetbtn = True Then
                Exit For
            End If
            Label6.Visible = True
            For j = i + 1 To stringarr.Length - 1
                Delay(0.42)
                Label6.Text = ("Comparing " + CStr(stringarr(i)) + " with " + CStr(stringarr(j)))
                btnArray(j).BackColor = Color.LightSkyBlue 'selecting next element for comparision
                If play = False Then
                    pausetill()
                End If
                'comparing elements and chooses accordingly
                If stringarr(j).ToUpper < stringarr(minIndex).ToUpper And ascending.Checked = True And Alpha = True Then
                    Delay(0.45)
                    Label6.Text = ("Smaller Element Found " + CStr(stringarr(j)))
                    btnArray(j).BackColor = Color.Yellow
                    minIndex = j
                ElseIf stringarr(j).ToUpper > stringarr(minIndex).ToUpper And descending.Checked = True And Alpha = True Then
                    Delay(0.45)
                    Label6.Text = ("Larger Element Found " + CStr(stringarr(j)))
                    btnArray(j).BackColor = Color.Yellow
                    minIndex = j
                ElseIf stringarr(j).ToUpper = stringarr(minIndex).ToUpper Or Lexi = True Then
                    If stringarr(j) < stringarr(minIndex) And ascending.Checked = True Then
                        Delay(0.45)
                        Label6.Text = ("Smaller Element Found " + CStr(stringarr(j)))
                        btnArray(j).BackColor = Color.Yellow
                        minIndex = j
                        If play = False Then
                            pausetill()
                        End If
                    ElseIf stringarr(j) > stringarr(minIndex) And descending.Checked = True Then
                        Delay(0.45)
                        Label6.Text = ("Larger Element Found " + CStr(stringarr(j)))
                        btnArray(j).BackColor = Color.Yellow
                        minIndex = j
                    End If
                    If play = False Then
                        pausetill()
                    End If
                Else
                    Delay(0.45)
                    btnArray(j).BackColor = Color.Silver
                End If
                If mincheck = minIndex Then
                ElseIf mincheck > i Then
                    btnArray(mincheck).BackColor = Color.Silver
                End If
                If play = False Then
                    pausetill()
                End If
                If Resetbtn = True Then
                    Exit For
                End If
                mincheck = minIndex
            Next
            Dim temp As String = stringarr(i)
            If play = False Then
                pausetill()
            End If
            If minIndex = i Then
                btnArray(i).BackColor = Color.LightGreen
            Else
                If Resetbtn = False Then
                    Dim tmpbtnArray(1) As System.Windows.Forms.Button 'button array
                    tmpbtnArray(0) = New System.Windows.Forms.Button 'initialising array
                    tmpbtnArray(1) = New System.Windows.Forms.Button
                    Dim x As Integer = 0
                    If play = False Then
                        pausetill()
                    End If
                    While (x < 2)
                        With (tmpbtnArray(x))
                            .Tag = n + 1 ' Tag of button
                            .Width = 59 ' Width of button
                            .Height = 59 ' Height of button
                            If x = 0 Then
                                .Top = btnArray(i).Top - 59 ' y coordinate of button
                                .Left = btnArray(i).Left ' x coordinate of button
                                .Text = btnArray(i).Text
                            Else
                                .Top = btnArray(minIndex).Top - 59 ' y coordinate of button
                                .Left = btnArray(minIndex).Left ' x coordinate of button
                                .Text = btnArray(minIndex).Text
                            End If
                            ' Add buttons to Form:            
                            Me.Controls.Add(tmpbtnArray(x))
                            x += 1
                        End With
                    End While
                    x = 0
                    tmpbtnArray(0).BackColor = Color.Red 'giving color
                    tmpbtnArray(1).BackColor = Color.Yellow
                    Label6.Text = ("Swapping " + CStr(stringarr(i)) + " And " + CStr(stringarr(minIndex)))
                    'swapping button algo
                    For k As Integer = btnArray(i).Left To btnArray(minIndex).Left
                        Delay(0.03)
                        If play = False Then ' to pause during swapping
                            pausetill()
                        End If
                        Me.Controls.Remove(tmpbtnArray(0))
                        Me.Controls.Remove(tmpbtnArray(1))
                        If Resetbtn = True Then
                            Exit For
                        End If
                        Me.Controls.Add(tmpbtnArray(0))
                        Me.Controls.Add(tmpbtnArray(1))
                        If play = False Then
                            pausetill()
                        End If
                        tmpbtnArray(0).Left = k
                        tmpbtnArray(1).Left = btnArray(minIndex).Left - k + btnArray(i).Left
                        k += 5
                    Next
                    If play = False Then
                        pausetill()
                    End If
                    If Resetbtn = True Then
                        Exit For
                    Else
                        'swapping values
                        stringarr(i) = stringarr(minIndex)
                        stringarr(minIndex) = temp
                        Delay(0.45)
                        btnArray(i).Text = stringarr(i)
                        btnArray(minIndex).Text = temp
                        Label6.Text = ("Swapping done")
                    End If
                    While (x < 2)
                        With (tmpbtnArray(x))                       'remove buttons from Form:            
                            Me.Controls.Remove(tmpbtnArray(x))
                            x += 1
                        End With
                    End While
                End If
                If play = False Then
                    pausetill()
                End If
                If Resetbtn = True Then
                    Exit For
                Else
                    btnArray(minIndex).BackColor = Color.Silver 'color assignment
                    btnArray(i).BackColor = Color.LightGreen
                    Delay(0.45)
                End If
            End If
        Next
        btnArray(stringarr.Length - 1).BackColor = Color.LightGreen 'color to last element
        Label6.Text = ("Array Sorted")
        If play = False Then
            pausetill()
        End If
        If Resetbtn = True Then
        Else
            Delay(3) 'The time array stays in picture
        End If
        Dim txtOutput As String = ""
        txtOutput = Join(stringarr, " ")
        TextBox3.Text = txtOutput
        If Resetbtn = True Then
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
        Label6.Visible = False
        ascending.Enabled = True
        descending.Enabled = True
        sort.Enabled = True
        play_pause.Visible = False
    End Sub
    Sub sort_novis()
        ' First stored the textbox input in a string array
        Dim trim_string As String
        trim_string = Trim(TextBox2.Text)
        Dim pattern As String = "\s+"
        Dim regex As Regex = New Regex(pattern)
        Dim stringarr() As String = regex.Split(trim_string, trim_string.Length, 0)
        sort.Enabled = False
        Resetbtn = False
        If Lexi = True Or Alpha = True Then
            Lexi_Alpha_sort_novis()
            sort.Enabled = True
            Exit Sub
        End If
        ' Converted the string array into a integer array
        Dim enteredNum(stringarr.Length - 1) As Decimal
        For i As Decimal = 0 To stringarr.Length - 1
            Try
                enteredNum(i) = stringarr(i)
                If enteredNum(i) > 9999999 Or enteredNum(i) < -9999999 Then
                    MessageBox.Show("You can only enter decimal numbers in the range -9999999 to 9999999", "Warning!")
                    sort.Enabled = True
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show("Please, enter valid input ", "Warning")
                sort.Enabled = True
                Exit Sub
            End Try
        Next

        ' Code checks which radio button is selected and sorts accordingly
        For i = 0 To enteredNum.Length - 2
            If ascending.Checked = True Then
                descending.Enabled = False
            Else
                ascending.Enabled = False
            End If
            Dim minIndex As Integer = i
            If Resetbtn = True Then
                Exit For
            End If
            'comparing loop of algo
            For j = i + 1 To enteredNum.Length - 1
                If enteredNum(j) < enteredNum(minIndex) And ascending.Checked = True Then
                    minIndex = j
                ElseIf enteredNum(j) > enteredNum(minIndex) And descending.Checked = True Then
                    minIndex = j
                Else
                End If
            Next
            Dim temp As Decimal = enteredNum(i)
            enteredNum(i) = enteredNum(minIndex)
            enteredNum(minIndex) = temp

            If Resetbtn = True Then
                Exit For
            End If
        Next
        ' Sorted the string array according to our integer array
        For i As Integer = 0 To enteredNum.Length - 1
            stringarr(i) = enteredNum(i)
        Next
        'output to output boxes
        Dim txtOutput As String = ""
        txtOutput = Join(stringarr, " ")
        TextBox4.Visible = True
        TextBox3.Text = txtOutput
        TextBox4.Text = txtOutput
        If Resetbtn = True Then 'if reset button clicked
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox4.Visible = False
        End If
        ascending.Enabled = True
        descending.Enabled = True
        sort.Enabled = True
    End Sub
    Sub Lexi_Alpha_sort_novis()
        'converting string to acceptable form for algo
        Dim n As Integer = 0
        Dim trim_string As String
        trim_string = Trim(TextBox2.Text)
        Dim pattern As String = "\s+"
        Dim regex As Regex = New Regex(pattern)
        Dim stringarr() As String = regex.Split(trim_string, trim_string.Length, 0)
        'check for string length
        For i As Integer = 0 To stringarr.Length - 1
            If stringarr(i).Length > 15 Then
                MessageBox.Show("Enter strings of length less then 15", "Warning!")
                sort.Enabled = True
                Exit Sub
            End If
        Next i
        ' Code checks which radio button is selected and sorts accordingly
        For i = 0 To stringarr.Length - 2
            If ascending.Checked = True Then
                descending.Enabled = False
            Else
                ascending.Enabled = False
            End If
            Dim minIndex As Integer = i
            For j = i + 1 To stringarr.Length - 1
                'comparing part of algo
                If play = False Then
                    pausetill()
                End If
                If stringarr(j).ToUpper < stringarr(minIndex).ToUpper And ascending.Checked = True And Alpha = True Then
                    minIndex = j
                ElseIf stringarr(j).ToUpper > stringarr(minIndex).ToUpper And descending.Checked = True And Alpha = True Then
                    minIndex = j
                ElseIf stringarr(j).ToUpper = stringarr(minIndex).ToUpper Or Lexi = True Then
                    If stringarr(j) < stringarr(minIndex) And ascending.Checked = True Then
                        minIndex = j

                    ElseIf stringarr(j) > stringarr(minIndex) And descending.Checked = True Then
                        minIndex = j
                    End If
                End If
            Next
            'swapping values
            Dim temp As String = stringarr(i)
            stringarr(i) = stringarr(minIndex)
            stringarr(minIndex) = temp
        Next

        'ouput to textboxes
        Dim txtOutput As String = ""
        txtOutput = Join(stringarr, " ")
        TextBox4.Visible = True
        TextBox3.Text = txtOutput
        TextBox4.Text = txtOutput
        If Resetbtn = True Then
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox4.Visible = False
        End If
        ascending.Enabled = True
        descending.Enabled = True
        sort.Enabled = True
    End Sub
    'reset all values
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Reset.Click
        Resetbtn = True
        sort.Enabled = True
        play_pause.Visible = False
        Button1.Text = "Sort Type"
        Delay(1)
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        Panel1.Visible = False
    End Sub
    ' Checking whether the size of input array is actually a positive integer or not
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBox1.KeyPress
        ' Allowing the key press to be only integers, Ctrl+C/V/X/A/Z/-/+ , Backspace, Whitespace
        If (Asc(e.KeyChar) < 3 And Asc(e.KeyChar) <> 1) Or (Asc(e.KeyChar) > 3 And Asc(e.KeyChar) < 8) Or (Asc(e.KeyChar) > 8 And Asc(e.KeyChar) < 22) Or Asc(e.KeyChar) = 23 Or (Asc(e.KeyChar) > 24 And Asc(e.KeyChar) < 32 And Asc(e.KeyChar) <> 26) Or (Asc(e.KeyChar) > 32 And Asc(e.KeyChar) < 45 And Asc(e.KeyChar) <> 43) Or Asc(e.KeyChar) = 47 Or Asc(e.KeyChar) > 57 Then
            e.Handled = True
            MessageBox.Show("You can only input integer here!", "Warning!")
        End If
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
            MessageBox.Show("You cannot insert space here!", "Warning!")
        End If
    End Sub
    'checks at every keypress in textbox 2
    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBox2.KeyPress
        ' Checking if textbox1 is empty before filling textbox2
        If String.IsNullOrEmpty(TextBox1.Text) Then
            MessageBox.Show("First fill the amount of numbers you want to sort", "Warning!")
            e.Handled = True
        ElseIf Asc(e.KeyChar) = 32 Then
            Dim trim_string As String
            trim_string = Trim(TextBox2.Text)
            Dim pattern As String = "\s+"
            Dim regex As Regex = New Regex(pattern)
            Dim stringarr() As String = regex.Split(trim_string, trim_string.Length, 0)
            'try and catch for checking array size
            Try
                If stringarr.Length + 1 > CInt(TextBox1.Text) And Not Asc(e.KeyChar) = 8 Then
                    e.Handled = True
                    MessageBox.Show("Array size full", "Warning!")
                End If
            Catch ex As Exception
                MessageBox.Show("Enter correct array size", "Warning")
                e.Handled = True
            End Try
        End If
        'check if sorting type is not selected
        If Alpha = False And Numb = False And Lexi = False Then
            MessageBox.Show("First select sorting type", "Warning")
            e.Handled = True
        End If
        If Numb = True Then
            ' Allowing the key press to be only integers, Ctrl+C/V/X/A/Z/-/+ , Backspace, Whitespace
            If (Asc(e.KeyChar) < 3 And Asc(e.KeyChar) <> 1) Or (Asc(e.KeyChar) > 3 And Asc(e.KeyChar) < 8) Or (Asc(e.KeyChar) > 8 And Asc(e.KeyChar) < 22) Or Asc(e.KeyChar) = 23 Or (Asc(e.KeyChar) > 24 And Asc(e.KeyChar) < 32 And Asc(e.KeyChar) <> 26) Or (Asc(e.KeyChar) > 32 And Asc(e.KeyChar) < 45 And Asc(e.KeyChar) <> 43) Or Asc(e.KeyChar) = 47 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
                MessageBox.Show("You can only input space separated decimals here!", "Warning!")
            End If
        ElseIf Alpha = True Then
            If (Asc(e.KeyChar) < 3 And Asc(e.KeyChar) <> 1) Or (Asc(e.KeyChar) > 3 And Asc(e.KeyChar) < 8) Or (Asc(e.KeyChar) > 8 And Asc(e.KeyChar) < 22) Or Asc(e.KeyChar) = 23 Or (Asc(e.KeyChar) > 24 And Asc(e.KeyChar) < 32 And Asc(e.KeyChar) <> 26) Or (Asc(e.KeyChar) > 32 And Asc(e.KeyChar) < 45 And Asc(e.KeyChar) <> 43) Or Asc(e.KeyChar) = 47 Or (Asc(e.KeyChar) > 57 And Asc(e.KeyChar) < 65) Or (Asc(e.KeyChar) > 90 And Asc(e.KeyChar) < 97) Or Asc(e.KeyChar) > 122 Then

                e.Handled = True
            End If
        End If
        'upper limit of array
        Try
            If CInt(TextBox1.Text) > 100 Then
                MessageBox.Show("Upper limit of array is 100", "Warning")
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show("Enter valid input", "Warning!")
        End Try
    End Sub
    'perform these of assignment of default values at form load
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ascending.Checked = True
        Visualisation_check.Checked = True
        Button1.PerformClick()
        Delay(0.2)
        Numerical.PerformClick()
        LinkLabel1.Links.Add(0, 28, "www.hackerearth.com/practice/algorithms/sorting")
        LinkLabel2.Links.Add(0, 32, "www.hackerearth.com/practice/algorithms/sorting/selection-sort/visualize/")
        LinkLabel3.Links.Add(0, 32, "https://github.com/priyanshu2103/selection_sort_visualizer/blob/master/User_Documentation.pdf/")
        Button2_MouseLeave()
    End Sub
    'delay function which takes seconds as input
    Sub Delay(ByVal dblSecs As Double)
        Const onesec As Double = 1.0# / (1440.0# * 60.0#)
        Dim dblwaittil As Date
        Now.AddSeconds(onesec)
        dblwaittil = Now.AddSeconds(onesec).AddSeconds(dblSecs)
        Do Until Now > dblwaittil
            Application.DoEvents()
        Loop
    End Sub
    'max function takes two integer as argument and return maximum
    Private Function max(ByVal a As Integer, ByRef b As Integer)
        If a > b Then
            Return a
        Else
            Return b
        End If
    End Function
    'min function takes two integer as argument and return minimum
    Private Function Min(ByVal a As Integer, ByRef b As Integer)
        If a > b Then
            Return b
        Else
            Return a
        End If
    End Function
    'exit button
    Private Sub ExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        reset.PerformClick() 'first reset then close
        Delay(0.5)
        Me.Close()
    End Sub
    'when sort type is clicked
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Timer1.Start()

        If Not Panel1.Visible = False Then
            Panel1.Visible = False
            Timer1.Enabled = False
        End If
    End Sub
    'timer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Panel1.Visible = True
        Timer1.Stop()
    End Sub
    'when user select numerical sorting
    Private Sub Numerical_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Numerical.Click
        Numb = True
        Alpha = False
        Lexi = False
        Panel1.Visible = False
        Button1.Text = Numerical.Text
    End Sub
    'when user select alphabatical sorting
    Private Sub Alphabatically_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Alphabatically.Click
        Numb = False
        Alpha = True
        Lexi = False
        Panel1.Visible = False
        Button1.Text = Alphabatically.Text
    End Sub
    'when user select lexicographical sorting
    Private Sub Lexicographically_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lexicographically.Click
        Numb = False
        Alpha = False
        Lexi = True
        Panel1.Visible = False
        Button1.Text = Lexicographically.Text
    End Sub
    'instruction to display
    Private Sub Button2_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Numerical.MouseHover
        Label7.Visible = True
    End Sub
    'for instruction to end
    Private Sub Button2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Numerical.MouseLeave
        Label7.Visible = False
    End Sub
    'instruction to display
    Private Sub Button3_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Alphabatically.MouseHover, Lexicographically.MouseHover
        Label9.Visible = True
    End Sub
    'for instruction to end
    Private Sub Button3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Alphabatically.MouseLeave, Lexicographically.MouseLeave
        Label9.Visible = False
    End Sub
    'for array size instruction
    Private Sub textbox1_focusenter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Enter
        Label8.Visible = True
    End Sub
    Private Sub textbox1_focusLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        Label8.Visible = False
    End Sub
    'when form is closed
    Private Sub Selection_Sort_Visualiser_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        reset.PerformClick()
    End Sub
    'pause funtion
    Sub pausetill()
        While (play = False)
            Application.DoEvents()
        End While
    End Sub
    'play and pause button
    Private Sub play_pause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles play_pause.Click
        If play = False Then
            play = True
            play_pause.Text = "Pause"
        Else
            play = False
            play_pause.Text = "Play"
        End If
    End Sub
    'link label for other sorting algo
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString)
    End Sub
    'link for step wise visualisation of selection sort
    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString)
    End Sub
    'browse file
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim FileNum As Integer = FreeFile()
            Dim TempS As String = ""
            Dim TempL As String
            'set properties of the browse file
            OpenFileDialog1 = New OpenFileDialog
            OpenFileDialog1.FileName = ""
            'set file type to be opend
            OpenFileDialog1.Filter = "Text file only (*.txt)|*.txt"
            With OpenFileDialog1
                'set default extension
                .DefaultExt = "txt"
                'set open dialog title
                .Title = "Open a text file"
                'check if file do exists
                .CheckFileExists = True
                'restrict multiselect
                .Multiselect = False
                ' if successfully opened
                If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Try
                        'storing input in a string
                        FileOpen(FileNum, OpenFileDialog1.FileName, OpenMode.Input)
                        Do Until EOF(FileNum)
                            TempL = LineInput(FileNum)
                            TempS += TempL + " "
                        Loop
                        'trim extra spaces
                        Dim trim_string As String
                        trim_string = Trim(TempS)
                        Dim pattern As String = "\s+"
                        Dim regex As Regex = New Regex(pattern)
                        Dim stringarr() As String = regex.Split(trim_string, trim_string.Length, 0)
                        TextBox1.Text = stringarr.Length 'extracting number of data
                        TextBox2.Text = TempS  'redirecting input to textbox 2
                        FileClose(FileNum)
                    Catch fileexception As Exception
                        Throw fileexception
                    End Try
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub
    ' save file
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        sort.PerformClick()
        Dim FileNum As Integer = FreeFile()
        Try
            'set properties of save file dialog
            SaveFileDialog1 = New SaveFileDialog
            SaveFileDialog1.FileName = "Untitled" 'default name to Untitled
            'Setting output file type to text file
            SaveFileDialog1.Filter = "Text file only (*.txt)|*.txt"
            With SaveFileDialog1
                'Add extension automatically
                .AddExtension = True
                'check path
                .CheckPathExists = True
                'check if file already exit
                .CheckFileExists = True
                'overite prompt
                .OverwritePrompt = True
                'validation
                .ValidateNames = False
                'default extension
                .DefaultExt = "txt"
                'show help
                .ShowHelp = True
                'save text file
                If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                    'writing everything that is in textbox 3 to file
                    Try
                        My.Computer.FileSystem.WriteAllText(.FileName, TextBox3.Text, False, System.Text.Encoding.ASCII)
                    Catch fileexception As Exception
                        Throw fileexception
                    End Try
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString)
    End Sub

    Private Sub Button2_MouseLeave()
        Label7.Visible = False
    End Sub

End Class