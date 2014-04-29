namespace EGLPABC082_Net
{
    partial class EGLPABC082_ReceiveEmail
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
            this.statlistBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.messagelistBox = new System.Windows.Forms.ListBox();
            this.RecBtn = new System.Windows.Forms.Button();
            this.maillabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHead)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPageTitle
            // 
            this.labelPageTitle.Size = new System.Drawing.Size(159, 35);
            this.labelPageTitle.Text = "接收邮件";
            // 
            // statlistBox
            // 
            this.statlistBox.FormattingEnabled = true;
            this.statlistBox.ItemHeight = 12;
            this.statlistBox.Location = new System.Drawing.Point(392, 185);
            this.statlistBox.Name = "statlistBox";
            this.statlistBox.Size = new System.Drawing.Size(194, 64);
            this.statlistBox.TabIndex = 151;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 150;
            this.label1.Text = "当前状态";
            // 
            // messagelistBox
            // 
            this.messagelistBox.FormattingEnabled = true;
            this.messagelistBox.HorizontalScrollbar = true;
            this.messagelistBox.ItemHeight = 12;
            this.messagelistBox.Location = new System.Drawing.Point(66, 283);
            this.messagelistBox.Name = "messagelistBox";
            this.messagelistBox.Size = new System.Drawing.Size(520, 172);
            this.messagelistBox.TabIndex = 149;
            // 
            // RecBtn
            // 
            this.RecBtn.Location = new System.Drawing.Point(108, 185);
            this.RecBtn.Name = "RecBtn";
            this.RecBtn.Size = new System.Drawing.Size(117, 40);
            this.RecBtn.TabIndex = 148;
            this.RecBtn.Text = "接收邮件";
            this.RecBtn.UseVisualStyleBackColor = true;
            this.RecBtn.Click += new System.EventHandler(this.RecBtn_Click);
            // 
            // maillabel
            // 
            this.maillabel.AutoSize = true;
            this.maillabel.Location = new System.Drawing.Point(148, 135);
            this.maillabel.Name = "maillabel";
            this.maillabel.Size = new System.Drawing.Size(0, 12);
            this.maillabel.TabIndex = 152;
            // 
            // EGLPABC082_ReceiveEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(792, 516);
            this.Controls.Add(this.maillabel);
            this.Controls.Add(this.statlistBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.messagelistBox);
            this.Controls.Add(this.RecBtn);
            this.Name = "EGLPABC082_ReceiveEmail";
            this.Controls.SetChildIndex(this.labelPageTitle, 0);
            this.Controls.SetChildIndex(this.label课程信息, 0);
            this.Controls.SetChildIndex(this.label程序信息, 0);
            this.Controls.SetChildIndex(this.label姓名, 0);
            this.Controls.SetChildIndex(this.label学号, 0);
            this.Controls.SetChildIndex(this.pictureBoxHead, 0);
            this.Controls.SetChildIndex(this.button退出, 0);
            this.Controls.SetChildIndex(this.button返回, 0);
            this.Controls.SetChildIndex(this.button确定, 0);
            this.Controls.SetChildIndex(this.RecBtn, 0);
            this.Controls.SetChildIndex(this.messagelistBox, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.statlistBox, 0);
            this.Controls.SetChildIndex(this.maillabel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHead)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox statlistBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox messagelistBox;
        private System.Windows.Forms.Button RecBtn;
        private System.Windows.Forms.Label maillabel;
    }
}
