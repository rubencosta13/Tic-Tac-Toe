Public Class jogo

    Private Sub jogo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Modulo.startGame()
        Modulo.Jogador = True
        For i = 0 To UBound(Modulo.matrizGalo)
            For j = 0 To UBound(Modulo.matrizGalo)
                Modulo.matrizGalo(i, j) = 0
            Next
        Next
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Text = VerificaJogada(0, 0, Jogador)
        Button1.Enabled = False
        VerificaVencedor()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Text = VerificaJogada(0, 1, Jogador)
        Button2.Enabled = False
        VerificaVencedor()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button3.Text = VerificaJogada(0, 2, Jogador)
        Button3.Enabled = False
        VerificaVencedor()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button4.Text = VerificaJogada(1, 0, Jogador)
        Button4.Enabled = False
        VerificaVencedor()

    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button5.Text = VerificaJogada(1, 1, Jogador)
        Button5.Enabled = False
        VerificaVencedor()

    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Button6.Text = VerificaJogada(1, 2, Jogador)
        Button6.Enabled = False
        VerificaVencedor()

    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Button7.Text = VerificaJogada(2, 0, Jogador)
        Button7.Enabled = False
        VerificaVencedor()

    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Button8.Text = VerificaJogada(2, 1, Jogador)
        Button8.Enabled = False
        VerificaVencedor()

    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Button9.Text = VerificaJogada(2, 2, Jogador)
        Button9.Enabled = False
        VerificaVencedor()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        MsgBox("O jogo irá recomeçar")
        Modulo.restartGame()
        MsgBox("Jogo Recomeçou!")
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Close()
        Form1.Show()
    End Sub
End Class