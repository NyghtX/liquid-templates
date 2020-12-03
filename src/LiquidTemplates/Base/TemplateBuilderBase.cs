using System;
using System.Collections.Generic;
using System.Text;
using LiquidTemplates.Extensions;
using LiquidTemplates.Replacement;
using LiquidTemplates.Tools;

namespace LiquidTemplates
{
    /// <summary>
    ///     Basis für Templates
    /// </summary>
    public abstract class TemplateBuilderBase : ITemplateBuilder
    {
        /// <summary>
        ///     Extensions, die für den ITemplateBuilder registriert sind
        /// </summary>
        private readonly Dictionary<Type, List<ITemplateBuilderExtension>> _extensions =
            new Dictionary<Type, List<ITemplateBuilderExtension>>();

        /// <summary>
        ///     Platzhalter, die im Template ersetzt werden können
        /// </summary>
        private readonly Dictionary<string, TemplatePlaceholder> _placeholders;

        /// <summary>
        ///     Replacements, die für das Builden des Templates genutzt werden
        /// </summary>
        private readonly Dictionary<string, List<PlaceHolderReplacement>> _replacements =
            new Dictionary<string, List<PlaceHolderReplacement>>();

        /// <summary>
        ///     Source Template
        /// </summary>
        protected readonly TemplateFile Source;

        public TemplateBuilderBase(TemplateFile templateFile, Dictionary<string, TemplatePlaceholder> placeholders)
        {
            Source = templateFile;
            _placeholders = placeholders;

            // => Extension List initialisieren
            _extensions.Add(typeof(ITemplateBuilderBeforeReplacementExtension), new List<ITemplateBuilderExtension>());

            // => Replacement Liste initialisieren
            foreach (var placeholdersKey in placeholders.Keys)
                _replacements.Add(placeholdersKey, new List<PlaceHolderReplacement>());
        }

        /// <summary>
        ///     Fügt der List der Replacements einen Eintrag hinzu
        /// </summary>
        /// <param name="replacement">Replacement, dass an den Placeholder gebracht wird</param>
        public void AddReplacement(PlaceHolderReplacement replacement)
        {
            // => Aus liste der Placeholder suchen
            var placeholder = _placeholders[replacement.Placeholder];
            if (!placeholder.Multiple)
                _replacements[replacement.Placeholder] = new List<PlaceHolderReplacement> {replacement};
            else
                _replacements[replacement.Placeholder].Add(replacement);
        }

        /// <summary>
        ///     Fügt der List der Replacements mehrere Einträge hinzu
        /// </summary>
        /// <param name="replacements">Replacements, die an verschiedene Placeholder gebracht werden</param>
        public void AddReplacements(IEnumerable<PlaceHolderReplacement> replacements)
        {
            foreach (var placeHolderReplacement in replacements)
                AddReplacement(placeHolderReplacement);
        }

        /// <summary>
        ///     Fügt dem Templatebuilder eine Extension hinzu
        /// </summary>
        /// <param name="extension">Extension, die dem TemplateBuilder hinzugefügt werden soll</param>
        public void AddExtension<TExtension>(TExtension extension) where TExtension : ITemplateBuilderExtension
        {
            _extensions[typeof(TExtension)].Add(extension);
        }


        public override string ToString()
        {
            var sb = new StringBuilder(Source.Content);

            // => EXTENSION ITemplateBuilderBeforeReplacementExtension
            if (TryGetExtensions<ITemplateBuilderBeforeReplacementExtension>(out var extensions))
                foreach (var templateBuilderBeforeReplacementExtension in extensions)
                    templateBuilderBeforeReplacementExtension.Execute(this);

            // => Placeholder durchgehen
            foreach (var placeholder in _placeholders.Values)
            {
                // => Replacements für den Placeholder laden
                var replacements = _replacements[placeholder.Identifier];

                // => Validierung
                if (placeholder.Required && replacements.Count < 1)
                    throw new MissingMemberException(
                        $"Es muss mindestens ein Replacement für den Placeholder {placeholder.Identifier} gesetzt sein.");

                // => Replacements zusammenführen
                var replacementStringBuilder = new StringBuilder();
                foreach (var placeHolderReplacement in replacements)
                    replacementStringBuilder.Append(placeHolderReplacement.ReplaceWith);

                // => Replacements anwenden
                sb.ReplacePlaceholder(placeholder.Identifier, replacementStringBuilder.ToString());
            }

            return sb.ToString();
        }


        /// <summary>
        ///     Versucht eine Extension für den Typen zu finden
        /// </summary>
        /// <param name="extensions">Extensions, die gefunden wurde</param>
        /// <typeparam name="TExtensionType"></typeparam>
        /// <returns></returns>
        private bool TryGetExtensions<TExtensionType>(out List<TExtensionType> extensions)
            where TExtensionType : ITemplateBuilderExtension
        {
            extensions = _extensions[typeof(TExtensionType)] as List<TExtensionType>;

            // => Angabe, ob Extensions gefunden wurden
            return extensions != null && extensions.Count > 0;
        }
    }
}