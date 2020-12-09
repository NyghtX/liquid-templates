using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Ergebnis des Builds
        /// </summary>
        protected string BuildResult = string.Empty;


        public TemplateBuilderBase(TemplateFile templateFile, Dictionary<string, TemplatePlaceholder> placeholders)
        {
            Source = templateFile;
            _placeholders = placeholders;

            // => Extension List initialisieren
            _extensions.Add(typeof(ITemplateBuilderBeforeReplacementExtension), new List<ITemplateBuilderExtension>());
            _extensions.Add(typeof(ITemplateBuilderBeforeBuildExtension), new List<ITemplateBuilderExtension>());
            _extensions.Add(typeof(ITemplateBuilderAfterBuildExtension), new List<ITemplateBuilderExtension>());

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
        public IEnumerable<PlaceHolderReplacement> GetReplacementsFor(string identifier) => Replacements[identifier];

        /// <summary>
        ///     Leert die Replacement Liste für einen bestimmten identifier
        /// </summary>
        /// <param name="replacementIdentifier">Replaement Identifier, dessen Liste geleert werden soll</param>
        public void ClearReplacementsFor(string replacementIdentifier) =>
            Replacements[replacementIdentifier] = new List<PlaceHolderReplacement>();

        /// <summary>
        ///     Fügt dem Templatebuilder eine Extension hinzu
        /// </summary>
        /// <param name="extension">Extension, die dem TemplateBuilder hinzugefügt werden soll</param>
        public void AddExtension<TExtension>(TExtension extension) where TExtension : ITemplateBuilderExtension =>
            _extensions[typeof(TExtension)].Add(extension);


        /// <summary>
        ///     Gibt die Liste der registrierten Extensions wieder
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ITemplateBuilderExtension> GetExtensions() => _extensions[typeof(ITemplateBuilderExtension)];

        /// <summary>
        /// Lässt den Template Builder builden
        /// </summary>
        /// <returns>Files, die das Resultat des Builds sind</returns>
        public virtual void Build()
        {
            // => Before Build Extensions ausführen
            RunExtensions(typeof(ITemplateBuilderBeforeBuildExtension));

            // => BeforeBuild builden
            BeforeBuild();
            
            // => Before Replacement Extensions aufrufen
            RunExtensions(typeof(ITemplateBuilderBeforeReplacementExtension));
            BuildResult = Source.Content.ReplacePlaceholders(_placeholders.Values, Replacements);

            // => After Build Extensions ausführen
            RunExtensions(typeof(ITemplateBuilderAfterBuildExtension));
            
            // => After Build
            AfterBuild();
        }

        /// <summary>
        /// Bevor der Build ausgeführt wird
        /// </summary>
        public virtual void BeforeBuild()
        {
            // => Kann vom Child überschrieben werden
        }
        
        /// <summary>
        /// Nachdem der Build ausgeführt wurde
        /// </summary>
        public virtual void AfterBuild()
        {
            // => Kann vom Child überschrieben werden
        }

        

        /// <summary>
        /// Führt alle registrierten Extensions eines bestimmten Typen aus
        /// </summary>
        /// <param name="ofType">Typ der Extensions, die ausgeführt werden sollen</param>
        protected void RunExtensions(Type ofType)
        {
            foreach (var extension in _extensions[ofType])
                extension.Execute();
        }
    }
}