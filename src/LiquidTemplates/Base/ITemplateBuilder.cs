using System.Collections.Generic;
using LiquidTemplates.Addition;
using LiquidTemplates.Extensions;
using LiquidTemplates.Replacement;

namespace LiquidTemplates
{
    public interface ITemplateBuilder
    {
        /// <summary>
        /// Setzt das Parent Element des Builders
        /// </summary>
        /// <param name="templateBuilder"></param>
        void SetParent(ITemplateBuilder templateBuilder);

        /// <summary>
        /// Fügt einen TemplateBuilder als Child Element hinzu
        /// </summary>
        /// <param name="templateBuilder"></param>
        void AddChild(ITemplateBuilder templateBuilder);

        /// <summary>
        /// Liest die Liste der Children des Builders
        /// </summary>
        /// <returns></returns>
        IEnumerable<ITemplateBuilder> GetChildren();

        /// <summary>
        /// Liest den Parent Builder des Builders
        /// </summary>
        /// <returns></returns>
        ITemplateBuilder GetParent();
        
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
        ///     Fügt dem Templatebuilder eine Addition hinzu
        /// </summary>
        /// <param name="addition">Addition, die dem TemplateBuilder hinzugefügt werden soll</param>
        public void AddAddition<TAddition>(TAddition addition) where TAddition : ITemplateBuilderAddition;

        /// <summary>
        ///     Gibt eine Liste mit Additions des Typen
        /// </summary>
        /// <typeparam name="TAddition">Typ der Additions</typeparam>
        /// <returns>Liste mit Additions</returns>
        public IEnumerable<TAddition> GetAdditions<TAddition>() where TAddition : ITemplateBuilderAddition;

        /// <summary>
        ///     Gibt die Liste der registrierten Extensions wieder
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ITemplateBuilderExtension> GetExtensions();

        /// <summary>
        /// Fügt dem Builder ein File hinzu
        /// </summary>
        /// <param name="file">File, das beim Build mit ausgegeben wird</param>
        public void AddFile(GeneratedFile file);

        /// <summary>
        /// Lässt den Template Builder builden
        /// </summary>
        /// <returns>Files, die das Resultat des Builds sind</returns>
        public IEnumerable<GeneratedFile> Build();
    }
}