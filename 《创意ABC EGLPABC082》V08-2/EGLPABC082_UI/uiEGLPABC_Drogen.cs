using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SHF_DA;
using EGLPABC082_BT;
using System.Data.OleDb;
using System.Collections;
using SHF_BT;
using SHF_UI;

namespace EGLPABC082_UI
{
    public partial class uiEGLPABC_Drogen : SHF_UI.uiSHF_CourseBase
    {
        public uiEGLPABC_Drogen()
        {
            InitializeComponent();
        }

        public uiEGLPABC_Drogen(Form callme, btSHFUserLogin shfUserlogin)
            : base(callme, shfUserlogin)
        {
            InitializeComponent();
            StudentID = shfUserlogin.UserID;
        }

        #region 变量说明
        btEGLPABCQuestions shfQS = new btEGLPABCQuestions();
        btEGLPABCUnitPractices shfUPS = new btEGLPABCUnitPractices();
        btSHFQuestions btQS = new btSHFQuestions();
        btSHFQuestion btQ = new btSHFQuestion();
        btSHFUnitScore btUS = new btSHFUnitScore();
        btSHFUnitScores btUSS = new btSHFUnitScores();
        btSHFUserLogin btUL = new btSHFUserLogin();
        int StudentID = 0;
        bool StartFlag = false; //单元启动标志
        int RightNumber = 0;    //回答正确的题目数
        int MaxQID = 0;  //题库中问题总数
        
        int id = 1;     //标识题号
        int notIndex = 0;  //未回答的题目
        int Index = 1;  //已经完成的题目
        ArrayList myQSAL = new ArrayList();   //存储
        ArrayList myQAAL = new ArrayList();
        ArrayList myQNAL = new ArrayList();
        string[,] Option = new string[50, 3];   //存储用户的选择
        string[,] myAllOption = new string[50, 5]; //存储所有选项的答案

        private System.Drawing.Point QPosition = new System.Drawing.Point(80, 20);
        private System.Drawing.Point CPosition = new System.Drawing.Point(20, 20);
        private Font TheFont = new Font("Times New Roman", 30);
        #endregion

        #region 变量初始化
        public void Initial()
        {
            shfUPS.Answered = Index;
            shfUPS.QueAll = MaxQID;
            shfUPS.notAnswered = notIndex;
            shfUPS.RightNumber = RightNumber;
            shfUPS.StartFlag = StartFlag;
            shfUPS.timer = this.timer;
        }
        #endregion

        #region 数组初始化
        public void InitString(string[,] tab)
        {
            for (int row = 0; row < tab.GetLength(0); row++)
            {
                for (int col = 0; col < tab.GetLength(1); col++)
                {
                    tab[row, col] = "0";
                }
            }
        }
        #endregion

        #region 窗口中显示问题
        private void ShowQuestion()
        {
            DrawQs();
            DrawCo();
        }
        #endregion

        #region 绘字符串
        private void DrawQs()
        {
            this.panelparent.Paint += new PaintEventHandler(drawqs);
            this.panelparent.Refresh();
        }

        private void drawqs(object sender, PaintEventArgs e)
        {
           
            Graphics g = e.Graphics;
            if (id <=MaxQID )
            {
            g.DrawString(id.ToString() + ". " + myQSAL[id - 1].ToString(), this.TheFont, new SolidBrush(Color.Beige), this.QPosition.X, this.QPosition.Y);
            
                
            }
            switch (id)
            {
                case 1:
                    pictureBox4.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "../../../../SHFDB/Image/pic/1.jpg");
                    break;
                case 2:
                    pictureBox4.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "../../../../SHFDB/Image/pic/2.jpg");
                    break;
                case 3:
                    pictureBox4.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "../../../../SHFDB/Image/pic/3.jpg");
                    break;
                case 4:
                    pictureBox4.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "../../../../SHFDB/Image/pic/4.jpg");
                    break;
                case 5:
                    pictureBox4.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "../../../../SHFDB/Image/pic/5.jpg");
                    break;
                case 6:
                    pictureBox4.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "../../../../SHFDB/Image/pic/6.jpg");
                    break;
                case 7:
                    pictureBox4.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "../../../../SHFDB/Image/pic/7.jpg");
                    break;
                case 8:
                    pictureBox4.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "../../../../SHFDB/Image/pic/8.jpg");
                    break;
                case 9:
                    pictureBox4.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "../../../../SHFDB/Image/pic/9.jpg");
                    break;
                case 10:
                    pictureBox4.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "../../../../SHFDB/Image/pic/10.jpg");
                    break;
                case 11:
                    pictureBox4.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "../../../../SHFDB/Image/pic/11.jpg");
                    break;
                case 12:
                    pictureBox4.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "../../../../SHFDB/Image/pic/12.jpg");
                    break;
                
            }
        }

        private void DrawCo()
        {
            this.panelchild_A.Paint += new PaintEventHandler(panelchild_A_Paint);
            this.panelchild_B.Paint += new PaintEventHandler(panelchild_B_Paint);
            this.panelchild_C.Paint += new PaintEventHandler(panelchild_C_Paint);
            this.panelchild_D.Paint += new PaintEventHandler(panelchild_D_Paint);

            this.panelchild_A.Refresh();
            this.panelchild_B.Refresh();
            this.panelchild_C.Refresh();
            this.panelchild_D.Refresh();
        }

        void panelchild_D_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString(myAllOption[id - 1, 4], this.TheFont, new SolidBrush(Color.Bisque), this.CPosition.X, this.CPosition.Y);
        }

        void panelchild_C_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString(myAllOption[id - 1, 3], this.TheFont, new SolidBrush(Color.Bisque), this.CPosition.X, this.CPosition.Y);
        }

        void panelchild_B_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString(myAllOption[id - 1, 2], this.TheFont, new SolidBrush(Color.Bisque), this.CPosition.X, this.CPosition.Y);
        }

        void panelchild_A_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString(myAllOption[id - 1, 1], this.TheFont, new SolidBrush(Color.Bisque), this.CPosition.X, this.CPosition.Y);
        }
        #endregion

        #region 载入窗体
        private void uiEGLPABC_Drogen_Load(object sender, EventArgs e)
        {
            this.InitString(Option);
            this.InitString(myAllOption);
            MaxQID = shfQS.GetMaxID();
          
            shfQS.MaxID = MaxQID;
            myQSAL = shfQS.GetAllQS();
            myQAAL = shfQS.GetAllQA();
            myAllOption = shfQS.GetAllOptions();
            shfUPS.studentID = StudentID;
            shfUPS.InitPractice();

        
            buttonPrevious.Enabled = false;
            buttonNext.Enabled = false;
            buttonOK.Enabled = false;
            labelTimer.Visible = false;
            buttonPrevious.Visible = false;
            buttonNext.Visible = false;
            buttonOK.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }
        #endregion

        #region 读取并保存用户的选择
        public void SaveSelection(string[,] table)
        {
            //string[,] table = new string[MaxID + 1, 3];
            if (radioButton1.Checked == true)
            {
                table[id - 1, 0] = id.ToString();
                table[id - 1, 1] = "A";
                table[id - 1, 2] = "1";
            }
            else if (radioButton2.Checked == true)
            {
                table[id - 1, 0] = id.ToString();
                table[id - 1, 1] = "B";
                table[id - 1, 2] = "2";
            }
            else if (radioButton3.Checked == true)
            {
                table[id - 1, 0] = id.ToString();
                table[id - 1, 1] = "C";
                table[id - 1, 2] = "3";
            }
            else if (radioButton4.Checked == true)
            {
                table[id - 1, 0] = id.ToString();
                table[id - 1, 1] = "D";
                table[id - 1, 2] = "4";
            }
            else
            {
                notIndex++;
            }
        }
        #endregion

  
        #region 重现用户的选择
        public void ShowChecked()
        {
            if (Option[id - 1, 2] == "1")
            {
                radioButton1.Checked = true;
            }
            else if (Option[id - 1, 2] == "2")
            {
                radioButton2.Checked = true;
            }
            else if (Option[id - 1, 2] == "3")
            {
                radioButton3.Checked = true;
            }
            else if (Option[id - 1, 2] == "4")
            {
                radioButton4.Checked = true;
            }
        }
        #endregion


        private void panelchild_A_Click(object sender, EventArgs e)
        {
            buttonNext.Enabled = true;
           
            if (myQAAL[id - 1].ToString() == "A")
            {
                RightNumber++;
                pictureBox2.Visible = true;
                labelAnswer.Visible = true;
                labelAnswer.Text = "对喽！";
            }
            else
            {
                pictureBox3.Visible = true;
                labelAnswer.Visible = true;
                labelAnswer.Text = "错了…";
            }
        }

        private void panelchild_B_Click(object sender, EventArgs e)
        {
            buttonNext.Enabled = true;
            
            if (myQAAL[id - 1].ToString() == "B")
            {
                RightNumber++;
                pictureBox2.Visible = true;
                labelAnswer.Visible = true;
                labelAnswer.Text = "对喽！";
            }
            else
            {
                pictureBox3.Visible = true;
                labelAnswer.Visible = true;
                labelAnswer.Text = "错了…";
            }
        }

        private void panelchild_C_Click(object sender, EventArgs e)
        {
            buttonNext.Enabled = true;
            
            if (myQAAL[id - 1].ToString() == "C")
            {
                RightNumber++;
                pictureBox2.Visible = true;
                labelAnswer.Visible = true;
                labelAnswer.Text = "对喽！";
            }
            else
            {
                pictureBox3.Visible = true;
                labelAnswer.Visible = true;
                labelAnswer.Text = "错了…";
            }
        }

        private void panelchild_D_Click(object sender, EventArgs e)
        {
            buttonNext.Enabled = true;
           
            if (myQAAL[id - 1].ToString() == "D")
            {
                RightNumber++;
                pictureBox2.Visible = true;
                labelAnswer.Visible = true;
                labelAnswer.Text = "对喽！";
            }
            else
            {
                pictureBox3.Visible = true;
                labelAnswer.Visible = true;
                labelAnswer.Text = "错了…";
            }
        }

        private void buttonBegin_Click(object sender, EventArgs e)
        {
            labelTimer.Visible = true;
            labelTimer.Text = "";
            timer.Enabled = true;
           // groupBox1.Visible = true;
       
            ShowQuestion();
            shfUPS.StartPractice();
            buttonBegin.Enabled = false;
            buttonPrevious.Visible = true;
            buttonNext.Visible = true;
            buttonOK.Visible = true;
            buttonPrevious.Enabled = false;
            buttonNext.Enabled = false;
            buttonOK.Enabled = true;
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
           
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            labelAnswer.Visible = false;
            SaveSelection(Option);
            id--;
            if (id == 0)                        //题目到达上界
            {
                MessageBox.Show("题目已到头!", "读题提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonPrevious.Enabled = false;
                id++;
            }
            else if (id > 0)
            {
                buttonNext.Enabled = true;
                if (Option[id - 1, 0] == "0")    //此题之前未曾做过
                {
                  
                    ShowQuestion();
                }
                else if (System.Convert.ToInt32(Option[id - 1, 0]) > 0)//此题之前已经做过
                {
                    ShowQuestion();    //显示问题
                    ShowChecked();            //显示之前做的结果
                }
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            buttonNext.Enabled = false;
          
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            labelAnswer.Visible = false;
            SaveSelection(Option);
            id++;
            Index++;
            if (id > MaxQID)                     //题目到达下界
            {
                
                MessageBox.Show("题库中已无题!", "读题提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonNext.Enabled = false;
                id--;
            }
            else
            {
                buttonPrevious.Enabled = true;
                if (Option[id - 1, 0] == "0")    //此题之前未曾做过    
                {
                   
                    ShowQuestion();    //显示问题
                }
                else if (System.Convert.ToInt32(Option[id - 1, 0]) > 0)//此题之前已经做过
                {
                    ShowQuestion();    //显示问题
                    ShowChecked();            //显示之前做的结果
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确认不再飞越了吗?", "确认不飞了", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                buttonNext.Enabled = false;
                buttonPrevious.Enabled = false;
                buttonOK.Enabled = false;
                shfQS.JudgeQuestion(myQAAL, Option, ref RightNumber);
                MessageBox.Show("你飞越了" + RightNumber.ToString() + "个龙潭", "飞越正确率信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                this.Initial();
                shfUPS.EndPractice();
            }
            else
            {
                ;
            }
        }

        string str_min = "";
        string str_sec = "";

        int minute = 1;
        int second = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (second > 0)
            {
                second--;
            }
            else
            {
                second = 59;
                minute--;
                if (minute < 10)
                {
                    str_min = "0" + minute.ToString();
                }
                else
                {
                    str_min = minute.ToString();
                }
            }
            if (second < 10)
            {
                str_sec = "0" + second.ToString();
            }
            else
            {
                str_sec = second.ToString();
            }
            labelTimer.Text = str_min + ":" + str_sec;
            if (minute == 0 && second == 0)
            {
                timer.Enabled = false;
                MessageBox.Show("飞越时间到!!", "飞越终结信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonNext.Enabled = false;
                buttonPrevious.Enabled = false;
                buttonOK.Enabled = false;
                shfQS.JudgeQuestion(myQAAL, Option, ref RightNumber);
                MessageBox.Show("你答对了" + RightNumber.ToString() + "道题", "飞越正确率信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                this.Initial();
                shfUPS.EndPractice();
            }
        }

        private void button返回_Click(object sender, EventArgs e)
        {

        }

        private void button退出_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
