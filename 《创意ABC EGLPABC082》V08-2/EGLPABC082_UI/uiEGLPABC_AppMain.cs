﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using SHF_UI;
using SHF_BT;
using SHF_DA;



namespace EGLPABC082_UI
{
    public partial class uiEGLPABC_AppMain : Form
    {
        #region     程序常数说明 V07-2.01版
        protected string shfConnect = string.Format("Provider={0};Data Source={1}{2}",
                "Microsoft.Jet.OLEDB.4.0;",
                System.AppDomain.CurrentDomain.BaseDirectory,
                "..\\..\\..\\SHFDB\\SHFDB_V07.01.mdb");
        private int myProgramID = 1030301;
        private string myProgramName = "创意ABC";
        //private string myProgramCode = "EGLPABC082";
        //private string myProgramNumber = "2008-09-01-01-01";
        //private string myProgramVersion = "V06-2";

        private int myCourseID = 10001; // 学科课程
        private string myCourseName = "课程名称";

        private int myUnitID = 1; // 学科课程
        private string myUnitName = "课程名称";

        private int inst01UnitID = 1;
        //private string inst01UnitName = "业务01";
        private int inst02UnitID = 2;
        //private string inst02UnitName = "业务02";
        private int Typing01UnitID = 6;
        //private string Typing01UnitName = "按键练习";
        private int Typing02UnitID = 7;
        //private string Typing02UnitName = "键盘练习";
        private int Typing03UnitID = 8;
        //private string Typing03UnitName = "综合练习";
        #endregion

        #region 全程变量 字段说明
        protected btSHFUser shfUser = new btSHFUser();
        private btSHFUsers shfUsers = new btSHFUsers();
        protected btSHFUserLogin shfUserLogin = new btSHFUserLogin();//用户运行配置数据，在各模块中需要引用。
        private btSHFUserLogins shfUserLogins = new btSHFUserLogins();
        protected btSHFUnitPractice shfUnitPractice = new btSHFUnitPractice();
        private btSHFUnitPractices shfUnitPractices = new btSHFUnitPractices();
        //protected btSHFUnitScore shfUnitScore = new btSHFUnitScore();
        //private btSHFUnitScores shfUnitScores = new btSHFUnitScores();
        protected btSHFPage shfSHFPage = new btSHFPage();
        //private btSHFPages shfSHFPages = new btSHFPages();
        //protected btSHFStructure shfSHFStructure = new btSHFStructure();
        //private btSHFStructures shfSHFStructures = new btSHFStructures();

        //private int shfPracticeID;
        //private string shfPracticeName;
        #endregion

        #region 局部变量 字段说明
        private Form callMeForm;
        #endregion

 		#region uiSHFMain 重载说明

		public uiEGLPABC_AppMain()
		{
			InitializeComponent();

            shfInitializer(); //设置默认登录
		}

		/// <summary>调用重载（测试用）
		/// 
		/// </summary>
		/// <param name="callForm"></param>
        public uiEGLPABC_AppMain(Form callForm)
		{
			InitializeComponent();
			callMeForm = callForm;
			shfInitializer(); //设置默认登录

		}
        public uiEGLPABC_AppMain(Form callForm,ref string callConnect)
        {
            InitializeComponent();
            callMeForm = callForm;
            callConnect = shfConnect;
            shfInitializer(); //设置默认登录

        }

		protected void shfInitializer()
		{
			// 初始化默认登录数据----需要初始化成为默认用户状态。
			shfUser = shfUsers.GetUserById(1);//设为默认用户。
			shfUserLogin = shfUserLogins.GetOneByUserID(1);//设为默认用户登录。

			shfUserLogin.LoginNumber++;
			shfUserLogin.LoginProgramID = this.myProgramID;//本程序标识
			shfUserLogin.LoginUnitID = 0; //主界面
			shfUserLogin.LastDateTime = shfUserLogin.ThisDateTime;
			shfUserLogin.ThisDateTime = DateTime.Now;

			shfUserLogins.UpdateOne(shfUserLogin);

		}


		#endregion

        #region  辅助功能--初始化、动态刷新 等

        /// <summary>登录返回
        /// 显示登录用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiSHF_Main_Activated(object sender, EventArgs e)
        {
            //
            try
            {
                shfUserLogin = new btSHFUserLogin();
                btSHFUserLogins shfUserLogins = new btSHFUserLogins();
                shfUserLogin = shfUserLogins.GetOneByUserID(shfUser.UserID);
                pictureBoxHead.ImageLocation = Application.StartupPath + shfUser.UserHeadPath;
                label学号.Text = "学号： " + shfUser.UserCode + " ";
                label姓名.Text = "姓名： " + shfUser.UserName + " ";
            }
            catch
            { }

        }

        #endregion

        #region  基本业务功能
        /// <summary>单击登录
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button登录_Click(object sender, EventArgs e)
        {
            // 登录信息中需要设置：
            //  1 登录用户
            //  2 登录程序
            //  3 累计登录次数
            //  4 累计在线时间
            //  5 在线状态
            shfUserLogin.LoginProgramID = myProgramID;       //程序标识
            shfUserLogin.ProgramName = myProgramName;   //程序名称
            shfUserLogin.LoginCourseID = myCourseID;//键盘训练实验程序ID
            shfUserLogin.CourseName = myCourseName; //填写单元名称
            shfUserLogin.LoginUnitID = 2;//实验客户端登录单元ID
            shfUserLogin.UnitName = myProgramName + "登录"; //填写单元名称

            uiSHF_Login usrLog = new uiSHF_Login(this, shfUser, shfUserLogin, 1); // 默认学生登录
            usrLog.Show();

        }

        private void button注册_Click(object sender, EventArgs e)
        {
            uiSHF_Login usrLog = new uiSHF_Login(this, shfUser); // 默认学生登录
            usrLog.Show();
        }

        /// <summary>单击编辑用户
        ///  进入用户设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button设置_Click(object sender, EventArgs e)
        {
            uiSHF_Login uiR = new uiSHF_Login(this);
            uiR.Show();
            this.Hide();

        }

        private void button教学01_Click(object sender, EventArgs e)
        {
            shfUserLogin.LoginUnitID = inst01UnitID;//设置学习内容
            //uiPageEditSimple fr = new uiPageEditSimple(this, shfUserLogin, shfSHFPage);
            //this.Hide();
            //fr.Show();

        }

        private void button教学02_Click(object sender, EventArgs e)
        {

            //shfPracticeID = 6;  设置训练课程
            shfUserLogin.LoginUnitID = inst02UnitID; //设置学习内容
            //uiPageShowSimple fr = new uiPageShowSimple(this, shfUserLogin, shfSHFPage);
            //fr.Show();
            //this.Hide();

        }

        private void button训练01_Click(object sender, EventArgs e)
        {

            //shfPracticeID = 6; //设置训练课程
            shfUserLogin.LoginUnitID = Typing01UnitID;//设置训练内容
            //uiTyping01 f = new uiTyping01(this, shfUserLogin.UserLoginID, shfPracticeID);
            //f.Show();


        }

        private void button训练02_Click(object sender, EventArgs e)
        {
            try
            {
                //shfPracticeID = 7; //设置训练课程

                shfUserLogin.LoginUnitID = Typing02UnitID;//设置训练内容
                shfUnitPractice = shfUnitPractices.GetOne(Typing02UnitID);
                //uiTyping02Option f = new uiTyping02Option(this, shfUserLogin, shfUnitPrac);
                //f.Show();
                //this.Hide();

            }
            catch
            {
                this.Text = "button训练02_Click 异常！  ";

            }


        }

        private void button训练03_Click(object sender, EventArgs e)
        {
            try
            {
                shfUserLogin.LoginUnitID = Typing03UnitID;//设置训练内容
                shfUnitPractice = shfUnitPractices.GetOne(Typing03UnitID);
                //btSHFUserLogin uL = new btSHFUserLogin();
                //btSHFStructure stt = new btSHFStructure();
                //uiSHFCourseBase f = new uiSHFCourseBase(this, shfUserLogin, shfSHFStructure);
                //uiTyping03Option f = new uiTyping03Option(this, shfUserLogin, shfUnitPrac);
                //f.Show();

            }
            catch
            {
                this.Text = "综合练习启动 异常！  ";

            }


        }

        /// <summary>单击查看成绩
        /// 查看登录用户的键盘训练成绩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button排行榜_Click(object sender, EventArgs e)
        {
            // 查看方式：
            //      1 显示给定的单元成绩记录。
            //      2 根据用户ID按顺序查看成绩。
            //      3 显示成绩表
            //uiVSKP vs = new uiVSKP();
            //uiViewScore vs = new uiViewScore(shfUser.UserID);
            //vs.Show();
        }

        private void button历史纪录_Click(object sender, EventArgs e)
        {
            shfUserLogin.LoginUnitID = Typing03UnitID;//设置训练内容
            shfUnitPractice = shfUnitPractices.GetOne(Typing03UnitID);
            //frTypeScore fr = new frTypeScore(this, shfUnitScore, shfUserLogin, shfUnitPrac);
            //fr.Show();
        }

        /// <summary>依据用户信息查看成绩
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button统计分析_Click(object sender, EventArgs e)
        {
            //uiViewScore vs = new uiViewScore(shfUser.UserID);
            //vs.Show();

        }

        private void button创建课程_Click(object sender, EventArgs e)
        {
            uiPageEditSimple fr = new uiPageEditSimple(this, shfUserLogin);
            //this.Hide();
            fr.Show();

        }

        private void button课程结构_Click(object sender, EventArgs e)
        {
            uiStructureManageer f = new uiStructureManageer(this, shfUserLogin);
            f.Show();
        }

        private void button退出_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        #endregion

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }
   
    }
}
