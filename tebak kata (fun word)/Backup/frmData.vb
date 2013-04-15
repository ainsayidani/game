Public Class frmData

    Private Sub frmData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer = FreeFile()
        FileOpen(i, Application.StartupPath & "\TK.txt", OpenMode.Input)
        txtData.Text = InputString(i, LOF(i))
        FileClose(i)

        txtData.SelectionStart = Len(txtData.Text) 'posisi ke akhir
    End Sub

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        Dim ar(), s As String
        Dim i As Integer

        ar = Split(txtData.Text, vbCrLf)
        For i = 0 To UBound(ar)
            If Trim(ar(i)) <> "" Then s &= IIf(s = "", "", vbCrLf) & Trim(ar(i))
        Next

        txtData.Text = s

        If txtData.Text = "" Then
            MsgBox("Data tidak boleh kosong !", vbExclamation)
            txtData.Focus()
        Else
            i = FreeFile()
            FileOpen(i, Application.StartupPath & "\TK.txt", OpenMode.Output)
            PrintLine(i, txtData.Text)
            FileClose(i)

            Me.Dispose()

            frmMain.RefreshData()
            frmMain.MulaiBaru()
        End If

    End Sub
End Class