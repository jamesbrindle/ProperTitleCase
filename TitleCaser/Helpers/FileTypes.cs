using System.Linq;

namespace TitleCaser.Helpers
{
    /// <summary>
    /// Arrays of common, applicable file types
    /// </summary>
    public static class FileTypes
    {
        // I.e. .txt
        public static string[] Text
        {
            get
            {
                string[] ext = new string[] { ".txt" };
                string[] extNoDot = ext.Select(x => x.Replace(".", "")).ToArray();

                return ext.Concat(extNoDot).ToArray();
            }
        }

        /// <summary>
        /// I.e. .csv, .tsv
        /// </summary>
        public static string[] Csv
        {
            get
            {
                string[] ext = new string[] { ".csv", ".tsv" };
                string[] extNoDot = ext.Select(x => x.Replace(".", "")).ToArray();

                return ext.Concat(extNoDot).ToArray();
            }
        }
    }
}
