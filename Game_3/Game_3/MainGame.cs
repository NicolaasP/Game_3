using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_3
{
    public partial class MainGame : Form
    {
        private enum side { HOR, VER, NONE};


        private Player player;
        private Ground ground;
        private Settings settings = new Settings();
        private List<box> traps = new List<box>();
        private box goal;
        private int stY = 0;
        private bool jm = false;
        Label l = new Label();

        public MainGame()
        {
            InitializeComponent();
            l.Location = new Point(10, 10);
            l.Visible = true;
            l.ForeColor = Color.Black;
            l.BackColor = Color.Gray;
            l.Text = "start";
        }

        private void MainGame_Load(object sender, EventArgs e)
        {
            player = new Player(10, 550);
            ground = new Ground(-10, 600);
            goal = new box(954, 570);
            ticker.Interval = 10;
            genEn();
            ticker.Start();

        }


        private void genEn()
        {
            Random r = new Random();
            int num = r.Next(1, 6);
            
            for(int i = 0; i <= num; i++)
            {
                int x = r.Next(50, 924);
                int y = r.Next(570, 599);
                traps.Add(new box(x, y));
            }
        }

        private void MainGame_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            //paint player
            graphics.FillRectangle(Brushes.Blue, player.x, player.y, player.getWidth(), player.getHeight());

            graphics.FillRectangle(Brushes.Green, goal.x, goal.y, goal.Width, goal.Height);

            try
            {
                for (int i = 0; i < traps.Count; i++)
                {
                    graphics.FillRectangle(Brushes.Red, traps[i].x, traps[i].y, traps[i].Width, traps[i].Height);
                }
            }
            catch (Exception)
            {

            }

            graphics.FillRectangle(Brushes.Brown, ground.x, ground.y, ground.getWidth(), ground.getHeight());
        }

        private void MainGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private bool hit(Rectangle a, Rectangle b)
        {
           return !((b.Y > (a.Y + a.Height) || a.Y > (b.Y + b.Height)) ||
                (b.X > (a.X + a.Width) || a.X > (b.X + b.Width)));
        }

        private void Ticker_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
            int pastX = player.x;
            int pastY = player.y;
            player.x -= settings.playerXSpeed;
            player.x += settings.playerYSpeed;
            if (jm && player.y <= stY)
            {
                settings.gravSpeed *= -1;
                jm = false;
            }
            if (!hit(new Rectangle(player.x, player.y, player.getWidth(), player.getHeight()), new Rectangle(ground.x, ground.y, ground.getWidth(), ground.getHeight())))
            {
                player.y += settings.gravSpeed;
            }
            if (player.x < 0) player.x = 0;
            l.Text = "Player x: " + player.x; 
            if ((player.x + (player.getWidth() + 16)) > this.Width) player.x = (this.Width - (player.getWidth() + 16));
            hitBox(pastX, pastY);
            if (new Rectangle(player.x, player.y, player.getWidth(), player.getHeight()).IntersectsWith(new Rectangle(goal.x, goal.y, goal.Width, goal.Height))) Win();
        }

        private void Win()
        {
            ticker.Stop();
            MessageBox.Show("You Won");
            reset();
            ticker.Start();
        }

        private void reset()
        {
            player.x = 10;
            player.y = 500;
            settings.playerXSpeed = 0;
            settings.playerYSpeed = 0;
            traps.Clear();
            genEn();
        }

        private void hitBox(int pX, int pY)
        {
            Rectangle pl = new Rectangle(player.x, player.y, player.getWidth(), player.getHeight());
            try
            {
                foreach(box temp in traps)
                {
                    Rectangle rectangle = new Rectangle(temp.x, temp.y, temp.Width, temp.Height);
                    if (pl.IntersectsWith(rectangle))
                    {
                        ticker.Stop();
                        Die();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void Die()
        {
            MessageBox.Show("You Died");
            player.x = 10;
            player.y = 500;
            settings.playerXSpeed = 0;
            settings.playerYSpeed = 0;
            ticker.Start();
        }

        private void jump()
        {
            if (hit(new Rectangle(player.x, player.y, player.getWidth(), player.getHeight()), new Rectangle(ground.x, ground.y, ground.getWidth(), ground.getHeight())))
            {
                jm = true;
                stY = player.y - settings.jumpHeight;
                player.y -= settings.gravSpeed;
                settings.gravSpeed *= -1;
            }
        }

        private void gen()
        {
            
            int x = Cursor.Position.X - this.Left - 14;
            int y = Cursor.Position.Y - this.Top - 37;
            traps.Add(new box(x, y));
        }

        private void MainGame_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.A:
                    settings.playerXSpeed = 10;
                    break;
                case Keys.D:
                    settings.playerXSpeed = -10;
                    break;
                case Keys.Space:
                    jump();
                    break;
                case Keys.P:
                    gen();
                    break;
                case Keys.O:
                    reset();
                    break;
            }
        }

        private void MainGame_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.A:
                    settings.playerXSpeed = 0;
                    break;
                case Keys.D:
                    settings.playerXSpeed = 0;
                    break;
            }
        }
    }
}
