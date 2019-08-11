using System;
using System.IO;
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

        void LangEN()
        {

        }

        void LangCN()
        {
            this.button1.Text = "Cancel";
            this.label1.Text = "label1";
            this.Text = "Progress";
        }

        private void Lang()
        {
            switch (OpenDefaultData.Lang)
            {
                case "CN": LangCN(); break;
                case "EN": LangEN(); break;
                default: LangCN(); break;
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            Lang();
            if (SubFilePath == string.Empty)
            {
                Utility.Dialog(OpenDefaultData.Lang == "CN" ? "尝试确定路径..." : "Locating path");
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = OpenDefaultData.Lang == "CN" ? "Sven-Coop 脚本（*.as）|*.as" : "Sven-Coop Scripts（*.as）|*.as";
                save.FilterIndex = 1;
                save.RestoreDirectory = true;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    SubFilePath = save.FileName;
                    Utility.ComboDialog.Add(SubFilePath);
                }

            }

            if (string.IsNullOrEmpty(SubFilePath))
            {
                Utility.Dialog(OpenDefaultData.Lang == "CN" ? "输出文件被中断了！" : "Breaked!");
                label1.Text = OpenDefaultData.Lang == "CN" ? "已中断." : "Breaked";
                button1.Text = OpenDefaultData.Lang == "CN" ? "确定" : "Yes";
                return;
            }
            else if (!SubFilePath.Contains(".as"))
            {
                Utility.Dialog(OpenDefaultData.Lang == "CN" ? "没有指定正确扩展名，中断操作！" : "Breaked");
                this.Hide();
                this.Dispose();
                return;
            }
            else if (!File.Exists(SubFilePath))
            {
                Utility.Dialog(OpenDefaultData.Lang == "CN" ? "没有此文件，尝试新建..." : "Creating file");
            }
            else if (File.Exists(SubFilePath))
            {
                Utility.Dialog(OpenDefaultData.Lang == "CN" ? "存在文件，询问是否继续...." : "File existed");
                DialogResult dr = OpenDefaultData.Lang == "CN" ?
                    MessageBox.Show("发现文件！是否覆盖？", "覆盖警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) :
                    MessageBox.Show("Find the file! Does it cover?", "Cover Warn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.OK)
                {
                    Utility.Dialog(OpenDefaultData.Lang == "CN" ? "覆盖被取消了..." : "Cover canceled");
                    this.Hide();
                    this.Dispose();
                    return;
                }
            }
            else if (!Directory.Exists(SubFilePath))
            {
                Utility.Dialog(OpenDefaultData.Lang == "CN" ? "非法路径，中断操作！" : "Illegal path!");
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
                string szExp = OpenDefaultData.Lang == "CN" ? "导出中" : "Exporting";
                switch (i % 5)
                {
                    case 0: label1.Text = szExp + "."; break;
                    case 1: label1.Text = szExp + ".."; break;
                    case 2: label1.Text = szExp + "..."; break;
                    case 3: label1.Text = szExp + "...."; break;
                    case 4: label1.Text = szExp + "....."; break;
                    default: label1.Text = szExp + "......"; break;
                }
            }
            button1.Text = OpenDefaultData.Lang == "CN" ? "确定" : "Yes";
            label1.Text = OpenDefaultData.Lang == "CN" ?
                "文件：\n" + SubFilePath.Substring(SubFilePath.LastIndexOf("\\") + 1) + "已导出完毕." :
                "File：\n" + SubFilePath.Substring(SubFilePath.LastIndexOf("\\") + 1) + "Exported.";
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
