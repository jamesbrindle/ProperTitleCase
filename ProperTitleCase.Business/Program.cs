using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TitleCaser
{
    internal class Program
    {
        static void Main()
        {
            List<string> titles = File.ReadAllLines(@"C:\Temp\test.csv").ToList();

            List<string> additionalAbbreviations = new List<string>
            {
                "Psmt",
                "CCGS",
                "BBA"
            };

            var processedTitles = TitleCaseConverter.ToProperTitleCase(
                titles,
                new TitleCaseConverter.Options
                {
                    AdditionalAbbreviations = additionalAbbreviations
                });

            foreach (var title in processedTitles)
                Console.WriteLine(title);

            Console.In.ReadLine();
        }
    }
}
