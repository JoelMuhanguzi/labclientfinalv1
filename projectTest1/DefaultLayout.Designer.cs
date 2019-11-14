namespace projectTest1
{
    partial class DefaultLayout
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefaultLayout));
            this.waveformGraph1 = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.waveformPlot2 = new NationalInstruments.UI.WaveformPlot();
            this.xAxis1 = new NationalInstruments.UI.XAxis();
            this.yAxis1 = new NationalInstruments.UI.YAxis();
            this.frequency_knob = new NationalInstruments.UI.WindowsForms.Knob();
            this.amplitude_knob = new NationalInstruments.UI.WindowsForms.Knob();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadLabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeLabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screenShotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startLabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finishLabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeDisplay = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lab_Circuit = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ExistingLabList = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.waveformGraph1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequency_knob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amplitude_knob)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lab_Circuit)).BeginInit();
            this.SuspendLayout();
            // 
            // waveformGraph1
            // 
            this.waveformGraph1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.waveformGraph1.Border = NationalInstruments.UI.Border.Raised;
            this.waveformGraph1.Caption = "WAVEFORMS";
            this.waveformGraph1.CaptionForeColor = System.Drawing.Color.Blue;
            this.waveformGraph1.ForeColor = System.Drawing.Color.Blue;
            this.waveformGraph1.Location = new System.Drawing.Point(388, 69);
            this.waveformGraph1.Margin = new System.Windows.Forms.Padding(4);
            this.waveformGraph1.Name = "waveformGraph1";
            this.waveformGraph1.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot2});
            this.waveformGraph1.Size = new System.Drawing.Size(544, 609);
            this.waveformGraph1.TabIndex = 0;
            this.waveformGraph1.UseColorGenerator = true;
            this.waveformGraph1.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis1});
            this.waveformGraph1.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis1});
            // 
            // waveformPlot2
            // 
            this.waveformPlot2.LineColor = System.Drawing.Color.Blue;
            this.waveformPlot2.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor;
            this.waveformPlot2.XAxis = this.xAxis1;
            this.waveformPlot2.YAxis = this.yAxis1;
            // 
            // frequency_knob
            // 
            this.frequency_knob.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.frequency_knob.Caption = "Frequency (Hz)";
            this.frequency_knob.CaptionForeColor = System.Drawing.Color.Blue;
            this.frequency_knob.DialColor = System.Drawing.SystemColors.Info;
            this.frequency_knob.KnobStyle = NationalInstruments.UI.KnobStyle.FlatWithThinNeedle;
            this.frequency_knob.Location = new System.Drawing.Point(194, 345);
            this.frequency_knob.Margin = new System.Windows.Forms.Padding(4);
            this.frequency_knob.Name = "frequency_knob";
            this.frequency_knob.PointerColor = System.Drawing.SystemColors.HotTrack;
            this.frequency_knob.Range = new NationalInstruments.UI.Range(0D, 1000D);
            this.frequency_knob.Size = new System.Drawing.Size(166, 161);
            this.frequency_knob.TabIndex = 1;
            this.frequency_knob.Value = 100D;
            this.frequency_knob.AfterChangeValue += new NationalInstruments.UI.AfterChangeNumericValueEventHandler(this.knob1_AfterChangeValue);
            this.frequency_knob.MouseUp += new System.Windows.Forms.MouseEventHandler(this.knob1_MouseUp);
            // 
            // amplitude_knob
            // 
            this.amplitude_knob.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.amplitude_knob.Caption = "Amplitude (Vpp)";
            this.amplitude_knob.CaptionForeColor = System.Drawing.Color.Blue;
            this.amplitude_knob.DialColor = System.Drawing.SystemColors.Info;
            this.amplitude_knob.KnobStyle = NationalInstruments.UI.KnobStyle.FlatWithThinNeedle;
            this.amplitude_knob.Location = new System.Drawing.Point(12, 345);
            this.amplitude_knob.Margin = new System.Windows.Forms.Padding(4);
            this.amplitude_knob.Name = "amplitude_knob";
            this.amplitude_knob.PointerColor = System.Drawing.SystemColors.HotTrack;
            this.amplitude_knob.Range = new NationalInstruments.UI.Range(0D, 5D);
            this.amplitude_knob.Size = new System.Drawing.Size(163, 161);
            this.amplitude_knob.TabIndex = 2;
            this.amplitude_knob.Value = 1D;
            this.amplitude_knob.AfterChangeValue += new NationalInstruments.UI.AfterChangeNumericValueEventHandler(this.knob2_AfterChangeValue);
            this.amplitude_knob.MouseUp += new System.Windows.Forms.MouseEventHandler(this.knob2_MouseUp);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.Color.Blue;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "sine",
            "square",
            "triangle"});
            this.comboBox1.Location = new System.Drawing.Point(97, 525);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(128, 25);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(13, 528);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Signal Type";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(12, 565);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Switches";
            this.label2.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.screenShotToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.startLabToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.resumeToolStripMenuItem,
            this.finishLabToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(932, 29);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadLabToolStripMenuItem,
            this.closeLabToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 25);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // uploadLabToolStripMenuItem
            // 
            this.uploadLabToolStripMenuItem.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.uploadLabToolStripMenuItem.Name = "uploadLabToolStripMenuItem";
            this.uploadLabToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.uploadLabToolStripMenuItem.Text = "Upload lab";
            this.uploadLabToolStripMenuItem.Click += new System.EventHandler(this.uploadLabToolStripMenuItem_Click);
            // 
            // closeLabToolStripMenuItem
            // 
            this.closeLabToolStripMenuItem.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.closeLabToolStripMenuItem.Name = "closeLabToolStripMenuItem";
            this.closeLabToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.closeLabToolStripMenuItem.Text = "Close ";
            this.closeLabToolStripMenuItem.Click += new System.EventHandler(this.closeLabToolStripMenuItem_Click);
            // 
            // screenShotToolStripMenuItem
            // 
            this.screenShotToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.screenShotToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.screenShotToolStripMenuItem.Name = "screenShotToolStripMenuItem";
            this.screenShotToolStripMenuItem.Size = new System.Drawing.Size(101, 25);
            this.screenShotToolStripMenuItem.Text = "ScreenShot";
            this.screenShotToolStripMenuItem.Click += new System.EventHandler(this.screenShotToolStripMenuItem_Click_1);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.downloadToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(93, 25);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // startLabToolStripMenuItem
            // 
            this.startLabToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.startLabToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.startLabToolStripMenuItem.Name = "startLabToolStripMenuItem";
            this.startLabToolStripMenuItem.Size = new System.Drawing.Size(83, 25);
            this.startLabToolStripMenuItem.Text = "Start Lab";
            this.startLabToolStripMenuItem.Click += new System.EventHandler(this.startLabToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pauseToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(62, 25);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // resumeToolStripMenuItem
            // 
            this.resumeToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.resumeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.resumeToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.resumeToolStripMenuItem.Name = "resumeToolStripMenuItem";
            this.resumeToolStripMenuItem.Size = new System.Drawing.Size(78, 25);
            this.resumeToolStripMenuItem.Text = "Resume";
            this.resumeToolStripMenuItem.Click += new System.EventHandler(this.resumeToolStripMenuItem_Click);
            // 
            // finishLabToolStripMenuItem
            // 
            this.finishLabToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.finishLabToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.finishLabToolStripMenuItem.Name = "finishLabToolStripMenuItem";
            this.finishLabToolStripMenuItem.Size = new System.Drawing.Size(92, 25);
            this.finishLabToolStripMenuItem.Text = "Finish Lab";
            this.finishLabToolStripMenuItem.Click += new System.EventHandler(this.finishLabToolStripMenuItem_Click);
            // 
            // TimeDisplay
            // 
            this.TimeDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TimeDisplay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeDisplay.ForeColor = System.Drawing.Color.Blue;
            this.TimeDisplay.Location = new System.Drawing.Point(698, 33);
            this.TimeDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.TimeDisplay.Name = "TimeDisplay";
            this.TimeDisplay.ReadOnly = true;
            this.TimeDisplay.Size = new System.Drawing.Size(222, 29);
            this.TimeDisplay.TabIndex = 10;
            this.TimeDisplay.Text = "HH: mm:ss";
            this.TimeDisplay.TextChanged += new System.EventHandler(this.Time_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(568, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 21);
            this.label3.TabIndex = 11;
            this.label3.Text = "Remaining time";
            // 
            // lab_Circuit
            // 
            this.lab_Circuit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_Circuit.Location = new System.Drawing.Point(13, 69);
            this.lab_Circuit.Margin = new System.Windows.Forms.Padding(4);
            this.lab_Circuit.Name = "lab_Circuit";
            this.lab_Circuit.Size = new System.Drawing.Size(347, 259);
            this.lab_Circuit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lab_Circuit.TabIndex = 12;
            this.lab_Circuit.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Lab circuit";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 586);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(347, 92);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Yu Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Blue;
            this.textBox1.Location = new System.Drawing.Point(79, 180);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 34);
            this.textBox1.TabIndex = 15;
            this.textBox1.Text = "Lab Circuit";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(568, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 21);
            this.label5.TabIndex = 17;
            this.label5.Text = "Recent Labs";
            // 
            // ExistingLabList
            // 
            this.ExistingLabList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExistingLabList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ExistingLabList.FormattingEnabled = true;
            this.ExistingLabList.Location = new System.Drawing.Point(698, 12);
            this.ExistingLabList.Name = "ExistingLabList";
            this.ExistingLabList.Size = new System.Drawing.Size(222, 25);
            this.ExistingLabList.TabIndex = 18;
            this.ExistingLabList.SelectedIndexChanged += new System.EventHandler(this.ExistingLabList_SelectedIndexChanged);
            // 
            // DefaultLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(932, 684);
            this.Controls.Add(this.ExistingLabList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lab_Circuit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TimeDisplay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.amplitude_knob);
            this.Controls.Add(this.frequency_knob);
            this.Controls.Add(this.waveformGraph1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Blue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(846, 572);
            this.Name = "DefaultLayout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab Client";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.waveformGraph1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequency_knob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amplitude_knob)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lab_Circuit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.UI.WindowsForms.WaveformGraph waveformGraph1;
        private NationalInstruments.UI.XAxis xAxis1;
        private NationalInstruments.UI.YAxis yAxis1;
        private NationalInstruments.UI.WindowsForms.Knob frequency_knob;
        private NationalInstruments.UI.WindowsForms.Knob amplitude_knob;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadLabToolStripMenuItem;
        private System.Windows.Forms.TextBox TimeDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private NationalInstruments.UI.WaveformPlot waveformPlot2;
        private System.Windows.Forms.ToolStripMenuItem closeLabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startLabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finishLabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem screenShotToolStripMenuItem;
        private System.Windows.Forms.PictureBox lab_Circuit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumeToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ExistingLabList;
    }
}

