using System.Threading;

namespace TitleCaser.Helpers
{
    /// <summary>
    /// Language specific function
    /// </summary>
    internal class CultureHelper
    {
        /// <summary>
        /// GB uses the date format: dd-MM-yyyy
        /// </summary>
        internal static void GloballySetCultureToGB()
        {
            var culture = new System.Globalization.CultureInfo("en-GB");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }
    }
}
