namespace MarsLander
{
    partial class MarsLanderNavSimulator
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
            this.TestThruster = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.LetItFly = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtAxialThrust = new System.Windows.Forms.TextBox();
            this.lblSimulationSettings = new System.Windows.Forms.Label();
            this.txtSetGrav = new System.Windows.Forms.TextBox();
            this.txtParachuteVel = new System.Windows.Forms.TextBox();
            this.txtReleaseHeight = new System.Windows.Forms.TextBox();
            this.txtEngineCutHeight = new System.Windows.Forms.TextBox();
            this.txtSlowDescentHeight = new System.Windows.Forms.TextBox();
            this.txtHighFallSpeed = new System.Windows.Forms.TextBox();
            this.txtLowFallSpeed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.UpdateSettings = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ReadRecentFlightData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TestThruster
            // 
            this.TestThruster.Location = new System.Drawing.Point(570, 433);
            this.TestThruster.Name = "TestThruster";
            this.TestThruster.Size = new System.Drawing.Size(97, 23);
            this.TestThruster.TabIndex = 1;
            this.TestThruster.TabStop = false;
            this.TestThruster.Text = "Pre-Flight tests";
            this.TestThruster.UseVisualStyleBackColor = true;
            this.TestThruster.Click += new System.EventHandler(this.TestThruster_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 461);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(452, 203);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(470, 461);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(196, 203);
            this.textBox2.TabIndex = 3;
            // 
            // LetItFly
            // 
            this.LetItFly.Location = new System.Drawing.Point(389, 433);
            this.LetItFly.Name = "LetItFly";
            this.LetItFly.Size = new System.Drawing.Size(75, 23);
            this.LetItFly.TabIndex = 4;
            this.LetItFly.Text = "Let Fly!!";
            this.LetItFly.UseVisualStyleBackColor = true;
            this.LetItFly.Click += new System.EventHandler(this.LetItFly_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(200, 100);
            this.tabPage1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(200, 100);
            this.tabPage2.TabIndex = 0;
            // 
            // txtAxialThrust
            // 
            this.txtAxialThrust.Location = new System.Drawing.Point(556, 83);
            this.txtAxialThrust.Name = "txtAxialThrust";
            this.txtAxialThrust.Size = new System.Drawing.Size(100, 20);
            this.txtAxialThrust.TabIndex = 5;
            this.txtAxialThrust.Click += new System.EventHandler(this.TextBlock_Click);
            // 
            // lblSimulationSettings
            // 
            this.lblSimulationSettings.AutoSize = true;
            this.lblSimulationSettings.Location = new System.Drawing.Point(404, 56);
            this.lblSimulationSettings.Name = "lblSimulationSettings";
            this.lblSimulationSettings.Size = new System.Drawing.Size(238, 13);
            this.lblSimulationSettings.TabIndex = 6;
            this.lblSimulationSettings.Text = "Simulator Settings:  Default Configuration Loaded";
            // 
            // txtSetGrav
            // 
            this.txtSetGrav.Location = new System.Drawing.Point(556, 109);
            this.txtSetGrav.Name = "txtSetGrav";
            this.txtSetGrav.Size = new System.Drawing.Size(100, 20);
            this.txtSetGrav.TabIndex = 7;
            this.txtSetGrav.Click += new System.EventHandler(this.TextBlock_Click);
            // 
            // txtParachuteVel
            // 
            this.txtParachuteVel.Location = new System.Drawing.Point(556, 135);
            this.txtParachuteVel.Name = "txtParachuteVel";
            this.txtParachuteVel.Size = new System.Drawing.Size(100, 20);
            this.txtParachuteVel.TabIndex = 8;
            this.txtParachuteVel.Click += new System.EventHandler(this.TextBlock_Click);
            // 
            // txtReleaseHeight
            // 
            this.txtReleaseHeight.Location = new System.Drawing.Point(556, 161);
            this.txtReleaseHeight.Name = "txtReleaseHeight";
            this.txtReleaseHeight.Size = new System.Drawing.Size(100, 20);
            this.txtReleaseHeight.TabIndex = 9;
            this.txtReleaseHeight.Click += new System.EventHandler(this.TextBlock_Click);
            // 
            // txtEngineCutHeight
            // 
            this.txtEngineCutHeight.Location = new System.Drawing.Point(556, 187);
            this.txtEngineCutHeight.Name = "txtEngineCutHeight";
            this.txtEngineCutHeight.Size = new System.Drawing.Size(100, 20);
            this.txtEngineCutHeight.TabIndex = 10;
            this.txtEngineCutHeight.Click += new System.EventHandler(this.TextBlock_Click);
            // 
            // txtSlowDescentHeight
            // 
            this.txtSlowDescentHeight.Location = new System.Drawing.Point(556, 213);
            this.txtSlowDescentHeight.Name = "txtSlowDescentHeight";
            this.txtSlowDescentHeight.Size = new System.Drawing.Size(100, 20);
            this.txtSlowDescentHeight.TabIndex = 11;
            this.txtSlowDescentHeight.Click += new System.EventHandler(this.TextBlock_Click);
            // 
            // txtHighFallSpeed
            // 
            this.txtHighFallSpeed.Location = new System.Drawing.Point(556, 239);
            this.txtHighFallSpeed.Name = "txtHighFallSpeed";
            this.txtHighFallSpeed.Size = new System.Drawing.Size(100, 20);
            this.txtHighFallSpeed.TabIndex = 12;
            this.txtHighFallSpeed.Click += new System.EventHandler(this.TextBlock_Click);
            // 
            // txtLowFallSpeed
            // 
            this.txtLowFallSpeed.Location = new System.Drawing.Point(556, 265);
            this.txtLowFallSpeed.Name = "txtLowFallSpeed";
            this.txtLowFallSpeed.Size = new System.Drawing.Size(100, 20);
            this.txtLowFallSpeed.TabIndex = 13;
            this.txtLowFallSpeed.Click += new System.EventHandler(this.TextBlock_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(402, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Axial Thrust (m/s^2)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(402, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Set Gravity (m/s^2)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(402, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Parachute Terminal Velocity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(402, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Parachute Release Height";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(402, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Engine Cut Height";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(402, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Slow Descent Height";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(402, 246);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Target High Altitude Fall Speed";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(402, 272);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Low Altitude Fall Speed";
            // 
            // UpdateSettings
            // 
            this.UpdateSettings.Location = new System.Drawing.Point(556, 291);
            this.UpdateSettings.Name = "UpdateSettings";
            this.UpdateSettings.Size = new System.Drawing.Size(100, 23);
            this.UpdateSettings.TabIndex = 22;
            this.UpdateSettings.Text = "Update Settings";
            this.UpdateSettings.UseVisualStyleBackColor = true;
            this.UpdateSettings.Click += new System.EventHandler(this.UpdateSettings_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MarsLander.Properties.Resources.Rendered_Vehicle_04;
            this.pictureBox1.Location = new System.Drawing.Point(12, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(381, 273);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;

            this.ReadRecentFlightData.Location = new System.Drawing.Point(13, 433);
            this.ReadRecentFlightData.Name = "ReadRecentFlightData";
            this.ReadRecentFlightData.Size = new System.Drawing.Size(213, 23);
            this.ReadRecentFlightData.TabIndex = 25;
            this.ReadRecentFlightData.Text = "Open Most Recent Flight Data";
            this.ReadRecentFlightData.UseVisualStyleBackColor = true;
            this.ReadRecentFlightData.Click += new System.EventHandler(this.ReadRecentFlightData_Click);
            
            // 
            // MarsLanderNavSimulator
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(678, 676);
            this.Controls.Add(this.ReadRecentFlightData);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.UpdateSettings);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLowFallSpeed);
            this.Controls.Add(this.txtHighFallSpeed);
            this.Controls.Add(this.txtSlowDescentHeight);
            this.Controls.Add(this.txtEngineCutHeight);
            this.Controls.Add(this.txtReleaseHeight);
            this.Controls.Add(this.txtParachuteVel);
            this.Controls.Add(this.txtSetGrav);
            this.Controls.Add(this.lblSimulationSettings);
            this.Controls.Add(this.txtAxialThrust);
            this.Controls.Add(this.LetItFly);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TestThruster);
            this.Name = "MarsLanderNavSimulator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Objects created specifically for self/pre-flight testing
        AxialThruster MainThruster = new AxialThruster(24);
        TrajectoryModel ThrottleCalculator = new TrajectoryModel(24, 8, 8, 5000, 5, 100, 5, 500);
        RollThruster RollThruster = new RollThruster();
        AxialThruster AxialThruster = new AxialThruster();
        GuidanceControl GuidanceSystem = new GuidanceControl();

        private System.Windows.Forms.Button TestThruster;
        private System.Windows.Forms.Button LetItFly;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtAxialThrust;
        private System.Windows.Forms.Label lblSimulationSettings;
        private System.Windows.Forms.TextBox txtSetGrav;
        private System.Windows.Forms.TextBox txtParachuteVel;
        private System.Windows.Forms.TextBox txtReleaseHeight;
        private System.Windows.Forms.TextBox txtEngineCutHeight;
        private System.Windows.Forms.TextBox txtSlowDescentHeight;
        private System.Windows.Forms.TextBox txtHighFallSpeed;
        private System.Windows.Forms.TextBox txtLowFallSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button UpdateSettings;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ReadRecentFlightData;
    }
}

