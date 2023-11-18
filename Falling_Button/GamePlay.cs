using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Falling_Button
{
    public partial class GamePlay : Form
    {
        
        public GamePlay()
        {
            InitializeComponent();
            InitGame();
        }

        private void timer_UpdateGame_Tick(object sender, EventArgs e)
        {
            PlayerMove();
            PlayerOver();
            LongButtonsMove();
            ScoreProcess();
        }

        private void timer_GenerateLongButton_Tick(object sender, EventArgs e)
        {
            SpawnLongButton();
        }

        private void button_Player_Click(object sender, EventArgs e)
        {
            PlayerJump();
        }

        private void GamePlay_MouseDown(object sender, MouseEventArgs e)
        {
            PlayerJump();
        }

        private void GamePlay_KeyDown(object sender, KeyEventArgs e)
        {
            PlayerJump();
        }

        //自定义函数
        int score = 0;//得分
        const double JUMP_SPEED = 3.5;
        double dy = 0.0;
        private void InitGame()
        {
            dy = -JUMP_SPEED;//负值向上
        }

        private void PlayerMove()
        {
            button_Player.Location = new Point(button_Player.Location.X, button_Player.Location.Y + (int)dy);
            dy += 0.25;
            if (button_Player.Location.Y < 0)//防止button_Player跳出窗口外
            {
                button_Player.Location = new Point(button_Player.Location.X, 0);
                dy = 0.0;
            }
        }

        private void PlayerJump()
        {
            dy = -JUMP_SPEED;
        }

        private void PlayerOver()
        {
            if(button_Player.Location.Y > this.Size.Height + 64)
            {
                GameOverProcess();
            }
        }

        //长按钮(指显卡)
        List<Button> pillarButtons = new List<Button>();//每一组障碍的上下两根柱子
        List<Button> gapButtons = new List<Button>();//中间的缝隙
        const int LONG_BUTTON_MOVE_SPEED = 1;
        Button upLongButton;
        Button midButton;//指中间的空隙
        Button downLongButton;
        const int GAP_HEIGHT = 72;
        private void SpawnLongButton()
        {
            Random r = new Random();
            upLongButton = new Button();
            upLongButton.Location = new Point(this.Width + 32, 0);
            upLongButton.Size = new Size(32, r.Next(64, this.Size.Height - 128));//宽为64,高为 64与[该窗口的高-64]之间
            upLongButton.Enabled = false;
            upLongButton.BackColor = Color.DodgerBlue;

            midButton = new Button();
            midButton.Location = new Point(this.Width + 32, upLongButton.Location.Y + upLongButton.Size.Height);
            midButton.Size = new Size(32, GAP_HEIGHT);//缝隙高为72
            midButton.Enabled = false;
            midButton.BackColor = Color.ForestGreen;

            downLongButton = new Button();
            downLongButton.Location = new Point(upLongButton.Location.X, upLongButton.Location.Y + upLongButton.Height + GAP_HEIGHT);
            downLongButton.Size = new Size(upLongButton.Width, this.Height - upLongButton.Location.Y - upLongButton.Height - GAP_HEIGHT);//72为空隙高度
            downLongButton.Enabled = false;
            downLongButton.BackColor = Color.DodgerBlue;

            this.Controls.Add(upLongButton);
            this.Controls.Add(midButton);
            this.Controls.Add(downLongButton);
            pillarButtons.Add(upLongButton);
            gapButtons.Add(midButton);
            pillarButtons.Add(downLongButton);  
        }

        private void LongButtonsMove()
        {
            List<Button> temp = new List<Button>();//临时列表，用于删除长按钮
            foreach (Button button in pillarButtons)
            {
                button.Location = new Point(button.Location.X - LONG_BUTTON_MOVE_SPEED, button.Location.Y);
                if (button.Location.X < -64)
                {
                    temp.Add(button);
                }
                if(CheckCollision(button_Player.Location.X,button_Player.Location.Y,button_Player.Width,button_Player.Height
                    ,button.Location.X,button.Location.Y,button.Width,button.Height))
                {
                    GameOverProcess();
                }
            }
            foreach(Button button in temp)
            {
                this.Controls.Remove(button);
                pillarButtons.Remove(button);
            }

            List<Button> midTemp = new List<Button>();//临时列表，用于删除缝隙按钮
            foreach(Button button in gapButtons)
            {
                button.Location = new Point(button.Location.X - LONG_BUTTON_MOVE_SPEED, button.Location.Y);
                if (button.Location.X < -64)
                {
                    midTemp.Add(button);
                }
            }
            foreach (Button button in temp)
            {
                this.Controls.Remove(button);
                gapButtons.Remove(button);
            }
        }

        //处理得分
        private void ScoreProcess()
        {
            List<Button> midTemp = new List<Button>();//临时列表，用于删除缝隙按钮
            foreach (Button button in gapButtons)
            {
                if(CheckCollision(button_Player.Location.X,button_Player.Location.Y,button_Player.Width,button_Player.Height
                    ,button.Location.X,button.Location.Y,button.Width,button.Height))
                {
                    score++;
                    label_Score.Text = "Score:" + Convert.ToString(score);
                    midTemp.Add(button);
                }
            }
            foreach(Button button in midTemp)
            {
                this.Controls.Remove(button);
                gapButtons.Remove(button) ;
            }
        }

        //检测碰撞
        private bool CheckCollision(int x1, int y1, int w1, int h1, int x2, int y2, int w2, int h2)
        {
            if (x1 > x2 + w2 || x1 + w1 < x2 || y1 > y2 + h2 || y1 + h1 < y2)
            {
                return false;
            }
            return true;
        }

        //游戏结束
        private void GameOverProcess()
        {
            GameOver gameOver = new GameOver();
            gameOver.TopLevel = false;
            gameOver.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(gameOver);
            gameOver.label_Score.Text = label_Score.Text;
            gameOver.Show();
            this.Dispose();
        }
    }
}
 