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
    using System.Collections.Generic;
    using System.Linq;
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Tooling;

    /// <summary>
    /// A wrapper around SPCAF functionality within a Cake build script.
    /// </summary>
    public sealed class SPCAFRunner : Tool<SPCAFSettings>
    {
        private ICakeEnvironment environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="SPCAFRunner" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public SPCAFRunner(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            this.environment = environment;
        }

        /// <summary>
        /// Starts the SPCAF run.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Run(SPCAFSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            this.Run(settings, this.GetArguments(settings));
        }

        /// <summary>
        /// Uses ToolPath from setting and the typically cli tool path C:\Program Files (x86)\SPCAF\' to get alternative tool paths.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>Alertanitive tool paths.</returns>
        protected override IEnumerable<FilePath> GetAlternativeToolPaths(SPCAFSettings settings)
        {
            var toolPaths = base.GetAlternativeToolPaths(settings).ToList();

            if (settings.ToolPath != null)
            {
                toolPaths.Add(settings.ToolPath);
            }

            var workDir = new DirectoryPath(@"C:\\Program Files (x86)\Rencore\SPCAF");
            return toolPaths.Union(new string[] { "spcaf.exe" }.Select(x => workDir.GetFilePath(new FilePath(x))));
        }

        /// <summary>
        /// Possible tool executable names.
        /// </summary>
        /// <returns>The tool executable names.</returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            yield return "SPCAF.exe";
            yield return "SPCAF";
        }

        /// <summary>
        /// SPCAF tool name.
        /// </summary>
        /// <returns>The tool name.</returns>
        protected override string GetToolName()
        {
            return "SPCAF";
        }

        /// <summary>
        /// Get the arguments from the settings.
        /// </summary>
        /// <param name="settings">The SPCAF settings.</param>
        /// <returns>The process argument builder.</returns>
        private ProcessArgumentBuilder GetArguments(SPCAFSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var builder = new ProcessArgumentBuilder();
            settings.Evaluate(builder, this.environment);
            return builder;
        }
    }
}
