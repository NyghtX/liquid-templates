using System.Collections.Generic;
using LiquidTemplates.Csharp.Templates.Base;

namespace LiquidTemplates.Csharp.Templates.Class.Property
{
    /// <summary>
    ///     PlaceHolder, die vom PropertyTemplate verwendet werden
    /// </summary>
    internal static class PropertyTemplatePlaceholder
    {
        public const string PropertyType = "PROPERTYTYPE";
        public const string PropertyName = "PROPERTYNAME";
        public const string PropertyEnd = "PROPERTYEND";
        
        /// <summary>
        ///     Placeholder, die zur Verfügung stehen
        /// </summary>
        public static Dictionary<string, TemplatePlaceholder> Placeholders = new Dictionary<string, TemplatePlaceholder>
        {
            {PropertyType, new TemplatePlaceholder(PropertyType, true, false)},
            {PropertyName, new TemplatePlaceholder(PropertyName, true, false)},
            {PropertyEnd, new TemplatePlaceholder(PropertyEnd)}
        };
    }
}