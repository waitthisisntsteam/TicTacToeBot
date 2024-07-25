using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeBot
{
    public class ChanceNode<T>
    {
        public GameState<T> GameState;
        public double MovePercentage;
        public double BlunderPercentage;
        public double MinimizerPercentage;

        public ChanceNode(GameState<T> gameState) 
        {
            GameState = gameState;
            MovePercentage = 0.0;

            BlunderPercentage = 30.0;
            MinimizerPercentage = 70.0;
        }
    }
}
