using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SHF_BT;
using EGLPABC082_BT;
using SHF_DA;
using SHF_UI;


namespace EGLPABC082_UI
{
    public partial class uiEGLPABC_TestEdit : SHF_UI.uiSHF_CourseBase
    {
        public uiEGLPABC_TestEdit()
        {
            InitializeComponent();
        }

        public uiEGLPABC_TestEdit(Form form,btSHFUserLogin shfUserLogin):base(form,shfUserLogin)
        {
            InitializeComponent();
            name = shfUserLogin.UserName;
        }

        #region 变量说明
        string name = "";
        btSHFQuestion q = new btSHFQuestion();
        btEGLPABCQuestion.sppQuestionstruct spp = new btEGLPABCQuestion.sppQuestionstruct();
        btEGLPABCQuestions qs = new btEGLPABCQuestions();
   
        DataSet ds = new DataSet();
        #endregion

        #region 从窗体获得要出的题目
        private bool GetQuestion(btEGLPABCQuestion.sppQuestionstruct spp, btSHFQuestion q)
        {
          
            if (txtQuestionAnswer.Text != "" && txtQuestionSubject.Text != "" &&
                textBoxA.Text != "" && textBoxB.Text != "" && 
                textBoxC.Text != "" && textBoxD.Text != "")
            {
                q.QuestionSubject = txtQuestionSubject.Text;
        
                spp.aq = textBoxA.Text;
                spp.bq = textBoxB.Text;
                spp.cq = textBoxC.Text;
                spp.dq = textBoxD.Text;
                if (txtQuestionAnswer.Text == "A" || txtQuestionAnswer.Text == "B" || 
                    txtQuestionAnswer.Text == "C" || txtQuestionAnswer.Text == "D" ||
                    txtQuestionAnswer.Text == "a" || txtQuestionAnswer.Text == "b" || 
                    txtQuestionAnswer.Text == "c" || txtQuestionAnswer.Text == "d")
                {
                    q.QuestionAnswer = txtQuestionAnswer.Text.ToUpper();
                    q.Question = spp.aq + "|" + spp.bq + "|" + spp.cq + "|" + spp.dq;
                    return true;
                    //return q;
                }
                else
                {
                    MessageBox.Show("正确答案填写错误!只能填写选项对应的标识:A(a),B(b),C(c),D(d)", "正确答案填写信息!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("所填题干、选项和答案不能有空项, 请重新填写!", "题目生成信息", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }            
        }
        #endregion

        #region 查看题目
        public DataSet ViewQuestion(string sql)
        {
            daSHFDB da = new daSHFDB();
            DataSet ds = new DataSet();
            ds = da.GetDataSet(sql);
            return ds;
        }
        #endregion

        
        

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click_1(object sender, EventArgs e)
        {
            bool flag = GetQuestion(spp, q);
            if (flag)
            {
                int id = qs.NewQuestion(q);
                if (id >= 0)
                {
                    MessageBox.Show("新题入库成功!", "添加新题", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxA.Clear();
                    textBoxB.Clear();
                    textBoxC.Clear();
                    textBoxD.Clear();
                    txtQuestionAnswer.Clear();
                    txtQuestionSubject.Clear();
                }
               
            }
            else
            {
                MessageBox.Show("新题入库失败!");
            }
        }

       
    }
}
