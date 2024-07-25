using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeBot
{
    public class ExpectiMaxTree<T>
    {
        private MiniMaxTree<T> MiniMaxTree;
        private List<ChanceNode<T>> AllChanceNodes;
        private List<GameState<T>> MaximizerNodes;

        public ExpectiMaxTree(MiniMaxTree<T> miniMaxTree)
        {
            MiniMaxTree = miniMaxTree;
            AllChanceNodes = new();
            MaximizerNodes = new();
        }

        private void GeneratePercentages()
        {
            for (int i = 0; i < AllChanceNodes.Count; i++)
            {
                if (AllChanceNodes[i].GameState.ParentState != null)
                {
                    double percentage = 100.0 / AllChanceNodes[i].GameState.ParentState.NextPossibleStates.Count;
                    AllChanceNodes[i].MovePercentage = percentage;
                }
            }
        } 
        
        public void GenerateTree()
        {
            for (int i = 1; i < MiniMaxTree.AllGameStates.Count; i++)
            {
                var runner = MiniMaxTree.AllGameStates[i];

                if (runner.CurrentPlayer == 'O')
                { AllChanceNodes.Add(new ChanceNode<T>(runner)); }
                else
                { MaximizerNodes.Add(runner); }
            }
            GeneratePercentages();
        }
    }
}