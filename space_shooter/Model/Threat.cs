using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space_shooter
{
    //interdace entitas dari peluru musuh dan musuhnya
    interface Threat
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
        int VelX
        {
            get;
            set;
        }
        int VelY
        {
            get;
            set;
        }
        int Width
        {
            get;
            set;
        }
        int Height
        {
            get;
            set;
        }
    }
}
