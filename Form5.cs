using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EZAsWeapon
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        void LangEN()
        {
            this.label1.Text = "Save location";
            this.label2.Text = "Scripts location";
            this.groupBox1.Text = "Weapons list";
            this.button2.Text = "Del";
            this.button1.Text = "Add";
            this.columnHeader3.Text = "UID";
            this.columnHeader1.Text = "Registe name";
            this.columnHeader2.Text = "File name(without.as)";
            this.button4.Text = "Export";
            this.button5.Text = "Import";
            this.label3.Text = "scripts/custom_weapons/";
            this.label4.Text = "scripts/plugins/";
            this.button3.Text = "Example";
            this.Text = "Register Manager";
        }

        void LangCN()
        {
            this.label1.Text = "Register保存位置";
            this.label2.Text = "脚本储存位置";
            this.groupBox1.Text = "武器列表";
            this.button2.Text = "删除";
            this.button1.Text = "添加";
            this.columnHeader3.Text = "序号";
            this.columnHeader1.Text = "注册名";
            this.columnHeader2.Text = "文件名(无.as)";
            this.button4.Text = "输出文件";
            this.button5.Text = "读取文件";
            this.label3.Text = "scripts/custom_weapons/";
            this.label4.Text = "scripts/plugins/";
            this.button3.Text = "生成示例";
            this.Text = "Register管理器";

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            switch (OpenDefaultData.Lang)
            {
                case "CN":
                    LangCN();
                    toolTip1.SetToolTip(textBox3, "填写baseweapon.as和\n其他生成武器所在的文件夹");
                    toolTip2.SetToolTip(textBox4, "填写register.as和所在的文件夹"); break;
                case "EN":
                    LangEN(); toolTip1.SetToolTip(textBox3, "Fill in the folders where baseweapon.as\nand other generated weapons are located");
                    toolTip2.SetToolTip(textBox4, "Fill in register. as and the folder you are in"); break;
                default: LangCN(); break;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                listView1.Items.Add(new ListViewItem(new string[] { "", textBox2.Text, textBox1.Text }));
                textBox1.Text = textBox2.Text = "";
            }
            RowTheList();
        }

        private void RowTheList()
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].SubItems[0].Text = (i + 1).ToString();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            for (int i = listView1.SelectedItems.Count - 1; i >= 0; i--)
            {
                listView1.Items.Remove(listView1.SelectedItems[i]);
            }
            RowTheList();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string szFilePath = string.IsNullOrEmpty(textBox4.Text) ? "" : "../";
            Regex rege = new Regex("/", RegexOptions.Compiled);
            for (int i = 0; i < rege.Matches(textBox4.Text).Count; i++)
            {
                szFilePath = szFilePath + "../";
            }
            szExpres.Add("#include '../" + szFilePath + "custom_weapons/" + textBox3.Text + "/baseweapon'\n\n");
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                szExpres.Add("#include '../" + szFilePath + "custom_weapons/" + textBox3.Text + "/" + listView1.Items[i].SubItems[2].ToString().Replace("ListViewSubItem: {", "").Replace("}", "") + "'\n");
            }

            szExpres.Add("void PluginInit()\n");
            szExpres.Add("{\n");
            szExpres.Add("	g_Module.ScriptInfo.SetAuthor( 'Dr.Abc' );\n");
            szExpres.Add("	g_Module.ScriptInfo.SetContactInfo( 'DrAbc@cykaskin.com' );\n");
            szExpres.Add("}\n\n");
            szExpres.Add("void MapInit() //添加注册\n");
            szExpres.Add("{\n");

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                szExpres.Add("      Register" + listView1.Items[i].SubItems[1].ToString().Replace("ListViewSubItem: {", "").Replace("}", "") + "();\n");
            }
            szExpres.Add("}\n//全文输出完毕");

            Utility.Dialog("尝试输出Register文件...");
            Form3 form3 = new Form3();
            form3.SubFilePath = "";
            form3.Content = szExpres.ToArray();
            form3.ShowDialog();
        }

        private List<string> szExpres = new List<string>(){
                    "/**===========================================================================\n",
                    "  							本脚本由EzAsWeapon程序自动生成\n" ,
                    "  							程序由Dr.Abc设计制作\n" ,
                    "  							联系方式Dr.Abc@cykaskin.com\n",
                    "=============================================================================**/\n" };

        private string CleanerHelper(in string szDirty)
        {
            return szDirty.Replace(" ", "").Replace(";", "").Replace("'", "").Replace("\t", "").Replace(".", "").Replace("/", "");
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            Utility.Dialog("尝试打开文件...");
            ofd.Filter = "Sven-Coop 脚本（*.as）|*.as";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            ofd.ShowDialog();
            if (!string.IsNullOrEmpty(ofd.FileName))
            {
                if (ofd.FileName.Contains(".as"))
                {
                    Utility.ComboDialog.Add(ofd.FileName);
                    StreamReader sr = File.OpenText(ofd.FileName);
                    string s = sr.ReadToEnd();
                    string[] temp = s.Split('\n');
                    List<string> sz1 = new List<string>(), sz2 = new List<string>();
                    for (int i = 0; i < temp.Length; i++)
                    {
                        string line = CleanerHelper(temp[i]);
                        if (line.IndexOf("baseweapon") != -1)
                            textBox3.Text = line.Replace("#includecustom_weapons", "").Replace("baseweapon", "");
                        else if (line.IndexOf("#include") != -1)
                        {
                            int j = i;
                            while (temp[j].IndexOf("#include") != -1)
                            {
                                sz1.Add(CleanerHelper(temp[j]).Replace("#includecustom_weapons", ""));
                                j++;
                            }
                        }
                        else if (line.IndexOf("voidMapInit()") != -1)
                        {
                            int j = i + 2;
                            while (temp[j].IndexOf("Register") != -1)
                            {
                                sz2.Add(CleanerHelper(temp[j]).Replace("(", "").Replace(")", "").Replace("Register", ""));
                                j++;
                            }
                        }
                    }
                    listView1.Items.Clear();
                    for (int j = 0; j < Math.Min(sz1.Count, sz2.Count); j++)
                    {
                        listView1.Items.Add(new ListViewItem(new string[] { "", sz2[j], sz1[j] }));
                    }
                    RowTheList();
                    sr.Close();

                    Utility.Dialog("成功！");
                }
                else
                    Utility.Dialog("没有选择正确类型的文件...");
            }
            else
                Utility.Dialog("被中断！");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Items.Add(new ListViewItem(new string[] { "", "Exm9mm", "weapon_example_9mm" }));
            listView1.Items.Add(new ListViewItem(new string[] { "", "ExmShotgun", "weapon_example_shotgun" }));
            RowTheList();
            textBox3.Text = "EzWeapons";
            textBox4.Text = "EzWeapons";
        }
    }
}
