using System.Collections.Generic;
using System.Text;

namespace Templify.ClassGenerator.Templates
{
    /// <summary>
    /// Template für den Using Bereich einer Klasse
    /// </summary>
    public class UsingTemplate
    {
        /// <summary>
        /// Namespaces, die verwendet werden sollen
        /// </summary>
        private readonly List<string> _namespaces = new List<string>();

        /// <summary>
        /// Fügt einen Namespace zum Template hinzu
        /// </summary>
        /// <param name="fullNamespace">Namespace OHNE USING, der hinzugefügt werden soll</param>
        /// <returns></returns>
        public UsingTemplate AddNamespace(string fullNamespace)
        {
            // => Wenn der Namespace bereits eingebunden wurde
            if (_namespaces.Contains(fullNamespace))
                return this;
            
            _namespaces.Add(fullNamespace);
            return this;
        } 
        

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var ns in _namespaces)
                sb.Append($"using {ns};\n");

            return sb.ToString();
        }
    }
}