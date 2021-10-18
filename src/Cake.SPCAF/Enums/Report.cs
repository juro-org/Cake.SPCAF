namespace Cake.SPCAF.Enums
{
    public class Report : EnumBaseType
    {
        public static readonly Report None = new Report("None");
        public static readonly Report Html = new Report("HTML");
        public static readonly Report Xml = new Report("XML");
        public static readonly Report Csv = new Report("CSV");

        private Report(string value)
            : base(value)
        {
        }
    }
}
