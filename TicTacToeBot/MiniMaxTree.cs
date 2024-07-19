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

        public void GenerateTree()
        {
            if (PreviousPlay == 'X')
            {
                PreviousPlay = 'O';
            }
            else
            {
                PreviousPlay = 'X';
            }

            for (int column = 0; column < 3; column++)
            {
                for (int row = 0; row < 3; row++)
                {
                    var GameBoard = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
                    GameState<T> nextGameState = new(GameBoard);

                    if (Root.PuzzlePieces[column, row] == ' ')
                    {
                        nextGameState.PuzzlePieces[column, row] = PreviousPlay;
                        Root.NextLayer.Add(nextGameState);
                    }
                }
            }

        }
    }
}
