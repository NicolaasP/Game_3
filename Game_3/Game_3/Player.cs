using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_3
{
    class Player
    {
        public int y;
        public int x;
        public int speed = 5;
        private const int xSize = 30;
        private const int ySize = 30;

        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void setSpeed(int speed)
        {
            this.speed = speed;
        }

        public int getWidth()
        {
            return xSize;
        }

        public int getHeight()
        {
            return ySize;
        }
    }
}
