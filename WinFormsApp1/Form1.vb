Imports System.Drawing.Text

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim pfc As New PrivateFontCollection
        pfc.AddFontFile("C:\Users\Ruben Costa\Desktop\WinFormsApp1\LuckiestGuy-Regular.ttf")
        pfc.AddFontFile("C:\Users\Ruben Costa\Desktop\WinFormsApp1\font2.ttf")
        Button1.Font = New Font(pfc.Families(0), 22, FontStyle.Bold)
        Button2.Font = New Font(pfc.Families(0), 22, FontStyle.Bold)
        Button3.Font = New Font(pfc.Families(0), 22, FontStyle.Bold)
        jogo.Label1.Font = New Font(pfc.Families(1), 24, FontStyle.Bold)
        Label2.Text &= Modulo.getResults()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PlayerName0 = InputBox("Qual o teu nome: ")
        PlayerName1 = InputBox("Qual o teu nome: ")
        If Not Modulo.checkPlayerName(PlayerName0, PlayerName1) Then Return
        jogo.Show()
        Modulo.isMultiplayer = False
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PlayerName0 = InputBox("Qual o teu nome: ")
        PlayerName1 = "Computador"
        If Not Modulo.checkPlayerName(PlayerName0, PlayerName1) Then Return
        jogo.Show()
        Modulo.isMultiplayer = True
        System.Diagnostics.Debug.WriteLine(PlayerName0, PlayerName1)
        Me.Hide()
    End Sub
End Class
