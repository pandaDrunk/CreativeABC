using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.Collections;
using EGLPABC082_BT;
using SHF_BT;
using SHF_UI;
using SHF_DA;


namespace EGLPABC082_UI
{
    public partial class uiEGLPABC_ScoreShow1 : SHF_UI.uiSHF_CourseBase
    {
        public uiEGLPABC_ScoreShow1()
        {
            InitializeComponent();
        }

        public uiEGLPABC_ScoreShow1( Form callme, SHF_BT.btSHFUserLogin shfUserLogin)
            : base(callme, shfUserLogin)
        {
            InitializeComponent();
            StudentID = shfUserLogin.UserID;
        }

        private btSHFUnitScores btUS = new btSHFUnitScores();
        private int StudentID = 0;
        private int UserTimes = 0;

        #region 获得登录用户已练习次数
        public int GetUserTimes()
        {
            daSHFDB da = new daSHFDB();
            DataSet ds = new DataSet();
            string sql = "select StudentID from R_SHFUnitScores where StudentID=" + StudentID;
            ds = da.GetDataSet(sql);
            int times = ds.Tables[0].Columns.Count;
            return times;
        }
        #endregion

        #region 里程碑曲线绘制
        private void CreatGraph_best(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.XAxis.Scale.MaxAuto = true;
            myPane.XAxis.Scale.MinAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;
            myPane.YAxis.Scale.MinAuto = true;
            myPane.XAxis.MinSpace = 1;
            myPane.YAxis.MinSpace = 20;
            DataSet ds = new DataSet();

            myPane.Title.Text = "个人里程碑数据";
            myPane.XAxis.Title.Text = "训练进度";
            myPane.YAxis.Title.Text = "训练分数";
            ds = btUS.GetSQL("select distinct CorrectRate from R_SHFUnitScores where ProgramID=1030301 and StudentID=" + StudentID.ToString());
            double x, y;
            PointPairList list = new PointPairList();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                x = i;
                y = double.Parse(ds.Tables[0].Rows[i][0].ToString());
                list.Add(x, y);
            }
            LineItem mycurve = myPane.AddCurve("全部数据", list, Color.Red, SymbolType.Circle);
            zgc.AxisChange();
            zgc.Refresh();
        }
        #endregion

        #region 个人全部数据曲线绘制
        private void CreatGraph_all(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.XAxis.Scale.MaxAuto = true;
            myPane.XAxis.Scale.MinAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;
            myPane.YAxis.Scale.MinAuto = true;
            myPane.XAxis.MinSpace = 1;
            myPane.YAxis.MinSpace = 20;
            DataSet ds = new DataSet();

            myPane.Title.Text = "个人全部数据";
            myPane.XAxis.Title.Text = "训练进度";
            myPane.YAxis.Title.Text = "训练分数";
            ds = btUS.GetSQL("select CorrectRate from R_SHFUnitScores where ProgramID=1030301 and StudentID=" + StudentID);
            double x, y1;
            PointPairList list = new PointPairList();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                x = i;
                y1 = double.Parse(ds.Tables[0].Rows[i][0].ToString());
                list.Add(x, y1);
            }
            LineItem mycurve = myPane.AddCurve("全部数据", list, Color.Red, SymbolType.Diamond);
            zgc.AxisChange();
            zgc.Refresh();
        }
        #endregion

        #region 直方图查看
        private void CreatGraph_detailed(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.XAxis.Title.Text = "训练进度";
            myPane.YAxis.Title.Text = "训练分数";
            myPane.XAxis.Scale.MaxAuto = true;
            myPane.XAxis.Scale.MinAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;
            myPane.YAxis.Scale.MinAuto = true;
            myPane.XAxis.MinSpace = 1;
            myPane.YAxis.MinSpace = 20;

            DataSet ds1 = new DataSet();
         
            ds1 = btUS.GetSQL("select CorrectRate From R_SHFUnitScores where ProgramID=1030301 and UnitPracticeID=0 and StudentID=" + StudentID);
           
            string[] labels = { "综合训练" };
            double y1;
            ArrayList list1 = new ArrayList();
          
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                y1 = double.Parse(ds1.Tables[0].Rows[i][0].ToString());
                list1.Add(y1);
            }
         
            myPane.YAxis.Scale.Max = 100;

            myPane.BarSettings.Type = BarType.Stack;

            BarItem mybar = myPane.AddBar("综合训练", null, (double[])(list1.ToArray(typeof(double))), Color.Red);
            mybar.Bar.Fill = new Fill(Color.Red, Color.White, Color.Red);

           

            myPane.XAxis.Scale.TextLabels = labels;
            myPane.Title.Text = "直方图查看";
            zgc.AxisChange();
            zgc.Refresh();
        }
        #endregion


        private void button1_Click(object sender, EventArgs e)
        {
           
            zedGraphControl1.Visible = true;
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            CreatGraph_best(zedGraphControl1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            
            zedGraphControl1.Visible = true;
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            CreatGraph_all(zedGraphControl1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            zedGraphControl1.Visible = true;
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            CreatGraph_detailed(zedGraphControl1);
        }

        private void uiEGLPABC_ScoreShow1_Load_1(object sender, EventArgs e)
        {
            zedGraphControl1.Visible = false;
            UserTimes = GetUserTimes();
            UserTimes++;
        }

      
    }
}

