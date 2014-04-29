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
    public partial class uiEGLPABC_WordList : SHF_UI.uiSHF_CourseBase
    {
        public uiEGLPABC_WordList()
        {
            InitializeComponent();
        }
        
        public uiEGLPABC_WordList(Form callme, btSHFUserLogin shfUserlogin)
            : base(callme, shfUserlogin)
        {
            InitializeComponent();
           
        }

        btEGLPABCQuestions shfQS = new btEGLPABCQuestions();
        btEGLPABCUnitPractices shfUPS = new btEGLPABCUnitPractices();
        btSHFQuestions btQS = new btSHFQuestions();
        btSHFQuestion btQ = new btSHFQuestion();
        ArrayList myQSAL = new ArrayList();   //存储
        ArrayList myQAAL = new ArrayList();
        string[,] Option = new string[50, 3];   //存储用户的选择
        string[,] myAllOption = new string[50, 5]; //存储所有选项的答案
        int StudentID = 0;
        bool StartFlag = false; //单元启动标志
        int RightNumber = 0;    //回答正确的题目数
        int MaxQID = 0;  //题库中问题总数
        int ID = 1;     //标识题号
        int notIndex = 0;  //未回答的题目

        #region 变量初始化
        public void Initial()
        {
            //ups.Answered = Index;
            shfUPS.QueAll = MaxQID;
            shfUPS.notAnswered = notIndex;
            shfUPS.RightNumber = RightNumber;
            shfUPS.StartFlag = StartFlag;
            
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

        private void ShowList(int id)
        {

            label1.Text = id.ToString() + ". " + myQSAL[id - 1].ToString();

            label2.Text = myAllOption[id - 1, 1];
            label3.Text = myAllOption[id - 1, 2];
            label4.Text = myAllOption[id - 1, 3];
            label5.Text = myAllOption[id - 1, 4];

        }

        #region 载入窗体
        private void uiEGLPABC_WordList_Load(object sender, EventArgs e)
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

            groupBox1.Visible = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
        }

        #endregion

        #region 开始学习
        private void button3_Click(object sender, EventArgs e)
        {
           
           
            groupBox1.Visible = true;
           
            ShowList(ID);
            shfUPS.StartPractice();
            button3.Enabled = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button1.Enabled = true;
            button2.Enabled = true;
            label10.Text = "";
            
        }

        #endregion

        #region 上一题
        private void button1_Click(object sender, EventArgs e)
        {
            label10.Text = "";
            ID--;
            if (ID == 0)                        //题目到达上界
            {
                MessageBox.Show("题目已到头!", "读题提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1.Enabled = false;
                ID++;
            }
            else if (ID > 0)
            {
                button2.Enabled = true;
                if (Option[ID - 1, 0] == "0")    //此题之前未曾做过
                {
                   
                    ShowList(ID);
                }
                else if (System.Convert.ToInt32(Option[ID - 1, 0]) > 0)//此题之前已经做过
                {
                    ShowList(ID);    //显示问题
                   
                }
            }
        }
        #endregion

        #region 下一题
        private void button2_Click(object sender, EventArgs e)
        {
            label10.Text = "";
            ID++;
            if (ID > MaxQID)                     //题目到达下界
            {
                MessageBox.Show("题库中已无题!", "读题提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button2.Enabled = false;
                ID--;
            }
            else
            {
                button1.Enabled = true;
                if (Option[ID - 1, 0] == "0")    //此题之前未曾做过    
                {
                    
                    ShowList(ID);    //显示问题
                }
                else if (System.Convert.ToInt32(Option[ID - 1, 0]) > 0)//此题之前已经做过
                {
                    ShowList(ID);    //显示问题
                    
                }
            }
        }
        #endregion



        #region 显示答案
        private void button4_Click(object sender, EventArgs e)
        {
            label10.Text = myQAAL[ID - 1].ToString();
        }
        #endregion
      
       
       
       

       
    }
}
