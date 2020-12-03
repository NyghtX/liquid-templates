using System.Collections.Generic;
using LiquidTemplates.Replacement;

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
        public const string Property = "PROPERTY";
        public const string Method = "METHOD";
        public const string Inheritance = "INHERITANCE";
        public const string Implements = "IMPLEMENTS";

        /// <summary>
        ///     Placeholder, die zur Verfügung stehen
        /// </summary>
        public static Dictionary<string, TemplatePlaceholder> Placeholders = new Dictionary<string, TemplatePlaceholder>
        {
            {Classname, new TemplatePlaceholder(Classname, true, false)},
            {Namespace, new TemplatePlaceholder(Namespace, true, false)},
            {AccessModifier, new TemplatePlaceholder(AccessModifier, true, false)},
            {Usings, new TemplatePlaceholder(Usings)},
            {Property, new TemplatePlaceholder(Property)},
            {Method, new TemplatePlaceholder(Method)},
            {Inheritance, new TemplatePlaceholder(Inheritance, true, false)},
            {Implements, new TemplatePlaceholder(Implements)}
        };
    }
}