using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EGLPABC082_UI
{
    public partial class uiEGLPABC_CourseShow1 : SHF_UI.uiSHF_CourseBase
    {
       public uiEGLPABC_CourseShow1()
        {
            InitializeComponent();
        }
        public uiEGLPABC_CourseShow1(Form form)
            : base(form)
        {
            InitializeComponent();
        }
        public uiEGLPABC_CourseShow1(Form callme, SHF_BT.btSHFUserLogin shfUserLogin)
            : base(callme, shfUserLogin)
        {
            InitializeComponent();
        }
        const int MIN = 1;

        private void button1_Click(object sender, EventArgs e)
        {
            int pageID = MIN + 2;
            SHF_BT.btSHFPage f = this.myPages.GetOne(pageID);
            this.richTextBox2.Text = f.TextInfo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int pageID = MIN + 4;
            SHF_BT.btSHFPage f = this.myPages.GetOne(pageID);
            this.richTextBox2.Text = f.TextInfo;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int pageID = MIN + 5;
            SHF_BT.btSHFPage f = this.myPages.GetOne(pageID);
            this.richTextBox2.Text = f.TextInfo;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int pageID = MIN + 3;
            SHF_BT.btSHFPage f = this.myPages.GetOne(pageID);
            this.richTextBox2.Text = f.TextInfo;
        }

        private void uiEGLPABC_CourseShow1_Load(object sender, EventArgs e)
        {
           
            int pageID = MIN ;
            SHF_BT.btSHFPage f = this.myPages.GetOne(pageID);

            this.richTextBox1.Text = f.TextInfo;
        }
    }
}
