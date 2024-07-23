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
        public GameState<T>? ParentState;
        public List<GameState<T>> NextPossibleStates;

        public char[,] TicTacToeBoard;
        public int Score;

        public char CurrentPlayer => GetPlayer();

        public GameState(char[,] ticTacToeBoard)
        {
            ParentState = null;
            NextPossibleStates = new();
            Score = 0;

            TicTacToeBoard = new char[3, 3];
            for (int column = 0; column < 3; column++)
            {
                for (int row = 0; row < 3; row++)
                {
                    TicTacToeBoard[column, row] = ticTacToeBoard[column, row];
                }
            }         
        }

        public int GetScore()
        {
            char winningPiece = ' ';

            if ((TicTacToeBoard[1, 1] != ' ') && ((TicTacToeBoard[0, 0] == TicTacToeBoard[1, 1] && TicTacToeBoard[1, 1] == TicTacToeBoard[2, 2]) || (TicTacToeBoard[2, 0] == TicTacToeBoard[1, 1] && TicTacToeBoard[1, 1] == TicTacToeBoard[0, 2])))
            { winningPiece = TicTacToeBoard[1, 1]; }
            else
            {
                for (int currentPiece = 0; currentPiece < 3; currentPiece++)
                {
                    if ((TicTacToeBoard[currentPiece, 0] != ' ' && TicTacToeBoard[currentPiece, 0] == TicTacToeBoard[currentPiece, 1] && TicTacToeBoard[currentPiece, 1] == TicTacToeBoard[currentPiece, 2]))
                    { winningPiece = TicTacToeBoard[currentPiece, 0]; break; }
                    else if ((TicTacToeBoard[0, currentPiece] != ' ') && TicTacToeBoard[0, currentPiece] == TicTacToeBoard[1, currentPiece] && TicTacToeBoard[1, currentPiece] == TicTacToeBoard[2, currentPiece])
                    { winningPiece = TicTacToeBoard[0, currentPiece]; break; }
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
                    if (TicTacToeBoard[column, row] == 'X') 
                    { xCount++; }
                    else if (TicTacToeBoard[column, row] == 'O')
                    { oCount++; }
                }
            }

            if (xCount < oCount)
            { return 'X'; }
            return 'O';
        }
    }
}
