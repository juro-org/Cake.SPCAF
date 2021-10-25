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
    using System.Reflection;
    using System.Runtime.Serialization;
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Tooling;
    using Cake.SPCAF.Extensions;

    /// <summary>
    /// SPCAF tool settings.
    /// </summary>
    public sealed class SPCAFSettings : ToolSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SPCAFSettings" /> class.
        /// </summary>
        public SPCAFSettings()
        {
            this.Report = new List<Enums.Report>();
            this.InputFiles = new List<Path>();
        }

        /// <summary>
        /// Gets the report generator that will be used to generate the output file. Visual Studio compatible console output will be generated regardless of this argument.
        /// </summary>
        [DataMember(Name = "r")]
        public List<Enums.Report> Report { get; }

        /// <summary>
        /// Gets or sets the output file with processed data when a report generator is specified.
        /// </summary>
        [DataMember(Name = "o")]
        public FilePath Output { get; set; }

        /// <summary>
        /// Gets the required location of files to be included in the analysis.
        /// </summary>
        [DataMember(Name = "i")]
        public List<Path> InputFiles { get; }

        /// <summary>
        /// Gets or sets a list of regular expressions, separated by a semicolon which is applied as filters for the input files.Helpful if argument input files is a directory.Only the input files which match the filter are analyzed.
        /// </summary>
        [DataMember(Name = "f")]
        public string Filters { get; set; }

        /// <summary>
        /// Gets or sets the name of SPCAF ruleset file.
        /// </summary>
        [DataMember(Name = "s")]
        public FilePath Settings { get; set; }

        /// <summary>
        /// Gets or sets directory into which all temporary files are extract.
        /// </summary>
        [DataMember(Name = "t")]
        public DirectoryPath TempDir { get; set; }

        /// <summary>
        /// Gets or sets the path where the log file should be written to.
        /// </summary>
        [DataMember(Name = "l")]
        public FilePath LogFile { get; set; }

        /// <summary>
        /// Gets or sets the amount of information to display in the output window.
        /// </summary>
        [DataMember(Name = "v")]
        public Enums.Verbosity Verbosity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to scan the input folder recursively for analyzable files.
        /// This is to be used if you have files in subfolders.
        /// </summary>
        [DataMember(Name = "c")]
        public bool Recursive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to skip the creation of a .spcaf project file.
        /// </summary>
        [DataMember(Name = "p")]
        public bool SkipProjectCreation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the help is shown.
        /// </summary>
        [DataMember(Name = "help")]
        public bool Help { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the information about the software is shown.
        /// </summary>
        [DataMember(Name = "a")]
        public bool About { get; set; }

        /// <summary>
        /// Evaluate the given properties.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="environment">The enviroment.</param>
        public void Evaluate(ProcessArgumentBuilder builder, ICakeEnvironment environment)
        {
            this.GetType()
                .GetProperties()
                .ToList()
                .ForEach(p =>
                {
                    var attr = p.GetCustomAttribute(typeof(DataMemberAttribute)) as DataMemberAttribute;
                    if (attr == null)
                    {
                        return;
                    }

                    if (p.PropertyType == typeof(string))
                    {
                        var value = p.GetValue(this) as string;
                        if (string.IsNullOrWhiteSpace(value))
                        {
                            return;
                        }

                        builder.Append(string.Format("-{0} {1}", attr.Name, value));
                        return;
                    }

                    if (p.PropertyType == typeof(bool))
                    {
                        var value = p.GetValue(this) as bool?;
                        if (!value.HasValue || !value.Value)
                        {
                            return;
                        }

                        builder.Append(string.Format("-{0}", attr.Name));
                        return;
                    }

                    if (p.PropertyType.BaseType == typeof(Enums.EnumBaseType))
                    {
                        var value = p.GetValue(this) as Enums.EnumBaseType;
                        if (value == null)
                        {
                            return;
                        }

                        builder.Append(string.Format("-{0} {1}", attr.Name, value.ToString()));
                        return;
                    }

                    if (p.PropertyType == typeof(FilePath))
                    {
                        var value = p.GetValue(this) as FilePath;
                        if (value == null)
                        {
                            return;
                        }

                        builder.Append(string.Format("-{0} {1}", attr.Name, CakePath.AbsolutePathQuoted(value, environment)));
                        return;
                    }

                    if (p.PropertyType == typeof(DirectoryPath))
                    {
                        var value = p.GetValue(this) as DirectoryPath;
                        if (value == null)
                        {
                            return;
                        }

                        builder.Append(string.Format("-{0} {1}", attr.Name, CakePath.AbsolutePathQuoted(value, environment)));
                        return;
                    }

                    if (p.PropertyType.GenericTypeArguments.Length > 0 && p.PropertyType.GenericTypeArguments[0].BaseType == typeof(Enums.EnumBaseType))
                    {
                        var value = p.GetValue(this) as IEnumerable<Enums.EnumBaseType>;
                        if (value == null || !value.Any())
                        {
                            return;
                        }

                        builder.Append(string.Format("-{0} \"{1}\"", attr.Name, string.Join(";", value)));
                        return;
                    }

                    if (p.PropertyType.GenericTypeArguments.Length > 0 && p.PropertyType.GenericTypeArguments[0] == typeof(Path))
                    {
                        var value = p.GetValue(this) as IEnumerable<Path>;
                        if (value == null || !value.Any())
                        {
                            return;
                        }

                        var fullPaths = value.Select(s => CakePath.AbsolutePathQuoted(s, environment).Quote()).ToArray();

                        builder.Append(string.Format("-{0} {1}", attr.Name, string.Join(";", fullPaths)));
                        return;
                    }

                    throw new ArgumentOutOfRangeException($"Unknown PropertyType {p.PropertyType} of property {p.Name}", new NotImplementedException());
                });
        }
    }
}
