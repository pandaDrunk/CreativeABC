using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using SHF_UI;
using SHF_BT;
using SHF_DA;

namespace EGLPABC082_Net
{
    //声明向列表窗体添加字符串的委托
    public delegate void SetMyListBox(string mylistvalue);
    //声明获得信件消息的委托
    public delegate string GetMyMessage();

    public partial class EGLPABC082_SetEmail : uiSHF_CourseBase
    {
        //初始化字符串共有变量SMTP服务器 POP3服务器 用户名和密码
        public string smtpserver = "";
        public string pop3server = "";
        public string name = "";
        public string password = "";

        #region 构造函数
        public EGLPABC082_SetEmail()
        {
            InitializeComponent();
        }
        public EGLPABC082_SetEmail(Form callForm)
            : base(callForm)
        {
            InitializeComponent();
        }
        public EGLPABC082_SetEmail(Form callForm, btSHFUserLogin callLog)
            : base(callForm, callLog)
        {
            InitializeComponent();
        }
        public EGLPABC082_SetEmail(Form callForm, btSHFUserLogin callLog, btSHFStructure callItem)
            : base(callForm, callLog, callItem)
        {
            InitializeComponent();
        }
        public EGLPABC082_SetEmail(Form callForm, btSHFUserLogin callLog, btSHFUnitPractice callUnit)
            : base(callForm, callLog, callUnit)
        {
            InitializeComponent();
        }
        public EGLPABC082_SetEmail(Form callForm, btSHFUserLogin callLog, btSHFUnitPractice callUnit, btSHFStructure callItem)
            : base(callForm, callLog, callUnit, callItem)
        {
            InitializeComponent();
        }
        #endregion


        //在文本框改变后使用改变后的数据更新公有变量
        private void pop3Box_TextChanged(object sender, EventArgs e)
        {
            pop3server = pop3Box.Text.ToString();
        }
        private void userBox_TextChanged(object sender, EventArgs e)
        {
            name = nameBox.Text.ToString();
        }
        private void smtpBox_TextChanged(object sender, EventArgs e)
        {
            smtpserver = smtpBox.Text.ToString();
        }
        private void passBox_TextChanged(object sender, EventArgs e)
        {
            password = passBox.Text.ToString();
        }
        private void SendMailBtn_Click(object sender, EventArgs e)
        {
            //若SMTP服务器信息为空 弹出错误对话框 并返回
            if ("" == smtpserver)
            {
                MessageBox.Show("服务器未设置");
                return;
            }

            //若用户名和密码信息为空 弹出错误对话框 并返回
            if (("" == name) || ("" == password))
            {
                MessageBox.Show("用户名和密码不能为空！");
                return;
            }

            //初始化EGLPABC_SendEmail实例 并将发送邮件所必需的信息作为参数传递进实例
            EGLPABC_SendEmail form = new EGLPABC_SendEmail(smtpserver, name, password);
            //显示发送窗体
            form.Show();
        }

        private void ReceMailBtn_Click(object sender, EventArgs e)
        {
            //若POP3服务器信息为空 弹出错误对话框 并返回
            if ("" == pop3server)
            {
                MessageBox.Show("服务器未设置");
                return;
            }
            //若用户名和密码信息为空 弹出错误对话框 并返回
            if (("" == name) || ("" == password))
            {
                MessageBox.Show("用户名和密码不能为空！");
                return;
            }
            //初始化EGLPABC082_ReceiveEmail实例 并将接收邮件所必需的信息作为参数传递进实例
            EGLPABC082_ReceiveEmail form = new EGLPABC082_ReceiveEmail(pop3server, name, password);
            //显示接收窗体
            form.Show();
        }

        private void EGLPABC082_SetEmail_Activated(object sender, EventArgs e)
        {
            //设置主窗口文本框中值为EGLPABC082_SetEmail类中的相应变量
            pop3server = pop3Box.Text;
            smtpserver = smtpBox.Text;
            name = nameBox.Text;
            password = passBox.Text;
        }

        private void EGLPABC082_SetEmail_Load(object sender, EventArgs e)
        {
            try
            {
                btSHFUsers users = new btSHFUsers();
                btSHFUser user = users.GetUserByRegistName(callMeLog.UserName);
                nameBox.Text = user.RegistEmail;
                passBox.Text = user.UserPassword;
                pop3Box.Text = "pop.gmail.com";
                smtpBox.Text = "smtp.gmail.com";
            }
            catch
            {
            }
        }

       
     
       
       

     

       
    }
}