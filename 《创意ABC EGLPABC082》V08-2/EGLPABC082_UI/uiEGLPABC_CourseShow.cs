using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using SHF_BT;
using SHF_UI;
using SHF_DA;

namespace EGLPABC082_UI
{
    public partial class uiEGLPABC_CourseShow : SHF_UI.uiSHF_CourseBase
    {
        string path = Directory.GetCurrentDirectory() + @"..\..\..\..\EGLPABC082_UI";
        
         btSHFPage shfPage = new btSHFPage();　　　　//用来保存某个课程信息
         btSHFPages shfPages = new btSHFPages();    //用来对数据库进行操作
         btSHFStructure shfStructure = new btSHFStructure();
         btSHFStructures shfStructures = new btSHFStructures();

        public uiEGLPABC_CourseShow()
        {
            InitializeComponent();
        }
        public uiEGLPABC_CourseShow(Form form)
            : base(form)
        {
            InitializeComponent();
        }
        public uiEGLPABC_CourseShow(Form callme, SHF_BT.btSHFUserLogin shfUserLogin)
            : base(callme, shfUserLogin)
        {
            InitializeComponent();
        }
        #region 读取文本文件的内容(文本文件编码方式:UTF-8)
        public void readFile(string path, RichTextBox richTextBox)
        {
            richTextBox.Clear();
            richTextBox.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox.SelectionIndent = 20;
            richTextBox.SelectionHangingIndent = -20;

            StreamReader din = File.OpenText(path);
            String str;
            ArrayList al = new ArrayList();

            while ((str = din.ReadLine()) != null)
            {
                al.Add(str);
            }

            foreach (string s in al)
            {
                richTextBox.SelectedText += s;
                richTextBox.SelectedText += "\r\n";
            }
        }
        #endregion



        private void ucCourseManagerSimple1_comCourse_AfterSelect(object sender, EventArgs e)
        {
       
        
            label课程信息.Text = ucCourseManagerSimple1.FieldName + "|" + ucCourseManagerSimple1.CourseName + "|" + ucCourseManagerSimple1.UnitName;

            label程序信息.Text = "《创意ABC EGLPABC082》V08-2|EGLPABC_UI|uiEGLPABC_CourseShow";
            if (ucCourseManagerSimple1.TerminalID > 0) labelPageTitle.Text = this.myPages.GetOne(ucCourseManagerSimple1.TerminalID).PageTitle;
            else labelPageTitle.Text = this.ucCourseManagerSimple1.FieldName;
         
        }

       

        private void button连线与涂鸦_Click(object sender, EventArgs e)
        {
          string path1 = path + @"\Source\连线与涂鸦.txt";
            readFile(path1, richTextBox1);
            
        }

        private void button猴子爬树藤_Click(object sender, EventArgs e)
        {
            string path1 = path + @"\Source\猴子爬树藤.txt";
            readFile(path1, richTextBox1);
        }

        private void button飞越毒龙潭_Click(object sender, EventArgs e)
        {
            string path1 = path + @"\Source\飞越毒龙潭.txt";
            readFile(path1, richTextBox1);
        }

        // TreeView控件选择事件
      
		

        private void ucCourseManagerSimple1_trvCourse_AfterSelect(object sender, EventArgs e)
        {
            if (ucCourseManagerSimple1.TerminalID > 0)
                textBox1.Text = this.myPages.GetOne(ucCourseManagerSimple1.TerminalID).TextInfo;

            else textBox1.Text = "";
        }

        
      

       




    }
}
