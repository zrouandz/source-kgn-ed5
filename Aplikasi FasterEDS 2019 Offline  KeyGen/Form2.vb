Public Class Form2

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Label1.Top <= 220 Then
            Label1.Top -= 1
        End If

        If Label1.Bottom <= 0 Then
            Label1.Top = 220
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label1.Top -= 30
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Label1.Top += 30
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Form2_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosed
        Timer1.Stop()
        Label1.Top = 220
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Button3.Text = "STOP !" Then
            Timer1.Stop()
            Button3.Text = "START !"
        ElseIf Button3.Text = "START !" Then
            Timer1.Start()
            Button3.Text = "STOP !"
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub
End Class