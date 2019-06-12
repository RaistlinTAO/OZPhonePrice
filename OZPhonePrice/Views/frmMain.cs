#region COPYRIGHT & CODE DESCRIPTION

// © 2006-2012 by D.E.M.O.N Studio. All rights reserved
// 
// D.E.M.O.N Studio: Decisively, Earnestly, Masterfully, Observantly, Naturally
// 
// SOLUTION: OZPhonePrice
// PROJECT:    OZPhonePrice
// FILENAME:  frmMain.cs
// 
// CREATED IN 9:47 PM (11/02/2013)
// 
// LAST EDITED: 10:42 PM (12/02/2013)

#endregion

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OZPhonePrice.Views
{
    public partial class frmMain : Form
    {
        //函数的作用是为当前的应用程序释放鼠标的捕获

        //当用户选择窗口菜单的一条命令或当用户选择最大化或最小化时那个窗口会收到此消息  274
        public const int WM_SYSCOMMAND = 0x0112;
        //向窗口发送移动的消息  61456
        public const int SC_MOVE = 0Xf010;
        //表明鼠标在Windows 的标题栏中 2
        public const int HTCAPTION = 0x0002;

        public frmMain()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        //函数的作用是发送消息
        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                return;
            }
            prgrsCheck.Value = 0;
            cmdSearch.Enabled = false;
            txtName.Enabled = false;
            lsvResult.Items.Clear();

            var iList = new List<OZPhoneDetail.clsPhone>();

            DelegateCheckInfo dn = OZWebSearch.NetSearch.clsGumTree.CheckPrice;

            IAsyncResult iar = dn.BeginInvoke(txtName.Text, null, null);

            while (iar.IsCompleted == false)
            {
                Application.DoEvents();
            }
            prgrsCheck.Value = 15;
            iList.AddRange(dn.EndInvoke(iar));

            DelegateCheckInfo dn1 = OZWebSearch.NetSearch.clsEbay.CheckPrice;

            IAsyncResult iar1 = dn1.BeginInvoke(txtName.Text, null, null);

            while (iar1.IsCompleted == false)
            {
                Application.DoEvents();
            }
            prgrsCheck.Value = 30;
            iList.AddRange(dn1.EndInvoke(iar1));

            DelegateCheckInfo dn2 = OZWebSearch.NetSearch.clsKogan.CheckPrice;

            IAsyncResult iar2 = dn2.BeginInvoke(txtName.Text, null, null);

            while (iar2.IsCompleted == false)
            {
                Application.DoEvents();
            }
            prgrsCheck.Value = 45;
            iList.AddRange(dn2.EndInvoke(iar2));

            DelegateCheckInfo dn3 = OZWebSearch.NetSearch.clsMobiCity.CheckPrice;

            IAsyncResult iar3 = dn3.BeginInvoke(txtName.Text, null, null);

            while (iar3.IsCompleted == false)
            {
                Application.DoEvents();
            }
            prgrsCheck.Value = 60;
            iList.AddRange(dn3.EndInvoke(iar3));

            DelegateCheckInfo dn4 = OZWebSearch.NetSearch.clsMobileCiti.CheckPrice;

            IAsyncResult iar4 = dn4.BeginInvoke(txtName.Text, null, null);

            while (iar4.IsCompleted == false)
            {
                Application.DoEvents();
            }
            prgrsCheck.Value = 75;
            iList.AddRange(dn4.EndInvoke(iar4));

            //iList.AddRange(OZWebSearch.NetSearch.clsGumTree.CheckPrice(txtName.Text));
            //iList.AddRange(OZWebSearch.NetSearch.clsAllPhone.CheckPrice(txtName.Text));
            //iList.AddRange(OZWebSearch.NetSearch.clsEbay.CheckPrice(txtName.Text));
            //iList.AddRange(OZWebSearch.NetSearch.clsJBHF.CheckPrice(txtName.Text));
            //iList.AddRange(OZWebSearch.NetSearch.clsKogan.CheckPrice(txtName.Text));
            //iList.AddRange(OZWebSearch.NetSearch.clsMobiCity.CheckPrice(txtName.Text));
            //iList.AddRange(OZWebSearch.NetSearch.clsMobileCiti.CheckPrice(txtName.Text));

            iList.Sort(
                delegate(OZPhoneDetail.clsPhone s1, OZPhoneDetail.clsPhone s2)
                    { return double.Parse(s1.PhonePrice).CompareTo(double.Parse(s2.PhonePrice)); });
            iList.Reverse();
            prgrsCheck.Value = 80;
            int i = 1;
            foreach (var clsPhone in iList)
            {
                var iTemp = new ListViewItem();
                iTemp.Text = i.ToString();
                iTemp.SubItems.Add(clsPhone.PhoneName);
                iTemp.SubItems.Add(clsPhone.PhonePrice);
                iTemp.SubItems.Add(clsPhone.PhoneSource);
                lsvResult.Items.Add(iTemp);
                i++;
                Application.DoEvents();
            }
            prgrsCheck.Value = 100;
            txtName.Enabled = true;
            cmdSearch.Enabled = true;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private delegate List<OZPhoneDetail.clsPhone> DelegateCheckInfo(string iSearch);
    }
}