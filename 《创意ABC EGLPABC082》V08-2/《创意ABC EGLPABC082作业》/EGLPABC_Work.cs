using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGLPABC082_UI;
using EGLPABC082_BT;
using EGLPABC082_Test;
using _创意ABC_EGLPABC082_;
using SHF_BT;
using SHF_UI;
using SHF_DA;

namespace _创意ABC_EGLPABC082作业_
{
    public partial class EGLPABC_Work : uiEGLPABC_WorkMain
    {
        public EGLPABC_Work()
        {
            InitializeComponent();
        }

        private void EGLPABC_Work_Load(object sender, EventArgs e)
        {

        }

        
        private void button应用程序_Click(object sender, EventArgs e)
        {
            EGLPABC082 f = new EGLPABC082();
            f.Show();
        }

        private void button原版实验_Click(object sender, EventArgs e)
        {
            EGLPABC_TestV081 f = new EGLPABC_TestV081();
            f.Show();
        }

        private void button实验程序_Click(object sender, EventArgs e)
        {
            EGLPABC_TestV082 f = new EGLPABC_TestV082(this, shfConnect);
            f.Show();
        }

 


        private void button程序功能列表_Click(object sender, EventArgs e)
        {
           
        }

        private void button课程结构编辑_Click(object sender, EventArgs e)
        {

        }

        private void button需求功能列表_Click(object sender, EventArgs e)
        {
           
        }

        private void button原始版_Click(object sender, EventArgs e)
        {

        }

        private void button基础版_Click(object sender, EventArgs e)
        {
            uiEGLPABC_AppMain f = new uiEGLPABC_AppMain(this);
            f.Show();
        }

    }
}
