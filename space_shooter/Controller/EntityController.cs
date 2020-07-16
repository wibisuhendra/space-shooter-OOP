using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space_shooter
{
    class EntityController
    {
        //merupakan controller yang mengatur semua entitas yang ada pada game ini
        private List<Threat> thr = new List<Threat>();
        private List<Threat> ebullet = new List<Threat>();
        private List<Friendly> frn = new List<Friendly>();

        Threat Tr;
        Friendly Fr;
        

        Game game;
        Physic ph;

        Random r;

        internal List<Threat> Thr { get => thr; set => thr = value; }//entitas musuh
        internal List<Threat> Ebullet { get => ebullet; set => ebullet = value; }//peluru musuh
        internal List<Friendly> Frn { get => frn; set => frn = value; }//peluru player


        //constructor
        public EntityController(Game game)
        {
            r = new Random();
            this.game = game;
            ph = new Physic(game);

        }

        //mendefiniskan pergerakan setiap entitas
        public void tick()
        {
            int hit = 0;

            for (int i = 0; i < Thr.Count; i++)//loop untuk musuh
            {
                Thr[i].tick();
                int x = r.Next(0, Thr.Count);
                if (ph.Collision(Thr[i], frn))//jika terjadi interseksi musuh dengan peluru player
                {
                    removeThreat(Thr[i]);
                    hit = 1;//hit agar kedua object dihilangkan dari frame
                    game.Score++;
                    game.DeadEnemy++;
                }
                
            }



            for (int i = 0; i < Frn.Count; i++)//loop untuk peluru player
            {
                Frn[i].tick();
                if (Frn[i].Y < 0)
                {
                    removeFriendly(Frn[i]);
                }
                else
                {
                    if (hit == 1)
                    {
                        removeFriendly(Frn[i]);
                    }   
                }
                
            }

            for (int i = 0; i < Ebullet.Count; i++)//loop untuk peluru musuh
            {
                Ebullet[i].tick();
                
            }

           

        }

        //menggambar tick di atas
        public void render(Graphics g)
        {
            for (int i = 0; i < Thr.Count; i++)//loop musuh
            {
                Thr[i].render(g);

            }

            for (int i = 0; i < Frn.Count; i++)//loop peluru player
            {
                Frn[i].render(g);
            }

            for (int i = 0; i < Ebullet.Count; i++)//loop peluru musuh
            {
                Ebullet[i].render(g);
            }

        }

        public void makeEnemy(int enemy_count)//method agar musuh terus datang dengan jumlah yang dinamis, disesuaikan dengan score
        {
            string e1 = "img/enemy1.png";
            string e2 = "img/enemy2.png";
            string e3 = "img/enemy3.png";

            Enemy en;

            for (int i = 0; i < enemy_count / 3; i++)//musuh jenis satu 
            {
                en = new Enemy(e3, r.Next(12)*33, r.Next(1,game.CountEnemy)*-45, 35, 35,0,5,r.Next(1,4)*4,game,this);
                addThreat(en);
            }
            for (int i = enemy_count/3; i < enemy_count * 2 / 3; i++)//musuh jenis dua
            {
                en = new Enemy(e2, r.Next(12) * 33, r.Next(1,game.CountEnemy) * -45, 35, 35, 0, 5, r.Next(1, 4) * 4, game, this);
                addThreat(en);
            }
            for (int i = enemy_count * 2 / 3; i < enemy_count; i++)// musuh jenis 3
            {
                en = new Enemy(e1, r.Next(12) * 33, r.Next(1,game.CountEnemy) * -45, 35, 35, 0, 5, r.Next(1, 4) * 4, game, this);
                addThreat(en);
            }


        }

       //method untuk menambahkan serta menghapus objek dari tiap tiap entitas
        public void addFriendly(Friendly ent)
        {
            this.Frn.Add(ent);
        }

        public void removeFriendly(Friendly ent)
        {
            this.Frn.Remove(ent);
        }

        public void addThreat(Threat ent)
        {
            this.Thr.Add(ent);
        }

        public void removeThreat(Threat ent)
        {
            this.Thr.Remove(ent);
        }

        public void addEbullet(Threat ent)
        {
            this.Ebullet.Add(ent);
        }

        public void removeEbullet(Threat ent)
        {
            this.Ebullet.Remove(ent);
        }

    }
}
