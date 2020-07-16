using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space_shooter
{
    //kelas dari player
    class Player : GameObject, Friendly
    {
       
        private Image image;
        private int velX;
        private int velY;
        private Game game;
        private Physic ph;
        
        public Image Image { get => image; set => image = value; }
        public int VelX { get => velX; set => velX = value; }
        public int VelY { get => velY; set => velY = value; }
        public Game Game { get => game; set => game = value; }

        //constructor
        public Player(String img,int x, int y, int w, int h, Game game) : base(x,y,w,h)
        {
            
            Image = Image.FromFile(img);
            VelX = 0;
            VelY = 0;
            this.game = game;
            ph = new Physic(game);
        }

        //tick
        public void tick()
        {

            if (ph.Collision(this, game.Threats)||ph.Collision(this,game.Enemybullet))//cek tabrakan tiap ticknya baik itu dengan musuh ataupun peluru musuh
            {
                Game.Gameover = true;
            }

            this.X += VelX;
            this.Y += VelY;

            //batasan

            if (X <= 0)
            {
                X = 0;
            }
            if (X >= this.game.Width - Width - 20 )
            {
                X = game.Width - Width - 20;
            }
           if (Y <= 7)
            {
                Y = 7;
            }
            if (Y >= game.Height - Height - Height)
            {
                Y = game.Height - Height - 50;
            }

        }

        //gambar tick
        public void render(Graphics g)
        {
            g.DrawImage(Image, X, Y, Width, Height);
        }

        
    }
}
