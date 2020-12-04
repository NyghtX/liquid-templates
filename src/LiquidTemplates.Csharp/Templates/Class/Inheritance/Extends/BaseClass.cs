using System.Collections.Generic;
using LiquidTemplates.Replacement;

namespace LiquidTemplates.Csharp.Templates.Class.Inheritance.Extends
{
    /// <summary>
    ///     Base Class Builder
    /// </summary>
    public class BaseClass : IReplacementBuilder
    {
        /// <summary>
        ///     Werte, die in die Platzhalter kommen
        /// </summary>
        private readonly Dictionary<string, List<PlaceHolderReplacement>> _replacements;

        /// <summary>
        ///     Implementierungen, die übernommen werden
        /// </summary>
        private readonly IEnumerable<string> _implementations;

        /// <summary>
        ///     Platzhalter
        /// </summary>
        private readonly IEnumerable<TemplatePlaceholder> _placeholders;

        public BaseClass(string className, string ns, IEnumerable<string> implementations,
            IEnumerable<TemplatePlaceholder> placeholders, Dictionary<string, List<PlaceHolderReplacement>> replacements)
        {
            _implementations = implementations;
            _placeholders = placeholders;
            _replacements = replacements;
            ClassName = className;
            Namespace = ns;
        }

        public BaseClass(string className, string ns) : this(className, ns, new List<string>(),
            new List<TemplatePlaceholder>(), new Dictionary<string, List<PlaceHolderReplacement>>())
        {
        }

        /// <summary>
        ///     Name der Baseclass
        /// </summary>
        public string ClassName { get; }

        /// <summary>
        ///     Namespace, in dem die Baseclass sich befindet
        /// </summary>
        public string Namespace { get; }


        /// <summary>
        ///     Holt das Replacement aus dem Builder
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PlaceHolderReplacement> GetReplacements()
        {
            // => Replacements ausführen
            foreach (var implementation in _implementations)
            {
                // => Placeholder Replacen
                yield return new PlaceHolderReplacement(ClassTemplatePlaceholder.Method,
                    implementation.ReplacePlaceholders(_placeholders, _replacements));
                implementation.ReplacePlaceholders(_placeholders, _replacements);
            }

            yield return new PlaceHolderReplacement(ClassTemplatePlaceholder.Usings, Namespace);
            yield return new PlaceHolderReplacement(ClassTemplatePlaceholder.Inheritance, ClassName);
        }
    }
}