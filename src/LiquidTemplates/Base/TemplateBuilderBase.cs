using System;
using System.Collections.Generic;
using System.Linq;
using LiquidTemplates.Addition;
using LiquidTemplates.Extensions;
using LiquidTemplates.Replacement;

namespace LiquidTemplates
{
    /// <summary>
    ///     Basis für Templates
    /// </summary>
    public abstract class TemplateBuilderBase : ITemplateBuilder
    {
        /// <summary>
        ///     Additions, die dem Builder hinzugefügt wurden
        /// </summary>
        private readonly Dictionary<Type, List<ITemplateBuilderAddition>> _additions =
            new Dictionary<Type, List<ITemplateBuilderAddition>>();

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
        protected readonly Dictionary<string, List<PlaceHolderReplacement>> Replacements =
            new Dictionary<string, List<PlaceHolderReplacement>>();

        /// <summary>
        /// Files, die beim Build ausgegeben werden
        /// </summary>
        private readonly List<GeneratedFile> _files = new List<GeneratedFile>();

        /// <summary>
        /// Parent Builder
        /// </summary>
        private ITemplateBuilder _parent;

        /// <summary>
        /// Child Elemente des Template Builders
        /// </summary>
        private List<ITemplateBuilder> _children = new List<ITemplateBuilder>();

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
                Replacements.Add(placeholdersKey, new List<PlaceHolderReplacement>());
        }

        /// <summary>
        /// Setzt das Parent Element des Builders
        /// </summary>
        /// <param name="templateBuilder"></param>
        public void SetParent(ITemplateBuilder templateBuilder)
        {
            _parent = templateBuilder;
        }

        /// <summary>
        /// Fügt einen TemplateBuilder als Child Element hinzu
        /// </summary>
        /// <param name="templateBuilder"></param>
        public void AddChild(ITemplateBuilder templateBuilder)
        {
            _children.Add(templateBuilder);
        }

        /// <summary>
        /// Liest die Liste der Children des Builders
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ITemplateBuilder> GetChildren() => _children;

        /// <summary>
        /// Liest den Parent Builder des Builders
        /// </summary>
        /// <returns></returns>
        public ITemplateBuilder GetParent() => _parent;

        /// <summary>
        ///     Fügt der List der Replacements einen Eintrag hinzu
        /// </summary>
        /// <param name="replacement">Replacement, dass an den Placeholder gebracht wird</param>
        public void AddReplacement(PlaceHolderReplacement replacement)
        {
            // => Aus liste der Placeholder suchen
            var placeholder = _placeholders[replacement.Placeholder];
            if (!placeholder.Multiple)
                Replacements[replacement.Placeholder] = new List<PlaceHolderReplacement> {replacement};
            else
                Replacements[replacement.Placeholder].Add(replacement);
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
        ///     Gibt die Liste der registrierten Replacements wieder
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PlaceHolderReplacement> GetReplacementsFor(string identifier)
        {
            return Replacements[identifier];
        }

        /// <summary>
        ///     Leert die Replacement Liste für einen bestimmten identifier
        /// </summary>
        /// <param name="replacementIdentifier">Replaement Identifier, dessen Liste geleert werden soll</param>
        public void ClearReplacementsFor(string replacementIdentifier)
        {
            Replacements[replacementIdentifier] = new List<PlaceHolderReplacement>();
        }

        /// <summary>
        ///     Fügt dem Templatebuilder eine Extension hinzu
        /// </summary>
        /// <param name="extension">Extension, die dem TemplateBuilder hinzugefügt werden soll</param>
        public void AddExtension<TExtension>(TExtension extension) where TExtension : ITemplateBuilderExtension
        {
            _extensions[typeof(TExtension)].Add(extension);
        }

        /// <summary>
        ///     Fügt dem Templatebuilder eine Addition hinzu
        /// </summary>
        /// <param name="addition">Addition, die dem TemplateBuilder hinzugefügt werden soll</param>
        public void AddAddition<TAddition>(TAddition addition) where TAddition : ITemplateBuilderAddition
        {
            if (!_additions.ContainsKey(typeof(TAddition)))
                _additions.Add(typeof(TAddition), new List<ITemplateBuilderAddition>());

            _additions[typeof(TAddition)].Add(addition);
        }

        /// <summary>
        ///     Gibt eine Liste mit Additions des Typen
        /// </summary>
        /// <typeparam name="TAddition">Typ der Additions</typeparam>
        /// <returns>Liste mit Additions</returns>
        public IEnumerable<TAddition> GetAdditions<TAddition>() where TAddition : ITemplateBuilderAddition
        {
            return _additions.ContainsKey(typeof(TAddition))
                ? (IEnumerable<TAddition>) _additions[typeof(TAddition)]
                : new List<TAddition>();
        }

        public IEnumerable<ITemplateBuilderExtension> GetExtensions()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fügt dem Builder ein File hinzu
        /// </summary>
        /// <param name="file">File, das beim Build mit ausgegeben wird</param>
        public void AddFile(GeneratedFile file)
        {
            _files.Add(file);
        }

        /// <summary>
        /// Lässt den Template Builder builden
        /// </summary>
        /// <returns>Files, die das Resultat des Builds sind</returns>
        public virtual IEnumerable<GeneratedFile> Build()
        {
            // => Additions durchbuilden
            foreach (var templateBuilderAddition in _additions.Values.SelectMany(templateBuilderAdditions =>
                templateBuilderAdditions))
                templateBuilderAddition.Build();

            return _files;
        }
        


        public override string ToString()
        {
            // => EXTENSION ITemplateBuilderBeforeReplacementExtension
            if (TryGetExtensions<ITemplateBuilderBeforeReplacementExtension>(out var extensions))
                foreach (var templateBuilderBeforeReplacementExtension in extensions)
                    templateBuilderBeforeReplacementExtension.Execute(this);

            return Source.Content.ReplacePlaceholders(_placeholders.Values, Replacements);
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