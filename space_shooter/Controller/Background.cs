using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space_shooter
{
    class Background
    {
        //komponen background gerak berupa bintang
        private Rectangle[] bintang;
        private Random rand;
        private int backgroundspeed;
        private Color color;
        private Game game;

        public Rectangle[] Bintang { get => bintang; set => bintang = value; }
        public Random Rand { get => rand; set => rand = value; }
        public int Backgroundspeed { get => backgroundspeed; set => backgroundspeed = value; }
        public Color Color { get => color; set => color = value; }
        public Game Game { get => game; set => game = value; }

        public Background(Game game)
        {
            //membuat bintang berupa rectangle
            Bintang = new Rectangle[20];
            Rand = new Random();
            Backgroundspeed = 4;
            Game = game;
            Color = Color.Black;

            for (int i = 0; i < bintang.Length; i++)
            {
                //menentukan posisi bintang secara random
                bintang[i] = new Rectangle();
                bintang[i].Location = new Point(rand.Next(20, game.Width), rand.Next(-10, game.Height));
            }
        }

        //menambahkan pergerakan bintang
        public void tick()
        {
            for (int i = 0; i < bintang.Length / 3; i++)
            {
                bintang[i].Y += backgroundspeed;
                if (bintang[i].Y >= game.Height)
                {
                    bintang[i].Y = -15;
                }
            }
            for (int i = bintang.Length / 3; i < bintang.Length * 2 / 3; i++)
            {
                bintang[i].Y += backgroundspeed - 2;
                if (bintang[i].Top >= game.Height)
                {
                    bintang[i].Y = -10;
                }
            }
            for (int i = bintang.Length * 2 / 3; i < bintang.Length; i++)
            {
                bintang[i].Y += backgroundspeed - 1;
                if (bintang[i].Top >= game.Height)
                {
                    bintang[i].Y = -17;
                }
            }
        }

        //menggambar bintang
        public void render(Graphics g)
        {
            g.FillRectangle(new SolidBrush(color), 0, 0, game.Width, game.Height);
            for (int i = 0; i < bintang.Length; i++)
            {

                if (i % 2 == 1)
                {
                    bintang[i].Size = new Size(2, 2);
                    g.FillRectangle(new SolidBrush(Color.White), bintang[i]);
                }
                else
                {
                    bintang[i].Size = new Size(3, 3);
                    g.FillRectangle(new SolidBrush(Color.DarkGray), bintang[i]);
                }

            }
        }
    }
}
