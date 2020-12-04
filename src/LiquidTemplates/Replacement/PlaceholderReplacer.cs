using System;
using System.Collections.Generic;
using System.Text;
using LiquidTemplates.Tools;

namespace LiquidTemplates.Replacement
{
    public static class PlaceholderReplacer
    {
        public static string ReplacePlaceholders(this string value, IEnumerable<TemplatePlaceholder> placeholders,
            Dictionary<string, List<PlaceHolderReplacement>> replacements)
        {
            var sb = new StringBuilder(value);

            // => Placeholder durchgehen
            foreach (var placeholder in placeholders)
            {
                // => Replacements für den Placeholder laden
                var matchingReplacements = replacements[placeholder.Identifier];

                // => Validierung
                if (placeholder.Required && replacements.Count < 1)
                    throw new MissingMemberException(
                        $"Es muss mindestens ein Replacement für den Placeholder {placeholder.Identifier} gesetzt sein.");

                // => Replacements zusammenführen
                var replacementStringBuilder = new StringBuilder();
                foreach (var placeHolderReplacement in matchingReplacements)
                    replacementStringBuilder.Append(placeHolderReplacement.ReplaceWith);

                // => Replacements anwenden
                sb.ReplacePlaceholder(placeholder.Identifier, replacementStringBuilder.ToString());
            }

            return sb.ToString();
        }
    }
}