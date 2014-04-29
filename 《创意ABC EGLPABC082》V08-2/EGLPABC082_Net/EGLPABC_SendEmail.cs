using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
//指定电子邮件附件类型的命名空间语句
using System.Net.Mime;
using System.Threading;
using SHF_UI;
using SHF_BT;
using SHF_DA;

namespace EGLPABC082_Net
{
    public partial class EGLPABC_SendEmail : uiSHF_CourseBase
    {
        //声明线程对象
        private Thread thread1;

        //声明发送邮件类SMail
        private SMail mySendEmail;
        //声明一个委托dgMyListBox用来更新发送邮件的状态框值
        public SetMyListBox dgMyListBox;

        #region 构造函数
        public EGLPABC_SendEmail(string ss, string na, string pass)
        {
            //将smtpserver,name,password信息传入SMail类的构造函数中
            mySendEmail = new SMail(ss, na, pass);
            InitializeComponent();
        }
        public EGLPABC_SendEmail(Form callForm, string ss, string na, string pass)
            : base(callForm)
        {
            //将smtpserver,name,password信息传入SMail类的构造函数中
            mySendEmail = new SMail(ss, na, pass);
            InitializeComponent();
        }
        public EGLPABC_SendEmail(Form callForm, btSHFUserLogin callLog, string ss, string na, string pass)
            : base(callForm, callLog)
        {
            //将smtpserver,name,password信息传入SMail类的构造函数中
            mySendEmail = new SMail(ss, na, pass);
            InitializeComponent();
        }
        public EGLPABC_SendEmail(Form callForm, btSHFUserLogin callLog, btSHFStructure callItem, string ss, string na, string pass)
            : base(callForm, callLog, callItem)
        {
            //将smtpserver,name,password信息传入SMail类的构造函数中
            mySendEmail = new SMail(ss, na, pass);
            InitializeComponent();
        }
        public EGLPABC_SendEmail(Form callForm, btSHFUserLogin callLog, btSHFUnitPractice callUnit, string ss, string na, string pass)
            : base(callForm, callLog, callUnit)
        {
            //将smtpserver,name,password信息传入SMail类的构造函数中
            mySendEmail = new SMail(ss, na, pass);
            InitializeComponent();
        }
        public EGLPABC_SendEmail(Form callForm, btSHFUserLogin callLog, btSHFUnitPractice callUnit, btSHFStructure callItem, string ss, string na, string pass)
            : base(callForm, callLog, callUnit, callItem)
        {
            //将smtpserver,name,password信息传入SMail类的构造函数中
            mySendEmail = new SMail(ss, na, pass);
            InitializeComponent();
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void addAttach_Click(object sender, EventArgs e)
        {

        }



        public void Send()
        {
            //初始化两个委托用来改变窗体发送按钮的可操作属性
            MethodInvoker dgMyBtnTrue = new MethodInvoker(SetButtontrue);
            MethodInvoker dgMyBtnFalse = new MethodInvoker(SetButtonfalse);
            //初始化委托来更新状态信息窗口的消息
            dgMyListBox = new SetMyListBox(SetListBox);

            //发送时设置发送按钮不可用
            BeginInvoke(dgMyBtnFalse);
            //更新状态“正在连接服务器”
            statelistBox.Invoke(dgMyListBox, new object[] { "正在连接服务器。。。" });
            //使用mySendEmail类的Login方法进行登录
            mySendEmail.Login();
            //更新状态“正在发送消息”
            statelistBox.Invoke(dgMyListBox, new object[] { "正在发送。。。" });
            //使用mySendEmail类的EGLPABC_SendEmails方法发送邮件
            mySendEmail.EGLPABC_SendEmails();
            //邮件发送完毕后 设置发送按钮可用
            BeginInvoke(dgMyBtnTrue);
        }

        public void SetButtonfalse()
        {
            //设置按钮不接受用户触发
            button1.Enabled = false;
        }
        public void SetButtontrue()
        {
            //设置按钮接受用户触发
            button1.Enabled = true;
        }
        public void SetListBox(string mylistvalue)
        {
            //在listBox中加入字符串
            statelistBox.Items.Add(mylistvalue);
        }

        private void EGLPABC_SendEmail_Load(object sender, EventArgs e)
        {
            try
            {
                btSHFUsers users = new btSHFUsers();
                myUser = users.GetUserByRegistName(callMeLog.UserName);
                fromBox.Text = myUser.RegistEmail;
                toBox.Text = "282002237.qq.com";
                titleBox.Text = myUser.UserCode + myUser.UserName + "《创意ABC EGLPABC082》工作文档V08-2.08";
                btSHFUnitPractices pracs = new btSHFUnitPractices();
                textBox.Text = pracs.GetOne(1).ToString();
            }
            catch
            {
            }
        }

      

      

   
    }

    public class SMail
    {
        //smtp服务器地址
        private string smtpServer;
        //用户登录名
        private string name;
        //用户密码
        private string password;
        //附件路径
        private string filepath = "";
        //接收窗体对象传来的字符串数组
        private string[] msgUn;
        //声明SmtpClient和MailMessage对象
        SmtpClient client;
        MailMessage message;

        public SMail(string ss, string na, string pass)
        {
            //初始化发送邮件所需信息 
            //SMTP服务器地址 用户名和密码
            smtpServer = ss;
            name = na;
            password = pass;
        }

        public void SetmsgUn(string[] msg)
        {
            //初始化msgUn数组
            msgUn = msg;
        }

        public void Login()
        {
            //使用smtpServer字符串初始化client对象
            client = new SmtpClient(smtpServer);
            //使用发件人地址与发件人初始化发件人地址对象from 使用默认编码
            MailAddress from = new MailAddress(msgUn[0], msgUn[3], System.Text.Encoding.Default);
            //使用收件人地址初始化收件人对象to
            MailAddress to = new MailAddress(msgUn[1]);
            //使用from与to对象初始化电子邮件对象message
            message = new MailMessage(from, to);
            //初始化附件路径
            filepath = msgUn[4];

            //若附件地址不为空 则添加附件
            if ("" != filepath)
            {
                //使用附件路径初始化附件对象，不解释电子邮件的附件数据
                Attachment mailAttach = new Attachment(filepath, MediaTypeNames.Application.Octet);
                //获取此附件的MIME内容
                ContentDisposition fileDis = mailAttach.ContentDisposition;
                //获取该附件的创建时间
                fileDis.CreationDate = System.IO.File.GetCreationTime(filepath);
                //获取该附件的最后写入时间
                fileDis.ModificationDate = System.IO.File.GetLastWriteTime(filepath);
                //获取该附件的最后访问时间
                fileDis.ReadDate = System.IO.File.GetLastAccessTime(filepath);
                //将该附件信息加入电子邮件对象message中
                message.Attachments.Add(mailAttach);
            }
            //设置电子邮件的正文
            message.Body = msgUn[5];
            //正文的编码为默认的编码方式
            message.BodyEncoding = System.Text.Encoding.Default;
            //设置电子邮件的标题
            message.Subject = msgUn[2];
            //标题的编码为默认的编码方式
            message.SubjectEncoding = System.Text.Encoding.Default;

            //用户的默认登录信息不随邮件发送
            client.UseDefaultCredentials = false;
            //使用用户登录名和密码初始化验证信息
            client.Credentials = new System.Net.NetworkCredential(name, password);
            //设置电子邮件的发送方式为通过网络发送到SMTP服务器
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        public void EGLPABC_SendEmails()
        {
            try
            {
                //是用SMTP服务器对象client发送电子邮件对象message
                client.Send(message);
                //弹出发送成功对话框
                MessageBox.Show("发送成功！");
                //释放message对象使用的系统资源
                message.Dispose();
            }
            catch (Exception e)
            {
                //若发送出错 则弹出发送失败对话框
                MessageBox.Show("发送失败！");
                //释放message对象使用的系统资源
                message.Dispose();
            }
        }


    }

}