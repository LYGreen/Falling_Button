namespace Falling_Button
{
    partial class GamePlay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_Player = new System.Windows.Forms.Button();
            this.timer_UpdateGame = new System.Windows.Forms.Timer(this.components);
            this.timer_GenerateLongButton = new System.Windows.Forms.Timer(this.components);
            this.label_Score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Player
            // 
            this.button_Player.BackColor = System.Drawing.Color.DarkGreen;
            this.button_Player.Location = new System.Drawing.Point(46, 119);
            this.button_Player.Name = "button_Player";
            this.button_Player.Size = new System.Drawing.Size(32, 32);
            this.button_Player.TabIndex = 0;
            this.button_Player.UseVisualStyleBackColor = false;
            this.button_Player.Click += new System.EventHandler(this.button_Player_Click);
            // 
            // timer_UpdateGame
            // 
            this.timer_UpdateGame.Enabled = true;
            this.timer_UpdateGame.Interval = 1;
            this.timer_UpdateGame.Tick += new System.EventHandler(this.timer_UpdateGame_Tick);
            // 
            // timer_GenerateLongButton
            // 
            this.timer_GenerateLongButton.Enabled = true;
            this.timer_GenerateLongButton.Interval = 3000;
            this.timer_GenerateLongButton.Tick += new System.EventHandler(this.timer_GenerateLongButton_Tick);
            // 
            // label_Score
            // 
            this.label_Score.AutoSize = true;
            this.label_Score.BackColor = System.Drawing.Color.SkyBlue;
            this.label_Score.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Score.Location = new System.Drawing.Point(12, 9);
            this.label_Score.Name = "label_Score";
            this.label_Score.Size = new System.Drawing.Size(117, 28);
            this.label_Score.TabIndex = 1;
            this.label_Score.Text = "Score:0";
            // 
            // GamePlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(639, 379);
            this.Controls.Add(this.button_Player);
            this.Controls.Add(this.label_Score);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GamePlay";
            this.Text = "GamePlay";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GamePlay_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GamePlay_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Player;
        private System.Windows.Forms.Timer timer_UpdateGame;
        private System.Windows.Forms.Timer timer_GenerateLongButton;
        private System.Windows.Forms.Label label_Score;
    }
}