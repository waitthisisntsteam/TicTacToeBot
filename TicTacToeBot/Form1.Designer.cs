namespace TicTacToeBot
{
    partial class TicTacToe
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TopLeftButton = new Button();
            TopMiddleButton = new Button();
            TopRightButton = new Button();
            MiddleLeftButton = new Button();
            MiddleButton = new Button();
            MiddleRightButton = new Button();
            BottomLeftButton = new Button();
            BottomMiddleButton = new Button();
            BottomRightButton = new Button();
            WinningBar = new ProgressBar();
            ResetButton = new Button();
            CPUButton = new Button();
            SuspendLayout();
            // 
            // TopLeftButton
            // 
            TopLeftButton.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TopLeftButton.Location = new Point(-2, -2);
            TopLeftButton.Name = "TopLeftButton";
            TopLeftButton.Size = new Size(200, 200);
            TopLeftButton.TabIndex = 0;
            TopLeftButton.Text = " ";
            TopLeftButton.UseVisualStyleBackColor = true;
            TopLeftButton.Click += Button_Click;
            // 
            // TopMiddleButton
            // 
            TopMiddleButton.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TopMiddleButton.Location = new Point(200, -2);
            TopMiddleButton.Name = "TopMiddleButton";
            TopMiddleButton.Size = new Size(200, 200);
            TopMiddleButton.TabIndex = 1;
            TopMiddleButton.Text = " ";
            TopMiddleButton.UseVisualStyleBackColor = true;
            TopMiddleButton.Click += Button_Click;
            // 
            // TopRightButton
            // 
            TopRightButton.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TopRightButton.Location = new Point(402, -2);
            TopRightButton.Name = "TopRightButton";
            TopRightButton.Size = new Size(200, 200);
            TopRightButton.TabIndex = 2;
            TopRightButton.Text = " ";
            TopRightButton.UseVisualStyleBackColor = true;
            TopRightButton.Click += Button_Click;
            // 
            // MiddleLeftButton
            // 
            MiddleLeftButton.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MiddleLeftButton.Location = new Point(-2, 200);
            MiddleLeftButton.Name = "MiddleLeftButton";
            MiddleLeftButton.Size = new Size(200, 200);
            MiddleLeftButton.TabIndex = 3;
            MiddleLeftButton.Text = " ";
            MiddleLeftButton.UseVisualStyleBackColor = true;
            MiddleLeftButton.Click += Button_Click;
            // 
            // MiddleButton
            // 
            MiddleButton.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MiddleButton.Location = new Point(200, 200);
            MiddleButton.Name = "MiddleButton";
            MiddleButton.Size = new Size(200, 200);
            MiddleButton.TabIndex = 4;
            MiddleButton.Text = " ";
            MiddleButton.UseVisualStyleBackColor = true;
            MiddleButton.Click += Button_Click;
            // 
            // MiddleRightButton
            // 
            MiddleRightButton.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MiddleRightButton.Location = new Point(402, 200);
            MiddleRightButton.Name = "MiddleRightButton";
            MiddleRightButton.Size = new Size(200, 200);
            MiddleRightButton.TabIndex = 5;
            MiddleRightButton.Text = " ";
            MiddleRightButton.UseVisualStyleBackColor = true;
            MiddleRightButton.Click += Button_Click;
            // 
            // BottomLeftButton
            // 
            BottomLeftButton.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BottomLeftButton.Location = new Point(-2, 402);
            BottomLeftButton.Name = "BottomLeftButton";
            BottomLeftButton.Size = new Size(200, 200);
            BottomLeftButton.TabIndex = 6;
            BottomLeftButton.Text = " ";
            BottomLeftButton.UseVisualStyleBackColor = true;
            BottomLeftButton.Click += Button_Click;
            // 
            // BottomMiddleButton
            // 
            BottomMiddleButton.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BottomMiddleButton.Location = new Point(200, 402);
            BottomMiddleButton.Name = "BottomMiddleButton";
            BottomMiddleButton.Size = new Size(200, 200);
            BottomMiddleButton.TabIndex = 7;
            BottomMiddleButton.Text = " ";
            BottomMiddleButton.UseVisualStyleBackColor = true;
            BottomMiddleButton.Click += Button_Click;
            // 
            // BottomRightButton
            // 
            BottomRightButton.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BottomRightButton.Location = new Point(402, 402);
            BottomRightButton.Name = "BottomRightButton";
            BottomRightButton.Size = new Size(200, 200);
            BottomRightButton.TabIndex = 8;
            BottomRightButton.Text = " ";
            BottomRightButton.UseVisualStyleBackColor = true;
            BottomRightButton.Click += Button_Click;
            // 
            // WinningBar
            // 
            WinningBar.Location = new Point(-10, 600);
            WinningBar.Name = "WinningBar";
            WinningBar.Size = new Size(624, 23);
            WinningBar.TabIndex = 9;
            // 
            // ResetButton
            // 
            ResetButton.Location = new Point(75, 642);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(200, 50);
            ResetButton.TabIndex = 10;
            ResetButton.Text = "RESET";
            ResetButton.UseVisualStyleBackColor = true;
            ResetButton.Click += ResetButton_Click;
            // 
            // CPUButton
            // 
            CPUButton.Location = new Point(325, 642);
            CPUButton.Name = "CPUButton";
            CPUButton.Size = new Size(200, 50);
            CPUButton.TabIndex = 11;
            CPUButton.Text = "CPU";
            CPUButton.UseVisualStyleBackColor = true;
            CPUButton.Click += CPUButton_Click;
            // 
            // TicTacToe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 714);
            Controls.Add(CPUButton);
            Controls.Add(ResetButton);
            Controls.Add(WinningBar);
            Controls.Add(BottomRightButton);
            Controls.Add(BottomMiddleButton);
            Controls.Add(BottomLeftButton);
            Controls.Add(MiddleRightButton);
            Controls.Add(MiddleButton);
            Controls.Add(MiddleLeftButton);
            Controls.Add(TopRightButton);
            Controls.Add(TopMiddleButton);
            Controls.Add(TopLeftButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "TicTacToe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TicTacToe";
            ResumeLayout(false);
        }

        #endregion

        private Button TopLeftButton;
        private Button TopMiddleButton;
        private Button TopRightButton;
        private Button MiddleLeftButton;
        private Button MiddleButton;
        private Button MiddleRightButton;
        private Button BottomLeftButton;
        private Button BottomMiddleButton;
        private Button BottomRightButton;
        private ProgressBar WinningBar;
        private Button ResetButton;
        private Button CPUButton;
    }
}
