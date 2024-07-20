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
                if (largestScore != 0) { gameState.Score = largestScore; }               
            }
            else { gameState.Score = gameState.GetScore(); }
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
        private GameState<T> DFSSelector(List<GameState<T>> frontier)
        {
            GameState<T> dequeued = frontier[^1];
            frontier.RemoveAt(frontier.Count - 1);
            return dequeued;
        }
        public List<GameState<T>>? FindWinningPath(GameState<T> startingGameState, char winningPlayer)
        {
            List<GameState<T>> result = new();
            List<GameState<T>> frontier = new();
           
            GameState<T> current = Search(startingGameState);
            frontier.Add(current);
           
            while (frontier.Count > 0)
            {
                current = DFSSelector(frontier);

                bool WinContained = false; // maybe has to do with defense ??
                foreach (var nextGameState in current.NextLayer)
                {
                    frontier.Add(nextGameState);
                    if (nextGameState.Score != 0)
                    {
                        WinContained = true;
                    }
                }

                if ((winningPlayer == 'X' && current.Score == 1 && current.NextLayer.Count <= 0) ||
                    (winningPlayer == 'O' && current.Score == -1 && current.NextLayer.Count <= 0))
                {
                    GameState<T> runner = current;
                    while (runner != null)
                    {
                        result.Add(runner);
                        runner = runner.Parent;
                    }
                    result.Reverse();
                    return result;
                }
            }
            return null;
        }
    }
}
