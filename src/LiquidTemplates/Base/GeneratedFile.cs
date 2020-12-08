namespace LiquidTemplates
{
    /// <summary>
    /// Datei, die durch den Generator erzeugt wurde
    /// </summary>
    public class GeneratedFile
    {
        public GeneratedFile(string filename, string source)
        {
            Filename = filename;
            Source = source;
        }

        /// <summary>
        /// Name der Datei
        /// </summary>
        public string Filename { get; }

        /// <summary>
        /// Inhalt der Datei, die generiert wurde
        /// </summary>
        public string Source { get; }
    }
}