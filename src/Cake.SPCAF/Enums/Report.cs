namespace Cake.SPCAF.Enums
{
    public class Report : EnumBaseType
    {
        public static readonly Report None = new Report("None");
        public static readonly Report Html = new Report(".html");
        public static readonly Report Xml = new Report(".xml");
        public static readonly Report Csv = new Report(".csv");

        private Report(string value)
            : base(value)
        {
        }
    }
}
