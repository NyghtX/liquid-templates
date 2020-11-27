using Templify.ClassGenerator.Templates.Base;

namespace Templify.ClassGenerator.Templates.Class
{
    public class ClassTemplate
    {
        public ClassTemplate(string source)
        {
            Source = source;
        }

        /// <summary>
        ///     Name der Klasse
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     SourceCode für die Klasse, der in den Compiler gegeben werden kann
        /// </summary>
        public string Source { get; }

        /// <summary>
        /// Namespace, in dem die Klasse angelegt werden soll
        /// </summary>
        public string Namespace { get; set; }

        public AccessModifier AccessModifier { get; set; }
    }
}