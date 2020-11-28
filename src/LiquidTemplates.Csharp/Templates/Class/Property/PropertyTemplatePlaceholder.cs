using System.Collections.Generic;

namespace LiquidTemplates.Csharp.Templates.Class.Property
{
    /// <summary>
    ///     PlaceHolder, die vom PropertyTemplate verwendet werden
    /// </summary>
    internal static class PropertyTemplatePlaceholder
    {
        public const string PropertyType = "PROPERTYTYPE";
        public const string PropertyName = "PROPERTYNAME";
        public const string AccessModifier = "ACCESSMODIFIER";
        public const string PropertyEnd = "PROPERTYEND";

        /// <summary>
        ///     Placeholder, die zur Verfügung stehen
        /// </summary>
        public static IEnumerable<string> All = new[]
        {
            AccessModifier,
            PropertyType,
            PropertyName,
            PropertyEnd
        };

        /// <summary>
        ///     Placeholder, die gefüllt werden müssen
        /// </summary>
        public static IEnumerable<string> Required = new[]
        {
            AccessModifier,
            PropertyType,
            PropertyName,
            PropertyEnd
        };
    }
}