using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeBot
{
    public class MiniMaxTree<T>
    {
        public GameState<T> Root;
        private char PreviousPlay;

        public MiniMaxTree(GameState<T> rootGameState, char prevPlay) 
        {
            Root = rootGameState;
            PreviousPlay = prevPlay;
        }

        private char[,] GetBoard (GameState<T> gameState)
        {
            var gameBoard = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };

            for (int column = 0; column < 3; column++)
            {
                for (int row = 0; row < 3; row++)
                {
                    gameBoard[column, row] = gameState.PuzzlePieces[column, row];
                }
            }

            return gameBoard;
        }

        public void GenerateTree(GameState<T> gameState, char previousPlay)
        {
            if (gameState.Score == 0)
            {
                if (previousPlay == 'X') 
                { previousPlay = 'O'; }
                else 
                { previousPlay = 'X'; }

                var gameBoard = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
                gameBoard = GetBoard(gameState);

                for (int column = 0; column < 3; column++)
                {
                    for (int row = 0; row < 3; row++)
                    {
                        GameState<T> nextGameState = new(gameBoard);

                        if (nextGameState.PuzzlePieces[column, row] == ' ')
                        {
                            nextGameState.PuzzlePieces[column, row] = previousPlay;
                            gameState.NextLayer.Add(nextGameState);
                            nextGameState.Parent = gameState;
                            GenerateTree(nextGameState, previousPlay);
                        }
                    }
                }
            }
        }
    }
}
