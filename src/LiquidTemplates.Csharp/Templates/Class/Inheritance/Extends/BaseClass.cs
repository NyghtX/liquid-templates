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
        /// Implementierungen, die übernommen werden
        /// </summary>
        private readonly IEnumerable<string> _implementations;
        
        /// <summary>
        /// Platzhalter
        /// </summary>
        private readonly IEnumerable<TemplatePlaceholder> _placeholders;
        
        /// <summary>
        /// Standardwerte, die in die Platzhalter kommen
        /// </summary>
        private readonly IEnumerable<PlaceHolderReplacement> _defaultValues;

        public BaseClass(string className, string ns, IEnumerable<string> implementations, IEnumerable<TemplatePlaceholder> placeholders, IEnumerable<PlaceHolderReplacement> defaultValues)
        {
            _implementations = implementations;
            _placeholders = placeholders;
            _defaultValues = defaultValues;
            ClassName = className;
            Namespace = ns;
        }

        public BaseClass(string className, string ns) : this(className, ns, new List<string>(),
            new List<TemplatePlaceholder>(), new List<PlaceHolderReplacement>())
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
            }

            return new List<PlaceHolderReplacement>
            {
                new PlaceHolderReplacement(ClassTemplatePlaceholder.Usings, Namespace),
                new PlaceHolderReplacement(ClassTemplatePlaceholder.Inheritance, ClassName)
            };
        }
    }
}