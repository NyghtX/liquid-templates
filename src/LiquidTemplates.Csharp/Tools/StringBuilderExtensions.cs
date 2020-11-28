using System.Text;

namespace LiquidTemplates.Csharp.Tools
{
    /// <summary>
    ///     Extensions für den StringBuilder
    /// </summary>
    public static class StringBuilderExtensions
    {
        public static string TemplatePlaceholderSyntax = "[PLACEHOLDER]";

        /// <summary>
        ///     Replaced einen Placeholder
        /// </summary>
        /// <param name="sb">StringBuilder, der für das Replacement genutzt werden soll</param>
        /// <param name="placeholder">Identifier des Placeholders</param>
        /// <param name="withValue">Wert, der an die Stelle des Placeholders eingesetzt werden soll </param>
        /// <returns></returns>
        public static StringBuilder ReplacePlaceholder(this StringBuilder sb, string placeholder, string withValue)
        {
            return sb.Replace(CreatePlaceholder(placeholder), withValue);
        }

        private static string CreatePlaceholder(string placeholder)
        {
            return TemplatePlaceholderSyntax.Replace("PLACEHOLDER", placeholder);
        }
    }
}