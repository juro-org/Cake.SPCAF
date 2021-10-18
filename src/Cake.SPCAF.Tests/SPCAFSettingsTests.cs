using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.SPCAF.Tests
{
    using Cake.Core.IO;
    using Cake.Testing;

    using NUnit.Framework;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    [TestOf(typeof(SPCAFSettings))]
    public class SPCAFSettingsTests
    {
        internal static IEnumerable<(Action<SPCAFSettings>, string)> Data
        {
            get
            {
                yield return (s => s.Report.Add(Enums.Report.Html), "-r \"HTML\"");
                yield return (s => { s.Report.Add(Enums.Report.Html); s.Report.Add(Enums.Report.Xml); }, "-r \"HTML;XML\"");
                yield return (s => s.Output = new FilePath("/File1.txt"), "-o \"/File1.txt\"");
                yield return (s => { s.Inputfiles.Add(new FilePath("/File1.txt")); }, "-i \"/File1.txt\"");
                yield return (s => { s.Inputfiles.Add(new FilePath("/File1.txt")); s.Inputfiles.Add(new DirectoryPath("/Directory")); }, "-i \"/File1.txt\";\"/Directory\"");
                yield return (s => s.Filters = "*.wsp,*.dll", "-f *.wsp,*.dll");
                yield return (s => s.Settings = new FilePath("/File1.txt"), "-s \"/File1.txt\"");
                yield return (s => s.Tempdir = new DirectoryPath("/Directory"), "-t \"/Directory\"");
                yield return (s => s.LogFile = new FilePath("/File1.txt"), "-l \"/File1.txt\"");
                yield return (s => s.Verbosity = Enums.Verbosity.Normal, "-v Normal");
                yield return (s => s.Recursive = true, "-c");
                yield return (s => s.SkipProjectCreation = true, "-p");
                yield return (s => s.Help = true, "-help");
                yield return (s => s.About = true, "-a");
            }
        }

        public static IEnumerator<object[]> TestData
        {
            get
            {
                return Data.Select(x => new[] { (object)x.Item1, x.Item2 }).GetEnumerator();
            }
        }

        [Test, TestCaseSource(nameof(TestData))]
        public void Test_all_setters(Action<SPCAFSettings> arrange, string expected)
        {
            var builder = new ProcessArgumentBuilder();
            var environment = FakeEnvironment.CreateWindowsEnvironment();
            var settings = new SPCAFSettings();

            arrange(settings);

            settings.Evaluate(builder, environment);
            var actual = builder.Render();
            Assert.AreEqual(expected, actual);
        }
    }
}
