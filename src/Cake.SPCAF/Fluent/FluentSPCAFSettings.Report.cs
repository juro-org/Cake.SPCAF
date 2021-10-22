// MIT License
//
// Copyright (c) 2021 Jürgen Rosenthal-Buroh
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

namespace Cake.SPCAF
{
    /// <summary>
    /// Wrapper for SPCAFSetting to generate fluent api.
    /// </summary>
    public partial class FluentSPCAFSettings
    {
        /// <summary>
        /// Csv generator that will be used to generate the output file.
        /// </summary>
        /// <returns>The FluentSPCAFSettings instance for fluent re-use.</returns>
        public FluentSPCAFSettings WithCsvReport()
        {
            this.settings.Report.Add(Enums.Report.Csv);
            return this;
        }

        /// <summary>
        /// Html generator that will be used to generate the output file.
        /// </summary>
        /// <returns>The FluentSPCAFSettings instance for fluent re-use.</returns>
        public FluentSPCAFSettings WithHtmlReport()
        {
            this.settings.Report.Add(Enums.Report.Html);
            return this;
        }

        /// <summary>
        /// None generator. Visual Studio compatible console output will be generated regardless of this argument.
        /// </summary>
        /// <returns>The FluentSPCAFSettings instance for fluent re-use.</returns>
        public FluentSPCAFSettings WithNoneReport()
        {
            this.settings.Report.Add(Enums.Report.None);
            return this;
        }

        /// <summary>
        /// XML generator that will be used to generate the output file.
        /// </summary>
        /// <returns>The FluentSPCAFSettings instance for fluent re-use.</returns>
        public FluentSPCAFSettings WithXmlReport()
        {
            this.settings.Report.Add(Enums.Report.Xml);
            return this;
        }
    }
}
