namespace TicTacToeBot
{
    public partial class Form1 : Form
    {
        private MiniMaxTree<char[,]>? BoardTree;

        private char PreviousPlay;
        private char[,] GameBoard;
        private GameState<char[,]> CurrentGameState;

        public Form1()
        {
            InitializeComponent();

            GameBoard = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };


            PreviousPlay = 'X';
            CurrentGameState = new GameState<char[,]>(GameBoard);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button pressedButton = (Button)sender;

            if (CurrentGameState.Score == 0)
            {
                if (pressedButton.Text == " ")
                {
                    if (PreviousPlay == 'X')
                    { pressedButton.Text = "O"; PreviousPlay = 'O'; }
                    else
                    { pressedButton.Text = "X"; PreviousPlay = 'X'; }

                    CurrentGameState.PuzzlePieces[pressedButton.Location.X / 200, pressedButton.Location.Y / 200] = PreviousPlay;

                    if (CurrentGameState.Score != 0)
                    {
                        Button_Click(sender, e);
                    }
                }
            }
            else
            {
                if (CurrentGameState.Score == 1)
                { /*changecolor*/ }
                else
                { /*changecolor*/ }

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

            GameBoard = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            CurrentGameState.PuzzlePieces = GameBoard;

            PreviousPlay = 'X';

            progressBar1.Value = 0;
            ;
        }

        private void CPUButton_Click(object sender, EventArgs e)
        {
            BoardTree = new(CurrentGameState, PreviousPlay);
            BoardTree.GenerateTree();

            ;
        }
    }
}
