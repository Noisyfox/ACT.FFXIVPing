using System;
using System.Drawing;
using System.Windows.Forms;

namespace ACT.FFXIVPing
{
    internal class MainController
    {
        public event Action SettingsLoaded;

        public void NotifySettingsLoaded()
        {
            SettingsLoaded?.Invoke();
        }

        public delegate void OnOverlayMovedDelegate(bool fromView, int x, int y);

        public event OnOverlayMovedDelegate OverlayMoved;

        public void NotifyOverlayMoved(bool fromView, int x, int y)
        {
            OverlayMoved?.Invoke(fromView, x, y);
        }

        public delegate void OnOpacityChangedDelegate(bool fromView, double value);

        public event OnOpacityChangedDelegate OpacityChanged;

        public void NotifyOpacityChanged(bool fromView, double value)
        {
            OpacityChanged?.Invoke(fromView, value);
        }

        public delegate void OnClickthroughChangedDelegate(bool fromView, bool clickthrough);

        public event OnClickthroughChangedDelegate ClickthroughChanged;

        public void NotifyClickthroughChanged(bool fromView, bool clickthrough)
        {
            ClickthroughChanged?.Invoke(fromView, clickthrough);
        }

        public delegate void OnOverlayContentChangedDelegate(bool fromView, string content);

        public event OnOverlayContentChangedDelegate OverlayContentChanged;

        public void NotifyOverlayContentChanged(bool fromView, string content)
        {
            OverlayContentChanged?.Invoke(fromView, content);
        }

        public delegate void OnLanguageChangedDelegate(bool fromView, string lang);

        public event OnLanguageChangedDelegate LanguageChanged;

        public void NotifyLanguageChanged(bool fromView, string lang)
        {
            LanguageChanged?.Invoke(fromView, lang);
        }

        public delegate void OnLogMessageAppendDelegate(bool fromView, string log);

        public event OnLogMessageAppendDelegate LogMessageAppend;

        public void NotifyLogMessageAppend(bool fromView, string log)
        {
            LogMessageAppend?.Invoke(fromView, log);
        }

        public delegate void OnOverlayFontChangedDelegate(bool fromView, Font font);

        public event OnOverlayFontChangedDelegate OverlayFontChanged;

        public void NotifyOverlayFontChanged(bool fromView, Font font)
        {
            OverlayFontChanged?.Invoke(fromView, font);
        }

        public delegate void OnShowOverlayChangedDelegate(bool fromView, bool showOverlay);

        public event OnShowOverlayChangedDelegate ShowOverlayChanged;

        public void NotifyShowOverlayChanged(bool fromView, bool showOverlay)
        {
            ShowOverlayChanged?.Invoke(fromView, showOverlay);
        }

        public delegate void OnOverlayAutoHideChangedDelegate(bool fromView, bool autoHide);

        public event OnOverlayAutoHideChangedDelegate OverlayAutoHideChanged;

        public void NotifyOverlayAutoHideChanged(bool fromView, bool autoHide)
        {
            OverlayAutoHideChanged?.Invoke(fromView, autoHide);
        }

        public delegate void OnActivatedProcessPathChangedDelegate(bool fromView, string path, uint pid);

        public event OnActivatedProcessPathChangedDelegate ActivatedProcessPathChanged;

        public void NotifyActivatedProcessPathChanged(bool fromView, string path, uint pid)
        {
            ActivatedProcessPathChanged?.Invoke(fromView, path, pid);
        }

        public delegate void OnUpdateCheckingStarted(bool fromView);

        public event OnUpdateCheckingStarted UpdateCheckingStarted;

        public void NotifyUpdateCheckingStarted(bool fromView)
        {
            UpdateCheckingStarted?.Invoke(fromView);
        }

        public delegate void OnNewVersionIgnored(bool fromView, string ignoredVersion);

        public event OnNewVersionIgnored NewVersionIgnored;

        public void NotifyNewVersionIgnored(bool fromView, string ignoredVersion)
        {
            NewVersionIgnored?.Invoke(fromView, ignoredVersion);
        }

        public delegate void OnVersionChecked(bool fromView, UpdateChecker.VersionInfo versionInfo, bool forceNotify);

        public event OnVersionChecked VersionChecked;

        public void NotifyVersionChecked(bool fromView, UpdateChecker.VersionInfo versionInfo, bool forceNotify)
        {
            VersionChecked?.Invoke(fromView, versionInfo, forceNotify);
        }

        public delegate void OnShortcutChanged(bool fromView, Shortcut shortcut, Keys key);

        public event OnShortcutChanged ShortcutChanged;

        public void NotifyShortcutChanged(bool fromView, Shortcut shortcut, Keys key)
        {
            ShortcutChanged?.Invoke(fromView, shortcut, key);
        }

        public delegate void OnShortcutRegister(bool fromView, Shortcut shortcut, bool isRegister,
            bool success);

        public event OnShortcutRegister ShortcutRegister;


        public void NotifyShortcutRegister(bool fromView, Shortcut shortcut, bool isRegister,
            bool success)
        {
            ShortcutRegister?.Invoke(fromView, shortcut, isRegister, success);
        }

        public delegate void OnShortcutFired(bool fromView, Shortcut shortcut);

        public event OnShortcutFired ShortcutFired;

        public void NotifyShortcutFired(bool fromView, Shortcut shortcut)
        {
            ShortcutFired?.Invoke(fromView, shortcut);
        }

    }
}
