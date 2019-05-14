using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_3
{
    class box
    {
        public int x;
        public int y;
        public int Width;
        public int Height;

        public box(int x = 0, int y = 0, int Width = 30, int Height = 30)
        {
            this.x = x;
            this.y = y;
            this.Width = Width;
            this.Height = Height;
        }
    }
}
