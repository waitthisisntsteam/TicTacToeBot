using System.Runtime.CompilerServices;

namespace TicTacToeBot
{
    public class MiniMaxTree<T>
    {
        private GameState<T> Root;
        private List<GameState<T>> AllGameStates;
        private char PreviousPlay;

        public MiniMaxTree(GameState<T> rootGameState, char prevPlay)
        {
            Root = rootGameState;
            PreviousPlay = prevPlay;

            AllGameStates = new();
            AllGameStates.Add(Root);
        }

        private bool VerifyWin(GameState<T> gameState) { return gameState.GetScore() != 0; }

        private char[,] GetBoard(GameState<T> gameState)
        {
            var gameBoard = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };

            for (int column = 0; column < 3; column++)
            {
                for (int row = 0; row < 3; row++)
                {
                    gameBoard[column, row] = gameState.TicTacToeBoard[column, row];
                }
            }

            return gameBoard;
        }
        private bool FindDuplicate(GameState<T> gameState)
        {
            for (int gameStateIndex = 0; gameStateIndex < AllGameStates.Count; gameStateIndex++)
            {
                bool duplicate = true;
                var currentGameStateBoard = GetBoard(AllGameStates[gameStateIndex]);
                var gameStateBoard = GetBoard(gameState);

                for (int column = 0; column < 3; column++)
                {
                    for (int row = 0; row < 3; row++)
                    {
                        if (currentGameStateBoard[column, row] != gameStateBoard[column, row])
                        {
                            duplicate = false;
                        }
                    }
                }
                if (duplicate)
                { return true; }
            }

            return false;
        }

        public void GenerateTree(GameState<T> gameState, char previousPlayer)
        {
            if (!VerifyWin(gameState))
            {
                if (previousPlayer == 'X')
                { previousPlayer = 'O'; }
                else
                { previousPlayer = 'X'; }

                var gameBoard = GetBoard(gameState);
                for (int column = 0; column < 3; column++)
                {
                    for (int row = 0; row < 3; row++)
                    {
                        GameState<T> nextGameState = new(gameBoard);

                        if (nextGameState.TicTacToeBoard[column, row] == ' ')
                        {
                            nextGameState.TicTacToeBoard[column, row] = previousPlayer;
                            gameState.NextPossibleStates.Add(nextGameState);
                            nextGameState.ParentState = gameState;

                            AllGameStates.Add(nextGameState);          

                            GenerateTree(nextGameState, previousPlayer);
                        }
                    }
                }

                int largestScore = 0;
                if (gameState.NextPossibleStates.Count > 0)
                {
                    if (previousPlayer == 'X')
                    { largestScore = -1; }
                    else
                    { largestScore = 1; }
                }

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
            else
            { gameState.Score = gameState.GetScore(); }
        }

        private GameState<T>? Search(GameState<T> wantedGameState)
        {
            for (int gameStateIndex = 0; gameStateIndex < AllGameStates.Count; gameStateIndex++)
            {
                bool boardCurrentlyEqual = true;

                for (int column = 0; column < 3; column++)
                {
                    for (int row = 0; row < 3; row++)
                    {
                        if (AllGameStates[gameStateIndex].TicTacToeBoard[column, row] != wantedGameState.TicTacToeBoard[column, row])
                        { boardCurrentlyEqual = false; }
                    }
                }
                if (boardCurrentlyEqual)
                { return AllGameStates[gameStateIndex]; }
            }

            return null;
        }
        public GameState<T>? FindWinningMove(GameState<T> startingGameState, char winningPlayer)
        {
            GameState<T>? start = Search(startingGameState);

            if (start != null)
            {
                foreach (var nextGameState in start.NextPossibleStates)
                {
                    if ((winningPlayer == 'X' && nextGameState.Score > 0) || (winningPlayer == 'O' && nextGameState.Score < 0))
                    { return nextGameState; }
                }
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
