using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EGLPABC082_BT;
using EGLPABC082_UI;
using _创意ABC_EGLPABC082_;
using SHF_UI;
using SHF_BT;
using SHF_DA;
using EGLPABC082_Test;
using EGLPABC082_Net;

namespace EGLPABC082_Test
{
    public partial class EGLPABC_TestV082 : SHF_UI.uiSHF_TestBase
    {
        public EGLPABC_TestV082()
        {
            InitializeComponent();
        }
        public EGLPABC_TestV082(Form callForm)
            : base(callForm) 
        {
            InitializeComponent();
        }
        public EGLPABC_TestV082(Form callForm, string callConnect)
            : base(callForm, callConnect) 
        {
            InitializeComponent();
        }

        private void EGLPABC_TestV083_Load(object sender, EventArgs e)
        {

        }


       private void button主界面_Click(object sender, EventArgs e)
			{
				EGLPABC082 f = new EGLPABC082( this);
				f.Show();
			}

       private void button登录_Click(object sender, EventArgs e)
       {
           // 说明：
           // this -- 升级版实验窗体对象
           // this myUser -- 用户对象，保存登录对象信息，默认为来宾。
           // this.myUserLogin --用户登录状态对象，保存登录用户的状态信息，包括时间等。
           // userType -- 用户类型，设定默认的用户列表。

           int userType = 0; // 0 =来宾，1 = 学生， 2 = 教师。
           SHF_UI.uiSHF_Login f = new uiSHF_Login(this, this.myUser, this.myUserLogin, userType);
           f.Show();
       }


        private void button目录_Click(object sender, EventArgs e)
        {
            // 训练对象：设置训练内容和训练要求。
            // 选择对象：修改训练对象内容。
            this.myUnitPrac = myUnitPracs.GetOne(6); // 按键练习的训练ID是 6；
            uiTyping01_Option f = new uiTyping01_Option(this);
            f.Show();

        }

        private void button业务处理01_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uiEGLPABC_CourseShow1 f = new uiEGLPABC_CourseShow1(this, this.myUserLogin);
            f.Show();
        }

        private void groupBoxSecurity_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            uiEGLPABC_CourseEdit f = new uiEGLPABC_CourseEdit(this, this.myUserLogin);
            f.Show();
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            uiEGLPABC_TestEdit f = new uiEGLPABC_TestEdit(this, this.myUserLogin);
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            uiEGLPABC_WordList f = new uiEGLPABC_WordList(this, this.myUserLogin);
            f.Show();
        }

        private void button成绩_Click(object sender, EventArgs e)
        {
            uiEGLPABC_ScoreShow1 f = new uiEGLPABC_ScoreShow1(this, this.myUserLogin);
            f.Show();
        }

        private void button业务处理03_Click(object sender, EventArgs e)
        {
            uiEGLPABC_ScoreShow2 f = new uiEGLPABC_ScoreShow2(this, this.myUserLogin);
            f.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            uiEGLPABC_TestShowH1 f = new uiEGLPABC_TestShowH1(this, this.myUserLogin);
            f.Show();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            uiEGLPABC_TestShowH2 f = new uiEGLPABC_TestShowH2(this, this.myUserLogin);
            f.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            uiEGLPABC_TestShowH3 f = new uiEGLPABC_TestShowH3(this, this.myUserLogin);
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            uiEGLPABC_TestShowH0 f = new uiEGLPABC_TestShowH0(this, this.myUserLogin);
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            uiEGLPABC_Monkey f = new uiEGLPABC_Monkey(this, this.myUserLogin);
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            uiEGLPABC_Drogen f = new uiEGLPABC_Drogen(this, this.myUserLogin);
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            EGLPABC082_SetEmail f = new EGLPABC082_SetEmail(this, this.myUserLogin);
            f.Show();
        }

       
        }
}

       
    

