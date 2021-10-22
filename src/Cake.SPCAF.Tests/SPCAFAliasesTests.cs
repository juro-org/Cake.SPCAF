/*
 * MIT License
 *
 * Copyright (c) 2021 Jürgen Rosenthal-Buroh
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

namespace Cake.SPCAF.Tests
{
    using Cake.Core.IO;
    using NUnit.Framework;
    using Shouldly;

    [TestFixture]
    [TestOf(typeof(SPCAFAliases))]
    public class SPCAFAliasesTests
    {
        [Test]
        public void JustCallSPCAF()
        {
            var fixture = new SPCAFAliasesFixture();

            fixture.Settings = null;
            var actual = fixture.Run();

            actual.Args.ShouldBe("");
        }

        [Test]
        public void SPCAF_SimpleDemo()
        {
            var fixture = new SPCAFAliasesFixture();

            //spcaf.exe -i "C:\wspfiles" -r "HTML;XML" -o "C:\outputdir\outputfilename.html"
            fixture.Settings = new SPCAFSettings();
            fixture.Settings.Report.Add(Enums.Report.Html);
            fixture.Settings.Report.Add(Enums.Report.Xml);
            fixture.Settings.InputFiles.Add(new DirectoryPath(@"C:/wspfiles"));
            fixture.Settings.Output = new FilePath(@"C:/outputdir/outputfilename.html");
            var actual = fixture.Run();

            actual.Args.ShouldBe(@"-r ""HTML;XML"" -o ""C:\outputdir\outputfilename.html"" -i ""C:\wspfiles""");
        }
    }
}
