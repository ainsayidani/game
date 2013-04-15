
Public Class frmMain
    Dim LB() As Label
    Dim BT(25) As Button 'membuat tombol A-Z
    Dim Data As New System.Collections.Specialized.StringCollection
    Dim DataSekarang As String
    Dim Kesempatan As Integer

    Sub TulisData() 'menulis data awal
        Dim i As Integer = FreeFile()
        FileOpen(i, Application.StartupPath & "\TK.txt", OpenMode.Output)
        PrintLine(i, "pensil" & vbCrLf & "buku" & vbCrLf & "komputer" & vbCrLf & "kaca mata" & vbCrLf & "sapu tangan")
        PrintLine(i, "uang" & vbCrLf & "air" & vbCrLf & "bintang" & vbCrLf & "dompet" & vbCrLf & "lampu")
        PrintLine(i, "tv" & vbCrLf & "kertas" & vbCrLf & "majalah" & vbCrLf & "kipas angin" & vbCrLf & "kalender")
        FileClose(i)

    End Sub
    Sub clue()
        Dim j As Integer = FreeFile()
        FileOpen(j, Application.StartupPath & "\CLUE.txt", OpenMode.Output)
        PrintLine(j, "alat untuk menulis?" & vbCrLf & "media untuk menulis?")
        FileClose(j)
       
    End Sub

    Sub RefreshData()
        Dim i As Integer, ar() As String

        If IO.File.Exists(Application.StartupPath & "\TK.txt") = False Then TulisData() 'jk data tdk ada

Lagi:
        i = FreeFile()
        FileOpen(i, Application.StartupPath & "\TK.txt", OpenMode.Input)
        ar = Split(InputString(i, LOF(i)), vbCrLf)
        FileClose(i)

        Data.Clear()
        For i = 0 To UBound(ar)
            If Trim(ar(i)) <> "" Then Data.Add(Trim(ar(i)))
        Next

        If Data.Count = 0 Then 'jk data kosong
            TulisData()
            GoTo Lagi 'mengulangi prosedur sebelumnya
        End If
    End Sub

    Sub MulaiBaru()
        Dim i As Integer
        If IsNothing(LB) = False Then
            For i = 0 To UBound(LB)
                LB(i).Dispose()
            Next
        End If

        Randomize()
        DataSekarang = Data(Rnd() * (Data.Count - 1)) 'mengacak data yg muncul

        ReDim LB(Len(DataSekarang) - 1) 'mengatur ulang jumlah huruf sesuai data sekarang

        For i = 0 To UBound(LB) 'proses membuat label
            LB(i) = New Label
            LB(i).TextAlign = ContentAlignment.MiddleCenter
            LB(i).BorderStyle = BorderStyle.FixedSingle
            LB(i).Width = 25
            LB(i).Top = 200

            If i = 0 Then
                LB(i).Left = 20
            Else
                LB(i).Left = LB(i - 1).Left + 35
            End If

            If Mid(DataSekarang, i + 1, 1) = " " Then 'jk spasi
                LB(i).Text = " "
                LB(i).BackColor = Color.FromArgb(200, 200, 200)
            Else
                LB(i).BackColor = Color.White
            End If

            Me.Controls.Add(LB(i))
        Next

        For i = 0 To 25 'meng enable semua button
            BT(i).Enabled = True
        Next

        Kesempatan = 5 'jml kesempatan awal
        lblKesempatan.Text = "Kesempatan Anda sebanyak : " & Kesempatan
    End Sub

    Function Jawaban() As String
        Dim i As Integer, s As String
        For i = 0 To UBound(LB)
            s &= LB(i).Text
        Next
        Jawaban = s
    End Function

    Sub BT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SendKeys.Send(CType(sender.Text, String))
    End Sub

    Private Sub frmMain_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'properti KeyPreview dari Form hrs bernilai True

        Dim i As Integer

        i = Asc(UCase(e.KeyChar)) - Asc("A")

        If i >= 0 And i <= 25 Then
            If BT(i).Enabled = False Then Exit Sub 'keluar dr prosedur jk tombol sdh pernah ditekan

            BT(i).Enabled = False
        End If


        If (InStr(UCase(DataSekarang), UCase(e.KeyChar)) <> 0) Then 'jika benar ada di data

            For i = 0 To Len(DataSekarang) - 1
                If Mid(UCase(DataSekarang), i + 1, 1) = UCase(e.KeyChar) Then LB(i).Text = UCase(e.KeyChar)
            Next

            If UCase(DataSekarang) = UCase(Jawaban) Then 'jika sudah komplit
                MsgBox("Anda berhasil !" & vbCrLf & UCase(DataSekarang), vbInformation)
                MulaiBaru()
            End If

        Else 'jika salah
            Kesempatan -= 1 'mengurangi kesempatan
            lblKesempatan.Text = "Kesempatan Anda sebanyak : " & Kesempatan

            If Kesempatan = 0 Then 'jika kesempatan habis
                MsgBox("Anda kalah !" & vbCrLf & "Kata yang benar adalah " & UCase(DataSekarang), vbCritical)
                MulaiBaru()
            End If

        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        For i = 0 To 25 'proses pembuatan tombol A-Z
            BT(i) = New Button
            BT(i).Text = Chr(Asc("A") + i)
            BT(i).Top = 250
            BT(i).Width = 22

            If i = 0 Then
                BT(i).Left = 10
            Else
                BT(i).Left = BT(i - 1).Left + 22
            End If

            AddHandler BT(i).Click, AddressOf BT_Click 'menambahakan event click

            Me.Controls.Add(BT(i))
        Next
        RefreshData()
        MulaiBaru()
    End Sub

    Private Sub btnMulaiBaru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMulaiBaru.Click
        MulaiBaru()
    End Sub

    Private Sub btnData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnData.Click
        frmData.ShowDialog()
    End Sub

    Private Sub Panel3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel3.Click
        FormCreator.Show()
    End Sub

    Private Sub Panel2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel2.Click
        Me.Close()
    End Sub
End Class
