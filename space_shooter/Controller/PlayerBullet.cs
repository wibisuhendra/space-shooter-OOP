using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space_shooter
{
    //peluru player
    class PlayerBullet : Bullet,Friendly
    {

        Game game;
        Physic ph;
        EntityController ec;
        public PlayerBullet(int x, int y, int w, int h,Color color, int speed,Game game, EntityController Ec) : base(x,y,w,h,color,speed)
        {
            this.game = game;
            ph = new Physic(game);
            ec = Ec;
        }

        public void tick()
        {
            Y -= Speed;

            
            
        }

        public void render(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color),X,Y,Width,Height);
        }
    }
}
