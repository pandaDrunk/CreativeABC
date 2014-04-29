namespace EGLPABC082_Net
{
    partial class EGLPABC082_SetEmail
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
            this.pop3Box = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.smtpBox = new System.Windows.Forms.TextBox();
            this.passBox = new System.Windows.Forms.TextBox();
            this.userlabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SendMailBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ReceMailBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHead)).BeginInit();
            this.SuspendLayout();
            // 
            // pop3Box
            // 
            this.pop3Box.Location = new System.Drawing.Point(113, 173);
            this.pop3Box.Name = "pop3Box";
            this.pop3Box.Size = new System.Drawing.Size(187, 21);
            this.pop3Box.TabIndex = 149;
     
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(366, 173);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(185, 21);
            this.nameBox.TabIndex = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 154;
            this.label2.Text = "POP3邮箱帐号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 153;
            this.label1.Text = "接收邮件服务器(POP3)";
            // 
            // smtpBox
            // 
            this.smtpBox.Location = new System.Drawing.Point(113, 247);
            this.smtpBox.Name = "smtpBox";
            this.smtpBox.Size = new System.Drawing.Size(187, 21);
            this.smtpBox.TabIndex = 151;
            // 
            // passBox
            // 
            this.passBox.Location = new System.Drawing.Point(366, 247);
            this.passBox.Name = "passBox";
            this.passBox.PasswordChar = '*';
            this.passBox.Size = new System.Drawing.Size(185, 21);
            this.passBox.TabIndex = 152;
            // 
            // userlabel
            // 
            this.userlabel.AutoSize = true;
            this.userlabel.Location = new System.Drawing.Point(379, 234);
            this.userlabel.Name = "userlabel";
            this.userlabel.Size = new System.Drawing.Size(0, 12);
            this.userlabel.TabIndex = 148;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 156;
            this.label4.Text = "密码";
            // 
            // SendMailBtn
            // 
            this.SendMailBtn.Location = new System.Drawing.Point(115, 357);
            this.SendMailBtn.Name = "SendMailBtn";
            this.SendMailBtn.Size = new System.Drawing.Size(75, 23);
            this.SendMailBtn.TabIndex = 157;
            this.SendMailBtn.Text = "发送邮件";
            this.SendMailBtn.UseVisualStyleBackColor = true;
            this.SendMailBtn.Click += new System.EventHandler(this.SendMailBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 155;
            this.label3.Text = "发送邮件服务器(SMTP)";
            // 
            // ReceMailBtn
            // 
            this.ReceMailBtn.Location = new System.Drawing.Point(277, 357);
            this.ReceMailBtn.Name = "ReceMailBtn";
            this.ReceMailBtn.Size = new System.Drawing.Size(75, 23);
            this.ReceMailBtn.TabIndex = 158;
            this.ReceMailBtn.Text = "接收邮件";
            this.ReceMailBtn.UseVisualStyleBackColor = true;
            this.ReceMailBtn.Click += new System.EventHandler(this.ReceMailBtn_Click);
            // 
            // EGLPABC082_SetEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(792, 516);
            this.Controls.Add(this.pop3Box);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.smtpBox);
            this.Controls.Add(this.passBox);
            this.Controls.Add(this.userlabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SendMailBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ReceMailBtn);
            this.Name = "EGLPABC082_SetEmail";
            this.Load += new System.EventHandler(this.EGLPABC082_SetEmail_Load);
            this .Activated+=new System.EventHandler(EGLPABC082_SetEmail_Activated);
            this.Controls.SetChildIndex(this.labelPageTitle, 0);
            this.Controls.SetChildIndex(this.label课程信息, 0);
            this.Controls.SetChildIndex(this.label程序信息, 0);
            this.Controls.SetChildIndex(this.label姓名, 0);
            this.Controls.SetChildIndex(this.label学号, 0);
            this.Controls.SetChildIndex(this.pictureBoxHead, 0);
            this.Controls.SetChildIndex(this.button退出, 0);
            this.Controls.SetChildIndex(this.button返回, 0);
            this.Controls.SetChildIndex(this.button确定, 0);
            this.Controls.SetChildIndex(this.ReceMailBtn, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.SendMailBtn, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.userlabel, 0);
            this.Controls.SetChildIndex(this.passBox, 0);
            this.Controls.SetChildIndex(this.smtpBox, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.nameBox, 0);
            this.Controls.SetChildIndex(this.pop3Box, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHead)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pop3Box;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox smtpBox;
        private System.Windows.Forms.TextBox passBox;
        private System.Windows.Forms.Label userlabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SendMailBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ReceMailBtn;
    }
}
