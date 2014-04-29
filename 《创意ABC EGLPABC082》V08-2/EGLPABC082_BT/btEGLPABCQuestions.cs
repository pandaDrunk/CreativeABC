using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SHF_BT;
using SHF_DA;
using System.Data;
using System.Collections;
using System.Windows.Forms;

namespace EGLPABC082_BT
{
    public class btEGLPABCQuestions : btSHFQuestions
    {

        #region 变量说明
        //const int MAX=255;
        btEGLPABCQuestion qq = new btEGLPABCQuestion();
        btEGLPABCQuestion.sppQuestionstruct spp = new btEGLPABCQuestion.sppQuestionstruct();
        btSHFQuestions qs = new btSHFQuestions();
        btSHFQuestion q = new btSHFQuestion();
        daSHFDB da = new daSHFDB();

        ArrayList myQSAL = new ArrayList(); //存储所有的题目
        ArrayList myQAAL = new ArrayList(); //存储所有题目的正确答案
        ArrayList myQNAL = new ArrayList(); //存储所有题目的图案地址
      
        private int m_MaxID = 0;    //题库中的题目总数
        #endregion

        public int MaxID
        {
            get { return m_MaxID; }
            set { m_MaxID = value; }
        }

        #region 生成新题
        public int NewQuestion(btSHFQuestion q)
        {
            int i, id = -1;
            btSHFQuestions myItems = new btSHFQuestions();
            i = myItems.CheckOne(q.QuestionSubject);
            if (i == 0)
            {
                id = myItems.AddOne(q);
            }
            return id;
        }
        #endregion

        #region 获取QuestionID的最大值
        public int GetMaxID()
        {
           
            myQSAL = qs.GetAll();
            int _MaxID = myQSAL.Count;
            return _MaxID;
        }
        #endregion

        #region 从数据库中读取所有题目的图片地址
        public ArrayList GetAllQN()
        {
            myQNAL.Clear();
            for (int i = 1; i <= m_MaxID; i++)
            {
                q = qs.GetByID(i);
                myQNAL.Add(q.QuestionNote);
            }
            return myQNAL;
        }
        #endregion

        #region 从数据库中读取所有的题目
        public ArrayList GetAllQS()
        {
           
            myQSAL.Clear();
            for (int i = 1; i <= m_MaxID; i++)
            {
                q = qs.GetByID(i);
                myQSAL.Add(q.QuestionSubject);
            }
            return myQSAL;
        }
        #endregion

        #region 从数据库中读取所有题目的正确答案
        public ArrayList GetAllQA()
        {
            myQAAL.Clear();
            for (int i = 1; i <= m_MaxID; i++)
            {
                q = qs.GetByID(i);
                myQAAL.Add(q.QuestionAnswer);
            }
            return myQAAL;
        }
        #endregion

       

        #region 从数据库中读取所有的选项答案
        public string[,] GetAllOptions()
        {
            string[,] table = new string[m_MaxID, 5];
            for (int i = 1; i <= m_MaxID; i++)
            {
                q = qs.GetByID(i);
                spp = qq.SHFQuesitonTosppQuestion(q);
                table[i - 1, 0] = i.ToString();
                table[i - 1, 1] = spp.aq;
                table[i - 1, 2] = spp.bq;
                table[i - 1, 3] = spp.cq;
                table[i - 1, 4] = spp.dq;
            }
            return table;
        }
        #endregion

        #region  判断用户回答是否正确
        public void JudgeQuestion(ArrayList QAAL, string[,] _table, ref int RightNumber)
        {
            for (int i = 0; i < m_MaxID; i++)
            {
                if (QAAL[i].ToString() == _table[i, 1])
                {
                    RightNumber++;
                }
            }
            
        }
        #endregion

       

    }
}
