using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space_shooter
{
    class Physic
    {
        //controller yang mengatur tabrakan tiap object game
        private Game game;

        public Game Game { get => game; set => game = value; }

        public Physic(Game G)
        {
            Game = G;
        }

        public bool Collision (Friendly frn, List<Threat> thr)
        {
            for(int i = 0; i < thr.Count; i++)
            {
                if (frn.getBound().IntersectsWith(thr[i].getBound()))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Collision(Threat frn, List<Friendly> thr)
        {
            for (int i = 0; i < thr.Count; i++)
            {
                if (frn.getBound().IntersectsWith(thr[i].getBound()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
