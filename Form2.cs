using System;
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
            Utility.Dialog(OpenDefaultData.Lang == "CN" ? "关闭并保存窗口" : "Save and close");
            this.Hide();
            this.Dispose();
        }

        private void LangEN()
        {
            label1.Text = "Pump time";
            label2.Text = "Insert time";
            label3.Text = "Finish reload time";
            label4.Text = "Pellets";
            label5.Text = "Spread";
            label6.Text = "Pump sound";
            label7.Text = "Finish sound";
            label8.Text = "Insert sound";
            label9.Text = "Sec pump sound";
            label10.Text = "Sec pellets";
            label11.Text = "Sec spread";
            groupBox1.Text = "Sec data";
            button1.Text = "Save ";
            Text = "Shotgun setting";
        }

        private void LangCN()
        {
            label1.Text = "泵动时间";
            label2.Text = "插入子弹时间";
            label3.Text = "完成换弹动作时间";
            label4.Text = "霰弹枪弹头数";
            label5.Text = "霰弹枪散布大小";
            label6.Text = "泵动声音";
            label7.Text = "完成声音";
            label8.Text = "插入声音";
            label9.Text = "次要泵动时间";
            label10.Text = "次要霰弹枪弹头数";
            label11.Text = "次要霰弹枪散布";
            groupBox1.Text = "右键霰弹枪设置";
            button1.Text = "保存并确定";
            Text = "霰弹枪设置";
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

        private void Form2_Load(object sender, EventArgs e)
        {
            Lang();

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
