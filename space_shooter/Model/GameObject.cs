using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space_shooter
{
    //komponen dasar dari objek yang ada pada game ini
    class GameObject
    {
        private int x;
        private int y;
        private int width;
        private int height;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }

        public GameObject(int x, int y, int w, int h)
        {
            this.X = x;
            this.Y = y;
            this.Width = w;
            this.Height = h;
        }

        public Rectangle getBound()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }

        
    }
}
