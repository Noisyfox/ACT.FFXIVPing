using System.Text.RegularExpressions;
using ACT.FoxCommon;
using ACT.FoxCommon.update;

namespace ACT.FFXIVPing
{
    public class UpdateChecker : UpdateCheckerBase<MainController, FFXIVPingPlugin>
    {
        public const string ReleasePage = "https://github.com/Noisyfox/ACT.FFXIVPing/releases";

        protected override string UpdateUrl { get; } = "https://api.github.com/repos/Noisyfox/ACT.FFXIVPing/releases";

        private const string NameMatcher =
            @"^ACT\.FFXIVPing(?:-|\.)(?<version>\d+(?:\.\d+)*)(?:|-Release)\.7z$";

        protected override string ParseVersion(string fileName)
        {
            var match = Regex.Match(fileName, NameMatcher);
            if (match.Success)
            {
                return match.Groups["version"].Value;
            }

            return null;
        }
    }
}
