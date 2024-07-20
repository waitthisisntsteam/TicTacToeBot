using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicTacToeBot
{
    public class GameState<T>
    {
        public GameState<T>? Parent;
        public List<GameState<T>> NextLayer;

        public char[,] PuzzlePieces;
        public int Score;

        public char CurrentPlayer => GetPlayer();

        public GameState(char[,] puzzlePieces)
        {
            Parent = null;
            NextLayer = new();

            PuzzlePieces = new char[puzzlePieces.GetLength(0), puzzlePieces.GetLength(1)];
            for (int column = 0; column < 3; column++)
            {
                for (int row = 0; row < 3; row++)
                {
                    PuzzlePieces[column, row] = puzzlePieces[column, row];
                }
            }
            Score = 0;
        }

        public int GetScore()
        {
            char winningPiece = ' ';

            if ((PuzzlePieces[1, 1] != ' ') && ((PuzzlePieces[0, 0] == PuzzlePieces[1, 1] && PuzzlePieces[1, 1] == PuzzlePieces[2, 2]) || (PuzzlePieces[2, 0] == PuzzlePieces[1, 1] && PuzzlePieces[1, 1] == PuzzlePieces[0, 2])))
            {
                winningPiece = PuzzlePieces[1, 1]; //diagnol win
            }
            else
            {
                for (int currentPiece = 0; currentPiece < 3; currentPiece++)
                {
                    if ((PuzzlePieces[currentPiece, 0] != ' ' && PuzzlePieces[currentPiece, 0] == PuzzlePieces[currentPiece, 1] && PuzzlePieces[currentPiece, 1] == PuzzlePieces[currentPiece, 2]))
                    {
                        winningPiece = PuzzlePieces[currentPiece, 0]; //column win
                        break;
                    }
                    else if ((PuzzlePieces[0, currentPiece] != ' ') && PuzzlePieces[0, currentPiece] == PuzzlePieces[1, currentPiece] && PuzzlePieces[1, currentPiece] == PuzzlePieces[2, currentPiece])
                    {
                        winningPiece = PuzzlePieces[0, currentPiece]; // row win
                        break;
                    }
                }
            }

            if (winningPiece != ' ')
            {
                if (winningPiece == 'X')
                { return 1; }
                return -1;
            }

            return 0;
        }
        public char GetPlayer()
        {
            int xCount = 0;
            int oCount = 0;

            for (int column = 0; column < 3; column++)
            {
                for (int row = 0; row < 3; row++)
                {
                    if (PuzzlePieces[column, row] == 'X') 
                    { xCount++; }
                    else if (PuzzlePieces[column, row] == 'O')
                    { oCount++; }
                }
            }

            if (xCount < oCount)
            {
                return 'X';
            }
            return 'O';
        }
    }
}
