using UnityEngine;
using System.Collections.Generic;

public class TicTacToeAI : MonoBehaviour
{
    public enum Player { None, X, O }
    private Player[,] board;
    private const int BoardSize = 3;

    void Start()
    {
        InitializeBoard();
    }

    void InitializeBoard()
    {
        board = new Player[BoardSize, BoardSize];
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                board[i, j] = Player.None;
            }
        }
    }

    public Vector2Int GetBestMove(Player aiPlayer)
    {
        int bestScore = aiPlayer == Player.X ? int.MinValue : int.MaxValue;
        Vector2Int bestMove = new Vector2Int(-1, -1);

        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                if (board[i, j] == Player.None)
                {
                    board[i, j] = aiPlayer;
                    int score = Minimax(0, aiPlayer == Player.X ? false : true);
                    board[i, j] = Player.None;

                    if (aiPlayer == Player.X)
                    {
                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestMove = new Vector2Int(i, j);
                        }
                    }
                    else
                    {
                        if (score < bestScore)
                        {
                            bestScore = score;
                            bestMove = new Vector2Int(i, j);
                        }
                    }
                }
            }
        }

        return bestMove;
    }

    private int Minimax(int depth, bool isMaximizing)
    {
        Player winner = CheckWinner();
        if (winner != Player.None)
        {
            return winner == Player.X ? 10 - depth : depth - 10;
        }

        if (IsBoardFull())
        {
            return 0;
        }

        if (isMaximizing)
        {
            int bestScore = int.MinValue;
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (board[i, j] == Player.None)
                    {
                        board[i, j] = Player.X;
                        int score = Minimax(depth + 1, false);
                        board[i, j] = Player.None;
                        bestScore = Mathf.Max(score, bestScore);
                    }
                }
            }
            return bestScore;
        }
        else
        {
            int bestScore = int.MaxValue;
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (board[i, j] == Player.None)
                    {
                        board[i, j] = Player.O;
                        int score = Minimax(depth + 1, true);
                        board[i, j] = Player.None;
                        bestScore = Mathf.Min(score, bestScore);
                    }
                }
            }
            return bestScore;
        }
    }

    private Player CheckWinner()
    {
        // Check rows, columns and diagonals
        for (int i = 0; i < BoardSize; i++)
        {
            if (board[i, 0] != Player.None && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                return board[i, 0];
            if (board[0, i] != Player.None && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                return board[0, i];
        }
        if (board[0, 0] != Player.None && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            return board[0, 0];
        if (board[0, 2] != Player.None && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            return board[0, 2];

        return Player.None;
    }

    private bool IsBoardFull()
    {
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                if (board[i, j] == Player.None)
                    return false;
            }
        }
        return true;
    }

    // Méthode pour faire jouer l'IA
    public void MakeAIMove(Player aiPlayer)
    {
        Vector2Int bestMove = GetBestMove(aiPlayer);
        board[bestMove.x, bestMove.y] = aiPlayer;
        // Ici, vous devriez mettre à jour l'interface utilisateur pour refléter le mouvement de l'IA
    }

    // Méthode pour faire jouer le joueur humain
    public void MakePlayerMove(int x, int y, Player humanPlayer)
    {
        if (board[x, y] == Player.None)
        {
            board[x, y] = humanPlayer;
            // Ici, vous devriez mettre à jour l'interface utilisateur pour refléter le mouvement du joueur
        }
    }
}