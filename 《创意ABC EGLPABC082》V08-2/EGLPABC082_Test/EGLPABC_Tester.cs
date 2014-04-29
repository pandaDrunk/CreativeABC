using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SHF_BT;
using SHF_UI;
using SHF_DA;
using EGLPABC082_BT; 
using EGLPABC082_UI;
using _创意ABC_EGLPABC082_;

namespace EGLPABC082_Test
{
    public partial class EGLPABC_Tester : uiSHF_TestBase
    {
        public EGLPABC_Tester()
        {
            InitializeComponent();
        }
        public EGLPABC_Tester(Form callForm):base(callForm)
        {
            InitializeComponent();
        }
        public EGLPABC_Tester(Form callForm, string callConnect):base(callForm, callConnect)
        {
            InitializeComponent();
        }
        private void EGLPABC_Tester_Load(object sender, EventArgs e)
        {

        }
    }
}
