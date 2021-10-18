namespace Cake.SPCAF.Enums
{
    public class Verbosity : EnumBaseType
    {
        /// <summary>
        /// No Output.
        /// </summary>
        public static readonly Verbosity Quiet = new Verbosity("Quiet");
        /// <summary>
        /// Only notifications are listed (typically used in automated builds).
        /// </summary>
        public static readonly Verbosity Minimal = new Verbosity("Minimal");
        /// <summary>
        /// Notifications and status information are listed.This is the default setting.
        /// </summary>
        public static readonly Verbosity Normal = new Verbosity("Normal");
        /// <summary>
        /// Notifications, status information, and errors are listed.
        /// </summary>
        public static readonly Verbosity Debug = new Verbosity("Debug");

        private Verbosity(string value)
            : base(value)
        {
        }
    }
}
