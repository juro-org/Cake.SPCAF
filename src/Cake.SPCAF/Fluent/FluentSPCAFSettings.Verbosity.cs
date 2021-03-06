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
        /// Set the amount of information to "debug".
        /// </summary>
        /// <returns>The FluentSPCAFSettings instance for fluent re-use.</returns>
        public FluentSPCAFSettings WithDebugVerbosity()
        {
            this.settings.Verbosity = Enums.Verbosity.Debug;
            return this;
        }

        /// <summary>
        /// Set the amount of information to "minimal".
        /// </summary>
        /// <returns>The FluentSPCAFSettings instance for fluent re-use.</returns>
        public FluentSPCAFSettings WithMinimalVerbosity()
        {
            this.settings.Verbosity = Enums.Verbosity.Minimal;
            return this;
        }

        /// <summary>
        /// Set the amount of information to "normal".
        /// </summary>
        /// <returns>The FluentSPCAFSettings instance for fluent re-use.</returns>
        public FluentSPCAFSettings WithNormalVerbosity()
        {
            this.settings.Verbosity = Enums.Verbosity.Normal;
            return this;
        }

        /// <summary>
        /// Set the amount of information to "quiet".
        /// </summary>
        /// <returns>The FluentSPCAFSettings instance for fluent re-use.</returns>
        public FluentSPCAFSettings WithQuietVerbosity()
        {
            this.settings.Verbosity = Enums.Verbosity.Quiet;
            return this;
        }
    }
}
