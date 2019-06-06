using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace EZAsWeapon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            tabPage3.Enabled = IsSecAmmo.Enabled = IsZoomMode.Enabled = IsSubProj.Enabled = IsSecFire.Checked;
            if (!IsSecFire.Checked)
                IsSecAmmo.Checked = IsZoomMode.Checked = IsSubProj.Checked = false;
            CheckChange(IsSecFire);
        }

        private void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (IsShotGun.Checked && IsProj.Checked)
            {
                MessageBox.Show("霰弹枪与左键投射物不兼容！", "错误操作！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                IsShotGun.Checked = false;
                return;
            }

            button8.Enabled = IsShotGun.Checked;
            CheckChange(IsShotGun);
            if (IsShotGun.Checked)
            {
                label7.Visible = label7.Enabled = m_RELOAD.Visible = m_RELOAD.Enabled = false;
                m_RELOAD.SelectedText = "";
                label23.Visible = label23.Enabled = label24.Visible = label25.Visible = label24.Enabled = label25.Enabled = true;
                m_AFTER_RELOAD.Visible = m_AFTER_RELOAD.Enabled = m_INSERT.Visible = m_START_RELOAD.Visible = m_INSERT.Enabled = m_START_RELOAD.Enabled = true;
            }
            else
            {
                label7.Visible = label7.Enabled = m_RELOAD.Visible = m_RELOAD.Enabled = true;
                m_AFTER_RELOAD.SelectedText = m_INSERT.SelectedText = m_START_RELOAD.SelectedText = "";
                label23.Visible = label23.Enabled = label24.Visible = label25.Visible = label24.Enabled = label25.Enabled = false;
                m_AFTER_RELOAD.Visible = m_AFTER_RELOAD.Enabled = m_INSERT.Visible = m_START_RELOAD.Visible = m_INSERT.Enabled = m_START_RELOAD.Enabled = false;
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            m_iDefaultGive2.Enabled = m_iMaxAmmoAmount2.Enabled = m_iClipDrop2.Enabled = FireAmount2.Enabled = IsSecAmmo.Checked;
            CheckChange(IsSecAmmo);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
                m_DataEnum.Items.Add(textBox1.Text);
            textBox1.Text = "";
            TBSj();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (m_DataEnum.SelectedIndex != -1)
                m_DataEnum.Items.RemoveAt(m_DataEnum.SelectedIndex);
            TBSj();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int index = m_DataEnum.SelectedIndex;
            if (index == -1)
                return;
            else if (index > 0)
            {
                string cache = m_DataEnum.Items[index].ToString();
                m_DataEnum.Items.RemoveAt(index);
                m_DataEnum.Items.Insert(index - 1, cache);
                m_DataEnum.SelectedIndex = index - 1;
            }

            TBSj();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            int index = m_DataEnum.SelectedIndex;
            if (index == -1)
                return;
            else if (index < m_DataEnum.Items.Count - 1)
            {
                string cache = m_DataEnum.Items[index].ToString();
                m_DataEnum.Items.RemoveAt(index);
                m_DataEnum.Items.Insert(index + 1, cache);
                m_DataEnum.SelectedIndex = index + 1;
            }
            TBSj();
        }

        private void TBSj()
        {
            ComboItemsBuffer(m_DataEnum, m_IDLE);
            ComboItemsBuffer(m_DataEnum, m_FIDGET);
            ComboItemsBuffer(m_DataEnum, m_DRAW);
            ComboItemsBuffer(m_DataEnum, m_SHOOT);
            ComboItemsBuffer(m_DataEnum, m_SHOOT2);
            ComboItemsBuffer(m_DataEnum, m_RELOAD);
            ComboItemsBuffer(m_DataEnum, m_START_RELOAD);
            ComboItemsBuffer(m_DataEnum, m_INSERT);
            ComboItemsBuffer(m_DataEnum, m_AFTER_RELOAD);

            //动作顺序
            string cache = "{\n";
            if (m_DataEnum.Items.Count != 0)
                cache = cache + "	" + m_DataEnum.Items[0].ToString().Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "") + " = 0,\n";
            for (int i = 1; i < m_DataEnum.Items.Count; i++)
            {
                cache = cache + "	" + m_DataEnum.Items[i].ToString().Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "") + (i == m_DataEnum.Items.Count - 1 ? "\n	}" : ",\n");
            }
            Utility.SaveBuffer("m_DataEnum", cache);
        }

        static void ComboItemsBuffer(ListBox Copy, ComboBox CopyTo)
        {
            CopyTo.Items.Clear();
            for (int i = 0; i < Copy.Items.Count; i++)
            {
                CopyTo.Items.Add(Copy.Items[i]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox5.DataSource = Utility.OutDialog;
            Utility.Dialog("待命");
            tabPage3.Enabled = false;
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (IsZoomMode.Checked && IsSubProj.Checked)
            {
                MessageBox.Show("开镜与右键投射物不兼容！", "错误操作！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                IsZoomMode.Checked = false;
            }
            else
                groupBox4.Enabled = IsZoomMode.Checked;
            CheckChange(IsZoomMode);
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (IsShotGun.Checked && IsProj.Checked)
            {
                MessageBox.Show("霰弹枪与左键投射物不兼容！", "错误操作！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                IsProj.Checked = false;
            }
            else
                tabPage5.Enabled = IsProj.Checked;
            CheckChange(IsProj);
        }

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (IsZoomMode.Checked && IsSubProj.Checked)
            {
                MessageBox.Show("开镜与右键投射物不兼容！", "错误操作！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                IsSubProj.Checked = false;
            }
            else
                tabPage5.Enabled = IsSubProj.Checked;
            CheckChange(IsSubProj);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            Utility.Dialog("尝试打开窗口...");
            form2.ShowDialog();
            Utility.Dialog("成功！");
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox53.Text))
            {
                ListBox ls;
                switch (tabControl3.SelectedIndex)
                {
                    case 0: ls = g_WeaponModel; break;
                    case 1: ls = g_WeaponSound; break;
                    case 2: ls = g_WeaponSprites; break;
                    default:ls = g_WeaponModel; break;
                }
                ls.Items.Add(textBox53.Text);
                ListBoxChange(ls);
            }
            textBox53.Text = "";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            ListBox ls;
            switch (tabControl3.SelectedIndex)
            {
                case 0: ls = g_WeaponModel; break;
                case 1: ls = g_WeaponSound; break;
                case 2: ls = g_WeaponSprites; break;
                default: ls = g_WeaponModel; break;
            }
            if (ls.SelectedIndex != -1)
            {
                ls.Items.RemoveAt(ls.SelectedIndex);
                ListBoxChange(ls);
            }
                
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            ListBox ls;
            switch (tabControl3.SelectedIndex)
            {
                case 0: ls = g_WeaponModel; break;
                case 1: ls = g_WeaponSound; break;
                case 2: ls = g_WeaponSprites; break;
                default: ls = g_WeaponModel; break;
            }
            int index = ls.SelectedIndex;
            if (index == -1)
                return;
            else if (index > 0)
            {
                string cache = ls.Items[index].ToString();
                ls.Items.RemoveAt(index);
                ls.Items.Insert(index - 1, cache);
                ls.SelectedIndex = index - 1;
                ListBoxChange(ls);
            }
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            ListBox ls;
            switch (tabControl3.SelectedIndex)
            {
                case 0: ls = g_WeaponModel; break;
                case 1: ls = g_WeaponSound; break;
                case 2: ls = g_WeaponSprites; break;
                default: ls = g_WeaponModel; break;
            }
            int index = ls.SelectedIndex;
            if (index == -1)
                return;
            else if (index < ls.Items.Count - 1)
            {
                string cache = ls.Items[index].ToString();
                ls.Items.RemoveAt(index);
                ls.Items.Insert(index + 1, cache);
                ls.SelectedIndex = index + 1;
                ListBoxChange(ls);
            }
        }

        private void 生成baseweaponasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.Dialog("尝试输出文件...");
            Form3 form3 = new Form3();
            form3.SubFilePath = comboBox10.Text;
            form3.Content = OpenDefaultData.baseweapon;
            form3.ShowDialog();
        }

        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.Dialog("退出中...");
            this.Hide();
            this.Dispose();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            comboBox10.Text = OpFileBuffer();
        }

        private TextBox FineName(in string szName)
        {
            if (this.GetType().GetField(szName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase) != null)
            {
                object obj = this.GetType().GetField(szName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                if (obj.GetType() == typeof(TextBox))
                    return (TextBox)obj;
                else return textBox2;
            }
            else return textBox2;
        }

        private ListBox LsFindName(string szName )
        {
            if (this.GetType().GetField(szName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase) != null)
            {
                object obj = this.GetType().GetField(szName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                return (ListBox)obj;
            }
            else return null;
        }

        private CheckBox CbFindName(string szName)
        {
            if (this.GetType().GetField(szName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase) != null)
            {
                object obj = this.GetType().GetField(szName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                return (CheckBox)obj;
            }
            else return null;
        }
        private ComboBox CbbFindName(string szName)
        {
            if (this.GetType().GetField(szName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase) != null)
            {
                object obj = this.GetType().GetField(szName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                return (ComboBox)obj;
            }
            else return null;
        }
        private void ComboBoxOpBuffer(ComboBox cbb,string sz)
        {
            cbb.SelectedIndex = Utility.Deg2Int(sz);
        }

        private void AnimeOpBuffer(ComboBox cbb,string sz)
        {
            string[] arySz = CDataBaseBuffer.Action().d_DataBase["m_DataEnum"].Replace("{", "").Replace("}", "").Replace(" ","").Replace("=0","").Replace("\n","").Split(',');
            for (int i = 0 ;i < arySz.Length; i++)
            {
                if (arySz[i].Trim() == sz)
                    cbb.SelectedIndex = i;
            }
        }

        private void CheckBoxOpBuffer(CheckBox cb, string sz)
        {
            cb.Checked = Utility.Str2Bool(sz);
        }

        private void ListboxOpBuffer(ListBox lb, string sz)
        {
            lb.Items.Clear();
            string[] aysz = sz.Replace("{", "").Replace("}", "").Split(',');
            for(int i = 0;i < aysz.Length; i++)
            {
                if(!string.IsNullOrEmpty(aysz[i]))
                    lb.Items.Add(aysz[i]);
            }
        }

        private string OpFileBuffer()
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
                    StringSpliter(s);
                    sr.Close();
                    
                    Utility.Dialog("成功！");
                }
                else
                {
                    Utility.Dialog("没有选择正确类型的文件...");
                    return null;
                }
            }
            else
                Utility.Dialog("被中断！");
            return ofd.FileName;
        }

        private void StringSpliter(string s)
        {
            string[] temp = s.Split('\n');
            for (int i = 0; i < temp.Length; i++)
            {
                string line = temp[i].Replace(" ", "").Replace(";", "").Replace("'", "").Replace("	", "");
                if (line.IndexOf("voidRegister") != -1)
                    FineName("g_WeaponRegisterName").Text = CDataBaseBuffer.Action().d_DataBase["g_WeaponRegisterName"] = line.Replace("voidRegister", "").Replace("()", "");
                else if (line.IndexOf("g_ItemRegistry.RegisterWeapon(") != -1)
                {
                    string[] ary = line.Replace("g_ItemRegistry.RegisterWeapon(", "").Replace(")", "").Split(',');
                    FineName("g_WeaponName").Text = CDataBaseBuffer.Action().d_DataBase["g_WeaponName"] = ary[0];
                    FineName("m_TXTDir").Text = CDataBaseBuffer.Action().d_DataBase["m_TXTDir"] = ary[1];
                    FineName("m_AmmoType").Text = CDataBaseBuffer.Action().d_DataBase["m_AmmoType"] = ary[2];
                    FineName("m_AmmoType2").Text = CDataBaseBuffer.Action().d_DataBase["m_AmmoType2"] = ary[3];
                    FineName("m_AmmoEntity").Text = CDataBaseBuffer.Action().d_DataBase["m_AmmoEntity"] = ary[4];
                    FineName("m_AmmoEntity2").Text = CDataBaseBuffer.Action().d_DataBase["m_AmmoEntity2"] = ary[5];
                }
                else if (line.IndexOf("SubProjOrgX=") != -1)
                    FineName("SubProjOrgX").Text = CDataBaseBuffer.Action().d_DataBase["SubProjOrgX"] = line.Replace("SubProjOrgX=", "");
                else if (line.IndexOf("SubProjOrgY=") != -1)
                    FineName("SubProjOrgY").Text = CDataBaseBuffer.Action().d_DataBase["SubProjOrgY"] = line.Replace("SubProjOrgY=", "");
                else if (line.IndexOf("SubProjOrgZ=") != -1)
                    FineName("SubProjOrgZ").Text = CDataBaseBuffer.Action().d_DataBase["SubProjOrgZ"] = line.Replace("SubProjOrgZ=", "");
                else if (line.IndexOf("SubProjOrgV=") != -1)
                    FineName("SubProjOrgV").Text = CDataBaseBuffer.Action().d_DataBase["SubProjOrgV"] = line.Replace("SubProjOrgV=", "");
                else if (line.IndexOf("IsSecFire=") != -1)
                    CheckBoxOpBuffer(CbFindName("IsSecFire"), line.Replace("IsSecFire=", ""));
                else if (line.IndexOf("IsSecAmmo=") != -1)
                    CheckBoxOpBuffer(CbFindName("IsSecAmmo"), line.Replace("IsSecAmmo=", ""));
                else if (line.IndexOf("IsZoomMode=") != -1)
                    CheckBoxOpBuffer(CbFindName("IsZoomMode"), line.Replace("IsZoomMode=", ""));
                else if (line.IndexOf("IsProj=") != -1)
                    CheckBoxOpBuffer(CbFindName("IsProj"), line.Replace("IsProj=", ""));
                else if (line.IndexOf("IsSubProj=") != -1)
                    CheckBoxOpBuffer(CbFindName("IsSubProj"), line.Replace("IsSubProj=", ""));
                else if (line.IndexOf("IsShotGun=") != -1)
                    CheckBoxOpBuffer(CbFindName("IsShotGun"), line.Replace("IsShotGun=", ""));
                else if (line.IndexOf("m_iAcc2=") != -1)
                    ComboBoxOpBuffer(CbbFindName("m_iAcc2"), line.Replace("m_iAcc2=", ""));
                else if (line.IndexOf("m_iAcc=") != -1)
                    ComboBoxOpBuffer(CbbFindName("m_iAcc"), line.Replace("m_iAcc=", ""));
                else if (line.IndexOf("enum") != -1)
                {
                    int j = i + 1; s = "";
                    while (temp[j].IndexOf("}") == -1)
                    {
                        s = s + temp[j].Replace("= 0", "").Replace(" ", "").Replace("	", "");
                        j++;
                    }
                    CDataBaseBuffer.Action().d_DataBase["m_DataEnum"] = s.Trim() + "}";
                    ListboxOpBuffer(LsFindName("m_DataEnum"), CDataBaseBuffer.Action().d_DataBase["m_DataEnum"]);
                    TBSj();
                }
                else if (line.IndexOf("m_IDLE") != -1)
                    AnimeOpBuffer(m_IDLE, line.Replace("m_IDLE=", "").Replace(",", "").Trim());

                else if (line.IndexOf("m_FIDGET") != -1)
                    AnimeOpBuffer(m_FIDGET, line.Replace("m_FIDGET=", "").Trim());
                else if (line.IndexOf("m_RELOAD") != -1)
                    AnimeOpBuffer(m_RELOAD, line.Replace("m_RELOAD=", "").Trim());
                else if (line.IndexOf("m_DRAW") != -1)
                    AnimeOpBuffer(m_DRAW, line.Replace("m_DRAW=", "").Trim());
                else if (line.IndexOf("m_SHOOT2") != -1)
                    AnimeOpBuffer(m_SHOOT2, line.Replace("m_SHOOT2=", "").Trim());
                else if (line.IndexOf("m_SHOOT") != -1)
                    AnimeOpBuffer(m_SHOOT, line.Replace("m_SHOOT=", "").Trim());
                else if (line.IndexOf("m_START_RELOAD") != -1)
                    AnimeOpBuffer(m_START_RELOAD, line.Replace("m_START_RELOAD=", "").Trim());
                else if (line.IndexOf("m_INSERT") != -1)
                    AnimeOpBuffer(m_INSERT, line.Replace("m_INSERT=", "").Trim());
                else if (line.IndexOf("m_AFTER_RELOAD") != -1)
                    AnimeOpBuffer(m_AFTER_RELOAD, line.Replace("m_AFTER_RELOAD=", "").Trim());
                else if (line.IndexOf("g_WeaponModel=") != -1)
                {
                    int j = i + 1; s = "";
                    while (!temp[j].Contains("}"))
                    {
                        s = s + temp[j].Replace(" ", "").Replace("'", "").Replace("	", "");
                        j++;
                    }
                    CDataBaseBuffer.Action().d_DataBase["g_WeaponModel"] = "{" + s.Replace("	", "") + "}";
                    ListboxOpBuffer(LsFindName("g_WeaponModel"), CDataBaseBuffer.Action().d_DataBase["g_WeaponModel"]);

                }
                else if (line.IndexOf("g_WeaponSound=") != -1)
                {
                    int j = i + 1; s = "";
                    while (!temp[j].Contains("}"))
                    {
                        s = s + temp[j].Replace("'", "").Replace(" ", "");
                        j++;
                    }
                    CDataBaseBuffer.Action().d_DataBase["g_WeaponSound"] = "{" + s.Replace("	", "") + "}";
                    ListboxOpBuffer(LsFindName("g_WeaponSound"), CDataBaseBuffer.Action().d_DataBase["g_WeaponSound"]);
                }
                else if (line.IndexOf("g_WeaponSprites=") != -1)
                {
                    int j = i + 1; s = "";
                    while (!temp[j].Contains("}"))
                    {
                        s = s + temp[j].Replace("'", "").Replace(" ", "");
                        j++;
                    }
                    CDataBaseBuffer.Action().d_DataBase["g_WeaponSprites"] = "{" + s.Replace("	", "") + "}";
                    ListboxOpBuffer(LsFindName("g_WeaponSprites"), CDataBaseBuffer.Action().d_DataBase["g_WeaponSprites"]);
                }
                else
                {
                    string[] arykey = CDataBaseBuffer.Action().d_DataBase.Keys.ToArray();
                    for (int u = 1; u < arykey.Length - 5; u++)
                    {
                        if (line.IndexOf(arykey[u] + "=") != -1)
                            CDataBaseBuffer.Action().d_DataBase[arykey[u]] = line.Replace(arykey[u] + "=", "");
                        FineName(arykey[u]).Text = CDataBaseBuffer.Action().d_DataBase[arykey[u]].Replace("models/", "");
                    }
                }
            }
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            comboBox10.Text = Utility.SvFilePathBuffer();
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utility.ClearDIalog();
        }
        private void ListBoxChange(ListBox lb)
        {
            string cache = "		{\n";
            for (int i = 0; i < lb.Items.Count; i++)
            {
                cache = cache + "		'" + lb.Items[i].ToString().Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "") + (i == lb.Items.Count - 1 || lb.Items.Count ==0 ? "'\n" : "',\n");
            }
            cache = cache + "		}";
            Utility.SaveBuffer(lb.Name, cache);
        }
        private void TextLeave(object sender, EventArgs e)
        {
            TextBox bu = (TextBox)sender;
            TextChange(bu);
        }

        private void MDlTextChange(object sender, EventArgs e)
        {
            TextBox bu = (TextBox)sender;
            TextChange(bu,true);
        }

        private void TextChange(TextBox tb,bool md = false)
        {
            if (!string.IsNullOrEmpty(tb.Text))
                Utility.SaveBuffer(tb.Name, md ? "models/" + tb.Text : tb.Text);
        }
        private void CheckChange(CheckBox cb)
        {
            Utility.SaveBuffer(cb.Name, Utility.Bool2Str(cb.Checked));
        }
        private void ComboChange(object sender, EventArgs e)
        {
            ComboBox com = (ComboBox)sender;
            ComBoxChange(com);
        }

        private void ComBoxChange(ComboBox cbb)
        {
            if (cbb == null || cbb.SelectedItem == null)
                return;
            else if (!string.IsNullOrEmpty(cbb.SelectedItem.ToString()))
                Utility.SaveBuffer(cbb.Name, cbb.SelectedItem.ToString());
        }

        private void DegreeChange(object sender, EventArgs e)
        {
            ComboBox com = (ComboBox)sender;
            if (com == null || com.SelectedItem == null)
                return;
            if (!string.IsNullOrEmpty(com.SelectedItem.ToString()))
                Utility.SaveBuffer(com.Name, Utility.Str2Degree(com.SelectedItem.ToString()));
        }

        private void G_WeaponName_TextChanged(object sender, EventArgs e)
        {
            TextBox bu = (TextBox)sender;
            if (!string.IsNullOrEmpty(bu.Text))
                Utility.SaveBuffer(bu.Name, "weapon_" + bu.Text);
        }

        private string[] ExportFileBuffer()
        {
            string[] arycache = CDataBaseBuffer.Action().d_DataBase.Keys.ToArray();
            for (int i = 0; i < CDataBaseBuffer.Action().d_DataBase.Count - 1;i++)
            {
                CDataBaseBuffer.Action().d_DataBase[arycache[i]].Replace("\n", "").Replace("\r","");
            }
            //文件头
            string[] cache =
                {
                    "/**===========================================================================\n" ,
                    "  							本脚本由EzAsWeapon程序自动生成\n" ,
                    "  							程序由Dr.Abc设计制作\n" ,
                    "  							联系方式Dr.Abc@cykaskin.com\n" ,
                    "================================================================================\n" ,
                    "  					            		动作顺序\n" ,
                    "=============================================================================**/\n" ,
                     "enum AnimeEn_" , CDataBaseBuffer.Action().d_DataBase["g_WeaponRegisterName"] , "\n" ,
                     CDataBaseBuffer.Action().d_DataBase["m_DataEnum"] , ";\n" ,
                     "/**===========================================================================\n" ,
                     "  								       数据\n" ,
                     "=============================================================================**/\n" ,
                     "class " , CDataBaseBuffer.Action().d_DataBase["g_WeaponName"] , " : CustomWeapons::CBaseWeapon\n" ,
                     "{\n" ,
                     "	" , CDataBaseBuffer.Action().d_DataBase["g_WeaponName"] , "()\n" ,
                     "	{\n" ,
                     "		m_IDLE 				= " + CDataBaseBuffer.Action().d_DataBase["m_IDLE"] + ";\n" ,
                     "		m_FIDGET 			= " , CDataBaseBuffer.Action().d_DataBase["m_FIDGET"] , ";\n" ,
                     "		m_RELOAD 			= " , CDataBaseBuffer.Action().d_DataBase["m_RELOAD"] , ";\n" ,
                     "		m_DRAW 				= " , CDataBaseBuffer.Action().d_DataBase["m_DRAW"] , ";\n" ,
                     "		m_SHOOT 			= " , CDataBaseBuffer.Action().d_DataBase["m_SHOOT"] , ";\n" ,
                     "		m_SHOOT2 			= " , CDataBaseBuffer.Action().d_DataBase["m_SHOOT2"] , ";\n" ,
                     "		m_START_RELOAD 		= " , CDataBaseBuffer.Action().d_DataBase["m_START_RELOAD"] , ";\n" ,
                     "		m_INSERT 			= " , CDataBaseBuffer.Action().d_DataBase["m_INSERT"] , ";\n" ,
                     "		m_AFTER_RELOAD 		= " , CDataBaseBuffer.Action().d_DataBase["m_AFTER_RELOAD"] , ";\n" ,
                     "\n" ,
                     "		m_VModel 			= '" , CDataBaseBuffer.Action().d_DataBase["m_VModel"] , "';\n" ,
                     "		m_PModel 			= '" , CDataBaseBuffer.Action().d_DataBase["m_PModel"] , "';\n" ,
                     "		m_WModel 			= '" , CDataBaseBuffer.Action().d_DataBase["m_WModel"] , "';\n" ,
                     "		m_SModel 			= '" , CDataBaseBuffer.Action().d_DataBase["m_SModel"] , "';\n" ,
                     "\n" ,
                     "		m_strDryFireSound 	= '" , CDataBaseBuffer.Action().d_DataBase["m_strDryFireSound"] , "';\n" ,
                     "		m_FireSounds 		= '" , CDataBaseBuffer.Action().d_DataBase["m_FireSounds"] , "';\n" ,
                     "\n" ,
                     "		m_strTextName 		= '" , CDataBaseBuffer.Action().d_DataBase["m_strTextName"] , "';\n" ,
                     "\n" ,
                     "		m_strAnimeName 		= '" , CDataBaseBuffer.Action().d_DataBase["m_strAnimeName"] , "';\n" ,
                     "\n" ,
                     "		m_iDefaultGive 		= " , CDataBaseBuffer.Action().d_DataBase["m_iDefaultGive"] , ";\n" ,
                     "		m_iDefaultGive2 	= " , CDataBaseBuffer.Action().d_DataBase["m_iDefaultGive2"] , ";\n" ,
                     "		m_iMaxAmmoAmount 	= " , CDataBaseBuffer.Action().d_DataBase["m_iMaxAmmoAmount"] , ";\n" ,
                     "		m_iMaxAmmoAmount2 	= " , CDataBaseBuffer.Action().d_DataBase["m_iMaxAmmoAmount2"] , ";\n" ,
                     "		m_iClipMax 			= " , CDataBaseBuffer.Action().d_DataBase["m_iClipMax"] , ";\n" ,
                     "		m_iClipDrop 		= " , CDataBaseBuffer.Action().d_DataBase["m_iClipDrop"] , ";\n" ,
                     "		m_iClipDrop2 		= " , CDataBaseBuffer.Action().d_DataBase["m_iClipDrop2"] , ";\n" ,
                     "\n" ,
                     "		IsSecFire 			= " , CDataBaseBuffer.Action().d_DataBase["IsSecFire"] , ";\n" ,
                     "\n" ,
                     "		IsSecAmmo 			= " , CDataBaseBuffer.Action().d_DataBase["IsSecAmmo"] , ";\n" ,
                     "\n" ,
                     "		IsZoomMode 			= " , CDataBaseBuffer.Action().d_DataBase["IsZoomMode"] , ";\n" ,
                     "		m_iZoomSpeed 		= " , CDataBaseBuffer.Action().d_DataBase["m_iZoomSpeed"] , ";\n" ,
                     "		m_iZoomFOV 			= " , CDataBaseBuffer.Action().d_DataBase["m_iZoomFOV"] , ";\n" ,
                     "		m_ZoomSound 		= '" , CDataBaseBuffer.Action().d_DataBase["m_ZoomSound"] , "';\n" ,
                     "\n" ,
                     "		IsProj 				= " , CDataBaseBuffer.Action().d_DataBase["IsProj"] , ";\n" ,
                     "		pProjname 			= '" , CDataBaseBuffer.Action().d_DataBase["pProjname"] , "';\n" ,
                     "		ProjOrgX 			= " , CDataBaseBuffer.Action().d_DataBase["ProjOrgX"] , ";\n" ,
                     "		ProjOrgY 			= " , CDataBaseBuffer.Action().d_DataBase["ProjOrgY"] , ";\n" ,
                     "		ProjOrgZ 			= " , CDataBaseBuffer.Action().d_DataBase["ProjOrgZ"] , ";\n" ,
                     "		ProjOrgV 			= " , CDataBaseBuffer.Action().d_DataBase["ProjOrgV"] , ";\n" ,
                     "\n" ,
                     "		IsSubProj 			= " , CDataBaseBuffer.Action().d_DataBase["IsSubProj"] , ";\n" ,
                     "		strSubProjName 		= '" , CDataBaseBuffer.Action().d_DataBase["strSubProjName"] , "';\n" ,
                     "		SubProjOrgX 		= " , CDataBaseBuffer.Action().d_DataBase["SubProjOrgX"] , ";\n" ,
                     "		SubProjOrgY 		= " , CDataBaseBuffer.Action().d_DataBase["SubProjOrgY"] , ";\n" ,
                     "		SubProjOrgZ 		= " , CDataBaseBuffer.Action().d_DataBase["SubProjOrgZ"] , ";\n" ,
                     "		SubProjOrgV 		= " , CDataBaseBuffer.Action().d_DataBase["SubProjOrgV"] , ";\n" ,
                     "\n" ,
                     "		m_iSlotAmount 		= " , CDataBaseBuffer.Action().d_DataBase["m_iSlotAmount"] , ";\n" ,
                     "		m_iPositionAmount 	= " , CDataBaseBuffer.Action().d_DataBase["m_iPositionAmount"] , ";\n" ,
                     "		m_iWeightAmount 	= " , CDataBaseBuffer.Action().d_DataBase["m_iWeightAmount"] , ";\n" ,
                     "		m_iDamegeAmount 	= " , CDataBaseBuffer.Action().d_DataBase["m_iDamegeAmount"] , ";\n" ,
                     "		FireAmount 			= " , CDataBaseBuffer.Action().d_DataBase["FireAmount"] , ";\n" ,
                     "		FireAmount2 		= " , CDataBaseBuffer.Action().d_DataBase["FireAmount2"] , ";\n" ,
                     "		m_DeployTime 		= " , CDataBaseBuffer.Action().d_DataBase["m_DeployTime"] , ";\n" ,
                     "		m_FireTime 		    = " , CDataBaseBuffer.Action().d_DataBase["m_FireTime"] , ";\n" ,
                     "		m_ReloadTime 		= " , CDataBaseBuffer.Action().d_DataBase["m_ReloadTime"] , ";\n" ,
                     "\n" ,
                     "		m_XPunchMax 		= " , CDataBaseBuffer.Action().d_DataBase["m_XPunchMax"] , ";\n" ,
                     "		m_XPunchMin 		= " , CDataBaseBuffer.Action().d_DataBase["m_XPunchMin"] , ";\n" ,
                     "		m_YPunchMax 		= " , CDataBaseBuffer.Action().d_DataBase["m_YPunchMax"] , ";\n" ,
                     "		m_YPunchMin 		= " , CDataBaseBuffer.Action().d_DataBase["m_YPunchMin"] , ";\n" ,
                     "\n" ,
                     "		m_iAcc 				= " , CDataBaseBuffer.Action().d_DataBase["m_iAcc"] , ";\n" ,
                     "		m_iAcc2 			= " , CDataBaseBuffer.Action().d_DataBase["m_iAcc2"] , ";\n" ,
                     "\n" ,
                     "		m_iDamegeAmount2 	= " , CDataBaseBuffer.Action().d_DataBase["m_iDamegeAmount2"] , ";\n" ,
                     "		m_FireTime2 		= " , CDataBaseBuffer.Action().d_DataBase["m_FireTime2"] , ";\n" ,
                     "		m_FireSubSounds 	= '" , CDataBaseBuffer.Action().d_DataBase["m_FireSubSounds"] , "';\n" ,
                     "\n" ,
                     "		m_ShellOrgX 		= " , CDataBaseBuffer.Action().d_DataBase["m_ShellOrgX"] , ";\n" ,
                     "		m_ShellOrgY 		= " , CDataBaseBuffer.Action().d_DataBase["m_ShellOrgY"] , ";\n" ,
                     "		m_ShellOrgZ 		= " , CDataBaseBuffer.Action().d_DataBase["m_ShellOrgZ"] , ";\n" ,
                     "\n" ,
                     "		m_ShellDirXMax 		= " , CDataBaseBuffer.Action().d_DataBase["m_ShellDirXMax"] , ";\n" ,
                     "		m_ShellDirXMin 		= " , CDataBaseBuffer.Action().d_DataBase["m_ShellDirXMin"] , ";\n" ,
                     "		m_ShellDirYMax 		= " , CDataBaseBuffer.Action().d_DataBase["m_ShellDirYMax"] , ";\n" ,
                     "		m_ShellDirYMin 		= " , CDataBaseBuffer.Action().d_DataBase["m_ShellDirYMin"] , ";\n" ,
                     "		m_ShellDirZMax 		= " , CDataBaseBuffer.Action().d_DataBase["m_ShellDirZMax"] , ";\n" ,
                     "		m_ShellDirZMin 		= " , CDataBaseBuffer.Action().d_DataBase["m_ShellDirZMin"] , ";\n" ,
                     "\n" ,
                     "		IsShotGun 			= " , CDataBaseBuffer.Action().d_DataBase["IsShotGun"] , ";\n" ,
                     "		m_PumpTime 			= " , CDataBaseBuffer.Action().d_DataBase["m_PumpTime"] , ";\n" ,
                     "		m_InsertTime 		= " , CDataBaseBuffer.Action().d_DataBase["m_InsertTime"] , ";\n" ,
                     "		m_FinishInsertTime 	= " , CDataBaseBuffer.Action().d_DataBase["m_FinishInsertTime"] , ";\n" ,
                     "		ShotGunPelletCount 	= " , CDataBaseBuffer.Action().d_DataBase["ShotGunPelletCount"] , ";\n" ,
                     "		vecShotgunDM 		= " , CDataBaseBuffer.Action().d_DataBase["vecShotgunDM"] , ";\n" ,
                     "\n" ,
                     "		PumpSounds 			= '" , CDataBaseBuffer.Action().d_DataBase["PumpSounds"] , "';\n" ,
                     "		ShotgunFinishSound 	= '" , CDataBaseBuffer.Action().d_DataBase["ShotgunFinishSound"] , "';\n" ,
                     "		ShotgunInsertSound 	= '" , CDataBaseBuffer.Action().d_DataBase["ShotgunInsertSound"] , "';\n" ,
                     "\n" ,
                     "		m_PumpTime2 		= " , CDataBaseBuffer.Action().d_DataBase["m_PumpTime2"] , ";\n" ,
                     "		ShotGunSubPelletCount = " , CDataBaseBuffer.Action().d_DataBase["ShotGunSubPelletCount"] , ";\n" ,
                     "		vecShotgunDM2 		= " , CDataBaseBuffer.Action().d_DataBase["vecShotgunDM2"] , ";\n" ,
                     "\n" ,
                     "		g_WeaponModel 		= \n" , CDataBaseBuffer.Action().d_DataBase["g_WeaponModel"] , ";\n" ,
                     "		g_WeaponSound 		= \n" , CDataBaseBuffer.Action().d_DataBase["g_WeaponSound"] , ";\n" ,
                     "		g_WeaponSprites 	= \n" , CDataBaseBuffer.Action().d_DataBase["g_WeaponSprites"] , ";\n" ,
                     "\n" ,
                     "	}\n" ,
                     "}\n" ,
                     "/**===========================================================================\n" ,
                     "  								    实体注册\n" ,
                     "=============================================================================**/\n" ,
                     "void Register" , CDataBaseBuffer.Action().d_DataBase["g_WeaponRegisterName"] , "()\n" ,
                     "{\n" ,
                     "	g_CustomEntityFuncs.RegisterCustomEntity( '" , CDataBaseBuffer.Action().d_DataBase["g_WeaponName"] , "','" , CDataBaseBuffer.Action().d_DataBase["g_WeaponName"] , "' );\n" ,
                     "g_ItemRegistry.RegisterWeapon( '" , CDataBaseBuffer.Action().d_DataBase["g_WeaponName"] , "', '" , CDataBaseBuffer.Action().d_DataBase["m_TXTDir"] , "', '" , CDataBaseBuffer.Action().d_DataBase["m_AmmoType"] , "', '" ,
                     CDataBaseBuffer.Action().d_DataBase["m_AmmoType2"] , "', '" , CDataBaseBuffer.Action().d_DataBase["m_AmmoEntity"] , "', '" , CDataBaseBuffer.Action().d_DataBase["m_AmmoEntity2"] , "');\n" ,
                     "}\n" ,
                     "//全文输出完毕."
            };
            return cache;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            string[] arykey = CDataBaseBuffer.Action().d_DataBase.Keys.ToArray();
            for (int i = 0; i < arykey.Length; i++)
            {
                if(this.GetType().GetField(arykey[i], System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase) != null)
                {
                    object obj = this.GetType().GetField(arykey[i], System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                    if (obj.GetType() == typeof(TextBox))
                    {
                        TextBox tb = (TextBox)obj;
                        if (tb.Name == "m_VModel" || tb.Name == "m_PModel" || tb.Name == "m_WModel" || tb.Name == "m_SModel")
                            TextChange(tb, true);
                        else
                            TextChange(tb);
                    }
                    else if (obj.GetType() == typeof(CheckBox))
                        CheckChange((CheckBox)obj);
                    else if (obj.GetType() == typeof(ListBox))
                    {
                        ListBox lb = (ListBox)obj;
                        if (lb.Name == "m_DataEnum")
                        {
                            string cache = "{\n";
                            if (m_DataEnum.Items.Count != 0)
                                cache = cache + "	" + m_DataEnum.Items[0].ToString().Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "") + " = 0,\n";
                            for (int k = 1; k < m_DataEnum.Items.Count; k++)
                            {
                                cache = cache + "	" + m_DataEnum.Items[k].ToString().Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "") + (k == m_DataEnum.Items.Count - 1 ? "\n	}" : ",\n");
                            }
                            Utility.SaveBuffer("m_DataEnum", cache);
                        }
                        else
                            ListBoxChange(lb);
                    }
                        
                    else if (obj.GetType() == typeof(ComboBox))
                        ComBoxChange((ComboBox)obj);
                }
            }
            for(int j=1;j<arykey.Length - 5;j++)
            {
                CDataBaseBuffer.Action().d_DataBase[arykey[j]] = CDataBaseBuffer.Action().d_DataBase[arykey[j]].Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
            }
            Utility.Dialog("尝试输出文件...");
            Form3 form3 = new Form3();
            form3.SubFilePath = comboBox10.Text;
            form3.Content = ExportFileBuffer();
            form3.ShowDialog();
        }

        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utility.Dialog("打开关于界面....");
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void Hlmp5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.Dialog("打开示例：hlmp5....");
            StringSpliter(OpenDefaultData.Exm9mm);
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Utility.Dialog("启动Register管理器...");
            Form5 from5 = new Form5();
            from5.Show();
        }

        private void HlshotgunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.Dialog("打开示例：hlshotgun....");
            StringSpliter(OpenDefaultData.ExmShotGun);
        }
    }
}
