using Templify.ClassGenerator.Templates.Base;

namespace Templify.ClassGenerator.Templates.Class.Property
{
    public class PropertyTemplate
    {
        public PropertyTemplate(string source)
        {
            Source = source;
        }

        /// <summary>
        ///     Name der Klasse
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name des Types der Property
        /// </summary>
        public string PropertyTypeName { get; set; }

        /// <summary>
        ///     SourceCode für die Klasse, der in den Compiler gegeben werden kann
        /// </summary>
        public string Source { get; }
        

        public AccessModifier AccessModifier { get; set; }    }
}