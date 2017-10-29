namespace ACT.FFXIVPing
{
    partial class FFXIVPingTabControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageGeneralSettings = new System.Windows.Forms.TabPage();
            this.groupBoxUpdate = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelCurrentVersion = new System.Windows.Forms.Label();
            this.labelCurrentVersionValue = new System.Windows.Forms.Label();
            this.labelLatestStableVersion = new System.Windows.Forms.Label();
            this.labelLatestVersion = new System.Windows.Forms.Label();
            this.labelLatestStableVersionValue = new System.Windows.Forms.Label();
            this.labelLatestVersionValue = new System.Windows.Forms.Label();
            this.checkBoxCheckUpdate = new System.Windows.Forms.CheckBox();
            this.checkBoxNotifyStableOnly = new System.Windows.Forms.CheckBox();
            this.buttonCheckUpdate = new System.Windows.Forms.Button();
            this.buttonDownloadUpdate = new System.Windows.Forms.Button();
            this.tableLayoutPanelMainLanguage = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelMainLanguage = new System.Windows.Forms.Label();
            this.labelNeedToRestart = new System.Windows.Forms.Label();
            this.groupBoxOverlay = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.labelPosition = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.labelOpacity = new System.Windows.Forms.Label();
            this.trackBarOpacity = new System.Windows.Forms.TrackBar();
            this.labelOpacityValue = new System.Windows.Forms.Label();
            this.checkBoxClickthrough = new System.Windows.Forms.CheckBox();
            this.checkBoxShowOverlay = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoHide = new System.Windows.Forms.CheckBox();
            this.labelShortcutHide = new System.Windows.Forms.Label();
            this.buttonShortcutHide = new System.Windows.Forms.Button();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPageGeneralSettings.SuspendLayout();
            this.groupBoxUpdate.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanelMainLanguage.SuspendLayout();
            this.groupBoxOverlay.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).BeginInit();
            this.tabPageLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageGeneralSettings);
            this.tabControl1.Controls.Add(this.tabPageLog);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(677, 494);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPageGeneralSettings
            // 
            this.tabPageGeneralSettings.AutoScroll = true;
            this.tabPageGeneralSettings.Controls.Add(this.groupBoxUpdate);
            this.tabPageGeneralSettings.Controls.Add(this.tableLayoutPanelMainLanguage);
            this.tabPageGeneralSettings.Controls.Add(this.groupBoxOverlay);
            this.tabPageGeneralSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneralSettings.Name = "tabPageGeneralSettings";
            this.tabPageGeneralSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneralSettings.Size = new System.Drawing.Size(669, 468);
            this.tabPageGeneralSettings.TabIndex = 0;
            this.tabPageGeneralSettings.Text = "General Settings";
            this.tabPageGeneralSettings.UseVisualStyleBackColor = true;
            // 
            // groupBoxUpdate
            // 
            this.groupBoxUpdate.Controls.Add(this.tableLayoutPanel4);
            this.groupBoxUpdate.Location = new System.Drawing.Point(6, 240);
            this.groupBoxUpdate.Name = "groupBoxUpdate";
            this.groupBoxUpdate.Size = new System.Drawing.Size(263, 190);
            this.groupBoxUpdate.TabIndex = 4;
            this.groupBoxUpdate.TabStop = false;
            this.groupBoxUpdate.Text = "Update";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.labelCurrentVersion, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelCurrentVersionValue, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelLatestStableVersion, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelLatestVersion, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.labelLatestStableVersionValue, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelLatestVersionValue, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.checkBoxCheckUpdate, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.checkBoxNotifyStableOnly, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.buttonCheckUpdate, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.buttonDownloadUpdate, 0, 6);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 7;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(257, 170);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // labelCurrentVersion
            // 
            this.labelCurrentVersion.AutoSize = true;
            this.labelCurrentVersion.Location = new System.Drawing.Point(3, 0);
            this.labelCurrentVersion.Name = "labelCurrentVersion";
            this.labelCurrentVersion.Size = new System.Drawing.Size(101, 12);
            this.labelCurrentVersion.TabIndex = 0;
            this.labelCurrentVersion.Text = "Current Version:";
            // 
            // labelCurrentVersionValue
            // 
            this.labelCurrentVersionValue.AutoSize = true;
            this.labelCurrentVersionValue.Location = new System.Drawing.Point(146, 0);
            this.labelCurrentVersionValue.Name = "labelCurrentVersionValue";
            this.labelCurrentVersionValue.Size = new System.Drawing.Size(41, 12);
            this.labelCurrentVersionValue.TabIndex = 1;
            this.labelCurrentVersionValue.Text = "label2";
            // 
            // labelLatestStableVersion
            // 
            this.labelLatestStableVersion.AutoSize = true;
            this.labelLatestStableVersion.Location = new System.Drawing.Point(3, 12);
            this.labelLatestStableVersion.Name = "labelLatestStableVersion";
            this.labelLatestStableVersion.Size = new System.Drawing.Size(137, 12);
            this.labelLatestStableVersion.TabIndex = 2;
            this.labelLatestStableVersion.Text = "Latest Stable Version:";
            // 
            // labelLatestVersion
            // 
            this.labelLatestVersion.AutoSize = true;
            this.labelLatestVersion.Location = new System.Drawing.Point(3, 24);
            this.labelLatestVersion.Name = "labelLatestVersion";
            this.labelLatestVersion.Size = new System.Drawing.Size(95, 12);
            this.labelLatestVersion.TabIndex = 3;
            this.labelLatestVersion.Text = "Latest Version:";
            // 
            // labelLatestStableVersionValue
            // 
            this.labelLatestStableVersionValue.AutoSize = true;
            this.labelLatestStableVersionValue.Location = new System.Drawing.Point(146, 12);
            this.labelLatestStableVersionValue.Name = "labelLatestStableVersionValue";
            this.labelLatestStableVersionValue.Size = new System.Drawing.Size(41, 12);
            this.labelLatestStableVersionValue.TabIndex = 4;
            this.labelLatestStableVersionValue.Text = "label5";
            // 
            // labelLatestVersionValue
            // 
            this.labelLatestVersionValue.AutoSize = true;
            this.labelLatestVersionValue.Location = new System.Drawing.Point(146, 24);
            this.labelLatestVersionValue.Name = "labelLatestVersionValue";
            this.labelLatestVersionValue.Size = new System.Drawing.Size(41, 12);
            this.labelLatestVersionValue.TabIndex = 5;
            this.labelLatestVersionValue.Text = "label6";
            // 
            // checkBoxCheckUpdate
            // 
            this.checkBoxCheckUpdate.AutoSize = true;
            this.checkBoxCheckUpdate.Checked = true;
            this.checkBoxCheckUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel4.SetColumnSpan(this.checkBoxCheckUpdate, 2);
            this.checkBoxCheckUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxCheckUpdate.Location = new System.Drawing.Point(3, 39);
            this.checkBoxCheckUpdate.Name = "checkBoxCheckUpdate";
            this.checkBoxCheckUpdate.Size = new System.Drawing.Size(251, 16);
            this.checkBoxCheckUpdate.TabIndex = 6;
            this.checkBoxCheckUpdate.Text = "Check Update on Startup";
            this.checkBoxCheckUpdate.UseVisualStyleBackColor = true;
            // 
            // checkBoxNotifyStableOnly
            // 
            this.checkBoxNotifyStableOnly.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.checkBoxNotifyStableOnly, 2);
            this.checkBoxNotifyStableOnly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxNotifyStableOnly.Location = new System.Drawing.Point(3, 61);
            this.checkBoxNotifyStableOnly.Name = "checkBoxNotifyStableOnly";
            this.checkBoxNotifyStableOnly.Size = new System.Drawing.Size(251, 16);
            this.checkBoxNotifyStableOnly.TabIndex = 7;
            this.checkBoxNotifyStableOnly.Text = "Check for Stable Version Only";
            this.checkBoxNotifyStableOnly.UseVisualStyleBackColor = true;
            // 
            // buttonCheckUpdate
            // 
            this.buttonCheckUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCheckUpdate.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.buttonCheckUpdate, 2);
            this.buttonCheckUpdate.Location = new System.Drawing.Point(143, 83);
            this.buttonCheckUpdate.Name = "buttonCheckUpdate";
            this.buttonCheckUpdate.Size = new System.Drawing.Size(111, 23);
            this.buttonCheckUpdate.TabIndex = 8;
            this.buttonCheckUpdate.Text = "Check Update Now";
            this.buttonCheckUpdate.UseVisualStyleBackColor = true;
            this.buttonCheckUpdate.Click += new System.EventHandler(this.buttonCheckUpdate_Click);
            // 
            // buttonDownloadUpdate
            // 
            this.buttonDownloadUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDownloadUpdate.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.buttonDownloadUpdate, 2);
            this.buttonDownloadUpdate.Location = new System.Drawing.Point(113, 112);
            this.buttonDownloadUpdate.Name = "buttonDownloadUpdate";
            this.buttonDownloadUpdate.Size = new System.Drawing.Size(141, 23);
            this.buttonDownloadUpdate.TabIndex = 9;
            this.buttonDownloadUpdate.Text = "Open Download Website";
            this.buttonDownloadUpdate.UseVisualStyleBackColor = true;
            this.buttonDownloadUpdate.Click += new System.EventHandler(this.buttonDownloadUpdate_Click);
            // 
            // tableLayoutPanelMainLanguage
            // 
            this.tableLayoutPanelMainLanguage.ColumnCount = 3;
            this.tableLayoutPanelMainLanguage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMainLanguage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMainLanguage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMainLanguage.Controls.Add(this.comboBoxLanguage, 1, 0);
            this.tableLayoutPanelMainLanguage.Controls.Add(this.labelMainLanguage, 0, 0);
            this.tableLayoutPanelMainLanguage.Controls.Add(this.labelNeedToRestart, 2, 0);
            this.tableLayoutPanelMainLanguage.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanelMainLanguage.Name = "tableLayoutPanelMainLanguage";
            this.tableLayoutPanelMainLanguage.RowCount = 1;
            this.tableLayoutPanelMainLanguage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMainLanguage.Size = new System.Drawing.Size(505, 31);
            this.tableLayoutPanelMainLanguage.TabIndex = 0;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(68, 5);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(273, 20);
            this.comboBoxLanguage.TabIndex = 3;
            // 
            // labelMainLanguage
            // 
            this.labelMainLanguage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelMainLanguage.AutoSize = true;
            this.labelMainLanguage.Location = new System.Drawing.Point(3, 9);
            this.labelMainLanguage.Name = "labelMainLanguage";
            this.labelMainLanguage.Size = new System.Drawing.Size(59, 12);
            this.labelMainLanguage.TabIndex = 4;
            this.labelMainLanguage.Text = "Language:";
            // 
            // labelNeedToRestart
            // 
            this.labelNeedToRestart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelNeedToRestart.AutoSize = true;
            this.labelNeedToRestart.Enabled = false;
            this.labelNeedToRestart.Location = new System.Drawing.Point(347, 9);
            this.labelNeedToRestart.Name = "labelNeedToRestart";
            this.labelNeedToRestart.Size = new System.Drawing.Size(155, 12);
            this.labelNeedToRestart.TabIndex = 5;
            this.labelNeedToRestart.Text = "*Need to restart the ACT.";
            // 
            // groupBoxOverlay
            // 
            this.groupBoxOverlay.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxOverlay.Location = new System.Drawing.Point(6, 43);
            this.groupBoxOverlay.Name = "groupBoxOverlay";
            this.groupBoxOverlay.Size = new System.Drawing.Size(505, 191);
            this.groupBoxOverlay.TabIndex = 1;
            this.groupBoxOverlay.TabStop = false;
            this.groupBoxOverlay.Text = "Overlay Settings";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownY, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelPosition, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelX, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelY, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownX, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelSize, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelWidth, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelHeight, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownWidth, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownHeight, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelOpacity, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.trackBarOpacity, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelOpacityValue, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxClickthrough, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxShowOverlay, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxAutoHide, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelShortcutHide, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonShortcutHide, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(499, 171);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownY.Location = new System.Drawing.Point(332, 54);
            this.numericUpDownY.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownY.Minimum = new decimal(new int[] {
            65535,
            0,
            0,
            -2147483648});
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(164, 21);
            this.numericUpDownY.TabIndex = 3;
            this.numericUpDownY.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // labelPosition
            // 
            this.labelPosition.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(3, 58);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(53, 12);
            this.labelPosition.TabIndex = 0;
            this.labelPosition.Text = "Position";
            // 
            // labelX
            // 
            this.labelX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(86, 58);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(17, 12);
            this.labelX.TabIndex = 1;
            this.labelX.Text = "X:";
            // 
            // labelY
            // 
            this.labelY.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(309, 58);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(17, 12);
            this.labelY.TabIndex = 2;
            this.labelY.Text = "Y:";
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownX.Location = new System.Drawing.Point(109, 54);
            this.numericUpDownX.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownX.Minimum = new decimal(new int[] {
            65535,
            0,
            0,
            -2147483648});
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(164, 21);
            this.numericUpDownX.TabIndex = 2;
            this.numericUpDownX.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // labelSize
            // 
            this.labelSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(3, 85);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(29, 12);
            this.labelSize.TabIndex = 5;
            this.labelSize.Text = "Size";
            // 
            // labelWidth
            // 
            this.labelWidth.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(62, 85);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(41, 12);
            this.labelWidth.TabIndex = 6;
            this.labelWidth.Text = "Width:";
            // 
            // labelHeight
            // 
            this.labelHeight.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(279, 85);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(47, 12);
            this.labelHeight.TabIndex = 7;
            this.labelHeight.Text = "Height:";
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownWidth.Location = new System.Drawing.Point(109, 81);
            this.numericUpDownWidth.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownWidth.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(164, 21);
            this.numericUpDownWidth.TabIndex = 4;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownHeight.Location = new System.Drawing.Point(332, 81);
            this.numericUpDownHeight.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownHeight.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(164, 21);
            this.numericUpDownHeight.TabIndex = 5;
            this.numericUpDownHeight.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // labelOpacity
            // 
            this.labelOpacity.AutoSize = true;
            this.labelOpacity.Location = new System.Drawing.Point(3, 105);
            this.labelOpacity.Name = "labelOpacity";
            this.labelOpacity.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelOpacity.Size = new System.Drawing.Size(53, 22);
            this.labelOpacity.TabIndex = 10;
            this.labelOpacity.Text = "Opacity:";
            // 
            // trackBarOpacity
            // 
            this.trackBarOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarOpacity.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.trackBarOpacity, 2);
            this.trackBarOpacity.Location = new System.Drawing.Point(62, 108);
            this.trackBarOpacity.Maximum = 100;
            this.trackBarOpacity.Name = "trackBarOpacity";
            this.trackBarOpacity.Size = new System.Drawing.Size(211, 45);
            this.trackBarOpacity.TabIndex = 6;
            this.trackBarOpacity.TickFrequency = 10;
            this.trackBarOpacity.Value = 100;
            this.trackBarOpacity.ValueChanged += new System.EventHandler(this.trackBarOpacity_ValueChanged);
            // 
            // labelOpacityValue
            // 
            this.labelOpacityValue.AutoSize = true;
            this.labelOpacityValue.Location = new System.Drawing.Point(279, 105);
            this.labelOpacityValue.MinimumSize = new System.Drawing.Size(35, 0);
            this.labelOpacityValue.Name = "labelOpacityValue";
            this.labelOpacityValue.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelOpacityValue.Size = new System.Drawing.Size(35, 22);
            this.labelOpacityValue.TabIndex = 12;
            this.labelOpacityValue.Text = "100%";
            this.labelOpacityValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkBoxClickthrough
            // 
            this.checkBoxClickthrough.AutoSize = true;
            this.checkBoxClickthrough.Location = new System.Drawing.Point(332, 108);
            this.checkBoxClickthrough.Name = "checkBoxClickthrough";
            this.checkBoxClickthrough.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.checkBoxClickthrough.Size = new System.Drawing.Size(96, 21);
            this.checkBoxClickthrough.TabIndex = 7;
            this.checkBoxClickthrough.Text = "Clickthrough";
            this.checkBoxClickthrough.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowOverlay
            // 
            this.checkBoxShowOverlay.AutoSize = true;
            this.checkBoxShowOverlay.Checked = true;
            this.checkBoxShowOverlay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxShowOverlay, 3);
            this.checkBoxShowOverlay.Location = new System.Drawing.Point(3, 3);
            this.checkBoxShowOverlay.Name = "checkBoxShowOverlay";
            this.checkBoxShowOverlay.Size = new System.Drawing.Size(96, 16);
            this.checkBoxShowOverlay.TabIndex = 0;
            this.checkBoxShowOverlay.Text = "Show Overlay";
            this.checkBoxShowOverlay.UseVisualStyleBackColor = true;
            this.checkBoxShowOverlay.CheckedChanged += new System.EventHandler(this.checkBoxShowOverlay_CheckedChanged);
            // 
            // checkBoxAutoHide
            // 
            this.checkBoxAutoHide.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxAutoHide, 2);
            this.checkBoxAutoHide.Location = new System.Drawing.Point(279, 3);
            this.checkBoxAutoHide.Name = "checkBoxAutoHide";
            this.checkBoxAutoHide.Size = new System.Drawing.Size(180, 16);
            this.checkBoxAutoHide.TabIndex = 1;
            this.checkBoxAutoHide.Text = "Automatically Hide Overlay";
            this.checkBoxAutoHide.UseVisualStyleBackColor = true;
            this.checkBoxAutoHide.CheckedChanged += new System.EventHandler(this.checkBoxAutoHide_CheckedChanged);
            // 
            // labelShortcutHide
            // 
            this.labelShortcutHide.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelShortcutHide.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelShortcutHide, 2);
            this.labelShortcutHide.Location = new System.Drawing.Point(3, 30);
            this.labelShortcutHide.Name = "labelShortcutHide";
            this.labelShortcutHide.Size = new System.Drawing.Size(59, 12);
            this.labelShortcutHide.TabIndex = 13;
            this.labelShortcutHide.Text = "Shortcut:";
            // 
            // buttonShortcutHide
            // 
            this.buttonShortcutHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShortcutHide.Location = new System.Drawing.Point(109, 25);
            this.buttonShortcutHide.Name = "buttonShortcutHide";
            this.buttonShortcutHide.Size = new System.Drawing.Size(164, 23);
            this.buttonShortcutHide.TabIndex = 14;
            this.buttonShortcutHide.UseVisualStyleBackColor = true;
            this.buttonShortcutHide.Click += new System.EventHandler(this.buttonShortcutHide_Click);
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.richTextBoxLog);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLog.Size = new System.Drawing.Size(669, 468);
            this.tabPageLog.TabIndex = 2;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLog.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(663, 462);
            this.richTextBoxLog.TabIndex = 6;
            this.richTextBoxLog.Text = "";
            // 
            // FFXIVPingTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tabControl1);
            this.Name = "FFXIVPingTabControl";
            this.Size = new System.Drawing.Size(677, 494);
            this.tabControl1.ResumeLayout(false);
            this.tabPageGeneralSettings.ResumeLayout(false);
            this.groupBoxUpdate.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanelMainLanguage.ResumeLayout(false);
            this.tableLayoutPanelMainLanguage.PerformLayout();
            this.groupBoxOverlay.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).EndInit();
            this.tabPageLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageGeneralSettings;
        private System.Windows.Forms.GroupBox groupBoxUpdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label labelCurrentVersion;
        private System.Windows.Forms.Label labelCurrentVersionValue;
        private System.Windows.Forms.Label labelLatestStableVersion;
        private System.Windows.Forms.Label labelLatestVersion;
        private System.Windows.Forms.Label labelLatestStableVersionValue;
        private System.Windows.Forms.Label labelLatestVersionValue;
        private System.Windows.Forms.CheckBox checkBoxCheckUpdate;
        private System.Windows.Forms.CheckBox checkBoxNotifyStableOnly;
        private System.Windows.Forms.Button buttonCheckUpdate;
        private System.Windows.Forms.Button buttonDownloadUpdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMainLanguage;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label labelMainLanguage;
        private System.Windows.Forms.Label labelNeedToRestart;
        private System.Windows.Forms.GroupBox groupBoxOverlay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown numericUpDownY;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.NumericUpDown numericUpDownX;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Label labelOpacity;
        private System.Windows.Forms.TrackBar trackBarOpacity;
        private System.Windows.Forms.Label labelOpacityValue;
        private System.Windows.Forms.CheckBox checkBoxClickthrough;
        private System.Windows.Forms.CheckBox checkBoxShowOverlay;
        private System.Windows.Forms.CheckBox checkBoxAutoHide;
        private System.Windows.Forms.Label labelShortcutHide;
        private System.Windows.Forms.Button buttonShortcutHide;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
    }
}
