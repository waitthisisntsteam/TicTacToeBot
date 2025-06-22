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
        public List<GameState<T>> NextPossibleStates;
        public GameState<T>? ParentState;
        public int Score;

        public int Alpha;
        public int Beta;

        public int W; //value of total state --> win count - loss count
        public int N; //times this state or child states have ran
        public double C;

        public char[,] TicTacToeBoard;

        public char CurrentPlayer => GetPlayer();

        public GameState(char[,] ticTacToeBoard)
        {
            NextPossibleStates = new();
            ParentState = null;
            Score = 0;

            W = 0; 
            N = 0;
            C = 1.5;

            TicTacToeBoard = new char[3, 3];
            for (int column = 0; column < 3; column++)
            {
                for (int row = 0; row < 3; row++)
                {
                    TicTacToeBoard[column, row] = ticTacToeBoard[column, row];
                }
            }         
        }

        public double UCT() => N != 0 ? (W / N) + (C * Math.Sqrt(Math.Log(ParentState.N) / N)) : 0;

        public void GenerateChildren()
        {
            for (int column = 0; column < 3; column++)
            {
                for (int row = 0; row < 3; row++)
                {
                    GameState<T> nextGameState = new(TicTacToeBoard);

                    if (nextGameState.TicTacToeBoard[column, row] == ' ')
                    {
                        nextGameState.TicTacToeBoard[column, row] = CurrentPlayer;

                        nextGameState.ParentState = this;
                        NextPossibleStates.Add(nextGameState);
                    }
                }
            }
        }

        public int GetScore()
        {
            char winningPiece = ' ';

            if ((TicTacToeBoard[1, 1] != ' ') && ((TicTacToeBoard[0, 0] == TicTacToeBoard[1, 1] && TicTacToeBoard[1, 1] == TicTacToeBoard[2, 2]) || (TicTacToeBoard[2, 0] == TicTacToeBoard[1, 1] && TicTacToeBoard[1, 1] == TicTacToeBoard[0, 2])))
            { 
                winningPiece = TicTacToeBoard[1, 1];
            }
            else
            {
                for (int currentPiece = 0; currentPiece < 3; currentPiece++)
                {
                    if ((TicTacToeBoard[currentPiece, 0] != ' ' && TicTacToeBoard[currentPiece, 0] == TicTacToeBoard[currentPiece, 1] && TicTacToeBoard[currentPiece, 1] == TicTacToeBoard[currentPiece, 2]))
                    { 
                        winningPiece = TicTacToeBoard[currentPiece, 0]; 
                        break; 
                    }
                    else if ((TicTacToeBoard[0, currentPiece] != ' ') && TicTacToeBoard[0, currentPiece] == TicTacToeBoard[1, currentPiece] && TicTacToeBoard[1, currentPiece] == TicTacToeBoard[2, currentPiece])
                    { 
                        winningPiece = TicTacToeBoard[0, currentPiece]; 
                        break;
                    }
                }
            }

            if (winningPiece != ' ')
            {
                if (winningPiece == 'X')
                {
                    Alpha++;
                    return 1; 
                }
                Beta++;
                return -1;
            }

            return 0;
        }

        private char GetPlayer()
        {
            int xCount = 0;
            int oCount = 0;

            for (int column = 0; column < 3; column++)
            {
                for (int row = 0; row < 3; row++)
                {
                    if (TicTacToeBoard[column, row] == 'X') 
                    { 
                        xCount++; 
                    }
                    else if (TicTacToeBoard[column, row] == 'O')
                    {
                        oCount++; 
                    }
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