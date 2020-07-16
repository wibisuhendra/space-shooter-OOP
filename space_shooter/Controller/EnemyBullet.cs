using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space_shooter
{
    class EnemyBullet : Bullet,Threat
    {
        //merupakan Turunan dari bullet yang merupakan peluru, yg akan keluar dari musuh
        public int VelX { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int VelY { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public EnemyBullet(int x, int y, int w, int h,Color color, int speed) : base(x,y,w,h, color, speed)
        {
            
        }

        //metode pergerakan peluru musuh
        public void tick()
        {

            Y += Speed;
            
        }

        //menggamar tiap tick yang ada
        public void render(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color),X,Y,Width,Height);
        }
    }
}
