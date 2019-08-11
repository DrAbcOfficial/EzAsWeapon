using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
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
            int x = r.Next(0, 2000);
            int y = r.Next(0, 1000);
            SetCursorPos(x, y);
            label1.ForeColor = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255), 0);


            if (cti > 10)
            {
                Thread t = new Thread(Update);
                t.IsBackground = true;
                Form.CheckForIllegalCrossThreadCalls = false;
                t.Start();
                label4.Text = "?";
                label4.Visible = false;
                cti = 0;
            }
            else if (cti > 5)
            {
                label4.Text = "!";
                this.Location = new Point(r.Next(0, 800), r.Next(0, 1000));
            }
            else if (cti == 5)
                label4.Visible = true;

            cti++;
        }
        new void Update()
        {
            for (int i = 0; i < 125; i++)
            {
                SetCursorPos(i * 10, Convert.ToInt32(Math.Sin(Math.PI * i / 10) * 250) + 400);
                this.Location = new Point(Convert.ToInt32(Math.Cos(Math.PI * i / 10) * 500 + 5 * i), Convert.ToInt32(Math.Sin(Math.PI * i / 10) * 250 + 350));
                Color c = Color.FromArgb(255 - 2 * i, i, 2 * i);
                label1.ForeColor = c;
                Thread.Sleep(100);
            }
        }
    }
}
