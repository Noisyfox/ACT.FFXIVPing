using System.Drawing;
using System.Windows.Forms;
using ACT.FoxCommon;
using ACT.FoxCommon.core;

namespace ACT.FFXIVPing
{
    public class MainController : MainControllerBase
    {
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

    }
}
