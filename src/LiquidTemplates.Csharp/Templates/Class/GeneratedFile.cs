namespace LiquidTemplates.Csharp.Templates.Class
{
    public class GeneratedFile
    {
        public GeneratedFile(string filename, string conent)
        {
            Filename = filename;
            Conent = conent;
        }

        /// <summary>
        ///     Name des Files
        /// </summary>
        public string Filename { get; }

        /// <summary>
        ///     Inhalt des Files
        /// </summary>
        public string Conent { get; }
    }
}