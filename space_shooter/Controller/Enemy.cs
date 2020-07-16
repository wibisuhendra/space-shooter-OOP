using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space_shooter
{
    class Enemy : GameObject , Threat 
    {
       //komponen musuh
        private Image image;
        private int velX;
        private int velY;
        private Game game;
        private Random r;
        private List<EnemyBullet> b;
        private int default_delay_time = 500; //waktu delay default
        private int time;
        private EntityController ec;

        private int shoot_time;//kecepatan menembak
        
        public Image Image { get => image; set => image = value; }
        public int VelX { get => velX; set => velX = value; }
        public int VelY { get => velY; set => velY = value; }
        public int Shoot_time { get => shoot_time; set => shoot_time = value; }

        //konstruktor
        public Enemy(String img, int x, int y, int w, int h, int velX, int velY,int delay, Game game,EntityController ec) : base( x, y,  w,  h)
        {
            
            Image = Image.FromFile(img);
            VelX = velX;
            VelY = velY;
            this.game = game;
            b = new List<EnemyBullet>();
            Shoot_time = delay;
            time = default_delay_time;
            this.ec = ec;

        }
        
        //mthod agar musuh dapat menembak, menggunakan delay agar terdapat delay
        public void shoot()
        {
            time -= Shoot_time;
            Y += VelY;
            int u = default_delay_time;
            if (time <= 0)
            {
                time = default_delay_time;
                ec.addEbullet(new EnemyBullet(((this.X + this.Width / 2)), this.Y + this.Height, 4, 10, Color.Red, (this.VelY + 5)));
            }
        }
        
        //memberikan pergerakan dari objek musuh
        public void tick()
        {
            shoot();

            r = new Random();
            for (int i = 0; i< ec.Ebullet.Count; i++)
            {
                
                if (ec.Ebullet[i].X >= game.Height)
                {
                    ec.Ebullet.Remove(ec.Ebullet[i]);
                }
            }
            if (Y > game.Height)
            {
                Y = -60;
                velY = r.Next(2, 6);
                X = r.Next(12)*33;

            }

        }

        //menggambarkan tiap tick tersebut
        public void render(Graphics g)
        {
            g.DrawImage(Image, X, Y, Width, Height);
            for(int i = 0; i < b.Count; i++)
            {
                b[i].render(g);
            }
        }
    }
}
