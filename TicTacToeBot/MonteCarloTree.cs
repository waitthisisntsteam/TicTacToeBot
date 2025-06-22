using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeBot
{
    public class MonteCarloTree<T>
    {
        private GameState<T> Root;
        public List<GameState<T>> AllGameStates;
        private char PreviousPlay;
        private int LastDuplicateIndex;

        public MonteCarloTree(GameState<T> rootGameState, char prevPlay)
        {
            Root = rootGameState;
            PreviousPlay = prevPlay;

            AllGameStates = new();
            AllGameStates.Add(Root);

            LastDuplicateIndex = 0;

            //X = maximizer
            //O = minimizer
        }

        private bool AreBoardsEqual(char[,] firstGameState, char[,] secondGameState)
        {
            if (firstGameState[0, 0] == secondGameState[0, 0] &&
                firstGameState[0, 1] == secondGameState[0, 1] &&
                firstGameState[0, 2] == secondGameState[0, 2] &&
                firstGameState[1, 0] == secondGameState[1, 0] &&
                firstGameState[1, 1] == secondGameState[1, 1] &&
                firstGameState[1, 2] == secondGameState[1, 2] &&
                firstGameState[2, 0] == secondGameState[2, 0] &&
                firstGameState[2, 1] == secondGameState[2, 1] &&
                firstGameState[2, 2] == secondGameState[2, 2])
            {
                return true;
            }
            return false;
        }

        private GameState<T> Select(GameState<T> rootNode)
        {
            GameState<T> currentGameState = rootNode;

            while (currentGameState.NextPossibleStates.Count > 0)
            {
                GameState<T>? highestUCTChild = null;
                double highestUCT = double.NegativeInfinity;

                foreach (var child in currentGameState.NextPossibleStates)
                {
                    double val = child.UCT();
                    if (val > highestUCT)
                    {
                        highestUCT = val;
                        highestUCTChild = child;
                    }
                }

                if (highestUCTChild == null)
                {
                    break;
                }

                currentGameState = highestUCTChild;
            }

            return currentGameState;
        }

        private GameState<T> Expand(GameState<T> currentGameState)
        {
            currentGameState.GenerateChildren();

            if (currentGameState.NextPossibleStates.Count == 0)
            {
                return currentGameState;
            }
            return currentGameState.NextPossibleStates[0];
        }

        private int Simulate(GameState<T> currentGameState, Random random)
        {
            while (currentGameState.NextPossibleStates.Count > 0)
            {
                currentGameState.GenerateChildren();
                int randomIndex = random.Next(0, currentGameState.NextPossibleStates.Count);
                currentGameState = currentGameState.NextPossibleStates[randomIndex];
            }

            return currentGameState.GetScore();
        }

        private void Backpropagate(GameState<T> simulatedGameState, int value, char[,] rootNode)
        {
            GameState<T>? currentGameState = simulatedGameState;

            while (AreBoardsEqual(currentGameState.TicTacToeBoard, rootNode))
            {
                value = -value;
                currentGameState.N++;
                currentGameState.W += value;

                currentGameState = currentGameState.ParentState;
            }
        }

        public GameState<T> MonteCarloTreeSearch(int iterations, char[,] curentBoard, Random random)
        {
            var rootNode = new GameState<T>(curentBoard);

            for (int i = 0; i < iterations; i++)
            {
                var selectedNode = Select(rootNode);
                var expandedChild = Expand(selectedNode);
                int value = Simulate(expandedChild, random);
                if (value == 0)
                {
                    ;
                }
                else if (value == -1)
                {
                    ;
                }
                else if (value == 1)
                {
                    ;
                }
                Backpropagate(expandedChild, value, rootNode.TicTacToeBoard);
            }

            var sortedChildren = rootNode.NextPossibleStates.OrderByDescending((state) => state.W);
            if (rootNode.CurrentPlayer == 'O')
            {
                sortedChildren.Reverse();
            }
            var topChild = sortedChildren.First();
            return topChild;
        }
    }
}
