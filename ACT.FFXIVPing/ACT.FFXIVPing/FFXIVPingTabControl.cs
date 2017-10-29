using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using ACT.FFXIVPing.localization;
using Advanced_Combat_Tracker;

namespace ACT.FFXIVPing
{
    public partial class FFXIVPingTabControl : UserControl, IPluginComponent
    {
        private FFXIVPingPlugin _plugin;
        private MainController _controller;

        public FFXIVPingTabControl()
        {
            InitializeComponent();

            comboBoxLanguage.DisplayMember = "DisplayName";
            comboBoxLanguage.ValueMember = "LangCode";
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
            settings.AddControlSetting(numericUpDownWidth);
            settings.AddControlSetting(numericUpDownHeight);
            settings.AddControlSetting(trackBarOpacity);
            settings.AddControlSetting(checkBoxClickthrough);
            settings.AddControlSetting(checkBoxShowOverlay);
            settings.AddControlSetting(checkBoxAutoHide);
            settings.AddControlSetting(checkBoxCheckUpdate);
            settings.AddControlSetting(checkBoxNotifyStableOnly);

            _controller = plugin.Controller;

            numericUpDownX.ValueChanged += NumericUpDownPositionOnValueChanged;
            numericUpDownY.ValueChanged += NumericUpDownPositionOnValueChanged;
            numericUpDownWidth.ValueChanged += NumericUpDownSizeOnValueChanged;
            numericUpDownHeight.ValueChanged += NumericUpDownSizeOnValueChanged;
            checkBoxClickthrough.CheckedChanged += CheckBoxClickthroughOnCheckedChanged;
            comboBoxLanguage.SelectedIndexChanged += ComboBoxLanguageSelectedIndexChanged;

            _controller.SettingsLoaded += ControllerOnSettingsLoaded;
            _controller.OverlayMoved += ControllerOnOverlayMoved;
            _controller.OverlayResized += ControllerOnOverlayResized;
            _controller.LanguageChanged += ControllerOnLanguageChanged;
            _controller.LogMessageAppend += ControllerOnLogMessageAppend;
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
            NumericUpDownSizeOnValueChanged(this, EventArgs.Empty);
            CheckBoxClickthroughOnCheckedChanged(this, EventArgs.Empty);
            checkBoxShowOverlay_CheckedChanged(this, EventArgs.Empty);
            checkBoxAutoHide_CheckedChanged(this, EventArgs.Empty);
        }

        public void DoLocalization()
        {
            Localization.TranslateControls(this);

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

        private void NumericUpDownSizeOnValueChanged(object sender, EventArgs eventArgs)
        {
            _controller.NotifyOverlayResized(false, (int)numericUpDownWidth.Value, (int)numericUpDownHeight.Value);
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
                CurrentKey = ShortkeyManager.StringToKey(_plugin.Settings.ShortcutHide)
            };
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var key = dialog.CurrentKey;

                _controller.NotifyShortcutChanged(true, Shortcut.HideOverlay, key);
            }
        }

        private void ControllerOnSettingsLoaded()
        {
            if (checkBoxCheckUpdate.Checked)
            {
                _plugin.UpdateChecker.CheckUpdate(false);
            }
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

        private void ControllerOnOverlayResized(bool fromView, int w, int h)
        {
            if (!fromView)
            {
                return;
            }

            numericUpDownWidth.ValueChanged -= NumericUpDownSizeOnValueChanged;
            numericUpDownHeight.ValueChanged -= NumericUpDownSizeOnValueChanged;

            numericUpDownWidth.Value = w;
            numericUpDownHeight.Value = h;

            numericUpDownWidth.ValueChanged += NumericUpDownSizeOnValueChanged;
            numericUpDownHeight.ValueChanged += NumericUpDownSizeOnValueChanged;
        }

        private void ControllerOnLanguageChanged(bool fromView, string lang)
        {
            if (fromView)
            {
                return;
            }
            var ld = localization.Localization.GetLanguage(lang);
            _controller.NotifyLanguageChanged(true, ld.LangCode);
            comboBoxLanguage.SelectedValue = ld.LangCode;
        }

        private void ControllerOnLogMessageAppend(bool fromView, string log)
        {
            ThreadInvokes.RichTextBoxAppendDateTimeLine(ActGlobals.oFormActMain, richTextBoxLog, log);
        }

        private void ControllerOnUpdateCheckingStarted(bool fromView)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(delegate
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

        private void ControllerOnVersionChecked(bool fromView, UpdateChecker.VersionInfo versionInfo, bool forceNotify)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(delegate
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

        private void ControllerOnShortcutChanged(bool fromView, Shortcut shortcut, Keys key)
        {
            var str = ShortkeyManager.KeyToString(key);

            switch (shortcut)
            {
                case Shortcut.HideOverlay:
                    buttonShortcutHide.Text = str;
                    break;
            }
        }

        private void ControllerOnShortcutRegister(bool fromView, Shortcut shortcut, bool isRegister, bool success)
        {
            switch (shortcut)
            {
                case Shortcut.HideOverlay:
                    UpdateHotkeyControlColor(buttonShortcutHide, isRegister, success);
                    break;
            }
        }

        private void ControllerOnShortcutFired(bool fromView, Shortcut shortcut)
        {
            switch (shortcut)
            {
                case Shortcut.HideOverlay:
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

        private UpdateChecker.PublishVersion IsNewVersion(UpdateChecker.PublishVersion newVersion)
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

        private void ShowUpdateResult(UpdateChecker.PublishVersion newVersion, bool forceNotify)
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
