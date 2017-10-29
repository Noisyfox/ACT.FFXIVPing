using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ACT.FFXIVPing
{
    /// <summary>
    /// PingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PingWindow : Window, IPluginComponent
    {
        private MainController _controller;

        private IntPtr _handle;

        private bool _isClosed = false;

        private bool _showOverlay = false;
        private bool _autoHide = false;
        private string _activatedExePath = null;

        public PingWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _handle = new WindowInteropHelper(this).Handle;
            _isClosed = false;
        }

        public void AttachToAct(FFXIVPingPlugin plugin)
        {
            _controller = plugin.Controller;

            _controller.OverlayMoved += ControllerOnOverlayMoved;
            _controller.OverlayResized += ControllerOnOverlayResized;
            _controller.OpacityChanged += ControllerOnOpacityChanged;
            _controller.ClickthroughChanged += ControllerOnClickthroughChanged;
            _controller.OverlayAutoHideChanged += ControllerOnOverlayAutoHideChanged;
            _controller.ShowOverlayChanged += ControllerOnShowOverlayChanged;
            _controller.ActivatedProcessPathChanged += ControllerOnActivatedProcessPathChanged;
        }

        public void PostAttachToAct(FFXIVPingPlugin plugin)
        {
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _controller.OverlayMoved -= ControllerOnOverlayMoved;
            _controller.OverlayResized -= ControllerOnOverlayResized;
            _controller.OpacityChanged -= ControllerOnOpacityChanged;
            _controller.ClickthroughChanged -= ControllerOnClickthroughChanged;
            _controller.OverlayAutoHideChanged -= ControllerOnOverlayAutoHideChanged;
            _controller.ShowOverlayChanged -= ControllerOnShowOverlayChanged;
            _controller.ActivatedProcessPathChanged -= ControllerOnActivatedProcessPathChanged;

            _isClosed = true;
        }

        private void ControllerOnOverlayMoved(bool fromView, int x, int y)
        {
            if (fromView)
            {
                return;
            }

            Top = y;
            Left = x;
        }

        private void ControllerOnOverlayResized(bool fromView, int w, int h)
        {
            if (fromView)
            {
                return;
            }

            Width = w;
            Height = h;
        }

        private void ControllerOnOpacityChanged(bool fromView, double value)
        {
            if (fromView)
            {
                return;
            }

            Background.Opacity = value;
        }

        private void ControllerOnClickthroughChanged(bool fromView, bool clickthrough)
        {
            if (fromView)
            {
                return;
            }
            Win32APIUtils.SetWS_EX_TRANSPARENT(_handle, clickthrough);

//            var v = clickthrough ? Visibility.Collapsed : Visibility.Visible;
//            ThumbResize.Visibility = v;
//            ThumbMove.Visibility = v;
        }

        private void ControllerOnOverlayAutoHideChanged(bool fromView, bool autoHide)
        {
            _autoHide = autoHide;
            CheckVisibility();
        }

        private void ControllerOnShowOverlayChanged(bool fromView, bool showOverlay)
        {
            _showOverlay = showOverlay;
            CheckVisibility();
        }

        private void ControllerOnActivatedProcessPathChanged(bool fromView, string path)
        {
            _activatedExePath = path;
            CheckVisibility();
        }

        private void CheckVisibility()
        {
            var targetVisible = false;
            if (_showOverlay && _autoHide)
            {
                if (_activatedExePath == null)
                {
                    targetVisible = true;
                }
                else
                {
                    if (Utils.IsGameExePath(_activatedExePath) || Utils.IsActExePath(_activatedExePath))
                    {
                        targetVisible = true;
                    }
                }
            }
            else
            {
                targetVisible = _showOverlay;
            }

            ApplyVisibility(targetVisible);
        }

        private void ApplyVisibility(bool visibility)
        {
            if (Dispatcher.CheckAccess())
            {
                if (_isClosed)
                {
                    return;
                }
                var t = visibility ? Visibility.Visible : Visibility.Hidden;
                if (Visibility != t)
                {
                    Visibility = t;
                }
            }
            else
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
                {
                    ApplyVisibility(visibility);
                }));
            }
        }
    }
}
