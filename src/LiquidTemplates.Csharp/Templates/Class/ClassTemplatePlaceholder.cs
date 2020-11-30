using System.Collections.Generic;
using LiquidTemplates.Csharp.Templates.Base;

namespace LiquidTemplates.Csharp.Templates.Class
{
    /// <summary>
    ///     PlaceHolder, die vom ClassTemplate verwendet werden
    /// </summary>
    internal static class ClassTemplatePlaceholder
    {
        public const string Usings = "USINGS";
        public const string Namespace = "NAMESPACE";
        public const string Classname = "CLASSNAME";
        public const string AccessModifier = "ACCESSMODIFIER";

        /// <summary>
        ///     Placeholder, die zur Verfügung stehen
        /// </summary>
        public static Dictionary<string, TemplatePlaceholder> Placeholders = new Dictionary<string, TemplatePlaceholder>
        {
            {Classname, new TemplatePlaceholder(Classname, true, false)},
            {Namespace, new TemplatePlaceholder(Namespace, true, false)},
            {AccessModifier, new TemplatePlaceholder(AccessModifier, true, false)},
            {Usings, new TemplatePlaceholder(Usings)}
        };
    }
}