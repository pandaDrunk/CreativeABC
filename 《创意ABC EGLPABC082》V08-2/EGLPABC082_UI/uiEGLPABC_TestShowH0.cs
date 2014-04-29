using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SHF_BT;
using SHF_UI;
using SHF_DA;
using EGLPABC082_BT;

namespace EGLPABC082_UI
{
    public partial class uiEGLPABC_TestShowH0 : SHF_UI.uiSHF_CourseBase
    {
        public uiEGLPABC_TestShowH0()
        {
            InitializeComponent();
        }
         public uiEGLPABC_TestShowH0(Form callme, btSHFUserLogin shfUserlogin)
            : base(callme, shfUserlogin)
        {
            InitializeComponent();
            
        }


        int N = 0;
        #region 连线过程
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 0)
            {
                N++;
            }
            else 
            {
                N--;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 1)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 2)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 3)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 4)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 5)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 6)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 7)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 8)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 9)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 10)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 11)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 12)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 13)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 14)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 15)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 16)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 17)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (N ==18)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 19)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 21)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 20)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 22)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 23)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 24)
            {
                N++;
            }
            else
            {
                N--;
            }
        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            if (N == 25)
            {
                N++;
            }
            else
            {
                N--;
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            groupBox2.Visible = true;
            checkBox1.Visible = true ;
            checkBox2.Visible = true;
            checkBox3.Visible = true;
            checkBox4.Visible = true;
            checkBox5.Visible = true;
            checkBox6.Visible = true;
            checkBox7.Visible = true;
            checkBox8.Visible = true;
            checkBox9.Visible = true;
            checkBox10.Visible = true;
            checkBox11.Visible = true;
            checkBox12.Visible = true;
            checkBox13.Visible = true;
            checkBox14.Visible = true;
            checkBox15.Visible = true;
            checkBox16.Visible = true;
            checkBox17.Visible = true;
            checkBox18.Visible = true;
            checkBox19.Visible = true;
            checkBox20.Visible = true;
            checkBox21.Visible = true;
            checkBox22.Visible = true;
            checkBox23.Visible = true;
            checkBox24.Visible = true;
            checkBox25.Visible = true;
            checkBox26.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (N == 26)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                MessageBox.Show("连线成功", "成功啦", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("连线失败", "失败了……", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void uiEGLPABC_TestShowH0_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            groupBox2.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false; 
            checkBox3.Visible = false; 
            checkBox4.Visible = false; 
            checkBox5.Visible = false; 
            checkBox6.Visible = false; 
            checkBox7.Visible = false;
            checkBox8.Visible = false;
            checkBox9.Visible = false;
            checkBox10.Visible = false;
            checkBox11.Visible = false;
            checkBox12.Visible = false;
            checkBox13.Visible = false;
            checkBox14.Visible = false;
            checkBox15.Visible = false;
            checkBox16.Visible = false;
            checkBox17.Visible = false;
            checkBox18.Visible = false;
            checkBox19.Visible = false;
            checkBox20.Visible = false;
            checkBox21.Visible = false;
            checkBox22.Visible = false;
            checkBox23.Visible = false;
            checkBox24.Visible = false;
            checkBox25.Visible = false;
            checkBox26.Visible = false;
        }


    }
}
