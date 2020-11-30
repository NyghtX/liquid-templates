namespace LiquidTemplates.Csharp.Templates.Base
{
    public static class TemplateFiles
    {
        /// <summary>
        ///     TemplateFile, das zur Generierung der einer Property genutzt werden soll
        ///     Muss gesetzt werden, um die Fluent Generierung einer Property nutzen zu können
        /// </summary>
        public static TemplateFile PropertyTemplateFile;
        
        /// <summary>
        ///     TemplateFile, das zur Generierung der einer Klasse genutzt werden soll
        ///     Muss gesetzt werden, um die Fluent Generierung einer Klasse nutzen zu können
        /// </summary>
        public static TemplateFile ClassTemplateFile;
    }
}