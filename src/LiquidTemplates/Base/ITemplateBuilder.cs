using System.Collections.Generic;
using LiquidTemplates.Extensions;
using LiquidTemplates.Replacement;

namespace LiquidTemplates
{
    public interface ITemplateBuilder
    {
        /// <summary>
        ///     Fügt der List der Replacements einen Eintrag hinzu
        /// </summary>
        /// <param name="replacement">Replacement, dass an den Placeholder gebracht wird</param>
        public void AddReplacement(PlaceHolderReplacement replacement);

        /// <summary>
        ///     Fügt der List der Replacements mehrere Einträge hinzu
        /// </summary>
        /// <param name="replacements">Replacements, die an verschiedene Placeholder gebracht werden</param>
        public void AddReplacements(IEnumerable<PlaceHolderReplacement> replacements);

        /// <summary>
        ///     Gibt die Liste der registrierten Replacements wieder
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PlaceHolderReplacement> GetReplacementsFor(string identifier);

        /// <summary>
        ///     Leert die Replacement Liste für einen bestimmten identifier
        /// </summary>
        /// <param name="replacementIdentifier">Replaement Identifier, dessen Liste geleert werden soll</param>
        public void ClearReplacementsFor(string replacementIdentifier);

        /// <summary>
        ///     Fügt dem Templatebuilder eine Extension hinzu
        /// </summary>
        /// <param name="extension">Extension, die dem TemplateBuilder hinzugefügt werden soll</param>
        public void AddExtension<TExtension>(TExtension extension) where TExtension : ITemplateBuilderExtension;

        /// <summary>
        ///     Gibt die Liste der registrierten Extensions wieder
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ITemplateBuilderExtension> GetExtensions();
    }
}