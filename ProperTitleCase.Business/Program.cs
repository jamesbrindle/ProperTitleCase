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
            List<string> titles = File.ReadAllLines(@"D:\Desktop\Folder Structure Download - Static.csv").ToList();

            List<string> additionalAbbreviations = new List<string>
            {
                "FAT",
                "SAT",
                "WAS",
                "Psmt",

            };

            var processedTitles = TitleCaseConverter.ToProperTitleCase(titles, new TitleCaseConverter.Options { AdditionalAbbreviations = additionalAbbreviations });

            foreach (var title in processedTitles)
                Console.WriteLine(title);

            Console.In.ReadLine();
        }
    }
}
