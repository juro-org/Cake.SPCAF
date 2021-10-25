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

namespace Cake.SPCAF.Extensions
{
    using System;
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// Helper class for cake Path.
    /// </summary>
    internal static class CakePath
    {
        /// <summary>
        /// Makes the path absolute (if relative) using the current working directory.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="envoriment">The enviroment.</param>
        /// <returns>An absolute path.</returns>
        internal static string AbsolutePath(Path path, ICakeEnvironment envoriment)
        {
            if (path is FilePath filePath)
            {
                return filePath.MakeAbsolute(envoriment).FullPath.Replace("/", "\\");
            }

            if (path is DirectoryPath directoryPath)
            {
                return directoryPath.MakeAbsolute(envoriment).FullPath.Replace("/", "\\");
            }

            throw new ArgumentOutOfRangeException("path", "Should be FilePath or DirectoryPath");
        }

        /// <summary>
        /// Makes the path absolute (if relative) using the current working directory and quotes it.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="envoriment">The enviroment.</param>
        /// <returns>An absolute path - quoted.</returns>
        internal static string AbsolutePathQuoted(Path path, ICakeEnvironment envoriment)
        {
            return CakePath.AbsolutePath(path, envoriment).Quote();
        }
    }
}
