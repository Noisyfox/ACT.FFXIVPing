using System;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using ACT.FFXIVPing.localization;
using Advanced_Combat_Tracker;

namespace ACT.FFXIVPing
{
    public class FFXIVPingPlugin : IActPluginV1
    {
        private bool _settingsLoaded = false;

        internal MainController Controller { get; private set; }
        public SettingsHolder Settings { get; private set; }
        public TabPage ParentTabPage { get; private set; }
        public Label StatusLabel { get; private set; }
        public FFXIVPingTabControl SettingsTab { get; private set; }
        public PingWindow OverlayWPF { get; private set; }
        private readonly NetworkProbeService _networkProbe = new NetworkProbeService();
        internal UpdateChecker UpdateChecker { get; } = new UpdateChecker();
        private readonly WindowsMessagePump _windowsMessagePump = new WindowsMessagePump();
        private ShortkeyManager _shortkeyManager;

        private bool _isGameActivated = false;

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            _settingsLoaded = false;
            ParentTabPage = pluginScreenSpace;
            StatusLabel = pluginStatusText;
            ParentTabPage.Text = "Chatting Translate";

            try
            {
                Controller = new MainController();
                Settings = new SettingsHolder();

                Settings.AttachToAct(this);

                OverlayWPF = new PingWindow();
                ElementHost.EnableModelessKeyboardInterop(OverlayWPF);
                OverlayWPF.AttachToAct(this);
                OverlayWPF.Show();

                SettingsTab = new FFXIVPingTabControl();
                SettingsTab.AttachToAct(this);

                Controller.ActivatedProcessPathChanged += ControllerOnActivatedProcessPathChanged;

                _networkProbe.AttachToAct(this);
                _windowsMessagePump.AttachToAct(this);
                UpdateChecker.AttachToAct(this);

                _shortkeyManager = new ShortkeyManager();
                _shortkeyManager.AttachToAct(this);

                Settings.PostAttachToAct(this);
                OverlayWPF.PostAttachToAct(this);
                SettingsTab.PostAttachToAct(this);
                _networkProbe.PostAttachToAct(this);
                _windowsMessagePump.PostAttachToAct(this);
                UpdateChecker.PostAttachToAct(this);
                _shortkeyManager.PostAttachToAct(this);

                Settings.Load();
                _settingsLoaded = true;

                DoLocalization();

                Settings.NotifySettingsLoaded();

                StatusLabel.Text = "Init Success. >w<";
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Init Failed: " + ex;
                if (_settingsLoaded)
                {
                    MessageBox.Show($"Init failed!\nCaused by:\n{ex}");
                }
                else
                {
                    MessageBox.Show($"Init failed before settings are loaded. Settings won't be saved until next successfully initialization to prevent settings lost!\nCaused by:\n{ex}");
                }
            }
        }

        private void DoLocalization()
        {
            Controller.NotifyLanguageChanged(false, Settings.Language);

            Localization.ConfigLocalization(Settings.Language);

            ParentTabPage.Text = strings.actPanelTitle;
            SettingsTab.DoLocalization();
        }

        public void DeInitPlugin()
        {
            _shortkeyManager?.Dispose();
            _shortkeyManager = null;

            _windowsMessagePump.Dispose();

            OverlayWPF?.Close();

            _networkProbe.Stop();
            UpdateChecker.Stop();

            if (_settingsLoaded)
            {
                Settings?.Save();
            }

            StatusLabel.Text = "Exited. Bye~";
        }

        private void ControllerOnActivatedProcessPathChanged(bool fromView, string path, uint pid)
        {
            _isGameActivated = Utils.IsGameExePath(path);
        }
    }

    public interface IPluginComponent
    {
        void AttachToAct(FFXIVPingPlugin plugin);
        void PostAttachToAct(FFXIVPingPlugin plugin);
    }

    internal enum Shortcut
    {
        HideOverlay
    }
}
