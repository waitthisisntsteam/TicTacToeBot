namespace TicTacToeBot
{
    public partial class TicTacToe : Form
    {
        private char PreviousPlayer;

        private char[,] BaseBoard;
        private GameState<char[,]> BaseState;
        private MiniMaxTree<char[,]> BoardTree;

        private char[,] CurrentGameBoard;
        private GameState<char[,]> CurrentGameState;

        private Point TopLeftButtonPoint;
        private Point TopMiddleButtonPoint;
        private Point TopRightButtonPoint;
        private Point MiddleLeftButtonPoint;
        private Point MiddleButtonPoint;
        private Point MiddleRightButtonPoint;
        private Point BottomLeftButtonPoint;
        private Point BottomMiddleButtonPoint;
        private Point BottomRightMiddlePoint;

        private ExpectiMaxTree<char[,]> ExpectiMaxTree;

        public TicTacToe()
        {
            InitializeComponent();

            PreviousPlayer = 'X';

            BaseBoard = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            BaseState = new GameState<char[,]>(BaseBoard);
            
            //BoardTree = new(BaseState, PreviousPlayer);
            //BoardTree.GenerateTree(BaseState, PreviousPlayer);
            
            CurrentGameBoard = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            CurrentGameState = new GameState<char[,]>(CurrentGameBoard);

            TopLeftButtonPoint = new Point(0, 0);
            TopMiddleButtonPoint = new Point(0, 1);
            TopRightButtonPoint = new Point(0, 2);
            MiddleLeftButtonPoint = new Point(1, 0);
            MiddleButtonPoint = new Point(1, 1);
            MiddleRightButtonPoint = new Point(1, 2);
            BottomLeftButtonPoint = new Point(2, 0);
            BottomMiddleButtonPoint = new Point(2, 1);
            BottomRightMiddlePoint = new Point(2, 2);

            ExpectiMaxTree = new(BaseState, PreviousPlayer);
            ExpectiMaxTree.GenerateTree(BaseState, PreviousPlayer);
            ExpectiMaxTree.GeneratePercentages();
            ;
        }

        private void PlayBotMove(GameState<char[,]>? move, EventArgs e)
        {
            if (move == null)
            { return; }

            for (int column = 0; column < 3; column++)
            {
                for (int row = 0; row < 3; row++)
                {
                    if (move.TicTacToeBoard[column, row] != CurrentGameState.TicTacToeBoard[column, row])
                    {
                        Point currentPoint = new Point(row, column);

                        if (currentPoint == TopLeftButtonPoint)
                        { Button_Click(TopLeftButton, e); }
                        else if (currentPoint == TopMiddleButtonPoint)
                        { Button_Click(TopMiddleButton, e); }
                        else if (currentPoint == TopRightButtonPoint)
                        { Button_Click(TopRightButton, e); }
                        else if (currentPoint == MiddleLeftButtonPoint)
                        { Button_Click(MiddleLeftButton, e); }
                        else if (currentPoint == MiddleButtonPoint)
                        { Button_Click(MiddleButton, e); }
                        else if (currentPoint == MiddleRightButtonPoint)
                        { Button_Click(MiddleRightButton, e); }
                        else if (currentPoint == BottomLeftButtonPoint)
                        { Button_Click(BottomLeftButton, e); }
                        else if (currentPoint == BottomMiddleButtonPoint)
                        { Button_Click(BottomMiddleButton, e); }
                        else if (currentPoint == BottomRightMiddlePoint)
                        { Button_Click(BottomRightButton, e); }

                        return;
                    }
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button pressedButton = (Button)sender;

            if (CurrentGameState.GetScore() == 0)
            {
                if (pressedButton.Text == " ")
                {
                    PreviousPlayer = PreviousPlayer == 'X' ? 'O' : 'X';
                    pressedButton.Text = "" + PreviousPlayer;

                    CurrentGameState.TicTacToeBoard[pressedButton.Location.X / 200, pressedButton.Location.Y / 200] = PreviousPlayer;
                    Button_Click(pressedButton, e);
                }
            }
            else
            { WinningBar.Value = 100; }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            WinningBar.Value = 0;

            PreviousPlayer = 'X';

            TopLeftButton.Text = " ";
            TopMiddleButton.Text = " ";
            TopRightButton.Text = " ";
            MiddleLeftButton.Text = " ";
            MiddleButton.Text = " ";
            MiddleRightButton.Text = " ";
            BottomLeftButton.Text = " ";
            BottomMiddleButton.Text = " ";
            BottomRightButton.Text = " ";

            CurrentGameBoard = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            CurrentGameState.TicTacToeBoard = CurrentGameBoard;
        }

        private void CPUButton_Click(object sender, EventArgs e)
        {
            GameState<char[,]>? winningCPUMove = BoardTree.FindWinningMove(CurrentGameState, PreviousPlayer == 'X' ? 'O' : 'X');
            PlayBotMove(winningCPUMove, e);
        }
    }
}