using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SHF_BT;
using EGLPABC082_BT;

namespace EGLPABC082_UI
{
    public partial class uiEGLPABC_Monkey : SHF_UI.uiSHF_CourseBase
    {
        #region 全局变量
        protected btSHFUnitScore shfUnitScore = new btSHFUnitScore();
        protected btSHFUnitScores shfUnitScores = new btSHFUnitScores();
        protected btSHFUserLogin shfUserLogin = new btSHFUserLogin();
        #endregion

        #region 局部变量
        private System.Drawing.Point Position = new System.Drawing.Point(100, 295);
        private System.Drawing.Point LPosition = new System.Drawing.Point(80, 80);
        private Pen aPen = new Pen(Color.Red);
        private System.Drawing.Point WordPosition = new System.Drawing.Point(20, 40);
        private Font TheFont = new Font("Times New Roman", 30);

        private string Letter = "";
        private btRandomLetterPick LetterPick = new btRandomLetterPick();
        private int RightCount = 0;
        private int WrongCount = 0;
        private int level1 = 0;
        private int level2 = 0;

        #endregion


        #region 窗体构造函数
        public uiEGLPABC_Monkey()
        {
            InitializeComponent();
        }

        public uiEGLPABC_Monkey(Form callme, btSHFUserLogin shfUserlogin)
            : base(callme, shfUserlogin)
        {
            InitializeComponent();

        }
        #endregion

        private void Init()
        {
            this.pictureBox_L.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "../../../../SHFDB/Image/gif/cli.gif");
            this.pictureBox_R.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "../../../../SHFDB/Image/gif/cli.gif");
            MonkeyClimb_L(1);
            MonkeyClimb_R(1);
            this.pictureBox_L.Visible = true;
            this.pictureBox_R.Visible = true;
            this.pictureBox_L.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox_R.SizeMode = PictureBoxSizeMode.StretchImage;
            Letter = LetterPick.RandomLetter();
            DrawLetter();
            this.KeyPreview = true;
            this.label1.Visible = false;
            this.pictureBox1.Visible = false;

            this.RightCount = 0;
            this.WrongCount = 0;
        }

        private void DrawTrunk()
        {
            this.panel_L.Paint += new PaintEventHandler(drawtrunk);
            this.panel_L.Refresh();

            this.panel_R.Paint += new PaintEventHandler(drawtrunk);
            this.panel_R.Refresh();
        }

        private void drawtrunk(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(new Pen(Color.Brown,12),Position.X-60,Position.Y,Position.X+60,Position.Y);
            g.DrawLine(new Pen(Color.BurlyWood,20),Position.X,Position.Y,Position.X,Position.Y-200);
            g.DrawLine(new Pen(Color.BurlyWood,15),Position.X,Position.Y-200,Position.X-50,Position.Y-250);
            g.DrawLine(new Pen(Color.BurlyWood,15),Position.X,Position.Y-200,Position.X+50,Position.Y-250);
        }

        private void uiEGLPABC_Monkey_Load(object sender, EventArgs e)
        {
            panel_L.Visible = false;
            panel_M.Visible = false;
            panel_R.Visible = false;
            button开始.Visible = false;
        }

        private void MonkeyClimb_L(int height)
        {
            this.pictureBox_L.Left = Position.X - 20;
            this.pictureBox_L.Top =  Position.Y - height*(160/level1);
        }

        private void MonkeyClimb_R(int height)
        {
            this.pictureBox_R.Left = Position.X - 20;
            this.pictureBox_R.Top = Position.Y - height * (160/level2);
        }

        private void DrawLetter()
        {
            this.panel_M.Paint +=new PaintEventHandler(drawletter);
            this.panel_M.Refresh();
        }

        private void drawletter(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString(Letter.ToString(), this.TheFont, new SolidBrush(Color.Red),this.LPosition.X,this.LPosition.Y);
        }

        private void Win()
        {
            this.label1.Text = "你赢了!";
            this.label1.Visible = true;
            this.label1.Refresh();
            this.pictureBox1.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "../../../../SHFDB/Image/gif/suc.gif");
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.Visible = true;
            this.pictureBox1.Refresh();
            this.KeyPreview = false;
        }

        private void Loose()
        {
            this.label1.Text = "你输了!";
            this.label1.Visible = true;
            this.label1.Refresh();
            this.pictureBox1.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "../../../../SHFDB/Image/gif/fail.gif");
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.Visible = true;
            this.pictureBox1.Refresh();
            this.KeyPreview = false;
        }

        private void uiEGLPABC_Monkey_KeyPress(object sender, KeyPressEventArgs e)
        {
            char j = e.KeyChar;
            string bigJ = j.ToString().ToUpper();
            j = bigJ[0];

            if (j >= 65 && j <= 90)
            {
                if (j.ToString() == Letter)
                {
                    this.RightCount++;
                    this.MonkeyClimb_L(this.RightCount + 1);
                }
                else
                {
                    this.WrongCount++;
                    this.MonkeyClimb_R(this.WrongCount + 1);
                }

                if (this.RightCount == level1)
                {
                    Win();
                    Save();
                }

                if (this.WrongCount == level2)
                {
                    Loose();
                    Save(); 
                }

                Letter = LetterPick.RandomLetter();
                DrawLetter();
            }
        }

        private void Save()
        {
            
            shfUnitScore.TotalScore = RightCount * 10;
            shfUnitScore.RightNumber = RightCount;
            shfUnitScore.ErrorNumber = WrongCount;
            shfUnitScore.StartDateTime = DateTime.Now;
            shfUnitScore.StudentID = shfUserLogin.UserID;
            shfUnitScore.ProgramID = 1030301;
            shfUnitScores.AddOne(shfUnitScore);
        }

        private void button开始_Click(object sender, EventArgs e)
        {
            Init();
        }

        #region 难度选择
        private void button1_Click(object sender, EventArgs e)
        {
            level1 = 4;
            level2 = 4;
            panel_L.Visible = true ;
            panel_M.Visible = true ;
            panel_R.Visible = true ;
            button开始.Visible = true ;
            DrawTrunk();
            Init();
            panel1.Visible = false;
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            level1 = 5;
            level2 = 4;
            panel_L.Visible = true;
            panel_M.Visible = true;
            panel_R.Visible = true;
            button开始.Visible = true;
            DrawTrunk();
            Init();
            panel1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            level1 = 6;
            level2 = 4;
            panel_L.Visible = true;
            panel_M.Visible = true;
            panel_R.Visible = true;
            button开始.Visible = true;
            DrawTrunk();
            Init();
            panel1.Visible = false;
        }
        #endregion

    }
}
