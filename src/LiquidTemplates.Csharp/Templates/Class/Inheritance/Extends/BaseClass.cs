using System.Collections.Generic;
using LiquidTemplates.Replacement;

namespace LiquidTemplates.Csharp.Templates.Class.Inheritance.Extends
{
    /// <summary>
    /// Base Class Builder
    /// </summary>
    public class BaseClass : IReplacementBuilder
    {
        public BaseClass(string className, string ns)
        {
            ClassName = className;
            Namespace = ns;
        }

        /// <summary>
        /// Name der Baseclass
        /// </summary>
        public string ClassName { get; }

        /// <summary>
        /// Namespace, in dem die Baseclass sich befindet
        /// </summary>
        public string Namespace { get; }


        /// <summary>
        ///     Holt das Replacement aus dem Builder
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PlaceHolderReplacement> GetReplacements()
        {
            // => Usings

            // => Inheritance
            yield return new PlaceHolderReplacement(ClassTemplatePlaceholder.Inheritance, ClassName);

            // => Overrides
        }
    }
}