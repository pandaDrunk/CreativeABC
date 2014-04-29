using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SHF_BT;
using EGLPABC082_BT;
using ZedGraph;

namespace EGLPABC082_UI
{
    public partial class uiEGLPABC_ScoreShow2 : SHF_UI.uiSHF_CourseBase
    {
        public uiEGLPABC_ScoreShow2()
        {
            InitializeComponent();
        }

         public uiEGLPABC_ScoreShow2(Form form, btSHFUserLogin shfUserLogin)
            : base(form, shfUserLogin)
        {
            InitializeComponent();
            StudentID = shfUserLogin.UserID;
        }

        #region 变量说明
        private int StudentID = 0;

        string sql_all = "select CorrectRate from R_SHFUnitScores where ProgramID=1030301 and StudentID=";    
        string sql_mon = "select TotalScore from R_SHFUnitScores where ProgramID=1030301 and StudentID=";
        string sql_best1 = "select distinct CorrectRate from R_SHFUnitScores where ProgramID=1030301 and StudentID=";
        string sql_best2 = "select distinct TotalScore from R_SHFUnitScores where ProgramID=1030301 and StudentID="; 
        string sql_detailed = "select StartDateTime,PracticeTime,TotalNumber,CompleteNumber," +
            "RightNumber,ErrorNumber,CorrectRate,TotalScore,Evaluation " +
            "from R_SHFUnitScores where ProgramID=1030301 and StudentID=";
        btSHFUnitScores btUSS = new btSHFUnitScores();
        DataSet ds_all = new DataSet();
        DataSet ds_best1 = new DataSet();
        DataSet ds_best2 = new DataSet();
        DataSet ds_detailed = new DataSet();
        DataSet ds_mon = new DataSet();
        #endregion

        private void uiEGLPABC_ScoreShow2_Load(object sender, EventArgs e)
        {
            sql_best1 = sql_best1 + StudentID + " and CorrectRate>=60 order by CorrectRate DESC";
            sql_best2 = sql_best2 + StudentID + " and TotalScore>=40 order by TotalScore DESC";
            sql_all = sql_all + StudentID + " order by CorrectRate DESC";
            sql_detailed = sql_detailed + StudentID + " order by CorrectRate DESC";
            sql_mon = sql_mon + StudentID + " order by TotalScore DESC";

            ds_best1 = btUSS.GetSQL(sql_best1);
            dataGridView2.DataSource = ds_best1.Tables[0].DefaultView;
            dataGridView2.Columns[0].HeaderText = "Dragon分数";

            ds_best2 = btUSS.GetSQL(sql_best2);
            dataGridView5.DataSource = ds_best2.Tables[0].DefaultView;
            dataGridView5.Columns[0].HeaderText = "Monkey分数";

            ds_detailed = btUSS.GetSQL(sql_detailed);
            dataGridView3.DataSource = ds_detailed.Tables[0].DefaultView;
            dataGridView3.Columns[0].HeaderText = "开始日期";
            dataGridView3.Columns[1].HeaderText = "练习时间";
            dataGridView3.Columns[2].HeaderText = "总练习题目数";
            dataGridView3.Columns[3].HeaderText = "完成题目数";
            dataGridView3.Columns[4].HeaderText = "正确题目数";
            dataGridView3.Columns[5].HeaderText = "错误题目数";
            dataGridView3.Columns[6].HeaderText = "Dragon分数";
            dataGridView3.Columns[7].HeaderText = "Monkey分数";
            dataGridView3.Columns[8].HeaderText = "成绩评定";

            ds_all = btUSS.GetSQL(sql_all);
            dataGridView1.DataSource = ds_all.Tables[0].DefaultView;
            dataGridView1.Columns[0].HeaderText = "Dragon分数";


            ds_mon = btUSS.GetSQL(sql_mon);
            dataGridView4.DataSource = ds_mon.Tables[0].DefaultView;
            dataGridView4.Columns[0].HeaderText = "Monkey分数";



        }

       

    }
}
