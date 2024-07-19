namespace TicTacToeBot
{
    partial class Form1
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            progressBar1 = new ProgressBar();
            ResetButton = new Button();
            CPUButton = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(-2, -2);
            button1.Name = "button1";
            button1.Size = new Size(200, 200);
            button1.TabIndex = 0;
            button1.Text = " ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(200, -2);
            button2.Name = "button2";
            button2.Size = new Size(200, 200);
            button2.TabIndex = 1;
            button2.Text = " ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(402, -2);
            button3.Name = "button3";
            button3.Size = new Size(200, 200);
            button3.TabIndex = 2;
            button3.Text = " ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Button_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(-2, 200);
            button4.Name = "button4";
            button4.Size = new Size(200, 200);
            button4.TabIndex = 3;
            button4.Text = " ";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Button_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(200, 200);
            button5.Name = "button5";
            button5.Size = new Size(200, 200);
            button5.TabIndex = 4;
            button5.Text = " ";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Button_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.Location = new Point(402, 200);
            button6.Name = "button6";
            button6.Size = new Size(200, 200);
            button6.TabIndex = 5;
            button6.Text = " ";
            button6.UseVisualStyleBackColor = true;
            button6.Click += Button_Click;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.Location = new Point(-2, 402);
            button7.Name = "button7";
            button7.Size = new Size(200, 200);
            button7.TabIndex = 6;
            button7.Text = " ";
            button7.UseVisualStyleBackColor = true;
            button7.Click += Button_Click;
            // 
            // button8
            // 
            button8.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.Location = new Point(200, 402);
            button8.Name = "button8";
            button8.Size = new Size(200, 200);
            button8.TabIndex = 7;
            button8.Text = " ";
            button8.UseVisualStyleBackColor = true;
            button8.Click += Button_Click;
            // 
            // button9
            // 
            button9.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.Location = new Point(402, 402);
            button9.Name = "button9";
            button9.Size = new Size(200, 200);
            button9.TabIndex = 8;
            button9.Text = " ";
            button9.UseVisualStyleBackColor = true;
            button9.Click += Button_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(-19, 600);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(655, 23);
            progressBar1.TabIndex = 9;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 714);
            Controls.Add(CPUButton);
            Controls.Add(ResetButton);
            Controls.Add(progressBar1);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private ProgressBar progressBar1;
        private Button ResetButton;
        private Button CPUButton;
    }
}
