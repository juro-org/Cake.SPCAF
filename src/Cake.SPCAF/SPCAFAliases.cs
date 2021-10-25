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

namespace Cake.SPCAF
{
    using System;
    using Cake.Core;
    using Cake.Core.Annotations;

    /// <summary>
    /// Provides a wrapper around SPCAF functionality within a Cake build script.
    /// </summary>
    [CakeAliasCategory("SPCAF")]
    public static class SPCAFAliases
    {
        /// <summary>
        /// Get SPCAF runner for fluent configuration.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="config">The fluent configuration action.</param>
        [CakeMethodAlias]
        public static void SPCAF(this ICakeContext context, Action<FluentSPCAFSettings> config)
        {
            var settings = new SPCAFSettings();
            var fluentSettings = new FluentSPCAFSettings(settings);
            config(fluentSettings);
            SPCAF(context, settings);
        }

        /// <summary>
        /// Get SPCAF runner.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">the settings.</param>
        [CakeMethodAlias]
        public static void SPCAF(this ICakeContext context, SPCAFSettings settings)
        {
            var runner = new SPCAFRunner(
                context.FileSystem,
                context.Environment,
                context.ProcessRunner,
                context.Tools);
            runner.Run(settings);
        }
    }
}
