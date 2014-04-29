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
    public partial class uiEGLPABC_TestShowH2 : SHF_UI.uiSHF_CourseBase
    {
        public uiEGLPABC_TestShowH2()
        {
            InitializeComponent();
        }

        public uiEGLPABC_TestShowH2(Form callme, btSHFUserLogin shfUserlogin)
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
        int ID = 6;     //标识题号
        int notIndex = 0;  //未回答的题目
        int Index = 1;  //已经完成的题目
        ArrayList myQSAL = new ArrayList();   //存储
        ArrayList myQAAL = new ArrayList();
        string[,] Option = new string[50, 3];   //存储用户的选择
        string[,] myAllOption = new string[50, 5]; //存储所有选项的答案
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
        private void ShowQuestion(int id)
        {

            int ip; ip = id - 5;
            labelTitle.Text = ip.ToString() + ". " + myQSAL[id - 1].ToString();

            buttonA.Text = myAllOption[id - 1, 1];
            buttonB.Text = myAllOption[id - 1, 2];
            buttonC.Text = myAllOption[id - 1, 3];
            buttonD.Text = myAllOption[id - 1, 4];
            radioButton1.Text = myAllOption[id - 1, 1];
            radioButton2.Text = myAllOption[id - 1, 2];
            radioButton3.Text = myAllOption[id - 1, 3];
            radioButton4.Text = myAllOption[id - 1, 4];
        }
        #endregion

        #region 载入窗体
        private void uiEGLPABC_Load(object sender, EventArgs e)
        {
            this.InitString(Option);
            this.InitString(myAllOption);
            MaxQID = shfQS.GetMaxID();
            //string[,] myAllOption = new string[MaxQID, 5]; //存储所有选项的答案 
            //this.InitString(myAllOption);
            shfQS.MaxID = MaxQID;
            myQSAL = shfQS.GetAllQS();
            myQAAL = shfQS.GetAllQA();
            myAllOption = shfQS.GetAllOptions();
            shfUPS.studentID = StudentID;
            shfUPS.InitPractice();

            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            groupBox1.Visible = false;
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
        public void SaveSelection(string[,] table, int id)
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

        #region 清空radioButton的选择
        public void ClearRadioButton()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }
        #endregion

        #region 重现用户的选择
        public void ShowChecked(int id)
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

        #region 开始飞越
        private void buttonBegin_Click(object sender, EventArgs e)
        {
            labelTimer.Visible = true;
            labelTimer.Text = "";
            timer.Enabled = true;
            groupBox1.Visible = true;
            ClearRadioButton();
            ShowQuestion(ID);
            shfUPS.StartPractice();
            buttonBegin.Enabled = false;
            buttonPrevious.Visible = true;
            buttonNext.Visible = true;
            buttonOK.Visible = true;
            buttonPrevious.Enabled = false;
            buttonNext.Enabled = false;
            buttonOK.Enabled = true;
        }
        #endregion

        #region 上一题
        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            buttonD.Enabled = false;
            buttonB.Enabled = false;
            buttonC.Enabled = false;
            buttonA.Enabled = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            labelAnswer.Visible = false;
            SaveSelection(Option, ID);
            ID--;
            if (ID == 5)                        //题目到达上界
            {
                MessageBox.Show("题目已到头!", "读题提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonPrevious.Enabled = false;
                ID++;
            }
            else if (ID > 0)
            {
                buttonNext.Enabled = true;
                if (Option[ID - 1, 0] == "0")    //此题之前未曾做过
                {
                    ClearRadioButton();
                    ShowQuestion(ID);
                }
                else if (System.Convert.ToInt32(Option[ID - 1, 0]) > 0)//此题之前已经做过
                {
                    ShowQuestion(ID);    //显示问题
                    ShowChecked(ID);            //显示之前做的结果
                }
            }
        }
        #endregion

        #region 下一题
        private void buttonNext_Click(object sender, EventArgs e)
        {
            buttonNext.Enabled = false;
            buttonD.Enabled = true;
            buttonB.Enabled = true;
            buttonC.Enabled = true;
            buttonA.Enabled = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            labelAnswer.Visible = false;
            SaveSelection(Option, ID);
            ID++;
            Index++;
            if (ID > 10)                     //题目到达下界
            {
                MessageBox.Show("题库中已无题!", "读题提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonNext.Enabled = false;
                ID--;
            }
            else
            {
                buttonPrevious.Enabled = true;
                if (Option[ID - 1, 0] == "0")    //此题之前未曾做过    
                {
                    ClearRadioButton();         //清楚当前radioButton的Checked属性
                    ShowQuestion(ID);    //显示问题
                }
                else if (System.Convert.ToInt32(Option[ID - 1, 0]) > 0)//此题之前已经做过
                {
                    ShowQuestion(ID);    //显示问题
                    ShowChecked(ID);            //显示之前做的结果
                }
            }
        }
        #endregion

        #region 完成飞越
        private void buttonOK_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("结束后将不能修改答案，确认不再飞越了吗?", "确认不飞了", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                groupBox1.Visible = false;
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
        #endregion

        private void button退出_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button返回_Click(object sender, EventArgs e)
        {

        }

        string str_min = "";
        string str_sec = "";

        int minute = 1;
        int second = 0;

        #region 飞越时间倒计时
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
                groupBox1.Visible = false;
                buttonNext.Enabled = false;
                buttonPrevious.Enabled = false;
                buttonOK.Enabled = false;
                shfQS.JudgeQuestion(myQAAL, Option, ref RightNumber);
                MessageBox.Show("你答对了" + RightNumber.ToString() + "道题", "飞越正确率信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                this.Initial();
                shfUPS.EndPractice();
            }
        }
        #endregion

        #region 选项选择
        private void buttonA_Click(object sender, EventArgs e)
        {
            buttonNext.Enabled = true;
            buttonD.Enabled = false;
            buttonB.Enabled = false;
            buttonC.Enabled = false;
            buttonA.Enabled = false;
            if (myQAAL[ID - 1].ToString() == "A")
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

        private void buttonB_Click(object sender, EventArgs e)
        {
            buttonNext.Enabled = true;
            buttonD.Enabled = false;
            buttonB.Enabled = false;
            buttonC.Enabled = false;
            buttonA.Enabled = false;
            if (myQAAL[ID - 1].ToString() == "B")
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

        private void buttonC_Click(object sender, EventArgs e)
        {
            buttonNext.Enabled = true;
            buttonD.Enabled = false;
            buttonB.Enabled = false;
            buttonC.Enabled = false;
            buttonA.Enabled = false;
            if (myQAAL[ID - 1].ToString() == "C")
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

        private void buttonD_Click(object sender, EventArgs e)
        {
            buttonNext.Enabled = true;
            buttonD.Enabled = false;
            buttonB.Enabled = false;
            buttonC.Enabled = false;
            buttonA.Enabled = false;
            if (myQAAL[ID - 1].ToString() == "D")
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

        #endregion




    }
}

