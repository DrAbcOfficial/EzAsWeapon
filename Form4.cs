using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZAsWeapon
{
    public partial class Form4 : Form
    {
        [DllImport("User32")]
        public extern static void SetCursorPos(int x, int y);

        public Form4()
        {
            InitializeComponent();
        }

        private int cti = 0;

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.Links[this.linkLabel1.Links.IndexOf(e.Link)].Visited = true;
            string targetUrl = e.Link.LinkData as string;
            if (string.IsNullOrEmpty(targetUrl))
                MessageBox.Show("没有链接地址！");
            else
                System.Diagnostics.Process.Start("iexplore.exe", targetUrl);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.linkLabel1.Links.Add(0, 4, @"https://github.com/DrAbcrealone");
            this.linkLabel2.Links.Add(0, 4, @"https://www.cykaskin.com");
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel2.Links[this.linkLabel2.Links.IndexOf(e.Link)].Visited = true;
            string targetUrl = e.Link.LinkData as string;
            if (string.IsNullOrEmpty(targetUrl))
                MessageBox.Show("没有链接地址！");
            else
                System.Diagnostics.Process.Start("iexplore.exe", targetUrl);
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int x = r.Next(-500, 500);
            int y = r.Next(-400, 400);
            SetCursorPos(x, y);
            label1.ForeColor = Color.FromArgb(r.Next(0,255), r.Next(0, 255), r.Next(0, 255), 0);
            if (cti == 5)
                label4.Visible = true;
            else
                cti++;

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }
    }
}
