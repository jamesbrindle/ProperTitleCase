# ProperTitleCase

* .NET Framework 4.8
* C#

A solution to convert a string, or list of strings to 'proper' title case. It attemps to keep measurement cases, acronym / abbreviations in their correct cases and uses various techniques should as regular expressions and dictionaries.

## Example Usage:

```
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
```

## Options

* AdditionalAbbreviations (List<string>)
* LookupCommonAbbreviations (boolean)
* KeepTypicalAllLowers (boolean)
* FormatMeasurements (boolean)
* MaxDictionaryLookupWordLength (int [0 to disable])

### Additional Abbreviations

Suppier your own list of abbreviations to ensure the proper case

### Lookup Common Abbreviations

There is a large list of common abbreviations set-up alread and it will use them by default. You can set this to false to not use them.

### Keep Typical AllLowers

Typically, words such as:

 "and", "as", "at", "for" etc, even in a title are always lowercase and this is the default behaviour. Set this to false to ignore this.

### Format Measurements

Measurment abbreviations and symbols have a specific case. I.e. `Gpbs`, `Hz`, `kWh`. When converting the function will pay attension to these and convert to the correct case. Set this to false to ignore this.

## Additiional Actions

* When something contains letters and number, or a mixure of special characters, they will be converted to all upercase. E.g. `293GH-34-IP-1A`
* It will pay attention to pleural abbreviations. E.g. `CSV's` or `CSVs`
* It will try to work out an abbreviation not in the list of common abbreviatioins, by also looking up a real UK dictionary (up to four letters or less).
  For example. The word 'svs' in not in the list of common abbreviatioins, but it's also not a real English word and it's 4 characters or less, so will be treated an an abbreviation and convert to uppercase.

## WinForms Application

There is also a WinForms application available:

![Screenshot](https://github.com/jamesbrindle/ProperTitleCase/blob/master/TitleCaser/screenshot.png?raw=true)

