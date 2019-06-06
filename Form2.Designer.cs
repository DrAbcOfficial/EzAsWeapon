namespace EZAsWeapon
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_PumpTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_InsertTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_FinishInsertTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ShotGunPelletCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.vecShotgunDMX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PumpSounds = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ShotgunFinishSound = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ShotgunInsertSound = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.m_PumpTime2 = new System.Windows.Forms.TextBox();
            this.vecShotgunDMY = new System.Windows.Forms.TextBox();
            this.vecShotgunDMZ = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ShotGunSubPelletCount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vecShotgunDM2Z = new System.Windows.Forms.TextBox();
            this.vecShotgunDM2Y = new System.Windows.Forms.TextBox();
            this.vecShotgunDM2X = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_PumpTime
            // 
            this.m_PumpTime.Location = new System.Drawing.Point(112, 8);
            this.m_PumpTime.Name = "m_PumpTime";
            this.m_PumpTime.Size = new System.Drawing.Size(112, 21);
            this.m_PumpTime.TabIndex = 0;
            this.m_PumpTime.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "泵动时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "插入子弹时间";
            // 
            // m_InsertTime
            // 
            this.m_InsertTime.Location = new System.Drawing.Point(112, 32);
            this.m_InsertTime.Name = "m_InsertTime";
            this.m_InsertTime.Size = new System.Drawing.Size(112, 21);
            this.m_InsertTime.TabIndex = 2;
            this.m_InsertTime.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "完成换弹动作时间";
            // 
            // m_FinishInsertTime
            // 
            this.m_FinishInsertTime.Location = new System.Drawing.Point(112, 56);
            this.m_FinishInsertTime.Name = "m_FinishInsertTime";
            this.m_FinishInsertTime.Size = new System.Drawing.Size(112, 21);
            this.m_FinishInsertTime.TabIndex = 4;
            this.m_FinishInsertTime.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "霰弹枪弹头数";
            // 
            // ShotGunPelletCount
            // 
            this.ShotGunPelletCount.Location = new System.Drawing.Point(112, 80);
            this.ShotGunPelletCount.MaxLength = 3;
            this.ShotGunPelletCount.Name = "ShotGunPelletCount";
            this.ShotGunPelletCount.Size = new System.Drawing.Size(112, 21);
            this.ShotGunPelletCount.TabIndex = 6;
            this.ShotGunPelletCount.TextChanged += new System.EventHandler(this.TextBox4_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "霰弹枪散布大小";
            // 
            // vecShotgunDMX
            // 
            this.vecShotgunDMX.Location = new System.Drawing.Point(112, 104);
            this.vecShotgunDMX.Name = "vecShotgunDMX";
            this.vecShotgunDMX.Size = new System.Drawing.Size(32, 21);
            this.vecShotgunDMX.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "泵动声音";
            // 
            // PumpSounds
            // 
            this.PumpSounds.Location = new System.Drawing.Point(112, 128);
            this.PumpSounds.Name = "PumpSounds";
            this.PumpSounds.Size = new System.Drawing.Size(112, 21);
            this.PumpSounds.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "完成声音";
            // 
            // ShotgunFinishSound
            // 
            this.ShotgunFinishSound.Location = new System.Drawing.Point(112, 152);
            this.ShotgunFinishSound.Name = "ShotgunFinishSound";
            this.ShotgunFinishSound.Size = new System.Drawing.Size(112, 21);
            this.ShotgunFinishSound.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "插入声音";
            // 
            // ShotgunInsertSound
            // 
            this.ShotgunInsertSound.Location = new System.Drawing.Point(112, 176);
            this.ShotgunInsertSound.Name = "ShotgunInsertSound";
            this.ShotgunInsertSound.Size = new System.Drawing.Size(112, 21);
            this.ShotgunInsertSound.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "次要泵动时间";
            // 
            // m_PumpTime2
            // 
            this.m_PumpTime2.Location = new System.Drawing.Point(112, 16);
            this.m_PumpTime2.Name = "m_PumpTime2";
            this.m_PumpTime2.Size = new System.Drawing.Size(112, 21);
            this.m_PumpTime2.TabIndex = 16;
            this.m_PumpTime2.TextChanged += new System.EventHandler(this.TextBox9_TextChanged);
            // 
            // vecShotgunDMY
            // 
            this.vecShotgunDMY.Location = new System.Drawing.Point(152, 104);
            this.vecShotgunDMY.Name = "vecShotgunDMY";
            this.vecShotgunDMY.Size = new System.Drawing.Size(32, 21);
            this.vecShotgunDMY.TabIndex = 18;
            // 
            // vecShotgunDMZ
            // 
            this.vecShotgunDMZ.Location = new System.Drawing.Point(192, 104);
            this.vecShotgunDMZ.Name = "vecShotgunDMZ";
            this.vecShotgunDMZ.Size = new System.Drawing.Size(32, 21);
            this.vecShotgunDMZ.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 12);
            this.label10.TabIndex = 21;
            this.label10.Text = "次要霰弹枪弹头数";
            // 
            // ShotGunSubPelletCount
            // 
            this.ShotGunSubPelletCount.Location = new System.Drawing.Point(112, 40);
            this.ShotGunSubPelletCount.MaxLength = 3;
            this.ShotGunSubPelletCount.Name = "ShotGunSubPelletCount";
            this.ShotGunSubPelletCount.Size = new System.Drawing.Size(112, 21);
            this.ShotGunSubPelletCount.TabIndex = 20;
            this.ShotGunSubPelletCount.TextChanged += new System.EventHandler(this.TextBox12_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 23;
            this.label11.Text = "次要霰弹枪散布";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vecShotgunDM2Z);
            this.groupBox1.Controls.Add(this.vecShotgunDM2Y);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.vecShotgunDM2X);
            this.groupBox1.Controls.Add(this.m_PumpTime2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.ShotGunSubPelletCount);
            this.groupBox1.Location = new System.Drawing.Point(0, 208);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 96);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "右键霰弹枪设置";
            // 
            // vecShotgunDM2Z
            // 
            this.vecShotgunDM2Z.Location = new System.Drawing.Point(192, 64);
            this.vecShotgunDM2Z.Name = "vecShotgunDM2Z";
            this.vecShotgunDM2Z.Size = new System.Drawing.Size(32, 21);
            this.vecShotgunDM2Z.TabIndex = 28;
            // 
            // vecShotgunDM2Y
            // 
            this.vecShotgunDM2Y.Location = new System.Drawing.Point(152, 64);
            this.vecShotgunDM2Y.Name = "vecShotgunDM2Y";
            this.vecShotgunDM2Y.Size = new System.Drawing.Size(32, 21);
            this.vecShotgunDM2Y.TabIndex = 27;
            // 
            // vecShotgunDM2X
            // 
            this.vecShotgunDM2X.Location = new System.Drawing.Point(112, 64);
            this.vecShotgunDM2X.Name = "vecShotgunDM2X";
            this.vecShotgunDM2X.Size = new System.Drawing.Size(32, 21);
            this.vecShotgunDM2X.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(144, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 24);
            this.button1.TabIndex = 25;
            this.button1.Text = "保存并确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form2
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 333);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.vecShotgunDMZ);
            this.Controls.Add(this.vecShotgunDMY);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ShotgunInsertSound);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ShotgunFinishSound);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PumpSounds);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.vecShotgunDMX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ShotGunPelletCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_FinishInsertTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_InsertTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_PumpTime);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "霰弹枪设置";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_PumpTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_InsertTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_FinishInsertTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ShotGunPelletCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox vecShotgunDMX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PumpSounds;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ShotgunFinishSound;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ShotgunInsertSound;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox m_PumpTime2;
        private System.Windows.Forms.TextBox vecShotgunDMY;
        private System.Windows.Forms.TextBox vecShotgunDMZ;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ShotGunSubPelletCount;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox vecShotgunDM2Z;
        private System.Windows.Forms.TextBox vecShotgunDM2Y;
        private System.Windows.Forms.TextBox vecShotgunDM2X;
    }
}