using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using space_shooter.Controller;
using WMPLib;

namespace space_shooter
{
    
    public partial class Game : Form
    {

        //komponen
        private int countEnemy;
        private int deadEnemy;
        private int iterator;
        private int score;
        private bool gameover,started,pause,newGame;

        WindowsMediaPlayer music;
        Player player;
        Background background;
        EntityController ec;
        List<Friendly> friendlies;
        List<Threat> threats;
        List<Threat> enemybullet;
        
        //ListEnemyBullet eb;


        
        string e1 = "img/enemy1.png";
        string e2 = "img/enemy2.png";
        string e3 = "img/enemy3.png";
        string e4 = "img/enemy4.png";

        Random r;

        private System.Timers.Timer gametimer = new System.Timers.Timer();

        //getset
        public int CountEnemy { get => countEnemy; set => countEnemy = value; }
        public int DeadEnemy { get => deadEnemy; set => deadEnemy = value; }
        internal EntityController Ec { get => ec; set => ec = value; }
        internal List<Friendly> Friendlies { get => friendlies; set => friendlies = value; }
        internal List<Threat> Threats { get => threats; set => threats = value; }
        public int Score { get => score; set => score = value; }
        public bool Gameover { get => gameover; set => gameover = value; }
        public bool Started { get => started; set => started = value; }
        public bool Pause { get => pause; set => pause = value; }
        public bool NewGame { get => newGame; set => newGame = value; }
        public System.Timers.Timer Gametimer { get => gametimer; set => gametimer = value; }
        internal List<Threat> Enemybullet { get => enemybullet; set => enemybullet = value; }

        MainForm Mf;

        //constructor
        public Game(MainForm mf)
        {
            
            Mf = mf;
            InitializeComponent();
            timerConfig();
            Init();

        }


        //configurasi timer
        public void timerConfig()
        {
            Gametimer.Interval = 33;
            Gametimer.Elapsed += gameTick;
            Gametimer.AutoReset = true;
            Gametimer.Enabled = true;
        }

        //inisialisasi awal
        public void Init()
        {
            Gameover = false;
            Started = true;
            Pause = false;
            NewGame = false;
            gamepause(Pause);

            //karena sistem game adalah save game sehingga score yang ada akan dicek terlebih dahulu untuk membuat musuh yang akan datang
            score = Mf.Uc.Peace;
            CountEnemy = score/4 + 4;
            DeadEnemy = 0;
            iterator = 1;
            
            //membuat object player
            player = new Player("img/player.png", (this.Width / 2) - 25, this.Height - 100, 35, 35,this);
            background = new Background(this);
            Ec = new EntityController(this);

            //membuat musuh
            Ec.makeEnemy(CountEnemy);

            Friendlies = Ec.Frn;
            Threats = Ec.Thr;
            Enemybullet = Ec.Ebullet;





            //musik
            music = new WindowsMediaPlayer();
            music.URL = "music/bgmusic.mp3";
            music.settings.setMode("Loop", true);
            music.settings.volume = 5;
            music.controls.play();
       
        }

       

        
        //tick dari core game
        public void gameTick(Object source, System.Timers.ElapsedEventArgs e)
        {
            

            Invalidate();
            
            if (!Gameover && !Pause)
            {
                player.tick();
                background.tick();
                if (DeadEnemy >= CountEnemy)
                {
                    DeadEnemy = 0;
                    CountEnemy += 2;
                    ec.makeEnemy(CountEnemy);
                }
                Ec.tick();
                
            }


        }


        //menggambar tick tersebut
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //draw
            
            background.render(g);
            player.render(g);
            Ec.render(g);
            g.DrawString("Score " + score, new Font(SystemFonts.DefaultFont.FontFamily,20), Brushes.White,2,2);


            if (Gameover)
            {
                gamestop(Gameover);
            }
            if (NewGame)
            {
                Init();
            }



            base.OnPaint(e);
        }
       
        //method untuk game ketika berakhir
        public void gamestop(bool a)
        {
            
            lblState.Text = "GAMEOVER";

            lblState.Location = new Point(29, 211);
            lblState.Visible = true;
            btnExit.Visible = true;
        }

        
        //method untuk game saat dalam state pause
        public void gamepause(bool a)
        {

            lblState.Text = "PAUSE";
            lblState.Location = new Point(90, 211);
            lblState.Visible = a;
            btnExit.Visible = a;
        }

      
        //keyboard input
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Gameover)
            {
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                {
                    player.VelX = 10;
                }
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                {
                    player.VelX = -10;
                }
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                {
                    player.VelY = -10;
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                {
                    player.VelY = 10;
                }
               
            }
            

        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            if (!Gameover)
            {
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                {
                    player.VelX = 0;
                }
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                {
                    player.VelX = 0;
                }
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                {
                    player.VelY = 0;
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                {
                    player.VelY = 0;
                }
                if (e.KeyCode == Keys.C || e.KeyCode == Keys.K)
                {
                    Ec.addFriendly(new PlayerBullet(player.X + (player.Width / 2), player.Y, 4, 8, Color.DarkOrange, 20, this, ec));
                }
                if (e.KeyCode == Keys.Space)
                {
                    if (Pause)
                    {

                        Pause = false;
                    }
                    else
                    {
                        Pause = true;
                    }
                    gamepause(Pause);

                }
            }
            
           
        }
        //method untuk tombol exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            Mf.Uc.Peace = score;
            Mf.Uc.update();
            Mf.update();
            music.controls.stop();
            Mf.Visible = true;
            this.Dispose();

        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            Pause = false;
            this.Focus();
            gamepause(Pause);

        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            Init();
        }

       


    }
}
