namespace TicTacToeBot
{
    public class MiniMaxTree<T>
    {
        public GameState<T> Root;
        private char PreviousPlay;

        private List<GameState<T>> AllGameStates;

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
                    gameBoard[column, row] = gameState.PuzzlePieces[column, row];
                }
            }

            return gameBoard;
        }
        public void GenerateTree(GameState<T> gameState, char previousPlay)
        {
            if (!VerifyWin(gameState))
            {
                if (previousPlay == 'X')
                { previousPlay = 'O'; }
                else
                { previousPlay = 'X'; }

                var gameBoard = GetBoard(gameState);
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

                            AllGameStates.Add(nextGameState);

                            GenerateTree(nextGameState, previousPlay);
                        }
                    }
                }

                int largestScore = 0;
                if (gameState.NextLayer.Count > 0)
                {
                    if (previousPlay == 'X')
                    {
                        largestScore = -1;
                    }
                    else
                    {
                        largestScore = 1;
                    }
                }

                for (int i = 0; i < gameState.NextLayer.Count; i++)
                {
                    if (previousPlay == 'X')
                    {
                        if (largestScore < gameState.NextLayer[i].Score)
                        {
                            largestScore = gameState.NextLayer[i].Score;
                        }
                    }
                    else
                    {
                        if (largestScore > gameState.NextLayer[i].Score)
                        {
                            largestScore = gameState.NextLayer[i].Score;
                        }
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
                        if (AllGameStates[gameStateIndex].PuzzlePieces[column, row] != wantedGameState.PuzzlePieces[column, row])
                        {
                            boardCurrentlyEqual = false;
                        }
                    }
                }
                if (boardCurrentlyEqual)
                {
                    return AllGameStates[gameStateIndex];
                }
            }
            return null;
        }
        public GameState<T> FindWinningMove(GameState<T> startingGameState, char winningPlayer)
        {
            GameState<T>? start = Search(startingGameState);

            foreach (var nextGameState in start.NextLayer)
            {
                if ((winningPlayer == 'X' && nextGameState.Score > 0) ||
                    (winningPlayer == 'O' && nextGameState.Score < 0))
                {
                    return nextGameState;
                }
            }
            foreach (var nextGameState in start.NextLayer)
            {
                if (nextGameState.Score == 0)
                {
                    return nextGameState;
                }
            }

            return start.NextLayer[0];
        }
    }
}
