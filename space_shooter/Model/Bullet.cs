using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space_shooter
{
    //merupakan kelas yang mengatur data dari peluru
    class Bullet : GameObject
    {
       
        private int speed;
        private Color color;
       
        public int Speed { get => speed; set => speed = value; }
        public Color Color { get => color; set => color = value; }

        public Bullet(int x, int y, int w, int h,Color color, int speed) : base(x,y,w,h)
        {
            
            Color = color;
            Speed = speed;
        }

        public void tick()
        {
            Y -= speed;
            
        }

        public void render(Graphics g)
        {
            g.FillRectangle(new SolidBrush(color),X,Y,Width,Height);
        }
    }
}
