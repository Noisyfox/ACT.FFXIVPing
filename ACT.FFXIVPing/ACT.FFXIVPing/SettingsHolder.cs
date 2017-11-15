using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ACT.FoxCommon.shortcut;
using Advanced_Combat_Tracker;

namespace ACT.FFXIVPing
{
    /// <summary>
    /// https://github.com/anoyetta/act_timeline/blob/origin/src/PluginSettings.cs
    /// </summary>
    internal class PluginSettings : SettingsSerializer
    {
        private readonly string _settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\ACT.FFXIVPing.config.xml");

        public PluginSettings(object ParentSettingsClass) : base(ParentSettingsClass)
        {
        }

        public void Load()
        {
            if (File.Exists(_settingsFile))
            {
                FileStream fs = new FileStream(_settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                XmlTextReader reader = new XmlTextReader(fs);
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "SettingsSerializer")
                        ImportFromXml(reader);
                }
                reader.Close();
            }
        }

        public void Save()
        {
            FileStream stream = new FileStream(_settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 1;
            writer.IndentChar = '\t';
            writer.WriteStartDocument(true);
            writer.WriteStartElement("Config");
            writer.WriteStartElement("SettingsSerializer");
            ExportToXml(writer);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
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

        #endregion

        #region Controller notify
        
        private MainController _controller;

        public void AttachToAct(FFXIVPingPlugin plugin)
        {
            Settings.AddStringSetting(nameof(Language));
            Settings.AddStringSetting(nameof(OverlayFont));
            Settings.AddStringSetting(nameof(VersionIgnored));
            Settings.AddStringSetting(nameof(ShortcutHide));

            _controller = plugin.Controller;

            _controller.LanguageChanged += ControllerOnLanguageChanged;
            _controller.OverlayFontChanged += ControllerOnOverlayFontChanged;
            _controller.NewVersionIgnored += ControllerOnNewVersionIgnored;
            _controller.ShortcutChanged += ControllerOnShortcutChanged;
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

        #endregion
    }
}
