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
                    double val = child.UCTCalculate();
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

        private GameState<T> Expand(GameState<T> currentGameState, Random random)
        {
            currentGameState.GenerateChildren();

            if (currentGameState.NextPossibleStates.Count == 0)
            {
                return currentGameState;
            }
            return currentGameState.NextPossibleStates[random.Next(0, currentGameState.NextPossibleStates.Count)];
        }

        private int Simulate(GameState<T> currentGameState, Random random, out GameState<T> backPropFrom)
        {
            while (currentGameState.GetScore() == 0)
            {
                currentGameState.GenerateChildren();
                if (currentGameState.NextPossibleStates.Count == 0)
                {
                    break;
                }
                int randomIndex = random.Next(0, currentGameState.NextPossibleStates.Count);
                currentGameState = currentGameState.NextPossibleStates[randomIndex];
            }

            backPropFrom = currentGameState;
            return currentGameState.GetScore();
        }

        private void Backpropagate(GameState<T> simulatedGameState, int value, char[,] rootNode)
        {
            GameState<T>? currentGameState = simulatedGameState;

            while (!AreBoardsEqual(currentGameState.TicTacToeBoard, rootNode))
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
                var expandedChild = Expand(selectedNode, random);
                var backPropFrom = expandedChild;
                int value = Simulate(expandedChild, random, out backPropFrom);
                Backpropagate(backPropFrom, value, rootNode.TicTacToeBoard);
            }

            var sortedChildren = rootNode.NextPossibleStates.OrderByDescending((state) => state.W);
            if (rootNode.CurrentPlayer == 'O')
            {
                sortedChildren.Reverse();
            }
            return sortedChildren.First();
        }
    }
}
