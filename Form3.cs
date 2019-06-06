using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZAsWeapon
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public string SubFilePath;
        public string[] Content;
        private void Form3_Load(object sender, EventArgs e)
        {
            if (SubFilePath == string.Empty)
            {
                Utility.Dialog("尝试确定路径...");
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Sven-Coop 脚本（*.as）|*.as";
                save.FilterIndex = 1;
                save.RestoreDirectory = true;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    SubFilePath = save.FileName;
                    Utility.ComboDialog.Add(SubFilePath);
                }
                    
            }

            if(string.IsNullOrEmpty(SubFilePath))
            {
                Utility.Dialog("输出文件被中断了！");
                label1.Text = "已中断.";
                button1.Text = "确定";
                return;
            }
            else if (!SubFilePath.Contains(".as"))
            {
                Utility.Dialog("没有指定正确扩展名，中断操作！");
                this.Hide();
                this.Dispose();
                return;
            }
            else if (!File.Exists(SubFilePath))
            {
                Utility.Dialog("没有此文件，尝试新建...");
            }
            else if (File.Exists(SubFilePath))
            {
                Utility.Dialog("存在文件，询问是否继续....");
                DialogResult dr = MessageBox.Show("发现文件！是否覆盖？", "覆盖警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.OK)
                {
                    Utility.Dialog("覆盖被取消了...");
                    this.Hide();
                    this.Dispose();
                    return;
                }
            }
            else if(!Directory.Exists(SubFilePath))
            {
                Utility.Dialog("非法路径，中断操作！");
                this.Hide();
                this.Dispose();
                return;
            }

            string cache = "";
            progressBar1.Show();
            progressBar1.Maximum = Content.Length;
            for (uint i = 0; i < Content.Length; i++)
            {
                cache = cache + Content[i];
                progressBar1.Value++;
                switch (i % 5)
                {
                    case 0: label1.Text = "导出中."; break;
                    case 1: label1.Text = "导出中.."; break;
                    case 2: label1.Text = "导出中..."; break;
                    case 3: label1.Text = "导出中...."; break;
                    case 4: label1.Text = "导出中....."; break;
                    default: label1.Text = "导出中......"; break;
                }
            }
            button1.Text = "确定";
            label1.Text = "文件：\n" + SubFilePath.Substring(SubFilePath.LastIndexOf("\\") + 1) + "已导出完毕.";
            Utility.ComboDialog.Add(SubFilePath);
            Utility.SaveFileBuffer(SubFilePath, cache);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

    }
}
