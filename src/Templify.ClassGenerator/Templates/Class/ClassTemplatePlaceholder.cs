using System.Collections.Generic;

namespace Templify.ClassGenerator.Templates.Class
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
        public static IEnumerable<string> All = new[]
        {
            Usings,
            Namespace,
            AccessModifier,
            Classname
        };

        /// <summary>
        ///     Placeholder, die gefüllt werden müssen
        /// </summary>
        public static IEnumerable<string> Required = new[]
        {
            Namespace,
            Classname
        };
    }
}