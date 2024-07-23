namespace TicTacToeBot
{
    public partial class Form1 : Form
    {
        private MiniMaxTree<char[,]> BoardTree;

        private char PreviousPlay;
        private int MoveCount;

        private char[,] BaseBoard;
        private GameState<char[,]> BaseState;
        
        private char[,] CurrentGameBoard;
        private GameState<char[,]> CurrentGameState;

        public Form1()
        {
            InitializeComponent();

            PreviousPlay = 'X';
            MoveCount = 0;

            CurrentGameBoard = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            BaseBoard = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };

            CurrentGameState = new GameState<char[,]>(CurrentGameBoard);
            BaseState = new GameState<char[,]>(BaseBoard);

            BoardTree = new(BaseState, PreviousPlay);
            BoardTree.GenerateTree(BaseState, PreviousPlay);

            ;
        }

        private void PlayBotMove(EventArgs e, List<GameState<char[,]>> path)
        {
            if (path == null || path.Count < MoveCount + 1)
            {
                return;
            }

            Point button1Point = new Point(0, 0);
            Point button2Point = new Point(0, 1);
            Point button3Point = new Point(0, 2);
            Point button4Point = new Point(1, 0);
            Point button5Point = new Point(1, 1);
            Point button6Point = new Point(1, 2);
            Point button7Point = new Point(2, 0);
            Point button8Point = new Point(2, 1);
            Point button9Point = new Point(2, 2);

            var predictedMove = path[MoveCount + 1];
            for (int column = 0; column < 3; column++)
            {
                for (int row = 0; row < 3; row++)
                {
                    if (predictedMove.PuzzlePieces[column, row] != CurrentGameState.PuzzlePieces[column, row])
                    {
                        Point currentPoint = new Point(row, column);
                        if (currentPoint == button1Point)
                        {
                            Button_Click(button1, e);
                        }
                        else if (currentPoint == button2Point)
                        {
                            Button_Click(button2, e);
                        }
                        else if (currentPoint == button3Point)
                        {
                            Button_Click(button3, e);
                        }
                        else if (currentPoint == button4Point)
                        {
                            Button_Click(button4, e);
                        }
                        else if (currentPoint == button5Point)
                        {
                            Button_Click(button5, e);
                        }
                        else if (currentPoint == button6Point)
                        {
                            Button_Click(button6, e);
                        }
                        else if (currentPoint == button7Point)
                        {
                            Button_Click(button7, e);
                        }
                        else if (currentPoint == button8Point)
                        {
                            Button_Click(button8, e);
                        }
                        else if (currentPoint == button9Point)
                        {
                            Button_Click(button9, e);
                        }
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
                  if (PreviousPlay == 'X')
                  { pressedButton.Text = "O"; PreviousPlay = 'O'; }
                  else
                  { pressedButton.Text = "X"; PreviousPlay = 'X'; }

                  CurrentGameState.PuzzlePieces[pressedButton.Location.X / 200, pressedButton.Location.Y / 200] = PreviousPlay;
                  MoveCount++;

                  if (CurrentGameState.GetScore() != 0)
                  {
                      Button_Click(sender, e);
                  }
              }
            }
            else
            {
                //if (CurrentGameState.Score == 1)
                //{ /*changecolor*/ }
                //else
                //{ /*changecolor*/ }

                progressBar1.Value = 100;
            }

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            button1.Text = " ";
            button2.Text = " ";
            button3.Text = " ";
            button4.Text = " ";
            button5.Text = " ";
            button6.Text = " ";
            button7.Text = " ";
            button8.Text = " ";
            button9.Text = " ";

            CurrentGameBoard = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            CurrentGameState.PuzzlePieces = CurrentGameBoard;

            MoveCount = 0;
            PreviousPlay = 'X';

            progressBar1.Value = 0;
            ;
        }

        private void CPUButton_Click(object sender, EventArgs e)
        {
            List<GameState<char[,]>>? winningCPUPath = BoardTree.FindWinningPath(CurrentGameState, 'X');

            PlayBotMove(e, winningCPUPath);

            ;
        }
    }
}
