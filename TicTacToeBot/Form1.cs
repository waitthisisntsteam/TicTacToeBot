namespace TicTacToeBot
{
    public partial class Form1 : Form
    {
        private char PreviousPlayer;
        
        public Point TopLeftButtonPoint;
        public Point TopMiddleButtonPoint;
        public Point TopRightButtonPoint;
        public Point MiddleLeftButtonPoint;
        public Point MiddleButtonPoint;
        public Point MiddleRightButtonPoint;
        public Point BottomLeftButtonPoint;
        public Point BottomMiddleButtonPoint;
        public Point BottomRightMiddlePoint;

        private char[,] BaseBoard;
        private GameState<char[,]> BaseState;
        
        private char[,] CurrentGameBoard;
        private GameState<char[,]> CurrentGameState;

        private MiniMaxTree<char[,]> BoardTree;

        public Form1()
        {
            InitializeComponent();

            PreviousPlayer = 'X';

            TopLeftButtonPoint = new Point(0, 0);
            TopMiddleButtonPoint = new Point(0, 1);
            TopRightButtonPoint = new Point(0, 2);
            MiddleLeftButtonPoint = new Point(1, 0);
            MiddleButtonPoint = new Point(1, 1);
            MiddleRightButtonPoint = new Point(1, 2);
            BottomLeftButtonPoint = new Point(2, 0);
            BottomMiddleButtonPoint = new Point(2, 1);
            BottomRightMiddlePoint = new Point(2, 2);

            CurrentGameBoard = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            BaseBoard = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };

            CurrentGameState = new GameState<char[,]>(CurrentGameBoard);
            BaseState = new GameState<char[,]>(BaseBoard);

            BoardTree = new(BaseState, PreviousPlayer);
            BoardTree.GenerateTree(BaseState, PreviousPlayer);
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
                    if (PreviousPlayer == 'X')
                    { pressedButton.Text = "O"; PreviousPlayer = 'O'; }
                    else
                    { pressedButton.Text = "X"; PreviousPlayer = 'X'; }

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
            char currentPlayer = PreviousPlayer;

            if (PreviousPlayer == 'X')
            { currentPlayer = 'O'; }
            else
            { currentPlayer = 'X'; }

            GameState<char[,]>? winningCPUMove = BoardTree.FindWinningMove(CurrentGameState, currentPlayer);
            PlayBotMove(winningCPUMove, e);
        }
    }
}
