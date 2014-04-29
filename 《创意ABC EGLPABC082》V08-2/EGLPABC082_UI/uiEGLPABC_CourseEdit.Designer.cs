namespace EGLPABC082_UI
{
    partial class uiEGLPABC_CourseEdit
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ucCourseManagerSimple1 = new SHF_UI.ucCourseManagerSimple();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox文本 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button添加文本 = new System.Windows.Forms.Button();
            this.textBoxEdit = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHead)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button确定
            // 
            this.button确定.Text = "保存";
            // 
            // label程序信息
            // 
            this.label程序信息.Size = new System.Drawing.Size(359, 12);
            this.label程序信息.Text = "《创意ABC EGLPABC082》V08-2|EGLPABC_UI|uiEGLPABC_CourseEdit";
            // 
            // label课程信息
            // 
            this.label课程信息.Size = new System.Drawing.Size(173, 12);
            this.label课程信息.Tag = "少儿英语|创意ABC|创意ABC教学";
            this.label课程信息.Text = "少儿英语|创意ABC|创意ABC编辑";
            // 
            // labelPageTitle
            // 
            this.labelPageTitle.Size = new System.Drawing.Size(213, 35);
            this.labelPageTitle.Text = "创意ABC编辑";
            // 
            // ucCourseManagerSimple1
            // 
            this.ucCourseManagerSimple1.AcdemicPoint = 1;
            this.ucCourseManagerSimple1.ChapterName = "";
            this.ucCourseManagerSimple1.CourseName = "";
            this.ucCourseManagerSimple1.FieldName = "";
            this.ucCourseManagerSimple1.Location = new System.Drawing.Point(32, 92);
            this.ucCourseManagerSimple1.Name = "ucCourseManagerSimple1";
            this.ucCourseManagerSimple1.PageName = "";
            this.ucCourseManagerSimple1.PointName = "";
            this.ucCourseManagerSimple1.Size = new System.Drawing.Size(169, 421);
            this.ucCourseManagerSimple1.StructureID = 0;
            this.ucCourseManagerSimple1.TabIndex = 149;
            this.ucCourseManagerSimple1.TerminalID = 0;
            this.ucCourseManagerSimple1.TitleName = "";
            this.ucCourseManagerSimple1.UnitName = "";
            this.ucCourseManagerSimple1.comCourse_AfterSelect += new SHF_UI.ucCourseManager.comCourseSelectHandle(this.ucCourseManagerSimple1_comCourse_AfterSelect);
            this.ucCourseManagerSimple1.trvCourse_AfterSelect += new SHF_UI.ucCourseManager.trvCourseSelectHandle(this.ucCourseManagerSimple1_trvCourse_AfterSelect);
            // 
            // richTextBox1
            // 
            this.richTextBox1.ForeColor = System.Drawing.Color.Blue;
            this.richTextBox1.Location = new System.Drawing.Point(18, 40);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(280, 134);
            this.richTextBox1.TabIndex = 162;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(304, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 21);
            this.button1.TabIndex = 160;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox文本
            // 
            this.textBox文本.Location = new System.Drawing.Point(154, 13);
            this.textBox文本.Name = "textBox文本";
            this.textBox文本.Size = new System.Drawing.Size(144, 21);
            this.textBox文本.TabIndex = 159;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(92, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 161;
            this.label1.Text = "文本文件";
            // 
            // button添加文本
            // 
            this.button添加文本.Location = new System.Drawing.Point(309, 140);
            this.button添加文本.Name = "button添加文本";
            this.button添加文本.Size = new System.Drawing.Size(80, 35);
            this.button添加文本.TabIndex = 167;
            this.button添加文本.Text = "添加文本";
            this.button添加文本.UseVisualStyleBackColor = true;
            this.button添加文本.Click += new System.EventHandler(this.button添加文本_Click);
            // 
            // textBoxEdit
            // 
            this.textBoxEdit.Location = new System.Drawing.Point(257, 313);
            this.textBoxEdit.Multiline = true;
            this.textBoxEdit.Name = "textBoxEdit";
            this.textBoxEdit.Size = new System.Drawing.Size(280, 170);
            this.textBoxEdit.TabIndex = 168;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(543, 445);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 38);
            this.button2.TabIndex = 169;
            this.button2.Text = "修改";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button添加文本);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox文本);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(226, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 186);
            this.groupBox1.TabIndex = 170;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文本添加";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(226, 293);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 202);
            this.groupBox2.TabIndex = 171;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "教学内容修改";
            // 
            // uiEGLPABC_CourseEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(792, 516);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxEdit);
            this.Controls.Add(this.ucCourseManagerSimple1);
            this.Controls.Add(this.groupBox2);
            this.Name = "uiEGLPABC_CourseEdit";
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.labelPageTitle, 0);
            this.Controls.SetChildIndex(this.label课程信息, 0);
            this.Controls.SetChildIndex(this.label程序信息, 0);
            this.Controls.SetChildIndex(this.label姓名, 0);
            this.Controls.SetChildIndex(this.label学号, 0);
            this.Controls.SetChildIndex(this.pictureBoxHead, 0);
            this.Controls.SetChildIndex(this.button退出, 0);
            this.Controls.SetChildIndex(this.button返回, 0);
            this.Controls.SetChildIndex(this.button确定, 0);
            this.Controls.SetChildIndex(this.ucCourseManagerSimple1, 0);
            this.Controls.SetChildIndex(this.textBoxEdit, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHead)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SHF_UI.ucCourseManagerSimple ucCourseManagerSimple1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox文本;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button添加文本;
        private System.Windows.Forms.TextBox textBoxEdit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;

    }
}
