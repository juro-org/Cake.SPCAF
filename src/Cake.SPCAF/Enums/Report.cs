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

namespace Cake.SPCAF.Enums
{
    /// <summary>
    /// Report generator types.
    /// </summary>
    public class Report : EnumBaseType
    {
        /// <summary>
        /// None generator - console output will be generated regardless of this argument.
        /// </summary>
        public static readonly Report None = new Report("None");

        /// <summary>
        /// Html generator.
        /// </summary>
        public static readonly Report Html = new Report("HTML");

        /// <summary>
        /// Xml generator.
        /// </summary>
        public static readonly Report Xml = new Report("XML");

        /// <summary>
        /// Csv generator.
        /// </summary>
        public static readonly Report Csv = new Report("CSV");

        private Report(string value)
            : base(value)
        {
        }
    }
}
