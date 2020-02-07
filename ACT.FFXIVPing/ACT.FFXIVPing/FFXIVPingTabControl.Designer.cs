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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FFXIVPingTabControl));
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
            this.labelOpacity = new System.Windows.Forms.Label();
            this.trackBarOpacity = new System.Windows.Forms.TrackBar();
            this.labelOpacityValue = new System.Windows.Forms.Label();
            this.checkBoxClickthrough = new System.Windows.Forms.CheckBox();
            this.checkBoxShowOverlay = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoHide = new System.Windows.Forms.CheckBox();
            this.labelShortcutHide = new System.Windows.Forms.Label();
            this.buttonShortcutHide = new System.Windows.Forms.Button();
            this.buttonFont = new System.Windows.Forms.Button();
            this.textBoxFont = new System.Windows.Forms.TextBox();
            this.tabPageAdvanced = new System.Windows.Forms.TabPage();
            this.groupBoxTextCustomization = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelOverlayContentNormal = new System.Windows.Forms.Label();
            this.textBoxOverlayContentNormal = new System.Windows.Forms.TextBox();
            this.buttonResetTexts = new System.Windows.Forms.Button();
            this.labelAvailableVariables = new System.Windows.Forms.Label();
            this.labelOverlayContentNoData = new System.Windows.Forms.Label();
            this.textBoxOverlayContentNoData = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxAdvancedPing = new System.Windows.Forms.CheckBox();
            this.labelAdvancedPing = new System.Windows.Forms.Label();
            this.labelRefreshInterval = new System.Windows.Forms.Label();
            this.numericUpDownRefreshInterval = new System.Windows.Forms.NumericUpDown();
            this.labelGameVersion = new System.Windows.Forms.Label();
            this.comboBoxGameVersion = new System.Windows.Forms.ComboBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).BeginInit();
            this.tabPageAdvanced.SuspendLayout();
            this.groupBoxTextCustomization.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshInterval)).BeginInit();
            this.tabPageLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageGeneralSettings);
            this.tabControl1.Controls.Add(this.tabPageAdvanced);
            this.tabControl1.Controls.Add(this.tabPageLog);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(618, 496);
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
            this.tabPageGeneralSettings.Size = new System.Drawing.Size(610, 470);
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
            this.tableLayoutPanel1.Controls.Add(this.labelOpacity, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.trackBarOpacity, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelOpacityValue, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxClickthrough, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxShowOverlay, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxAutoHide, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelShortcutHide, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonShortcutHide, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonFont, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxFont, 0, 4);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(499, 171);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownY.Location = new System.Drawing.Point(314, 54);
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
            this.numericUpDownY.Size = new System.Drawing.Size(182, 21);
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
            this.labelX.Location = new System.Drawing.Point(62, 58);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(17, 12);
            this.labelX.TabIndex = 1;
            this.labelX.Text = "X:";
            // 
            // labelY
            // 
            this.labelY.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(291, 58);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(17, 12);
            this.labelY.TabIndex = 2;
            this.labelY.Text = "Y:";
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownX.Location = new System.Drawing.Point(85, 54);
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
            this.numericUpDownX.Size = new System.Drawing.Size(182, 21);
            this.numericUpDownX.TabIndex = 2;
            this.numericUpDownX.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // labelOpacity
            // 
            this.labelOpacity.AutoSize = true;
            this.labelOpacity.Location = new System.Drawing.Point(3, 78);
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
            this.trackBarOpacity.Location = new System.Drawing.Point(62, 81);
            this.trackBarOpacity.Maximum = 100;
            this.trackBarOpacity.Name = "trackBarOpacity";
            this.trackBarOpacity.Size = new System.Drawing.Size(205, 45);
            this.trackBarOpacity.TabIndex = 6;
            this.trackBarOpacity.TickFrequency = 10;
            this.trackBarOpacity.Value = 100;
            this.trackBarOpacity.ValueChanged += new System.EventHandler(this.trackBarOpacity_ValueChanged);
            // 
            // labelOpacityValue
            // 
            this.labelOpacityValue.AutoSize = true;
            this.labelOpacityValue.Location = new System.Drawing.Point(273, 78);
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
            this.checkBoxClickthrough.Location = new System.Drawing.Point(314, 81);
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
            this.checkBoxAutoHide.Location = new System.Drawing.Point(273, 3);
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
            this.buttonShortcutHide.Location = new System.Drawing.Point(85, 25);
            this.buttonShortcutHide.Name = "buttonShortcutHide";
            this.buttonShortcutHide.Size = new System.Drawing.Size(182, 23);
            this.buttonShortcutHide.TabIndex = 14;
            this.buttonShortcutHide.UseVisualStyleBackColor = true;
            this.buttonShortcutHide.Click += new System.EventHandler(this.buttonShortcutHide_Click);
            // 
            // buttonFont
            // 
            this.buttonFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFont.Location = new System.Drawing.Point(314, 132);
            this.buttonFont.Name = "buttonFont";
            this.buttonFont.Size = new System.Drawing.Size(182, 23);
            this.buttonFont.TabIndex = 16;
            this.buttonFont.Text = "Change Font";
            this.buttonFont.UseVisualStyleBackColor = true;
            this.buttonFont.Click += new System.EventHandler(this.buttonFont_Click);
            // 
            // textBoxFont
            // 
            this.textBoxFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxFont, 4);
            this.textBoxFont.Location = new System.Drawing.Point(3, 133);
            this.textBoxFont.Name = "textBoxFont";
            this.textBoxFont.ReadOnly = true;
            this.textBoxFont.Size = new System.Drawing.Size(305, 21);
            this.textBoxFont.TabIndex = 15;
            // 
            // tabPageAdvanced
            // 
            this.tabPageAdvanced.AutoScroll = true;
            this.tabPageAdvanced.Controls.Add(this.groupBoxTextCustomization);
            this.tabPageAdvanced.Controls.Add(this.tableLayoutPanel2);
            this.tabPageAdvanced.Location = new System.Drawing.Point(4, 22);
            this.tabPageAdvanced.Name = "tabPageAdvanced";
            this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdvanced.Size = new System.Drawing.Size(610, 470);
            this.tabPageAdvanced.TabIndex = 3;
            this.tabPageAdvanced.Text = "Advanced Settings";
            this.tabPageAdvanced.UseVisualStyleBackColor = true;
            // 
            // groupBoxTextCustomization
            // 
            this.groupBoxTextCustomization.Controls.Add(this.tableLayoutPanel3);
            this.groupBoxTextCustomization.Location = new System.Drawing.Point(6, 277);
            this.groupBoxTextCustomization.Name = "groupBoxTextCustomization";
            this.groupBoxTextCustomization.Size = new System.Drawing.Size(504, 129);
            this.groupBoxTextCustomization.TabIndex = 1;
            this.groupBoxTextCustomization.TabStop = false;
            this.groupBoxTextCustomization.Text = "Text Customization";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.labelOverlayContentNormal, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxOverlayContentNormal, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonResetTexts, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.labelAvailableVariables, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.labelOverlayContentNoData, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBoxOverlayContentNoData, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(498, 109);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // labelOverlayContentNormal
            // 
            this.labelOverlayContentNormal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelOverlayContentNormal.AutoSize = true;
            this.labelOverlayContentNormal.Location = new System.Drawing.Point(3, 7);
            this.labelOverlayContentNormal.Name = "labelOverlayContentNormal";
            this.labelOverlayContentNormal.Size = new System.Drawing.Size(77, 12);
            this.labelOverlayContentNormal.TabIndex = 2;
            this.labelOverlayContentNormal.Text = "Normal Text:";
            // 
            // textBoxOverlayContentNormal
            // 
            this.textBoxOverlayContentNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOverlayContentNormal.Location = new System.Drawing.Point(92, 3);
            this.textBoxOverlayContentNormal.Name = "textBoxOverlayContentNormal";
            this.textBoxOverlayContentNormal.Size = new System.Drawing.Size(403, 21);
            this.textBoxOverlayContentNormal.TabIndex = 4;
            this.textBoxOverlayContentNormal.Text = "Ping {ping_ms_na}, {lost}% Pkt Lost";
            // 
            // buttonResetTexts
            // 
            this.buttonResetTexts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResetTexts.AutoSize = true;
            this.buttonResetTexts.Location = new System.Drawing.Point(414, 69);
            this.buttonResetTexts.Name = "buttonResetTexts";
            this.buttonResetTexts.Size = new System.Drawing.Size(81, 22);
            this.buttonResetTexts.TabIndex = 7;
            this.buttonResetTexts.Text = "Reset Texts";
            this.buttonResetTexts.UseVisualStyleBackColor = true;
            this.buttonResetTexts.Click += new System.EventHandler(this.buttonResetTexts_Click);
            // 
            // labelAvailableVariables
            // 
            this.labelAvailableVariables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAvailableVariables.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.labelAvailableVariables, 2);
            this.labelAvailableVariables.Location = new System.Drawing.Point(3, 54);
            this.labelAvailableVariables.Name = "labelAvailableVariables";
            this.labelAvailableVariables.Size = new System.Drawing.Size(492, 12);
            this.labelAvailableVariables.TabIndex = 6;
            this.labelAvailableVariables.Text = "Available Variables: {ping} {ping_ms_na} {lost}";
            // 
            // labelOverlayContentNoData
            // 
            this.labelOverlayContentNoData.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelOverlayContentNoData.AutoSize = true;
            this.labelOverlayContentNoData.Location = new System.Drawing.Point(3, 34);
            this.labelOverlayContentNoData.Name = "labelOverlayContentNoData";
            this.labelOverlayContentNoData.Size = new System.Drawing.Size(83, 12);
            this.labelOverlayContentNoData.TabIndex = 3;
            this.labelOverlayContentNoData.Text = "No Data Text:";
            // 
            // textBoxOverlayContentNoData
            // 
            this.textBoxOverlayContentNoData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOverlayContentNoData.Location = new System.Drawing.Point(92, 30);
            this.textBoxOverlayContentNoData.Name = "textBoxOverlayContentNoData";
            this.textBoxOverlayContentNoData.Size = new System.Drawing.Size(403, 21);
            this.textBoxOverlayContentNoData.TabIndex = 5;
            this.textBoxOverlayContentNoData.Text = "No Ping Data...";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.checkBoxAdvancedPing, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelAdvancedPing, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelRefreshInterval, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.numericUpDownRefreshInterval, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.labelGameVersion, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxGameVersion, 1, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(499, 265);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // checkBoxAdvancedPing
            // 
            this.checkBoxAdvancedPing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAdvancedPing.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.checkBoxAdvancedPing, 2);
            this.checkBoxAdvancedPing.Location = new System.Drawing.Point(3, 3);
            this.checkBoxAdvancedPing.Name = "checkBoxAdvancedPing";
            this.checkBoxAdvancedPing.Size = new System.Drawing.Size(493, 16);
            this.checkBoxAdvancedPing.TabIndex = 0;
            this.checkBoxAdvancedPing.Text = "Enable Advanced Ping";
            this.checkBoxAdvancedPing.UseVisualStyleBackColor = true;
            // 
            // labelAdvancedPing
            // 
            this.labelAdvancedPing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAdvancedPing.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.labelAdvancedPing, 2);
            this.labelAdvancedPing.Enabled = false;
            this.labelAdvancedPing.Location = new System.Drawing.Point(20, 22);
            this.labelAdvancedPing.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.labelAdvancedPing.Name = "labelAdvancedPing";
            this.labelAdvancedPing.Size = new System.Drawing.Size(476, 144);
            this.labelAdvancedPing.TabIndex = 1;
            this.labelAdvancedPing.Text = resources.GetString("labelAdvancedPing.Text");
            // 
            // labelRefreshInterval
            // 
            this.labelRefreshInterval.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelRefreshInterval.AutoSize = true;
            this.labelRefreshInterval.Location = new System.Drawing.Point(3, 219);
            this.labelRefreshInterval.Name = "labelRefreshInterval";
            this.labelRefreshInterval.Size = new System.Drawing.Size(149, 12);
            this.labelRefreshInterval.TabIndex = 2;
            this.labelRefreshInterval.Text = "Resampling Interval (s):";
            // 
            // numericUpDownRefreshInterval
            // 
            this.numericUpDownRefreshInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownRefreshInterval.DecimalPlaces = 1;
            this.numericUpDownRefreshInterval.Location = new System.Drawing.Point(158, 215);
            this.numericUpDownRefreshInterval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownRefreshInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRefreshInterval.Name = "numericUpDownRefreshInterval";
            this.numericUpDownRefreshInterval.Size = new System.Drawing.Size(338, 21);
            this.numericUpDownRefreshInterval.TabIndex = 3;
            this.numericUpDownRefreshInterval.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // labelGameVersion
            // 
            this.labelGameVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelGameVersion.AutoSize = true;
            this.labelGameVersion.Location = new System.Drawing.Point(3, 173);
            this.labelGameVersion.Name = "labelGameVersion";
            this.labelGameVersion.Size = new System.Drawing.Size(125, 12);
            this.labelGameVersion.TabIndex = 4;
            this.labelGameVersion.Text = "Game Client Version:";
            // 
            // comboBoxGameVersion
            // 
            this.comboBoxGameVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxGameVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGameVersion.FormattingEnabled = true;
            this.comboBoxGameVersion.Items.AddRange(new object[] {
            "AutoDetect",
            "Global",
            "China"});
            this.comboBoxGameVersion.Location = new System.Drawing.Point(158, 169);
            this.comboBoxGameVersion.Name = "comboBoxGameVersion";
            this.comboBoxGameVersion.Size = new System.Drawing.Size(338, 20);
            this.comboBoxGameVersion.TabIndex = 5;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.richTextBoxLog);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLog.Size = new System.Drawing.Size(610, 470);
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
            this.richTextBoxLog.Size = new System.Drawing.Size(604, 464);
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
            this.Size = new System.Drawing.Size(618, 496);
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).EndInit();
            this.tabPageAdvanced.ResumeLayout(false);
            this.groupBoxTextCustomization.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefreshInterval)).EndInit();
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
        private System.Windows.Forms.Button buttonFont;
        private System.Windows.Forms.TextBox textBoxFont;
        private System.Windows.Forms.TabPage tabPageAdvanced;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox checkBoxAdvancedPing;
        private System.Windows.Forms.Label labelAdvancedPing;
        private System.Windows.Forms.Label labelOverlayContentNormal;
        private System.Windows.Forms.Label labelOverlayContentNoData;
        private System.Windows.Forms.TextBox textBoxOverlayContentNormal;
        private System.Windows.Forms.TextBox textBoxOverlayContentNoData;
        private System.Windows.Forms.Label labelAvailableVariables;
        private System.Windows.Forms.Button buttonResetTexts;
        private System.Windows.Forms.GroupBox groupBoxTextCustomization;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label labelRefreshInterval;
        private System.Windows.Forms.NumericUpDown numericUpDownRefreshInterval;
        private System.Windows.Forms.Label labelGameVersion;
        private System.Windows.Forms.ComboBox comboBoxGameVersion;
    }
}
