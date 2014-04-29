using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SHF_BT;

namespace EGLPABC_BT
{
    public class btEGLPABCQuestion : btSHFQuestion
    {
        public new struct sppQuestionstruct
        {
            public string aq;
            public string bq;
            public string cq;
            public string dq;
        }

        #region 题目候选项转换
        public sppQuestionstruct SHFQuesitonTosppQuestion(btSHFQuestion shfQ)
        {
            //SWF.MessageBox.Show("StartReceive： " + strUC);
            string s = shfQ.Question;
            sppQuestionstruct q = new sppQuestionstruct();
            try
            {
                //检查 s 的有效性
                if (s.Length > 1 && s.IndexOf("|") > 0)
                {
                    //数据 5 项
                    q.aq = System.Convert.ToString(s.Substring(0, s.IndexOf("|")));
                    s = s.Remove(0, s.IndexOf("|") + 1);//r.UsrIDI =0;
                    q.bq = s.Substring(0, s.IndexOf("|"));
                    s = s.Remove(0, s.IndexOf("|") + 1);
                    q.cq = s.Substring(0, s.IndexOf("|"));
                    System.Convert.ToString(s); s = s.Remove(0, s.IndexOf("|") + 1);
                    q.dq = System.Convert.ToString(s);
                }
            }
            catch (Exception ex)
            {
                throw new System.ApplicationException("sppQuestionstruct " + ex.ToString());
            }
            return q;
        }//sppQuestionToSHFQuestion
        #endregion
    }
}
