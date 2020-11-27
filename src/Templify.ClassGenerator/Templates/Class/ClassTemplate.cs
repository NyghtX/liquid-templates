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
    }
}