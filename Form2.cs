using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZAsWeapon
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CDataBaseBuffer.Action().d_DataBase["m_PumpTime"] = m_PumpTime.Text;
            CDataBaseBuffer.Action().d_DataBase["m_InsertTime"] = m_InsertTime.Text;
            CDataBaseBuffer.Action().d_DataBase["m_FinishInsertTime"] = m_FinishInsertTime.Text;
            CDataBaseBuffer.Action().d_DataBase["ShotGunPelletCount"] = ShotGunPelletCount.Text;
            CDataBaseBuffer.Action().d_DataBase["PumpSounds"] = PumpSounds.Text;
            CDataBaseBuffer.Action().d_DataBase["ShotgunFinishSound"] = ShotgunFinishSound.Text;
            CDataBaseBuffer.Action().d_DataBase["ShotgunInsertSound"] = ShotgunInsertSound.Text;
            CDataBaseBuffer.Action().d_DataBase["m_PumpTime2"] = m_PumpTime2.Text;
            CDataBaseBuffer.Action().d_DataBase["ShotGunSubPelletCount"] = ShotGunSubPelletCount.Text;

            CDataBaseBuffer.Action().d_DataBase["vecShotgunDM"] = Utility.Str2Vec(vecShotgunDMX.Text, vecShotgunDMY.Text, vecShotgunDMZ.Text);
            CDataBaseBuffer.Action().d_DataBase["vecShotgunDM2"] = Utility.Str2Vec(vecShotgunDM2X.Text, vecShotgunDM2Y.Text, vecShotgunDM2Z.Text);
            Utility.Dialog("关闭并保存窗口");
            this.Hide();
            this.Dispose();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            m_PumpTime.Text = CDataBaseBuffer.Action().d_DataBase["m_PumpTime"];
            m_InsertTime.Text = CDataBaseBuffer.Action().d_DataBase["m_InsertTime"];
            m_FinishInsertTime.Text = CDataBaseBuffer.Action().d_DataBase["m_FinishInsertTime"];
            ShotGunPelletCount.Text = CDataBaseBuffer.Action().d_DataBase["ShotGunPelletCount"];
            vecShotgunDMX.Text = Utility.Vec2Str(0, CDataBaseBuffer.Action().d_DataBase["vecShotgunDM"]);
            PumpSounds.Text = CDataBaseBuffer.Action().d_DataBase["PumpSounds"];
            ShotgunFinishSound.Text = CDataBaseBuffer.Action().d_DataBase["ShotgunFinishSound"];
            ShotgunInsertSound.Text = CDataBaseBuffer.Action().d_DataBase["ShotgunInsertSound"];
            m_PumpTime2.Text = CDataBaseBuffer.Action().d_DataBase["m_PumpTime2"];
            vecShotgunDMY.Text = Utility.Vec2Str(1, CDataBaseBuffer.Action().d_DataBase["vecShotgunDM"]);
            vecShotgunDMZ.Text = Utility.Vec2Str(2, CDataBaseBuffer.Action().d_DataBase["vecShotgunDM"]);
            ShotGunSubPelletCount.Text = CDataBaseBuffer.Action().d_DataBase["ShotGunSubPelletCount"];
            vecShotgunDM2Z.Text = Utility.Vec2Str(2, CDataBaseBuffer.Action().d_DataBase["vecShotgunDM2"]);
            vecShotgunDM2Y.Text = Utility.Vec2Str(1, CDataBaseBuffer.Action().d_DataBase["vecShotgunDM2"]);
            vecShotgunDM2X.Text = Utility.Vec2Str(0, CDataBaseBuffer.Action().d_DataBase["vecShotgunDM2"]);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Utility.IsFloat(m_PumpTime);
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            Utility.IsFloat(m_InsertTime);
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            Utility.IsFloat(m_FinishInsertTime);
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            Utility.IsInt8(ShotGunPelletCount);
        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {
            Utility.IsFloat(m_PumpTime2);
        }

        private void TextBox12_TextChanged(object sender, EventArgs e)
        {
            Utility.IsInt8(ShotGunSubPelletCount);
        }
    }
}
