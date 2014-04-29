using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SHF_UI;
using SHF_BT;
using SHF_DA;

//套结字引用的命名空间语句
using System.Net.Sockets;
//输入输出的命名空间语句
using System.IO;
using System.Net;
using System.Threading;

namespace EGLPABC082_Net
{
    public partial class EGLPABC082_ReceiveEmail : uiSHF_CourseBase
    {
        //声明线程对象
        private Thread thread1;

        //初始化RMail类实例myReMail
        private RMail myReMail;
        //声明NetworkStream的一个对象来与POP3服务器通信
        private NetworkStream netStream;
        //声明如下委托来改变窗体类上的控件属性
        public SetMyListBox dgMyListBox;
        public SetMyListBox dgMyMailBox;
        public SetMyListBox dgMyMessageBox;
        public GetMyMessage dgMyMessage;

        #region 构造函数
        public EGLPABC082_ReceiveEmail(string ps, string na, string pass)
        {
            myReMail = new RMail(ps, na, pass);
            InitializeComponent();
        }
        public EGLPABC082_ReceiveEmail(Form callForm, string ps, string na, string pass)
            : base(callForm)
        {
            myReMail = new RMail(ps, na, pass);
            InitializeComponent();
        }
        public EGLPABC082_ReceiveEmail(Form callForm, btSHFUserLogin callLog, string ps, string na, string pass)
            : base(callForm, callLog)
        {
            myReMail = new RMail(ps, na, pass);
            InitializeComponent();
        }
        public EGLPABC082_ReceiveEmail(Form callForm, btSHFUserLogin callLog, btSHFStructure callItem, string ps, string na, string pass)
            : base(callForm, callLog, callItem)
        {
            myReMail = new RMail(ps, na, pass);
            InitializeComponent();
        }
        public EGLPABC082_ReceiveEmail(Form callForm, btSHFUserLogin callLog, btSHFUnitPractice callUnit, string ps, string na, string pass)
            : base(callForm, callLog, callUnit)
        {
            myReMail = new RMail(ps, na, pass);
            InitializeComponent();
        }
        public EGLPABC082_ReceiveEmail(Form callForm, btSHFUserLogin callLog, btSHFUnitPractice callUnit, btSHFStructure callItem, string ps, string na, string pass)
            : base(callForm, callLog, callUnit, callItem)
        {
            myReMail = new RMail(ps, na, pass);
            InitializeComponent();
        }
        #endregion

        private void RecBtn_Click(object sender, EventArgs e)
        {
            //初始化线程对象 用线程执行ReMail函数
            thread1 = new Thread(new ThreadStart(ReMail));
            //线程开始执行
            thread1.Start();
        }

        //双击消息列表事件按钮 触发ReadText方法
        private void messagelistBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ReadText();
        }

        public void ReadText()
        {
            //初始化字符串text为列表框中选择的项
            string text = messagelistBox.SelectedItem.ToString();
            //将text中字符串以空格分割放入字符串数组texts中
            string[] texts = text.Split(' ');
            //将netStream与邮件名传入ShowText类的构造函数中
            ShowText st = new ShowText(netStream, texts[1]);
            //显示对话框
            st.ShowDialog();
            //将欲读的邮件从列表框中移出
            messagelistBox.Items.Remove(messagelistBox.SelectedItem);
            //加入“已读”标记
            messagelistBox.Items.Add("已读" + text.Remove(0, 2));
        }

        public void SetButtonfalse()
        {
            //设置“接受邮件”按钮不受用户触发
            RecBtn.Enabled = false;
        }

        public void SetButtontrue()
        {
            //设置“接受邮件”按钮接受用户触发
            RecBtn.Enabled = true;
        }

        public void SetListBox(string mylistvalue)
        {
            //在状态列表窗口中加入字符串
            statlistBox.Items.Add(mylistvalue);
        }

        public void SetMailBox(string mymailvalue)
        {
            //改变标签值
            maillabel.Text = mymailvalue;
        }
        public void SetMessageBox(string mymessagevalue)
        {
            //在邮件列表窗口中加入字符串
            messagelistBox.Items.Add(mymessagevalue);
        }
        public void SetNetStream(NetworkStream ns)
        {
            //设置netStream值
            netStream = ns;
        }

        public string GetSelect()
        {
            //返回已选择的项目
            return (string)messagelistBox.SelectedItem;
        }



        public void ReMail()
        {
            //初始化改变接收按钮可操作性的委托
            MethodInvoker dgMyBtnTrue = new MethodInvoker(SetButtontrue);
            MethodInvoker dgMyBtnFalse = new MethodInvoker(SetButtonfalse);
            //初始化委托来更新窗体消息栏
            dgMyListBox = new SetMyListBox(SetListBox);
            dgMyMailBox = new SetMyListBox(SetMailBox);
            dgMyMessageBox = new SetMyListBox(SetMessageBox);

            //更新状态栏 “正在连接服务器。。。”
            statlistBox.Invoke(dgMyListBox, new object[] { "正在连接服务器。。。" });
            //设置接收邮件按钮不可用            
            BeginInvoke(dgMyBtnFalse);
            //调用myReMail的Connect方法 如果失败就返回
            if (!(myReMail.Connect()))
                return;
            //设置netStream的值 以便以后用来获得邮件正文
            netStream = myReMail.GetNetStream();

            //若连接成功 更新状态栏 “已连接”
            statlistBox.Invoke(dgMyListBox, new object[] { "已连接" });
            //更新状态栏 “正在验证用户名和密码。。。”
            statlistBox.Invoke(dgMyListBox, new object[] { "正在验证用户名和密码。。。" });

            //若登录失败则返回
            if (!(myReMail.Login()))
                return;
            //若输入密码错误则返回 并设置接收邮件按钮不可用提示用户改变密码
            if (!myReMail.EnterPass())
            {
                BeginInvoke(dgMyBtnFalse);
                return;
            }

            //若密码正确 更新状态栏 “已登录”
            statlistBox.Invoke(dgMyListBox, new object[] { "已登录" });
            //更新状态栏 “正在获得邮件数。。。”
            statlistBox.Invoke(dgMyListBox, new object[] { "正在获得邮件数。。。" });

            //调用GetMailCount()方法来获得用户邮件数
            int count = myReMail.GetMailCount();
            if (count > 0)
                //如果邮件数大于零，则提示用户邮件数
                maillabel.Invoke(dgMyMailBox, new object[] { "你有" + count + "封邮件" });
            else
                //否则显示无邮件
                maillabel.Invoke(dgMyMailBox, new object[] { "你没有邮件" });

            //初始化字符串数组来获得邮件头
            string[] mailtop;
            //循环获得所有邮件的头部信息
            for (int i = 1; i <= count; i++)
            {
                //获得第i封邮件的头部信息
                mailtop = myReMail.GetMailTop(i);
                //更新窗体中电子邮件信息窗口 并将邮件标为已读
                messagelistBox.Invoke(dgMyMessageBox, new object[] { "未读" + " " + i + " " + " " + mailtop[0] + " " + mailtop[1] });
            }
            //接收邮件完毕 设置接收邮件按钮可用
            BeginInvoke(dgMyBtnTrue);
        }

        class ShowText : Form
        {
            //将NetworkStream对象与邮件名传入ShowText类的构造函数
            public ShowText(NetworkStream netstr, string textnum)
            {
                //用传入的NetworkStream对象初始化字节流读取写入对象
                StreamReader strRe = new StreamReader(netstr);
                StreamWriter strWr = new StreamWriter(netstr);
                string re;

                //窗口标题为消息标号
                Text = "消息 " + textnum;
                //设置窗体大小
                Size = new Size(500, 400);

                //初始化文本框
                TextBox show = new TextBox();
                //文本框父容器为当前窗口
                show.Parent = this;
                //允许消息多行 水平与垂直滚动条均可见 文本框为只读
                show.Multiline = true;
                show.Dock = DockStyle.Fill;
                show.ScrollBars = ScrollBars.Both;
                show.ReadOnly = true;

                //将retr指令写入字节流 读取邮件正文
                strWr.WriteLine("retr " + textnum);
                strWr.Flush();
                re = strRe.ReadLine();

                //若POP3服务器返回消息以"-"开头，则说明连接有误
                if ('-' == re[0])
                {
                    MessageBox.Show("连接错误");
                    return;
                }

                //循环读取邮件正文
                while (true)
                {
                    re = strRe.ReadLine();
                    //读到句点则结束
                    if ("." == re)
                        break;
                    //把正文字符串加入到文本框中
                    show.Text += re + "\r\n";
                }
            }
        }

     
    }
    public class RMail
    {
        //声明并初始化接收邮件所需的对象
        //连接POP3服务器端的对象
        private TcpClient receClient = null;
        //读取写入字节流对象
        private StreamReader strRe = null;
        private StreamWriter strWr = null;
        //用于访问POP3服务器的基础数据流
        private NetworkStream netStream = null;

        //声明所使用的私有变量
        //邮件数变量
        private int totalmessage;
        //接收POP3服务器的字符串
        private string response;
        //POP3服务器地址以及用户名及密码
        private string pop3server;
        private string name;
        private string password;

        public RMail(string ps, string na, string pass)
        {
            //初始化接收邮件所需信息
            //POP3服务器地址 用户名和密码
            pop3server = ps;
            name = na;
            password = pass;
        }

        public bool Connect()
        {
            //使用POP3服务器地址和110端口实例化receClient对象
            receClient = new TcpClient(pop3server, 110);
            try
            {
                //若连接成功返回ture
                netStream = receClient.GetStream();
                return true;
            }
            catch (Exception e)
            {
                //若连接失败弹出失败消息对话框 返回false
                MessageBox.Show("与服务器连接失败");
                return false;
            }
        }
        public bool Login()
        {
            //实例化strRe对象 从POP3服务器读取字节流
            strRe = new StreamReader(netStream, System.Text.Encoding.Default);
            //实例化strWr对象 向POP3服务器写入字节流
            strWr = new StreamWriter(netStream, System.Text.Encoding.Default);
            try
            {
                //读取"+OK"字符串
                response = strRe.ReadLine();
                //输入用户名
                strWr.WriteLine("user " + name);
                //将用户写入数据流
                strWr.Flush();
                //读取"+OK"字符串
                response = strRe.ReadLine();
                //返回true值 说明成功登陆
                return true;
            }
            catch (Exception e)
            {
                //若登录失败，则弹出失败对话框
                MessageBox.Show("与服务器连接失败");
                //返回false值 说明登录失败
                return false;
            }
        }
        public bool EnterPass()
        {
            try
            {
                //输入密码
                strWr.WriteLine("pass " + password);
                //将密码写入字节流中
                strWr.Flush();
                //获得POP3服务器的响应消息
                response = strRe.ReadLine();
            }
            catch (Exception e)
            {
                //若连接错误 弹出连接失败对话框
                MessageBox.Show("与服务器连接失败");
                //返回false 值
                return false;
            }
            //若POP3服务器返回错误消息
            if ('-' == response[0])
            {
                //弹出密码错误对话框
                MessageBox.Show("密码错误");
                //返回false值
                return false;
            }
            //若以上程序执行无误 返回true值
            return true;
        }
        public int GetMailCount()
        {
            //输入stat指令 察看邮件数
            strWr.WriteLine("stat");
            //将指令写入字节流
            strWr.Flush();

            //获得POP3服务器的返回字符串
            response = strRe.ReadLine();
            //将该字符串中数据用空格分隔开，存入count字符串数组中
            string[] count = response.Split(' ');
            //将下标为1的数组成员 即邮件数返回
            totalmessage = Convert.ToInt32(count[1]);

            if (totalmessage > 0)
                return totalmessage;
            else
                //若无邮件返回0值
                return 0;
        }
        public string[] GetMailTop(int i)
        {
            //初始化发送者与邮件主题字符串
            string from = null;
            string subject = null;
            //用于该函数的返回值
            string[] getmailtop = new string[2];

            //输入top指令 查看制定邮件的邮件头
            strWr.WriteLine("top " + i + " 0");
            //将指令写入字节流
            strWr.Flush();
            //读取POP3服务器的响应消息
            string response = strRe.ReadLine();

            while (true)
            {
                //读取邮件头
                response = strRe.ReadLine();
                //在邮件头结束时以"."为标记
                if ("." == response)
                    break;
                if (response.Length > 4)
                {
                    //通过"From:"字符串来获得邮件的发件人
                    if ("From:" == response.Substring(0, 5))
                        from = response;
                    //通过"Subject:"字符串来获得邮件的主题
                    if ("Subject:" == response.Substring(0, 8))
                        subject = response;
                }
            }
            //将邮件的发件人与主题存入getmailtop字符串数组中并返回该字符串数组
            getmailtop[0] = from;
            getmailtop[1] = subject;
            return getmailtop;
        }

        public NetworkStream GetNetStream()
        {
            //返回NetworkStream对象netStream
            return netStream;
        }

    }

}