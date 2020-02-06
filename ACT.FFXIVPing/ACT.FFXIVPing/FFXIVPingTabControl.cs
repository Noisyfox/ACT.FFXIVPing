using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using ACT.FFXIVPing.localization;
using ACT.FoxCommon;
using ACT.FoxCommon.localization;
using ACT.FoxCommon.shortcut;
using ACT.FoxCommon.update;

namespace ACT.FFXIVPing
{
    public partial class FFXIVPingTabControl : UserControl, IPluginComponent
    {
        private FFXIVPingPlugin _plugin;
        private MainController _controller;
        private Font _currentFont;

        public FFXIVPingTabControl()
        {
            InitializeComponent();

            comboBoxLanguage.DisplayMember = nameof(LanguageDef.DisplayName);
            comboBoxLanguage.ValueMember = nameof(LanguageDef.LangCode);
            comboBoxLanguage.DataSource = Localization.SupportedLanguages;

            labelCurrentVersionValue.Text = Assembly.GetCallingAssembly().GetName().Version.ToString();
        }

        public void AttachToAct(FFXIVPingPlugin plugin)
        {
            _plugin = plugin;
            var parentTabPage = plugin.ParentTabPage;

            parentTabPage.Controls.Add(this);
            parentTabPage.Resize += ParentTabPageOnResize;
            ParentTabPageOnResize(parentTabPage, null);

            var settings = plugin.Settings;
            // add settings
            settings.AddControlSetting(numericUpDownX);
            settings.AddControlSetting(numericUpDownY);
            settings.AddControlSetting(trackBarOpacity);
            settings.AddControlSetting(checkBoxClickthrough);
            settings.AddControlSetting(checkBoxShowOverlay);
            settings.AddControlSetting(checkBoxAutoHide);
            settings.AddControlSetting(checkBoxCheckUpdate);
            settings.AddControlSetting(checkBoxNotifyStableOnly);
            settings.AddControlSetting(checkBoxAdvancedPing);
            settings.AddControlSetting(numericUpDownRefreshInterval);

            _controller = plugin.Controller;

            numericUpDownX.ValueChanged += NumericUpDownPositionOnValueChanged;
            numericUpDownY.ValueChanged += NumericUpDownPositionOnValueChanged;
            checkBoxClickthrough.CheckedChanged += CheckBoxClickthroughOnCheckedChanged;
            comboBoxLanguage.SelectedIndexChanged += ComboBoxLanguageSelectedIndexChanged;

            _controller.SettingsLoaded += ControllerOnSettingsLoaded;
            _controller.OverlayMoved += ControllerOnOverlayMoved;
            _controller.LanguageChanged += ControllerOnLanguageChanged;
            _controller.LogMessageAppend += ControllerOnLogMessageAppend;
            _controller.OverlayFontChanged += ControllerOnOverlayFontChanged;
            _controller.UpdateCheckingStarted += ControllerOnUpdateCheckingStarted;
            _controller.VersionChecked += ControllerOnVersionChecked;
            _controller.ShortcutChanged += ControllerOnShortcutChanged;
            _controller.ShortcutRegister += ControllerOnShortcutRegister;
            _controller.ShortcutFired += ControllerOnShortcutFired;
        }

        public void PostAttachToAct(FFXIVPingPlugin plugin)
        {
            trackBarOpacity_ValueChanged(this, EventArgs.Empty);
            NumericUpDownPositionOnValueChanged(this, EventArgs.Empty);
            CheckBoxClickthroughOnCheckedChanged(this, EventArgs.Empty);
            checkBoxShowOverlay_CheckedChanged(this, EventArgs.Empty);
            checkBoxAutoHide_CheckedChanged(this, EventArgs.Empty);

            if (!UpdateChecker.IsEnabled)
            {
                // Hide update checker panel
                groupBoxUpdate.Visible = false;
            }
        }

        public void DoLocalization()
        {
            LocalizationBase.TranslateControls(this);

            labelLatestStableVersionValue.Text = strings.versionUnknown;
            labelLatestVersionValue.Text = strings.versionUnknown;
        }

        private void ParentTabPageOnResize(object sender, EventArgs eventArgs)
        {
            Location = new Point(0, 0);
            Size = ((TabPage)sender).Size;
        }

        private void trackBarOpacity_ValueChanged(object sender, EventArgs e)
        {
            labelOpacityValue.Text = $"{trackBarOpacity.Value}%";
            _controller.NotifyOpacityChanged(false, trackBarOpacity.Value / 100D);
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            var fontdialog = new FontDialog();
            fontdialog.Font = _currentFont;

            if (fontdialog.ShowDialog() != DialogResult.Cancel)
            {
                _controller.NotifyOverlayFontChanged(true, fontdialog.Font);
            }
        }

        private void checkBoxShowOverlay_CheckedChanged(object sender, EventArgs e)
        {
            _controller.NotifyShowOverlayChanged(true, checkBoxShowOverlay.Checked);
        }

        private void checkBoxAutoHide_CheckedChanged(object sender, EventArgs e)
        {
            _controller.NotifyOverlayAutoHideChanged(true, checkBoxAutoHide.Checked);
        }
        private void NumericUpDownPositionOnValueChanged(object sender, EventArgs eventArgs)
        {
            _controller.NotifyOverlayMoved(false, (int)numericUpDownX.Value, (int)numericUpDownY.Value);
        }

        private void CheckBoxClickthroughOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            _controller.NotifyClickthroughChanged(false, checkBoxClickthrough.Checked);
        }

        private void ComboBoxLanguageSelectedIndexChanged(object sender, EventArgs e)
        {
            _controller.NotifyLanguageChanged(true, (string)comboBoxLanguage.SelectedValue);
        }

        private void buttonCheckUpdate_Click(object sender, EventArgs e)
        {
            _plugin.UpdateChecker.CheckUpdate(true);
        }

        private void buttonDownloadUpdate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(UpdateChecker.ReleasePage);
        }

        private void buttonShortcutHide_Click(object sender, EventArgs e)
        {
            var dialog = new ShortcutDialog
            {
                CurrentKey = ShortkeyUtils.StringToKey(_plugin.Settings.ShortcutHide)
            };
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var key = dialog.CurrentKey;

                _controller.NotifyShortcutChanged(true, PluginShortcut.HideOverlay, key);
            }
        }

        private void CheckBoxAdvancedPingOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            _controller.NotifyAdvancedPingEnabled(true, checkBoxAdvancedPing.Checked);
            comboBoxGameVersion.Enabled = checkBoxAdvancedPing.Checked;
            labelGameVersion.Enabled = checkBoxAdvancedPing.Checked;
        }

        private void NumericUpDownRefreshIntervalOnValueChanged(object sender, EventArgs eventArgs)
        {
            _controller.NotifyRefreshIntervalChanged(true, (double)numericUpDownRefreshInterval.Value);
        }

        private void TextBoxOverlayContentOnTextChanged(object sender, EventArgs eventArgs)
        {
            _controller.NotifyOverlayTextTemplateChanged(true, textBoxOverlayContentNormal.Text, textBoxOverlayContentNoData.Text);
        }

        private void ComboBoxGameVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            _plugin.Settings.GameClientVersion = (SettingsHolder.GameClientVersions) comboBoxGameVersion.SelectedIndex;
        }

        private void buttonResetTexts_Click(object sender, EventArgs e)
        {
            textBoxOverlayContentNormal.Text = strings.defaultOverlayContentNormal;
            textBoxOverlayContentNoData.Text = strings.defaultOverlayContentNoData;
        }

        private void ControllerOnSettingsLoaded()
        {
            if (checkBoxCheckUpdate.Checked)
            {
                _plugin.UpdateChecker.CheckUpdate(false);
            }

            checkBoxAdvancedPing.CheckedChanged += CheckBoxAdvancedPingOnCheckedChanged;
            numericUpDownRefreshInterval.ValueChanged += NumericUpDownRefreshIntervalOnValueChanged;

            var settings = _plugin.Settings;
            textBoxOverlayContentNormal.Text = settings.OverlayContentNormal ?? strings.defaultOverlayContentNormal;
            textBoxOverlayContentNoData.Text = settings.OverlayContentNoData ?? strings.defaultOverlayContentNoData;
            comboBoxGameVersion.SelectedIndex = (int) settings.GameClientVersion;

            textBoxOverlayContentNormal.TextChanged += TextBoxOverlayContentOnTextChanged;
            textBoxOverlayContentNoData.TextChanged += TextBoxOverlayContentOnTextChanged;
            comboBoxGameVersion.SelectedIndexChanged += ComboBoxGameVersion_SelectedIndexChanged;

            CheckBoxAdvancedPingOnCheckedChanged(this, EventArgs.Empty);
            NumericUpDownRefreshIntervalOnValueChanged(this, EventArgs.Empty);
            TextBoxOverlayContentOnTextChanged(this, EventArgs.Empty);
        }

        private void ControllerOnOverlayMoved(bool fromView, int x, int y)
        {
            if (!fromView)
            {
                return;
            }
            numericUpDownX.ValueChanged -= NumericUpDownPositionOnValueChanged;
            numericUpDownY.ValueChanged -= NumericUpDownPositionOnValueChanged;

            numericUpDownX.Value = x;
            numericUpDownY.Value = y;

            numericUpDownX.ValueChanged += NumericUpDownPositionOnValueChanged;
            numericUpDownY.ValueChanged += NumericUpDownPositionOnValueChanged;
        }

        private void ControllerOnLanguageChanged(bool fromView, string lang)
        {
            if (fromView)
            {
                return;
            }
            var ld = LocalizationBase.GetLanguage(lang);
            _controller.NotifyLanguageChanged(true, ld.LangCode);
            comboBoxLanguage.SelectedValue = ld.LangCode;
        }

        private void ControllerOnLogMessageAppend(bool fromView, string log)
        {
            richTextBoxLog.AppendDateTimeLine(log);
        }

        private void ControllerOnOverlayFontChanged(bool fromView, Font font)
        {
            _currentFont = font;
            textBoxFont.Text = TypeDescriptor.GetConverter(typeof(Font)).ConvertToString(font);
        }

        private void ControllerOnUpdateCheckingStarted(bool fromView)
        {
            if (InvokeRequired)
            {
                this.SafeInvoke(new Action(delegate
                {
                    ControllerOnUpdateCheckingStarted(fromView);
                }));
            }
            else
            {
                labelLatestStableVersionValue.Text = strings.updateChecking;
                labelLatestVersionValue.Text = strings.updateChecking;
            }
        }

        private void ControllerOnVersionChecked(bool fromView, VersionInfo versionInfo, bool forceNotify)
        {
            if (InvokeRequired)
            {
                this.SafeInvoke(new Action(delegate
                {
                    ControllerOnVersionChecked(fromView, versionInfo, forceNotify);
                }));
            }
            else
            {
                var stable = versionInfo?.LatestStableVersion?.ParsedVersion;
                var latest = versionInfo?.LatestVersion?.ParsedVersion;

                labelLatestStableVersionValue.Text = stable != null ? stable.ToString() : strings.versionUnknown;
                labelLatestVersionValue.Text = latest != null ? latest.ToString() : strings.versionUnknown;

                var stableOnly = checkBoxNotifyStableOnly.Checked;
                if (stableOnly)
                {
                    ShowUpdateResult(IsNewVersion(versionInfo?.LatestStableVersion), forceNotify);
                }
                else
                {
                    ShowUpdateResult(IsNewVersion(versionInfo?.LatestVersion), forceNotify);
                }
            }
        }

        private void ControllerOnShortcutChanged(bool fromView, PluginShortcut shortcut, Keys key)
        {
            var str = ShortkeyUtils.KeyToString(key);

            switch (shortcut)
            {
                case PluginShortcut.HideOverlay:
                    buttonShortcutHide.Text = str;
                    break;
            }
        }

        private void ControllerOnShortcutRegister(bool fromView, PluginShortcut shortcut, bool isRegister, bool success)
        {
            switch (shortcut)
            {
                case PluginShortcut.HideOverlay:
                    UpdateHotkeyControlColor(buttonShortcutHide, isRegister, success);
                    break;
            }
        }

        private void ControllerOnShortcutFired(bool fromView, PluginShortcut shortcut)
        {
            switch (shortcut)
            {
                case PluginShortcut.HideOverlay:
                    checkBoxShowOverlay.Checked = !checkBoxShowOverlay.Checked;
                    break;
            }
        }

        private static void UpdateHotkeyControlColor(Control control, bool isRegister, bool success)
        {
            var c = GetHotkeyRegisterColor(isRegister, success);

            if (c == Color.Empty)
            {
                control.ForeColor = Color.Empty;
            }
            else
            {
                control.ForeColor = Color.White;
            }
            control.BackColor = c;
        }

        private static Color GetHotkeyRegisterColor(bool isRegister, bool success)
        {
            if (!success)
            {
                return Color.Red;
            }

            return isRegister ? Color.Green : Color.Empty;
        }

        private PublishVersion IsNewVersion(PublishVersion newVersion)
        {
            if (newVersion == null)
            {
                return null;
            }
            var currentVersion = Assembly.GetCallingAssembly().GetName().Version;

            var v = newVersion.ParsedVersion;
            if (currentVersion.Revision == 0)
            {
                // Local build, no revision
                v = new Version(v.Major, v.Minor, v.Build);
            }

            return v > currentVersion ? newVersion : null;
        }

        private void ShowUpdateResult(PublishVersion newVersion, bool forceNotify)
        {
            if (newVersion == null)
            {
                if (forceNotify)
                {
                    MessageBox.Show(strings.messageLatest, strings.actPanelTitle, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                // Check if ignored
                if (forceNotify ||
                    !Version.TryParse(_plugin.Settings.VersionIgnored, out var v) ||
                    v < newVersion.ParsedVersion)
                {
                    // Show notify
                    var message = string.Format(newVersion.IsPreRelease
                            ? strings.messageNewPrerelease
                            : strings.messageNewStable,
                        newVersion.ParsedVersion);

                    MessageBoxManager.Yes = strings.buttonUpdateNow;
                    MessageBoxManager.No = strings.buttonIgnoreVersion;
                    MessageBoxManager.Cancel = strings.buttonUpdateLater;
                    MessageBoxManager.Register();
                    var res = MessageBox.Show(message, strings.actPanelTitle, MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    MessageBoxManager.Unregister();

                    if (res == DialogResult.No)
                    {
                        _controller.NotifyNewVersionIgnored(true, newVersion.ParsedVersion.ToString());
                    }
                    else if (res == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(newVersion.PublishPage);
                    }
                }
            }
        }
    }
}
