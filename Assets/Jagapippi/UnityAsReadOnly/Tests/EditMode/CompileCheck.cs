using System.IO;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.Build.Player;

namespace Jagapippi.UnityAsReadOnly.Tests
{
    internal sealed class CompileCheck
    {
        private const string OUTPUT_FOLDER = "Temp/CompileCheck";

        [Test]
        public void StandaloneOSX() => Check(BuildTarget.StandaloneOSX, BuildTargetGroup.Standalone);

        [Test]
        public void StandaloneWindows() => Check(BuildTarget.StandaloneWindows, BuildTargetGroup.Standalone);

        [Test]
        public void iOS() => Check(BuildTarget.iOS, BuildTargetGroup.iOS);

        [Test]
        public void Android() => Check(BuildTarget.Android, BuildTargetGroup.Android);

        [Test]
        public void StandaloneLinux() => Check(BuildTarget.StandaloneLinux, BuildTargetGroup.Standalone);

        [Test]
        public void StandaloneWindows64() => Check(BuildTarget.StandaloneWindows64, BuildTargetGroup.Standalone);

        [Test]
        public void WebGL() => Check(BuildTarget.WebGL, BuildTargetGroup.WebGL);

        [Test]
        public void WSAPlayer() => Check(BuildTarget.WSAPlayer, BuildTargetGroup.WSA);

        [Test]
        public void StandaloneLinux64() => Check(BuildTarget.StandaloneLinux64, BuildTargetGroup.Standalone);

        [Test]
        public void StandaloneLinuxUniversal() => Check(BuildTarget.StandaloneLinuxUniversal, BuildTargetGroup.Standalone);

        [Test]
        public void PS4() => Check(BuildTarget.PS4, BuildTargetGroup.PS4);

        [Test]
        public void XboxOne() => Check(BuildTarget.XboxOne, BuildTargetGroup.XboxOne);

        [Test]
        public void tvOS() => Check(BuildTarget.tvOS, BuildTargetGroup.tvOS);

        [Test]
        public void Switch() => Check(BuildTarget.Switch, BuildTargetGroup.Switch);

        [Test]
        public void Lumin() => Check(BuildTarget.Lumin, BuildTargetGroup.Lumin);

        private static void Check(BuildTarget target, BuildTargetGroup group)
        {
            var input = new ScriptCompilationSettings
            {
                target = target,
                group = group,
            };

            var result = PlayerBuildInterface.CompilePlayerScripts(input, OUTPUT_FOLDER);
            var assemblies = result.assemblies;

            var isSuccess =
                    assemblies != null &&
                    assemblies.Count != 0 &&
                    result.typeDB != null
                ;

            if (Directory.Exists(OUTPUT_FOLDER))
            {
                Directory.Delete(OUTPUT_FOLDER, true);
            }

            Assert.IsTrue(isSuccess);
        }
    }
}