using System;
using System.Collections.Generic;
using System.Text;
using LiquidTemplates.Csharp.Templates.Extensions;
using LiquidTemplates.Csharp.Tools;

namespace LiquidTemplates.Csharp.Templates.Base
{
    /// <summary>
    ///     Basis für Templates
    /// </summary>
    public abstract class TemplateBuilderBase : ITemplateBuilder
    {
        /// <summary>
        /// Replacements, die für das Builden des Templates genutzt werden
        /// </summary>
        private readonly Dictionary<string, List<PlaceHolderReplacement>> _replacements =
            new Dictionary<string, List<PlaceHolderReplacement>>();

        /// <summary>
        /// Platzhalter, die im Template ersetzt werden können
        /// </summary>
        private Dictionary<string, TemplatePlaceholder> _placeholders;

        /// <summary>
        ///     Source Template
        /// </summary>
        protected readonly TemplateFile Source;
        
        public TemplateBuilderBase(TemplateFile templateFile, Dictionary<string, TemplatePlaceholder> placeholders)
        {
            Source = templateFile;
            _placeholders = placeholders;
            
            // => Replacement Liste initialisieren
            foreach (var placeholdersKey in placeholders.Keys)
                _replacements.Add(placeholdersKey, new List<PlaceHolderReplacement>());
        }

        /// <summary>
        /// Fügt der List der Replacements einen Eintrag hinzu
        /// </summary>
        /// <param name="replacement">Replacement, dass an den Placeholder gebracht wird</param>
        public void AddReplacement(PlaceHolderReplacement replacement) =>
            _replacements[replacement.Placeholder].Add(replacement);

        public override string ToString()
        {
            var sb = new StringBuilder(Source.Content);
            
            // => Placeholder durchgehen
            foreach (var placeholder in _placeholders.Values)
            {
                // => Replacements für den Placeholder laden
                var replacements = _replacements[placeholder.Identifier];
                
                // => Validierung
                if(placeholder.Required && replacements.Count < 1)
                    throw new MissingMemberException($"Es muss mindestens ein Replacement für den Placeholder {placeholder.Identifier} gesetzt sein.");
                if(!placeholder.Multiple && replacements.Count > 1)
                    throw new MissingMemberException($"Es darf maximal ein Replacement für den Placeholder {placeholder.Identifier} gesetzt sein.");
                
                // => Replacements zusammenführen
                var replacementStringBuilder = new StringBuilder();
                foreach (var placeHolderReplacement in replacements)
                    replacementStringBuilder.Append(placeHolderReplacement.ReplaceWith);

                // => Replacements anwenden
                sb.ReplacePlaceholder(placeholder.Identifier, replacementStringBuilder.ToString());
            }
            
            return sb.ToString();
        }
    }
}