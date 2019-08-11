using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace EZAsWeapon
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Utility.Dialog("载入中....");
            Application.Run(new Form1());
        }
    }

    public static class Utility
    {
        public static BindingList<string> OutDialog = new BindingList<string>();
        public static BindingList<string> ComboDialog = new BindingList<string>();

        public static void ClearDIalog()
        {
            while (Utility.OutDialog.Count != 0)
            {
                Utility.OutDialog.RemoveAt(0);
            }
            while (Utility.ComboDialog.Count != 0)
            {
                Utility.ComboDialog.RemoveAt(0);
            }
        }
        public static void SaveBuffer(string index, string content)
        {
            if (CDataBaseBuffer.Action().d_DataBase.ContainsKey(index))
                CDataBaseBuffer.Action().d_DataBase[index] = content;
        }
        public static void Dialog(string sz)
        {
            Utility.OutDialog.Add(DateTime.Now.ToString() + " | " + sz + ".");
        }
        public static string Bool2Str(bool bo)
        {
            if (bo)
                return "true";
            else
                return "false";
        }

        public static bool Str2Bool(string sz)
        {
            string cache = sz.Trim().ToLower();
            if (cache == "true" || cache == "1")
                return true;
            else if (cache == "false" || cache == "0")
                return false;
            else
            {
                MessageBox.Show("参数：" + sz + "填写错误！\n是否为 “true/false”或“1/0”?", "读取错误！！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static string Str2Degree(string sz)
        {
            return sz == "0" ? "g_vecZero" : "VECTOR_CONE_" + sz + "DEGREES";
        }

        public static int Deg2Int(string Deg)
        {
            return Deg == "g_vecZero" ? 0 : Convert.ToInt16(Deg.Replace("VECTOR_CONE_", "").Replace("DEGREES", ""));
        }

        public static string Str2Vec(string x, string y, string z)
        {
            return "Vector(" + x + "," + y + "," + z + ")";
        }

        public static string Vec2Str(uint index, string Vec)
        {
            if (string.IsNullOrEmpty(Vec))
                return null;
            else if (index <= 2 || index >= 0)
                return Vec.Replace("Vector(", "").Replace(")", "").Split(',')[index];
            else
                return null;
        }

        public static bool IsFloat(TextBox Box)
        {
            if (string.IsNullOrEmpty(Box.Text))
                return true;
            try
            {
                float.Parse(Box.Text);
            }
            catch (Exception e)
            {
                Box.Text = null;
                MessageBox.Show("该项只可填写数字！", "填写错误！！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                throw e;
            }
            return true;
        }

        public static bool IsInt(TextBox Box)
        {
            if (string.IsNullOrEmpty(Box.Text))
                return true;
            try
            {
                int.Parse(Box.Text);
            }
            catch (Exception e)
            {
                Box.Text = null;
                MessageBox.Show("该项只可填写整数！", "填写错误！！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                throw e;
            }
            return true;
        }

        public static bool IsPos(TextBox Box)
        {
            if (Box.Text.IndexOf('-') == 0)
            {
                Box.Text = null;
                MessageBox.Show("该项只可填写正数！", "填写错误！！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public static bool IsInt8(TextBox Box)
        {
            if (string.IsNullOrEmpty(Box.Text))
                return true;
            try
            {
                byte.Parse(Box.Text);
            }
            catch (Exception e)
            {
                Box.Text = null;
                MessageBox.Show("该项只可填写0-255整数！", "填写错误！！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                throw e;
            }
            return true;
        }

        public static string SvFilePathBuffer()
        {
            string localFilePath = "";
            SaveFileDialog sfd = new SaveFileDialog();
            Utility.Dialog("尝试确定路径...");
            sfd.Filter = "Sven-Coop 脚本（*.as）|*.as";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                localFilePath = sfd.FileName.ToString();
                Utility.ComboDialog.Add(localFilePath);
                Utility.Dialog("成功！");
            }
            else
                Utility.Dialog("被中断！");
            return localFilePath;
        }

        public static void SaveFileBuffer(string path, string content)
        {
            try
            {
                if (path != string.Empty)
                {
                    using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
                    {
                        using (TextWriter text = new StreamWriter(file, Encoding.Default))
                        {
                            text.Write(content);
                        }
                    }
                    Utility.Dialog("输出完毕！");
                }
                else
                    Utility.Dialog("空白路径，中断操作！");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
