using System;

namespace TitleCase.Models
{
    /// <summary>
    /// Form configurations settings model - Serializable to be saved to XML File
    /// </summary>
    [Serializable]
    public class ConfigModel
    {
        /// <summary>
        /// Form configurations settings model - Serializable to be saved to XML File
        /// </summary>
        public ConfigModel()
        { }

        public string Titles { get; set; }

        public string AdditionalAbbreviations { get; set; }

        public bool ProcessCommonAbbreviations { get; set; } = true;

        public bool FormatMeasurments { get; set; } = true;

        public bool KeepTypicalLowercase { get; set; } = true;

        public bool RemoveStartEndEndQuotes { get; set; } = true;

        public bool RemoveDoubleSymbols { get; set; } = true;

        public bool DictionaryLookup { get; set; } = true;

        public int MaxDictionaryLookupLetters { get; set; } = 4;

        public bool RemoveEmptyLines { get; set; } = true;
    }
}
