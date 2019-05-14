using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_3
{
    class Ground
    {
        public int x;
        public int y;
        private const int width = 1000;
        private const int height = 400;

        public Ground(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getWidth() {
            return width;
        }

        public int getHeight()
        {
            return height;
        }
    }
}
