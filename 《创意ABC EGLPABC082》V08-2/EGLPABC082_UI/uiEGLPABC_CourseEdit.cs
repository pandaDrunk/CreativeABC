using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SHF_UI;
using SHF_BT;
using SHF_DA;

namespace EGLPABC082_UI
{
    public partial class uiEGLPABC_CourseEdit : SHF_UI.uiSHF_CourseBase
    {
        private btSHFPage shfPage = new btSHFPage();　　　　//用来保存某个课程信息
        private btSHFPages shfPages = new btSHFPages();    //用来对数据库进行操作
        private btSHFStructure shfStructure = new btSHFStructure();
        private btSHFStructures shfStructures = new btSHFStructures();

        
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        uiEGLPABC_CourseShow shfCS = new uiEGLPABC_CourseShow();
        string solution = "《创意ABC EGLPABC082》V08-2";   //解决方案文件夹名称

        public uiEGLPABC_CourseEdit()
        {
            InitializeComponent();
        
        }
         public uiEGLPABC_CourseEdit(Form form)
            : base(form)
        {
            InitializeComponent();
        }

        public uiEGLPABC_CourseEdit(Form form, btSHFUserLogin shfUserLogin)
            : base(form, shfUserLogin)
        {
            InitializeComponent();
            
        }

    

        

        private void button确定_Click(object sender, EventArgs e)
        {

            myPage.TextInfo = textBoxEdit.Text;//把页面上的信息保存到shfPage
            myPages.UpdateOne(myPage);//把shfPage写到数据库
            MessageBox.Show("编辑成功");
        }


        private void ucCourseManagerSimple1_comCourse_AfterSelect(object sender, EventArgs e)
        {
            label课程信息.Text = ucCourseManagerSimple1.FieldName + "|" + ucCourseManagerSimple1.CourseName + "|" + ucCourseManagerSimple1.UnitName;
            label程序信息.Text = "《创意ABC EGLPABC082》V08-2|EGLPABC_UI|uiEGLPABC_Edit";
            if (ucCourseManagerSimple1.TerminalID > 0)
            {
                labelPageTitle.Text = this.myPages.GetOne(ucCourseManagerSimple1.TerminalID).PageTitle;
                // myPage = myPages.GetOne(ucCourseManagerSimple1.TerminalID - 3);
            }
            else
            {
                labelPageTitle.Text = "使用编辑";
            }
        }
        private void ucCourseManagerSimple1_trvCourse_AfterSelect(object sender, EventArgs e)
        {
            //if (ucCourseManagerSimple1.TerminalID > 0 && ucCourseManagerSimple1.TerminalID < 4)
            //textBoxHelp.Text = this.myPages.GetOne(ucCourseManagerSimple1.TerminalID).TextInfo;
            if (ucCourseManagerSimple1.TerminalID > 0)
            {
                textBoxEdit.Text = this.myPages.GetOne(ucCourseManagerSimple1.TerminalID ).TextInfo;
                myPage = myPages.GetOne(ucCourseManagerSimple1.TerminalID);

            }
            else textBoxEdit.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = this.openFileDialog1.FileName;
                    textBox文本.Text = this.openFileDialog1.FileName;
                    shfCS.readFile(path, this.richTextBox1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void button添加文本_Click(object sender, EventArgs e)
        {
            if (textBox文本.Text != "")
            {
                try
                {
                    string path = textBox文本.Text;
                    
                    string path2 = Directory.GetCurrentDirectory() + @"..\..\..\..\EGLPABC_UI\Source";
                    FileInfo fi1 = new FileInfo(path);
                    File.Copy(path, path2 + fi1.Name, false);
                    MessageBox.Show("文本文件添加成功!", "添加文件信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox文本.Clear();
                    richTextBox1.Clear();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString(), "保存文件信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请选择文件!", "添加文件出错", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myPage.TextInfo = textBoxEdit.Text;//把页面上的信息保存到shfPage
            myPages.UpdateOne(myPage);//把shfPage写到数据库
            MessageBox.Show("编辑成功");
        }

    }
}

    
