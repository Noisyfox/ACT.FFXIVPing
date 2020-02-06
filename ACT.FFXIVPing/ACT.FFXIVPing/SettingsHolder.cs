using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ACT.FoxCommon.core;
using ACT.FoxCommon.shortcut;
using Advanced_Combat_Tracker;

namespace ACT.FFXIVPing
{
    /// <summary>
    /// https://github.com/anoyetta/act_timeline/blob/origin/src/PluginSettings.cs
    /// </summary>
    internal class PluginSettings : SettingsSerializer
    {
        private readonly SettingsIO _settingsIo = new SettingsIO("ACT.FFXIVPing");

        public PluginSettings(object ParentSettingsClass) : base(ParentSettingsClass)
        {
            _settingsIo.WriteSettings = writer =>
            {
                writer.WriteStartElement("SettingsSerializer");
                ExportToXml(writer);
                writer.WriteEndElement();
            };

            _settingsIo.ReadSettings = reader =>
            {
                switch (reader.LocalName)
                {
                    case "SettingsSerializer":
                        ImportFromXml(reader);
                        break;
                }
            };
        }

        public void Load()
        {
            _settingsIo.Load();
        }

        public void Save()
        {
            _settingsIo.Save();
        }
    }

    public class SettingsHolder : IPluginComponent
    {
        #region Proxy methods

        private PluginSettings Settings { get; }

        public SettingsHolder()
        {
            Settings = new PluginSettings(this);
        }

        public void AddControlSetting(Control controlToSerialize)
        {
            Settings.AddControlSetting(controlToSerialize.Name, controlToSerialize);
        }

        public void Load()
        {
            Settings.Load();
        }

        public void Save()
        {
            Settings.Save();
        }

        #endregion

        #region Settings
        
        public string Language { get; set; }

        public string OverlayFont { get; set; }

        public string VersionIgnored { get; set; }

        public string ShortcutHide { get; set; }

        public string OverlayContentNormal { get; set; }

        public string OverlayContentNoData { get; set; }

        public GameClientVersions GameClientVersion { get; set; } = GameClientVersions.AutoDetection;

        public enum GameClientVersions: int
        {
            AutoDetection = 0,
            Global = 1,
            China = 2,
        }

        #endregion

        #region Controller notify

        private MainController _controller;

        public void AttachToAct(FFXIVPingPlugin plugin)
        {
            Settings.AddStringSetting(nameof(Language));
            Settings.AddStringSetting(nameof(OverlayFont));
            Settings.AddStringSetting(nameof(VersionIgnored));
            Settings.AddStringSetting(nameof(ShortcutHide));
            Settings.AddStringSetting(nameof(OverlayContentNormal));
            Settings.AddStringSetting(nameof(OverlayContentNoData));
            Settings.AddIntSetting(nameof(GameClientVersion));

            _controller = plugin.Controller;

            _controller.LanguageChanged += ControllerOnLanguageChanged;
            _controller.OverlayFontChanged += ControllerOnOverlayFontChanged;
            _controller.NewVersionIgnored += ControllerOnNewVersionIgnored;
            _controller.ShortcutChanged += ControllerOnShortcutChanged;
            _controller.OverlayTextTemplateChanged += ControllerOnOverlayTextTemplateChanged;
        }

        public void PostAttachToAct(FFXIVPingPlugin plugin)
        {

        }

        public void NotifySettingsLoaded()
        {
            try
            {
                _controller.NotifyOverlayFontChanged(false,
                    (Font)TypeDescriptor.GetConverter(typeof(Font)).ConvertFromString(OverlayFont));
            }
            catch (Exception)
            {
                _controller.NotifyOverlayFontChanged(true, new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular));
            }

            _controller.NotifyShortcutChanged(false, PluginShortcut.HideOverlay, ShortkeyUtils.StringToKey(ShortcutHide));

            _controller.NotifySettingsLoaded();
        }

        private void ControllerOnLanguageChanged(bool fromView, string lang)
        {
            if (!fromView)
            {
                return;
            }

            Language = lang;
        }

        private void ControllerOnOverlayFontChanged(bool fromView, Font font)
        {
            if (!fromView)
            {
                return;
            }

            OverlayFont = TypeDescriptor.GetConverter(typeof(Font)).ConvertToString(font);
        }

        private void ControllerOnNewVersionIgnored(bool fromView, string ignoredVersion)
        {
            VersionIgnored = ignoredVersion;
        }

        private void ControllerOnShortcutChanged(bool fromView, PluginShortcut shortcut, Keys key)
        {
            if (!fromView)
            {
                return;
            }

            var ks = ShortkeyUtils.KeyToString(key);
            switch (shortcut)
            {
                case PluginShortcut.HideOverlay:
                    ShortcutHide = ks;
                    break;
            }
        }

        private void ControllerOnOverlayTextTemplateChanged(bool fromView, string normal, string noData)
        {
            OverlayContentNormal = normal;
            OverlayContentNoData = noData;
        }

        #endregion
    }
}
