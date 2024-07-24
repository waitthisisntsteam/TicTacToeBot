using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeBot
{
    public class ExpectiMaxTree<T>
    {
        private GameState<T> Root;
        private List<GameState<T>> AllGameStates;
        private char PreviousPlay;
        private int LastDuplicateIndex;

        public ExpectiMaxTree(GameState<T> rootGameState, char prevPlay)
        {
            Root = rootGameState;
            PreviousPlay = prevPlay;

            AllGameStates = new();
            AllGameStates.Add(Root);

            LastDuplicateIndex = 0;
        }

        private bool AreBoardsEqual(GameState<T> firstGameState, GameState<T> secondGameState)
        {
            if (firstGameState.TicTacToeBoard[0, 0] == secondGameState.TicTacToeBoard[0, 0] &&
                firstGameState.TicTacToeBoard[0, 1] == secondGameState.TicTacToeBoard[0, 1] &&
                firstGameState.TicTacToeBoard[0, 2] == secondGameState.TicTacToeBoard[0, 2] &&
                firstGameState.TicTacToeBoard[1, 0] == secondGameState.TicTacToeBoard[1, 0] &&
                firstGameState.TicTacToeBoard[1, 1] == secondGameState.TicTacToeBoard[1, 1] &&
                firstGameState.TicTacToeBoard[1, 2] == secondGameState.TicTacToeBoard[1, 2] &&
                firstGameState.TicTacToeBoard[2, 0] == secondGameState.TicTacToeBoard[2, 0] &&
                firstGameState.TicTacToeBoard[2, 1] == secondGameState.TicTacToeBoard[2, 1] &&
                firstGameState.TicTacToeBoard[2, 2] == secondGameState.TicTacToeBoard[2, 2])
            {
                return true;
            }
            return false;
        }
        private bool VerifyWin(GameState<T> gameState) { return gameState.GetScore() != 0; }

        private char[,] GetBoard(GameState<T> gameState)
        {
            var gameBoard = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };

            gameBoard[0, 0] = gameState.TicTacToeBoard[0, 0];
            gameBoard[0, 1] = gameState.TicTacToeBoard[0, 1];
            gameBoard[0, 2] = gameState.TicTacToeBoard[0, 2];
            gameBoard[1, 0] = gameState.TicTacToeBoard[1, 0];
            gameBoard[1, 1] = gameState.TicTacToeBoard[1, 1];
            gameBoard[1, 2] = gameState.TicTacToeBoard[1, 2];
            gameBoard[2, 0] = gameState.TicTacToeBoard[2, 0];
            gameBoard[2, 1] = gameState.TicTacToeBoard[2, 1];
            gameBoard[2, 2] = gameState.TicTacToeBoard[2, 2];

            return gameBoard;
        }
        private bool FindDuplicate(GameState<T> gameState)
        {
            for (int gameStateIndex = 0; gameStateIndex < AllGameStates.Count; gameStateIndex++)
            {
                if (AreBoardsEqual(gameState, AllGameStates[gameStateIndex]))
                {
                    LastDuplicateIndex = gameStateIndex;
                    return true;
                }
            }
            return false;
        }

        public void GeneratePercentages()
        {
            for (int i = 1; i < AllGameStates.Count; i++)
            {
                double percentage = (100.0 * AllGameStates[i].Score) / AllGameStates[i].ParentState.NextPossibleStates.Count;
                AllGameStates[i].WinPercentage = percentage;
            }
        }
        private void GenerateScores(GameState<T> gameState, char previousPlayer)
        {
            int largestScore = 0;
            if (gameState.NextPossibleStates.Count > 0)
            { largestScore = previousPlayer == 'X' ? -1 : 1; }
            for (int i = 0; i < gameState.NextPossibleStates.Count; i++)
            {
                if (previousPlayer == 'X')
                {
                    if (largestScore < gameState.NextPossibleStates[i].Score)
                    { largestScore = gameState.NextPossibleStates[i].Score; }
                }
                else
                {
                    if (largestScore > gameState.NextPossibleStates[i].Score)
                    { largestScore = gameState.NextPossibleStates[i].Score; }
                }
            }
            gameState.Score = largestScore;
        }
        public void GenerateTree(GameState<T> gameState, char previousPlayer)
        {
            if (!VerifyWin(gameState))
            {
                previousPlayer = previousPlayer == 'X' ? 'O' : 'X';
                var gameBoard = GetBoard(gameState);

                for (int column = 0; column < 3; column++)
                {
                    for (int row = 0; row < 3; row++)
                    {
                        GameState<T> nextGameState = new(gameBoard);

                        if (nextGameState.TicTacToeBoard[column, row] == ' ')
                        {
                            nextGameState.TicTacToeBoard[column, row] = previousPlayer;

                            AllGameStates.Add(nextGameState);
                            gameState.NextPossibleStates.Add(nextGameState);
                            nextGameState.ParentState = gameState;

                            GenerateTree(nextGameState, previousPlayer);
                        }
                    }
                }

                GenerateScores(gameState, previousPlayer);
            }
            else
            { gameState.Score = gameState.GetScore(); }
        }

        private GameState<T>? FindEqualGame(GameState<T> wantedGameState)
        {
            for (int gameStateIndex = 0; gameStateIndex < AllGameStates.Count; gameStateIndex++)
            {
                if (AreBoardsEqual(wantedGameState, AllGameStates[gameStateIndex]))
                { return AllGameStates[gameStateIndex]; }
            }

            return null;
        }
        public GameState<T>? FindWinningMove(GameState<T> startingGameState, char winningPlayer)
        {
            GameState<T>? start = FindEqualGame(startingGameState);
            GameState<T>? bestMove = null;

            if (start != null)
            {
                foreach (var nextGameState in start.NextPossibleStates)
                {
                    if ((winningPlayer == 'X' && nextGameState.Score > 0) || (winningPlayer == 'O' && nextGameState.Score < 0))
                    {
                        if (bestMove == null || (bestMove != null && bestMove.NextPossibleStates.Count > nextGameState.NextPossibleStates.Count))
                        { bestMove = nextGameState; }
                    }
                }
                if (bestMove != null)
                { return bestMove; }

                foreach (var nextGameState in start.NextPossibleStates)
                {
                    if (nextGameState.Score == 0)
                    { return nextGameState; }
                }

                if (start.NextPossibleStates.Count > 0)
                { return start.NextPossibleStates[0]; }
            }

            return null;
        }
    }
}