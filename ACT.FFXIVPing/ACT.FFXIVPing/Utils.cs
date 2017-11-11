using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media;
using FontFamily = System.Windows.Media.FontFamily;

namespace ACT.FFXIVPing
{
    internal static class Utils
    {

        public static bool IsGameExePath(string path)
        {
            var exe = Path.GetFileName(path);
            return exe == "ffxiv.exe" || exe == "ffxiv_dx11.exe";
        }

        public static bool IsActExePath(string path)
        {
            return path == Process.GetCurrentProcess().MainModule.FileName;
        }

        public static Typeface NewTypeFaceFromFont(Font f)
        {
            var ff = new FontFamily(f.Name);

            var typeface = new Typeface(ff,
                f.Style.HasFlag(System.Drawing.FontStyle.Italic) ? FontStyles.Italic : FontStyles.Normal,
                f.Style.HasFlag(System.Drawing.FontStyle.Bold) ? FontWeights.Bold : FontWeights.Normal,
                FontStretches.Normal);

            return typeface;
        }

        public static bool IsGameExeProcess(uint pid)
        {
            return IsGameExePath(Process.GetProcessById((int) pid).MainModule.FileName);
        }

        public static bool IsGameExeProcess(Process p)
        {
            return IsGameExePath(p.MainModule.FileName);
        }
    }
}
