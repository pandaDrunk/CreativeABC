using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SHF_BT;
using SHF_DA;
using System.Data;
using System.Windows.Forms;

namespace EGLPABC082_BT
{
    public class btEGLPABCUnitPractices : btSHFUnitPractices
    {
        #region 变量说明
        btSHFUnitScore myUnitScore = new btSHFUnitScore();
        btSHFUserLogin callMeLog = new btSHFUserLogin();
        private bool m_StartFlag = false;
        Timer m_timer = new Timer();
        private int m_QueAll = 0,          //题目总数
            m_RightNumber = 0,    //回答正确题目数
            m_notAnswered = 0,       //未回答题目数
            m_Answered = 0;         //已回答题目数 
        private string m_sql = "";
        daSHFDB da = new daSHFDB();
        DataSet ds = new DataSet();
        public int studentID = 0;
        #endregion

        #region 访问方法
        public bool StartFlag
        {
            get { return m_StartFlag; }
            set { m_StartFlag = value; }
        }

        public int QueAll
        {
            get { return m_QueAll; }
            set { m_QueAll = value; }
        }

        public int RightNumber
        {
            get { return m_RightNumber; }
            set { m_RightNumber = value; }
        }

        public int notAnswered
        {
            get { return m_notAnswered; }
            set { m_notAnswered = value; }
        }

        public int Answered
        {
            get { return m_Answered; }
            set { m_Answered = value; }
        }

        public Timer timer
        {
            get { return m_timer; }
            set { m_timer = value; }
        }

        public string sql
        {
            get { return m_sql; }
            set { m_sql = value; }
        }
        #endregion

        #region 初始化训练
        public void InitPractice()
        {
            this.myUnitScore.ProgramID = callMeLog.LoginProgramID;
            this.myUnitScore.StudentID = callMeLog.UserID;
            this.myUnitScore.UnitPracticeID = callMeLog.LoginUnitID;
            this.myUnitScore.ConfigID = callMeLog.UserLoginID;

            // 初始化单元成绩，设置训练进入时刻（不是练习开始时刻）。
            this.myUnitScore.StartDateTime = DateTime.Now;
            this.myUnitScore.PracticeTime = 0;

            m_StartFlag = false;
        }
        #endregion

        #region 启动单元训练
        public void StartPractice()
        {
            ///单元成绩清零
            this.myUnitScore.ProgramID = 1030301;
            this.myUnitScore.StudentID = studentID;
            this.myUnitScore.UnitPracticeID = callMeLog.LoginUnitID;
            this.myUnitScore.ConfigID = callMeLog.UserLoginID;

            //this.myUnitScore.TotalNumber = callMePractice.LimitNumber;
            this.myUnitScore.ClearCouts();

            ///登记单元开始时间
            this.myUnitScore.StartDateTime = DateTime.Now;
            this.myUnitScore.PracticeTime = 0;

            ///启动单元计时
            this.m_StartFlag = true;
            this.m_timer.Enabled = true;

            ///启动新题流程
            //this.StartNewQuestion();
        }
        #endregion

        #region 结束单元练习

        public void EndPractice()
        {
            //停止计时
            m_timer.Enabled = false;

            //计算时间
            TimeSpan ts = DateTime.Now.Subtract(myUnitScore.StartDateTime);
            myUnitScore.PracticeTime = (int)ts.TotalMilliseconds;

            // 登记成绩
            //m_Answered = m_QueAll - m_notAnswered;
            myUnitScore.ProgramID = 1030301;
            myUnitScore.StudentID = studentID;
            myUnitScore.TotalNumber = this.m_QueAll;
            myUnitScore.CompleteNumber = this.m_Answered;
            myUnitScore.RightNumber = this.m_RightNumber;
            myUnitScore.ErrorNumber = m_Answered - m_RightNumber;
            myUnitScore.CorrectRate = (int)(Convert.ToDouble(m_RightNumber) / m_QueAll * 100);

            // 评价成绩
            myUnitScore.DoEvaluation();

            // 保存成绩
            btSHFUnitScores us = new btSHFUnitScores();
            us.AddOne(myUnitScore);

            // 停止处理流程;
            m_StartFlag = false;
        }//EndPractice
        #endregion

        #region 查看训练题目
        public DataSet ViewPractice()
        {
            ds = da.GetDataSet(m_sql);
            return ds;
        }
        #endregion
    }
}
