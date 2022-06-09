using System;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using ACT.FFXIVPing.localization;
using ACT.FoxCommon;
using ACT.FoxCommon.core;
using ACT.FoxCommon.logging;

namespace ACT.FFXIVPing
{
    public class FFXIVPingPlugin : PluginBase<MainController>
    {
        private bool _settingsLoaded = false;

        public SettingsHolder Settings { get; private set; }
        public TabPage ParentTabPage { get; private set; }
        public Label StatusLabel { get; private set; }
        public FFXIVPingTabControl SettingsTab { get; private set; }
        public PingWindow OverlayWPF { get; private set; }
        private readonly NetworkProbeService _networkProbe = new NetworkProbeService();
        internal UpdateChecker UpdateChecker { get; } = new UpdateChecker();
        private readonly WindowsMessagePumpBase<MainController, FFXIVPingPlugin> _windowsMessagePump = new WindowsMessagePumpBase<MainController, FFXIVPingPlugin>();
        private readonly GameProcessMonitor _gameProcessMonitor = new GameProcessMonitor();
        internal MachinaProbeService MachinaService { get; } = new MachinaProbeService();
        private ShortkeyManager<MainController, FFXIVPingPlugin> _shortkeyManager;

        private bool _isGameActivated = false;

        public override void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {   
            // Display log
            Logger.OnLogging = s => Controller.NotifyLogMessageAppend(false, s);

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

                MachinaService.AttachToAct(this);
                _gameProcessMonitor.AttachToAct(this);
                _networkProbe.AttachToAct(this);
                _windowsMessagePump.AttachToAct(this);
                UpdateChecker.AttachToAct(this);

                _shortkeyManager = new ShortkeyManager<MainController, FFXIVPingPlugin>();
                _shortkeyManager.AttachToAct(this);

                Settings.PostAttachToAct(this);
                OverlayWPF.PostAttachToAct(this);
                SettingsTab.PostAttachToAct(this);
                MachinaService.PostAttachToAct(this);
                _gameProcessMonitor.PostAttachToAct(this);
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
            catch (SettingsNotLoadException ex)
            {
                StatusLabel.Text = "Init Failed: " + ex;
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

        public override void DeInitPlugin()
        {
            _gameProcessMonitor.Stop();
            MachinaService.Stop();

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

            Logger.OnLogging = null;
            StatusLabel.Text = "Exited. Bye~";
        }

        private void ControllerOnActivatedProcessPathChanged(bool fromView, ProcessInfo process)
        {
            _isGameActivated = process.IsGameProcess;
        }
    }

    public interface IPluginComponent: IPluginComponentBase<MainController, FFXIVPingPlugin>
    {
    }
}
