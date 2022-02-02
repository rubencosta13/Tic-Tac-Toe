
Imports System.Text.RegularExpressions

Module Modulo
    Public matrizGalo(2, 2) As Integer
    Public Jogador As Boolean
    Public isMultiplayer As Boolean = False
    Public emptySpots(2, 2) As Integer
    Public PlayerName0, PlayerName1 As String
    Public bestMoveScore = 30
    Public bestRow As Integer
    Public bestColumn As Integer
    Dim btns = {{jogo.Button1, jogo.Button2, jogo.Button3}, {jogo.Button4, jogo.Button5, jogo.Button6}, {jogo.Button7, jogo.Button8, jogo.Button9}}

    Public Function displayMatrixData()
        System.Diagnostics.Debug.Write($"-------------------------------------{vbCrLf}")
        For i = 0 To UBound(matrizGalo)
            For j = 0 To UBound(matrizGalo)
                System.Diagnostics.Debug.Write($"Indice: {i}:{j} -> Valor {matrizGalo(i, j)} {vbCrLf}")
            Next
        Next
    End Function

    Public Function VerificaJogada(coordX As Integer, coordY As Integer, ByRef Jogador As Boolean) As Char
        If isMultiplayer = False Then
            System.Diagnostics.Debug.WriteLine("Multiplayer")
            If Jogador Then
                matrizGalo(coordX, coordY) = 1
                emptySpots(coordX, coordY) = 1
                Jogador = Not Jogador
                displayMatrixData()
                Return "X"
            Else
                matrizGalo(coordX, coordY) = 2
                emptySpots(coordX, coordY) = 2
                Jogador = Not Jogador
                displayMatrixData()
                Return "O"
            End If
        Else
            System.Diagnostics.Debug.WriteLine("SinglePlayer")
            If Jogador Then
                VerificaVencedor()
                bestColumn = 0
                bestRow = 0
                matrizGalo(coordX, coordY) = 1
                computeMoves()
                outputOnButton(coordX, coordY)
                Jogador = False
                Return "X"
            Else
                VerificaVencedor()
                matrizGalo(coordX, coordY) = 2
                computeMoves()
                Jogador = True
                Return "O"
            End If
        End If
    End Function

    Public Function outputOnButton(coordX As Integer, coordY As Integer)
        btns(coordX, coordY).Text = IIf(Jogador = True, "X", "O")
        btns(coordX, coordY).Enabled = False
        VerificaVencedor()
    End Function

    Public Function computeMoves()
        If computeDiagonal() Then
            VerificaVencedor()
            Jogador = Not Jogador
            bestRow = 0
            bestColumn = 0
        Else
            VerificaVencedor()
            Jogador = Not Jogador
            bestRow = 0
            bestColumn = 0
        End If


    End Function

    Public Function computeDiagonal() As Boolean 'Workin' SORT OF
        VerificaVencedor()
        Dim currentValue As Integer = 0
        For i = 0 To UBound(matrizGalo)
            For j = 0 To UBound(matrizGalo)
                If matrizGalo(i, j) = 1 And Jogador = False Then 'Player
                    currentValue -= 10
                    If currentValue = -20 Then 'Bloqueia o Jogador
                        bestRow = i
                        bestColumn = j + 1
                        outputOnButton(bestRow, bestColumn)
                        matrizGalo(bestRow, bestColumn) = 2
                        currentValue = 0
                        Return True
                    End If
                ElseIf matrizGalo(i, j) = 2 And Jogador = False Then 'Computador
                    currentValue += 10
                    If currentValue = 20 Then
                        bestRow = i
                        bestColumn = j + 1
                        outputOnButton(bestRow, bestColumn)
                        matrizGalo(bestRow, bestColumn) = 2
                        currentValue = 0
                        Return True
                    End If
                ElseIf matrizGalo(j, i) = 1 And Jogador = False Then
                    currentValue -= 10
                    If currentValue = -20 Then
                        bestRow = i + 1
                        bestColumn = j
                        outputOnButton(bestRow, bestColumn)
                        matrizGalo(bestRow, bestColumn) = 2
                        currentValue = 0
                        Return True
                    End If
                ElseIf matrizGalo(j, i) = 2 And Jogador = False Then 'Computador
                    currentValue += 10
                    If currentValue = 20 Then
                        bestRow = i + 1
                        bestColumn = j
                        outputOnButton(bestRow, bestColumn)
                        matrizGalo(bestRow, bestColumn) = 2
                        currentValue = 0
                        Return True
                    End If
                End If
            Next
        Next
        Return False
    End Function

    Public Function CheckFreeSpaces() As String
        For i = 0 To UBound(matrizGalo)
            For j = 0 To UBound(matrizGalo)
                If matrizGalo(i, j) = 0 Then
                    matrizGalo(i, j) = emptySpots(i, j)
                End If
            Next
        Next
    End Function



    Public Function VerificaVencedor() As Integer
        System.Diagnostics.Debug.WriteLine("Verifica Vencedor" & vbCrLf)
        displayMatrixData()
        If VerificarDiagonalPrincipal() = 1 Then
            System.Diagnostics.Debug.WriteLine($"1.1.1 -> {VerificarDiagonalPrincipal()}")
            gameOver(1)
            Return False
        ElseIf VerificarDiagonalPrincipal() = 2 Then
            System.Diagnostics.Debug.WriteLine($"1.1.2 -> {VerificarDiagonalPrincipal()}")
            gameOver(2)
            Return False
        Else
            If Empate() = 1 Then
                System.Diagnostics.Debug.WriteLine($"1.2.1 -> {Empate()}")
                gameOver(0)
                Return False
            ElseIf VerificarDiagonalSecundaria() = 1 Then
                System.Diagnostics.Debug.WriteLine($"1.2.1 -> {VerificarDiagonalSecundaria()}")
                gameOver(1)
                Return False
            ElseIf VerificarDiagonalSecundaria() = 2 Then
                System.Diagnostics.Debug.WriteLine($"1.2.1 -> {VerificarDiagonalSecundaria()}")
                gameOver(2)
                Return False
            Else
                If VerificaPorColuna() = 1 Then
                    gameOver(1)
                    Return False
                ElseIf VerificaPorColuna() = 2 Then
                    gameOver(2)
                    Return False
                Else
                    If VerificaPorLinha() = 1 Then
                        gameOver(1)
                        Return False
                    ElseIf VerificaPorLinha() = 2 Then
                        gameOver(2)
                        Return False
                    Else
                        Return False
                    End If
                End If
            End If
        End If
    End Function

    '   FUNCAO DE GANHAR

    Public Function VerificaPorColuna() As Integer
        For i = 0 To UBound(matrizGalo)
            For j = 0 To UBound(matrizGalo)
                If matrizGalo(0, i) = 1 And matrizGalo(1, i) = 1 And matrizGalo(2, i) = 1 Then
                    Return 1
                ElseIf matrizGalo(0, i) = 2 And matrizGalo(1, i) = 2 And matrizGalo(2, i) = 2 Then
                    Return 2
                End If
            Next
        Next
        Return 3
    End Function


    Private Function Empate() As Integer
        For i = 0 To UBound(matrizGalo)
            For j = 0 To UBound(matrizGalo)
                If matrizGalo(i, j) = 0 Then
                    Return 0 'Sem empate | O jogo continua
                End If
            Next
        Next
        Return 1
    End Function
    Public Function VerificaPorLinha() As Integer
        For i = 0 To UBound(matrizGalo)
            For j = 0 To UBound(matrizGalo)
                If matrizGalo(i, 0) = 1 And matrizGalo(i, 1) = 1 And matrizGalo(i, 2) = 1 Then
                    Return 1
                ElseIf matrizGalo(i, 0) = 2 And matrizGalo(i, 1) = 2 And matrizGalo(i, 2) = 2 Then
                    Return 2
                End If

            Next
        Next
        Return 3
    End Function

    Public Function VerificarDiagonalSecundaria() As Integer
        Dim counterPlayer1 As Integer = 0
        Dim counterPlayer2 As Integer = 0
        Dim Valor As Integer = 0
        For i = 0 To UBound(matrizGalo)
            For j = UBound(matrizGalo) To 0
                If matrizGalo(i, j) = 1 Then
                    counterPlayer1 += 1
                    If counterPlayer1 = 3 Then
                        Return 1
                    End If
                ElseIf matrizGalo(i, j) = 2 Then
                    counterPlayer2 += 1
                    If counterPlayer2 = 3 Then
                        Return 2
                    End If
                End If
            Next
        Next
        Return 3
    End Function

    Public Function VerificarDiagonalPrincipal() As Integer
        Dim counterPlayer1 As Integer = 0
        Dim counterPlayer2 As Integer = 0
        Dim Diagonal As Integer = 0
        For i = 0 To UBound(matrizGalo)
            For j = 0 To UBound(matrizGalo)
                If i = j Then
                    If matrizGalo(i, j) = 1 Then
                        counterPlayer1 += 1
                        If counterPlayer1 = 3 Then
                            Return 1
                        End If
                    ElseIf matrizGalo(i, j) = 2 Then
                        counterPlayer2 += 1
                        If counterPlayer2 = 3 Then
                            Return 2
                        End If
                    End If
                End If
            Next
        Next
        Return 3
    End Function

    Public Function gameOver(Player As Integer) As Boolean
        If (Player = 0) Then
            MsgBox($"Empate!")
            For Each button As Button In jogo.Controls.OfType(Of Button)()
                button.Text = " "
                button.Enabled = False
            Next
        Else
            Dim playerName As String = IIf(Player = 1, PlayerName0, PlayerName1)
            MsgBox($"O Jogador {playerName} ganhou!")
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\Ruben Costa\Desktop\WinFormsApp1\scores.txt", True)
            file.WriteLine($"O Jogador {playerName} ganhou o jogo")
            file.Close()
            For Each button As Button In jogo.Controls.OfType(Of Button)()
                button.Text = " "
                button.Enabled = False
            Next
            Return True
        End If
    End Function

    Public Function actualRestart() As Boolean
        Jogador = True
        For i = 0 To UBound(matrizGalo)
            For j = 0 To UBound(matrizGalo)
                matrizGalo(i, j) = 0
                emptySpots(i, j) = 0
            Next
        Next
    End Function

    Public Function startGame() As Boolean
        For Each button As Button In jogo.Controls.OfType(Of Button)()
            button.Text = " "
        Next
        Return True
    End Function

    Public Function restartGame() As Boolean
        For Each button As Button In jogo.Controls.OfType(Of Button)()
            button.Text = " "
            button.Enabled = True
        Next
        actualRestart()
        Return True
    End Function

    Public Function getResults() As String
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText("C:\Users\Ruben Costa\Desktop\WinFormsApp1\scores.txt")
        Return fileReader
    End Function

    Public Function checkPlayerName(playerName0 As String, playerName1 As String) As Boolean
        If String.Equals(playerName0, "") Or String.Equals(playerName1, "") Then Return False
        If Regex.IsMatch(playerName0, "[!@#\$%\^&\*\(\)_\-\+=\{\}\[\]\\\|:;""'<>,\.\?/]") Or Regex.IsMatch(playerName1, "[!@#\$%\^&\*\(\)_\-\+=\{\}\[\]\\\|:;""'<>,\.\?/]") Then Return False
        Return True
    End Function
End Module
