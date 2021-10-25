namespace Cake.SPCAF.Tests
{
    using Cake.Core.IO;
    using Cake.SPCAF;
    using Cake.Testing;

    using NUnit.Framework;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    [TestOf(typeof(SPCAFSettings))]
    public class FluentSPCAFSettingsTests
    {
        internal static IEnumerable<(Action<FluentSPCAFSettings>, string)> Data
        {
            get
            {
                yield return (s => s.WithHtmlReport(), "-r \"HTML\"");
                yield return (s => s.WithHtmlReport().WithXmlReport(), "-r \"HTML;XML\"");
                yield return (s => s.WithOutput(new FilePath("/File1.txt")), "-o \"\\File1.txt\"");
                yield return (s => s.WithInput(new FilePath("/File1.txt")), "-i \"\\File1.txt\"");
                yield return (s => s.WithInput(new FilePath("/File1.txt"), new DirectoryPath("/Directory")), "-i \"\\File1.txt\";\"\\Directory\"");
                yield return (s => s.WithFilters("*.wsp,*.dll"), "-f *.wsp,*.dll");
                yield return (s => s.WithSettings(new FilePath("/File1.txt")), "-s \"\\File1.txt\"");
                yield return (s => s.WithTempDir(new DirectoryPath("/Directory")), "-t \"\\Directory\"");
                yield return (s => s.WithLogFile(new FilePath("/File1.txt")), "-l \"\\File1.txt\"");
                yield return (s => s.WithNormalVerbosity(), "-v Normal");
                yield return (s => s.Recursive(), "-c");
                yield return (s => s.SkipProjectCreation(), "-p");
                yield return (s => s.Help(), "-help");
                yield return (s => s.About(), "-a");
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
        public void Test_all_setters(Action<FluentSPCAFSettings> arrange, string expected)
        {
            var builder = new ProcessArgumentBuilder();
            var environment = FakeEnvironment.CreateWindowsEnvironment();
            var settings = new SPCAFSettings();
            var fluentSettings = new FluentSPCAFSettings(settings);
            arrange(fluentSettings);

            settings.Evaluate(builder, environment);
            var actual = builder.Render();
            Assert.AreEqual(expected, actual);
        }
    }
}
