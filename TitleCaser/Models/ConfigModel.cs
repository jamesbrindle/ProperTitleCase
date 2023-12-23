using System;

namespace TitleCaser.Models
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

        public bool ProcessCommonAbbreviations { get; set; }

        public bool FormatMeasurments { get; set; }

        public bool KeepTypicalLowercase { get; set; }

        public bool RemoveStartEndEndQuotes { get; set; }

        public bool RemoveDoubleSymbols { get; set; }
    }
}
