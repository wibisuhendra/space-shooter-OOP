using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space_shooter
{
    //interdace entitas dari peluru player dan pplayer
    interface Friendly
    {
        void tick();
        void render(Graphics g);
        Rectangle getBound();

        int X
        {
            get;
            set;
        }

        int Y
        {
            get;
            set;
        }
    }
}
