using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGLPABC082_UI;
using EGLPABC082_Net;
using SHF_UI;
using SHF_BT;
using SHF_DA;

namespace _创意ABC_EGLPABC082_
{
    public partial class EGLPABC082 :uiEGLPABC_AppMain
    {
        public EGLPABC082()
        {
            InitializeComponent();
        }
        public EGLPABC082(Form callForm)
            : base(callForm) 
        {
            InitializeComponent();
        }

        private void EGLPABC082_Load(object sender, EventArgs e)
        {

        }

        private void button训练01_Click(object sender, EventArgs e)
        {
            uiEGLPABC_Monkey f = new uiEGLPABC_Monkey(this, shfUserLogin);
            f.Show();
           
        }

       

        private void button训练02_Click_1(object sender, EventArgs e)
        {
            uiEGLPABC_Drogen f = new uiEGLPABC_Drogen(this, shfUserLogin);
            f.Show();
        }

        private void button训练03_Click(object sender, EventArgs e)
        {
            uiEGLPABC_TestShowH3 f = new uiEGLPABC_TestShowH3(this, shfUserLogin);
            f.Show();
            
        }

        private void button历史纪录_Click(object sender, EventArgs e)
        {
            uiEGLPABC_ScoreShow1 f = new uiEGLPABC_ScoreShow1(this, shfUserLogin);
            f.Show();
        }

        private void button排行榜_Click(object sender, EventArgs e)
        {

            uiEGLPABC_ScoreShow2 f = new uiEGLPABC_ScoreShow2(this, shfUserLogin);
            f.Show();
        }

        private void button教学01_Click(object sender, EventArgs e)
        {
            uiEGLPABC_CourseShow1 f = new uiEGLPABC_CourseShow1(this, shfUserLogin);
            f.Show();
        }

        private void button教学02_Click(object sender, EventArgs e)
        {
            uiEGLPABC_WordList f = new uiEGLPABC_WordList(this, shfUserLogin);
            f.Show();
        }

        private void button训练0_Click(object sender, EventArgs e)
        {
            uiEGLPABC_TestShowH0 f = new uiEGLPABC_TestShowH0(this, shfUserLogin);
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EGLPABC082_SetEmail f = new EGLPABC082_SetEmail(this, shfUserLogin);
            f.Show();
        }

      

       
        
    }
}
