using System.Collections.Generic;
using System.Linq;
using LiquidTemplates.Replacement;

namespace LiquidTemplates.Csharp.Templates.Class.Inheritance.Implements
{
    /// <summary>
    /// Implementierung eines Interfaces
    /// </summary>
    public class InterfaceImplementation : IReplacementBuilder
    {
        /// <summary>
        /// Liste der Implementierungen des Interfaces
        /// </summary>
        private readonly List<string> _implementations = new List<string>();
        
        public InterfaceImplementation(string interfaceName, string ns)
        {
            InterfaceName = interfaceName;
            Namespace = ns;
        }

        /// <summary>
        /// Name des Interfaces
        /// </summary>
        public string InterfaceName { get; }

        /// <summary>
        /// Namespace, in dem das Interface liegt
        /// </summary>
        public string Namespace { get; }

        public void AddImplementation(string implementation)
        {
            _implementations.Add(implementation);
        }


        /// <summary>
        ///     Holt das Replacement aus dem Builder
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PlaceHolderReplacement> GetReplacements()
        {
            var retVal = new List<PlaceHolderReplacement>();
            
            // => Using
            retVal.Add(new PlaceHolderReplacement(ClassTemplatePlaceholder.Usings, Namespace));

            // => Interface Inheritance
            retVal.Add(new PlaceHolderReplacement(ClassTemplatePlaceholder.Implements, InterfaceName));
            
            // => Implementations zurückgeben
            retVal.AddRange(_implementations.Select(implementation =>
                new PlaceHolderReplacement(ClassTemplatePlaceholder.Method, implementation)));
            
            
            return retVal;
        }
    }
}