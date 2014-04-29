namespace EGLPABC082_UI
{
    partial class uiEGLPABC_ScoreShow1
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
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.button里程碑数据 = new System.Windows.Forms.Button();
            this.button个人数据 = new System.Windows.Forms.Button();
            this.button直方图 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHead)).BeginInit();
            this.SuspendLayout();
            // 
            // label程序信息
            // 
            this.label程序信息.Size = new System.Drawing.Size(353, 12);
            this.label程序信息.Text = "《创意ABC EGLPABC082》V082|EGLPABC_UI|uiEGLPABC_ScoreShow1";
            // 
            // label课程信息
            // 
            this.label课程信息.Size = new System.Drawing.Size(155, 12);
            this.label课程信息.Tag = "";
            this.label课程信息.Text = "少儿英语|创意ABC|成绩曲线";
            // 
            // labelPageTitle
            // 
            this.labelPageTitle.Size = new System.Drawing.Size(159, 35);
            this.labelPageTitle.Text = "成绩曲线";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(30, 92);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0;
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(554, 394);
            this.zedGraphControl1.TabIndex = 148;
            // 
            // button里程碑数据
            // 
            this.button里程碑数据.Location = new System.Drawing.Point(606, 167);
            this.button里程碑数据.Name = "button里程碑数据";
            this.button里程碑数据.Size = new System.Drawing.Size(75, 23);
            this.button里程碑数据.TabIndex = 149;
            this.button里程碑数据.Text = "里程碑数据";
            this.button里程碑数据.UseVisualStyleBackColor = true;
            this.button里程碑数据.Click += new System.EventHandler(this.button1_Click);
            // 
            // button个人数据
            // 
            this.button个人数据.Location = new System.Drawing.Point(606, 196);
            this.button个人数据.Name = "button个人数据";
            this.button个人数据.Size = new System.Drawing.Size(75, 23);
            this.button个人数据.TabIndex = 150;
            this.button个人数据.Text = "个人数据";
            this.button个人数据.UseVisualStyleBackColor = true;
            this.button个人数据.Click += new System.EventHandler(this.button2_Click);
            // 
            // button直方图
            // 
            this.button直方图.Location = new System.Drawing.Point(606, 225);
            this.button直方图.Name = "button直方图";
            this.button直方图.Size = new System.Drawing.Size(75, 23);
            this.button直方图.TabIndex = 151;
            this.button直方图.Text = "直方图";
            this.button直方图.UseVisualStyleBackColor = true;
            this.button直方图.Click += new System.EventHandler(this.button3_Click);
            // 
            // uiEGLPABC_ScoreShow1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(792, 516);
            this.Controls.Add(this.button直方图);
            this.Controls.Add(this.button个人数据);
            this.Controls.Add(this.button里程碑数据);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "uiEGLPABC_ScoreShow1";
            this.Load += new System.EventHandler(this.uiEGLPABC_ScoreShow1_Load_1);
            this.Controls.SetChildIndex(this.zedGraphControl1, 0);
            this.Controls.SetChildIndex(this.button里程碑数据, 0);
            this.Controls.SetChildIndex(this.labelPageTitle, 0);
            this.Controls.SetChildIndex(this.label课程信息, 0);
            this.Controls.SetChildIndex(this.label程序信息, 0);
            this.Controls.SetChildIndex(this.label姓名, 0);
            this.Controls.SetChildIndex(this.label学号, 0);
            this.Controls.SetChildIndex(this.pictureBoxHead, 0);
            this.Controls.SetChildIndex(this.button退出, 0);
            this.Controls.SetChildIndex(this.button返回, 0);
            this.Controls.SetChildIndex(this.button确定, 0);
            this.Controls.SetChildIndex(this.button个人数据, 0);
            this.Controls.SetChildIndex(this.button直方图, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHead)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button button里程碑数据;
        private System.Windows.Forms.Button button个人数据;
        private System.Windows.Forms.Button button直方图;
    }
}
