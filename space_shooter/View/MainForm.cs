using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using space_shooter.Controller;

namespace space_shooter
{
    //form utama, menu game
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        UserController uc;

        internal UserController Uc { get => uc; set => uc = value; }

        //ketika tombol play diclick
        private void btnPlay_Click(object sender, EventArgs e)
        {
            Uc.Username = textusername.Text;
            Uc.insert();
            Game game = new Game(this);
            game.Visible = true;
            this.Visible = false;
            
        }

        private void textusername_TextChanged(object sender, EventArgs e)
        {
            btnPlay.Enabled = true;
        }

        //yang dilakukan ketika form load
        private void MainForm_Load(object sender, EventArgs e)
        {
            btnPlay.Enabled = false;
            update();
        }

        //ketika tombol exit diclick
        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        //update data pada table
        public void update()
        {
            Uc = new UserController();           
            Uc.getAll();
            Userdata.Add(Uc.Lu);
            UserGrid.DataSource = Uc.Lu.User;
        }
    }
}
