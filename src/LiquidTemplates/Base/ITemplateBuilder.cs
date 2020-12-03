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
        /// Fügt dem Templatebuilder eine Extension hinzu
        /// </summary>
        /// <param name="extension">Extension, die dem TemplateBuilder hinzugefügt werden soll</param>
        public void AddExtension<TExtension>(TExtension extension) where TExtension : ITemplateBuilderExtension;
    }
}