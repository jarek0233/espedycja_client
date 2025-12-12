namespace espedycja_client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtApiKey = new TextBox();
            btnInstallPlugin = new Button();
            btnStart = new Button();
            lblStatus = new Label();
            timerSend = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            lblDestComp = new Label();
            lblSourceComp = new Label();
            lblWeight = new Label();
            lblCargo = new Label();
            lblRoute = new Label();
            groupBox2 = new GroupBox();
            lblFuel = new Label();
            lblTruckModel = new Label();
            lblSpeed = new Label();
            groupBox3 = new GroupBox();
            pbCargoDamage = new ProgressBar();
            Ładunek = new Label();
            pbTrailerDamage = new ProgressBar();
            label2 = new Label();
            pbTruckDamage = new ProgressBar();
            label1 = new Label();
            gbTacho = new GroupBox();
            lblTachoStatus = new Label();
            lblSessionTime = new Label();
            menuStrip1 = new MenuStrip();
            pomocToolStripMenuItem = new ToolStripMenuItem();
            instrukcjaObsługiToolStripMenuItem = new ToolStripMenuItem();
            oAplikacjiToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            tsStatus = new ToolStripStatusLabel();
            tsVersion = new ToolStripStatusLabel();
            notifyIcon1 = new NotifyIcon(components);
            groupBox4 = new GroupBox();
            tbVolume = new TrackBar();
            btnRadioStop = new Button();
            btnRadioPlay = new Button();
            cbRadioStation = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            gbTacho.SuspendLayout();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbVolume).BeginInit();
            SuspendLayout();
            // 
            // txtApiKey
            // 
            txtApiKey.Location = new Point(19, 296);
            txtApiKey.Name = "txtApiKey";
            txtApiKey.Size = new Size(300, 23);
            txtApiKey.TabIndex = 0;
            // 
            // btnInstallPlugin
            // 
            btnInstallPlugin.Location = new Point(12, 27);
            btnInstallPlugin.Name = "btnInstallPlugin";
            btnInstallPlugin.Size = new Size(108, 48);
            btnInstallPlugin.TabIndex = 1;
            btnInstallPlugin.Text = "Zainstaluj Plugin";
            btnInstallPlugin.UseVisualStyleBackColor = true;
            btnInstallPlugin.Click += btnInstallPlugin_Click;
            // 
            // btnStart
            // 
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnStart.Location = new Point(110, 325);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(119, 23);
            btnStart.TabIndex = 2;
            btnStart.Text = "Połącz / Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(99, 351);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(121, 15);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "STATUS POŁĄCZENIA";
            // 
            // timerSend
            // 
            timerSend.Interval = 1000;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(57, 81);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(203, 194);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lblDestComp);
            groupBox1.Controls.Add(lblSourceComp);
            groupBox1.Controls.Add(lblWeight);
            groupBox1.Controls.Add(lblCargo);
            groupBox1.Controls.Add(lblRoute);
            groupBox1.Location = new Point(364, 166);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(169, 118);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Aktualne Zlecenie";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 58);
            label4.Name = "label4";
            label4.Size = new Size(22, 15);
            label4.TabIndex = 11;
            label4.Text = "Do";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 43);
            label3.Name = "label3";
            label3.Size = new Size(14, 15);
            label3.TabIndex = 10;
            label3.Text = "Z";
            // 
            // lblDestComp
            // 
            lblDestComp.AutoSize = true;
            lblDestComp.Location = new Point(39, 58);
            lblDestComp.Name = "lblDestComp";
            lblDestComp.Size = new Size(22, 15);
            lblDestComp.TabIndex = 9;
            lblDestComp.Text = "---";
            // 
            // lblSourceComp
            // 
            lblSourceComp.AutoSize = true;
            lblSourceComp.Location = new Point(39, 43);
            lblSourceComp.Name = "lblSourceComp";
            lblSourceComp.Size = new Size(22, 15);
            lblSourceComp.TabIndex = 8;
            lblSourceComp.Text = "---";
            // 
            // lblWeight
            // 
            lblWeight.AutoSize = true;
            lblWeight.Location = new Point(133, 87);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new Size(20, 15);
            lblWeight.TabIndex = 8;
            lblWeight.Text = "0 t";
            // 
            // lblCargo
            // 
            lblCargo.AutoSize = true;
            lblCargo.Location = new Point(10, 87);
            lblCargo.Name = "lblCargo";
            lblCargo.Size = new Size(76, 15);
            lblCargo.TabIndex = 7;
            lblCargo.Text = "Brak ładunku";
            // 
            // lblRoute
            // 
            lblRoute.AutoSize = true;
            lblRoute.Location = new Point(10, 19);
            lblRoute.Name = "lblRoute";
            lblRoute.Size = new Size(51, 15);
            lblRoute.TabIndex = 6;
            lblRoute.Text = "--- > ---";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblFuel);
            groupBox2.Controls.Add(lblTruckModel);
            groupBox2.Controls.Add(lblSpeed);
            groupBox2.Location = new Point(364, 90);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(392, 74);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Parametry Ciągnika";
            // 
            // lblFuel
            // 
            lblFuel.AutoSize = true;
            lblFuel.Location = new Point(6, 34);
            lblFuel.Name = "lblFuel";
            lblFuel.Size = new Size(63, 15);
            lblFuel.TabIndex = 7;
            lblFuel.Text = "Paliwo: 0 L";
            // 
            // lblTruckModel
            // 
            lblTruckModel.AutoSize = true;
            lblTruckModel.Location = new Point(66, 19);
            lblTruckModel.Name = "lblTruckModel";
            lblTruckModel.Size = new Size(99, 15);
            lblTruckModel.TabIndex = 7;
            lblTruckModel.Text = "Model ciężarówki";
            // 
            // lblSpeed
            // 
            lblSpeed.AutoSize = true;
            lblSpeed.Location = new Point(6, 19);
            lblSpeed.Name = "lblSpeed";
            lblSpeed.Size = new Size(45, 15);
            lblSpeed.TabIndex = 7;
            lblSpeed.Text = "0 km/h";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(pbCargoDamage);
            groupBox3.Controls.Add(Ładunek);
            groupBox3.Controls.Add(pbTrailerDamage);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(pbTruckDamage);
            groupBox3.Controls.Add(label1);
            groupBox3.Location = new Point(544, 166);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(212, 118);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Stan Techniczny";
            // 
            // pbCargoDamage
            // 
            pbCargoDamage.Location = new Point(80, 79);
            pbCargoDamage.Name = "pbCargoDamage";
            pbCargoDamage.Size = new Size(100, 23);
            pbCargoDamage.TabIndex = 10;
            // 
            // Ładunek
            // 
            Ładunek.AutoSize = true;
            Ładunek.Location = new Point(19, 85);
            Ładunek.Name = "Ładunek";
            Ładunek.Size = new Size(52, 15);
            Ładunek.TabIndex = 8;
            Ładunek.Text = "Ładunek";
            // 
            // pbTrailerDamage
            // 
            pbTrailerDamage.Location = new Point(79, 50);
            pbTrailerDamage.Name = "pbTrailerDamage";
            pbTrailerDamage.Size = new Size(100, 23);
            pbTrailerDamage.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 51);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 8;
            label2.Text = "Naczepa";
            // 
            // pbTruckDamage
            // 
            pbTruckDamage.Location = new Point(79, 22);
            pbTruckDamage.Name = "pbTruckDamage";
            pbTruckDamage.Size = new Size(100, 22);
            pbTruckDamage.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 24);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 8;
            label1.Text = "Ciężarówka";
            // 
            // gbTacho
            // 
            gbTacho.Controls.Add(lblTachoStatus);
            gbTacho.Controls.Add(lblSessionTime);
            gbTacho.Location = new Point(364, 27);
            gbTacho.Name = "gbTacho";
            gbTacho.Size = new Size(392, 57);
            gbTacho.TabIndex = 8;
            gbTacho.TabStop = false;
            gbTacho.Text = "Tachograf (Czas sesji)";
            // 
            // lblTachoStatus
            // 
            lblTachoStatus.AutoSize = true;
            lblTachoStatus.ForeColor = Color.Green;
            lblTachoStatus.Location = new Point(66, 19);
            lblTachoStatus.Name = "lblTachoStatus";
            lblTachoStatus.Size = new Size(61, 15);
            lblTachoStatus.TabIndex = 1;
            lblTachoStatus.Text = "W Normie";
            // 
            // lblSessionTime
            // 
            lblSessionTime.AutoSize = true;
            lblSessionTime.Location = new Point(17, 19);
            lblSessionTime.Name = "lblSessionTime";
            lblSessionTime.Size = new Size(34, 15);
            lblSessionTime.TabIndex = 0;
            lblSessionTime.Text = "00:00";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.DeepSkyBlue;
            menuStrip1.Items.AddRange(new ToolStripItem[] { pomocToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(768, 24);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // pomocToolStripMenuItem
            // 
            pomocToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { instrukcjaObsługiToolStripMenuItem, oAplikacjiToolStripMenuItem });
            pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            pomocToolStripMenuItem.Size = new Size(57, 20);
            pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // instrukcjaObsługiToolStripMenuItem
            // 
            instrukcjaObsługiToolStripMenuItem.Name = "instrukcjaObsługiToolStripMenuItem";
            instrukcjaObsługiToolStripMenuItem.Size = new Size(190, 22);
            instrukcjaObsługiToolStripMenuItem.Text = "INSTRUKCJA OBSŁUGI";
            instrukcjaObsługiToolStripMenuItem.Click += instrukcjaObsługiToolStripMenuItem_Click;
            // 
            // oAplikacjiToolStripMenuItem
            // 
            oAplikacjiToolStripMenuItem.Name = "oAplikacjiToolStripMenuItem";
            oAplikacjiToolStripMenuItem.Size = new Size(190, 22);
            oAplikacjiToolStripMenuItem.Text = "O APLIKACJI";
            oAplikacjiToolStripMenuItem.Click += oAplikacjiToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.DeepSkyBlue;
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsStatus, tsVersion });
            statusStrip1.Location = new Point(0, 411);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(768, 22);
            statusStrip1.TabIndex = 10;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsStatus
            // 
            tsStatus.Name = "tsStatus";
            tsStatus.Size = new Size(48, 17);
            tsStatus.Text = "Gotowy";
            // 
            // tsVersion
            // 
            tsVersion.ImageAlign = ContentAlignment.MiddleRight;
            tsVersion.Name = "tsVersion";
            tsVersion.Size = new Size(37, 17);
            tsVersion.Text = "v1.0.0";
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "e-Spedycja Client";
            notifyIcon1.Visible = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(tbVolume);
            groupBox4.Controls.Add(btnRadioStop);
            groupBox4.Controls.Add(btnRadioPlay);
            groupBox4.Controls.Add(cbRadioStation);
            groupBox4.Location = new Point(364, 296);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(392, 112);
            groupBox4.TabIndex = 11;
            groupBox4.TabStop = false;
            groupBox4.Text = "Radio e-spedycja";
            // 
            // tbVolume
            // 
            tbVolume.Location = new Point(19, 58);
            tbVolume.Maximum = 100;
            tbVolume.Name = "tbVolume";
            tbVolume.Size = new Size(342, 45);
            tbVolume.TabIndex = 12;
            tbVolume.Value = 50;
            // 
            // btnRadioStop
            // 
            btnRadioStop.Location = new Point(284, 29);
            btnRadioStop.Name = "btnRadioStop";
            btnRadioStop.Size = new Size(75, 23);
            btnRadioStop.TabIndex = 14;
            btnRadioStop.Text = "STOP";
            btnRadioStop.UseVisualStyleBackColor = true;
            btnRadioStop.Click += btnRadioStop_Click;
            // 
            // btnRadioPlay
            // 
            btnRadioPlay.Location = new Point(203, 29);
            btnRadioPlay.Name = "btnRadioPlay";
            btnRadioPlay.Size = new Size(75, 23);
            btnRadioPlay.TabIndex = 13;
            btnRadioPlay.Text = "Graj";
            btnRadioPlay.UseVisualStyleBackColor = true;
            btnRadioPlay.Click += btnRadioPlay_Click;
            // 
            // cbRadioStation
            // 
            cbRadioStation.FormattingEnabled = true;
            cbRadioStation.Location = new Point(32, 30);
            cbRadioStation.Name = "cbRadioStation";
            cbRadioStation.Size = new Size(165, 23);
            cbRadioStation.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(768, 433);
            Controls.Add(groupBox4);
            Controls.Add(statusStrip1);
            Controls.Add(gbTacho);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Controls.Add(lblStatus);
            Controls.Add(btnStart);
            Controls.Add(btnInstallPlugin);
            Controls.Add(txtApiKey);
            Controls.Add(menuStrip1);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "e-spedycja telemetry app";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            gbTacho.ResumeLayout(false);
            gbTacho.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbVolume).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtApiKey;
        private Button btnInstallPlugin;
        private Button btnStart;
        private Label lblStatus;
        private System.Windows.Forms.Timer timerSend;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private Label lblWeight;
        private Label lblCargo;
        private Label lblRoute;
        private GroupBox groupBox2;
        private Label lblFuel;
        private Label lblTruckModel;
        private Label lblSpeed;
        private GroupBox groupBox3;
        private Label label2;
        private ProgressBar pbTruckDamage;
        private Label label1;
        private ProgressBar pbCargoDamage;
        private Label Ładunek;
        private ProgressBar pbTrailerDamage;
        private Label lblDestComp;
        private Label lblSourceComp;
        private GroupBox gbTacho;
        private Label lblTachoStatus;
        private Label lblSessionTime;
        private Label label3;
        private Label label4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem pomocToolStripMenuItem;
        private ToolStripMenuItem instrukcjaObsługiToolStripMenuItem;
        private ToolStripMenuItem oAplikacjiToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsStatus;
        private ToolStripStatusLabel tsVersion;
        private NotifyIcon notifyIcon1;
        private GroupBox groupBox4;
        private TrackBar tbVolume;
        private Button btnRadioStop;
        private Button btnRadioPlay;
        private ComboBox cbRadioStation;
    }
}
