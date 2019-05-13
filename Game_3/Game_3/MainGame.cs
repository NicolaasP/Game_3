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
        private Player player;
        private Ground ground;
        private Settings settings = new Settings();
        private int stY = 0;
        private bool jm = false;

        public MainGame()
        {
            InitializeComponent();
        }

        private void MainGame_Load(object sender, EventArgs e)
        {
            player = new Player(10, 550);
            ground = new Ground(-10, 600);
            ticker.Interval = 100;
            ticker.Start();
        }

        private void MainGame_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            //paint player
            graphics.FillRectangle(Brushes.Brown, player.x, player.y, player.getWidth(), player.getHeight());
            //paint ground
            graphics.FillRectangle(Brushes.Green, ground.x, ground.y, ground.getWidth(), ground.getHeight());
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
            if (jm && player.y <= stY)
            {
                settings.gravSpeed *= -1;
                jm = false;
            }
            if (!hit(new Rectangle(player.x, player.y, player.getWidth(), player.getHeight()), new Rectangle(ground.x, ground.y, ground.getWidth(), ground.getHeight())))
            {
                player.y += settings.gravSpeed;
            }
            this.Invalidate();
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

        private void MainGame_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.A:
                    player.x -= settings.playerSpeed;
                    break;
                case Keys.D:
                    player.x += settings.playerSpeed;
                    break;
                case Keys.Space:
                    jump();
                    break;
            }
        }
    }
}
