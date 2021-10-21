namespace Cake.SPCAF.Builder
{
    using Cake.Core.IO;

    /// <summary>
    /// Extensions for SPCAFSetting to generate fluent api.
    /// </summary>
    public static partial class SPCAFSettingsExtensions {
        /// <summary>
        /// Sets the tool path.
        /// </summary>
        /// <param name="this">The SPCAFSettings for the command build.</param>
        /// <param name="filePath">The tool path.</param>
        /// <returns>The SPCAFSettings instance for fluent re-use.</returns>
        public static SPCAFSettings WithToolPath(this SPCAFSettings @this, FilePath filePath)
        {
            @this.ToolPath = filePath;
            return @this;
        }
    }
}
