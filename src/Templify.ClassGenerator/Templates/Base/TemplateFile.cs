using System;
using System.IO;
using System.Reflection;

namespace Templify.ClassGenerator.Templates.Base
{
    /// <summary>
    /// Geladenes Template File
    /// </summary>
    public class TemplateFile
    {
        /// <summary>
        /// Inhalt des Templates
        /// </summary>
        public string Content { get; }
        
        public TemplateFile(string content)
        {
            Content = content;
        }
        
        /// <summary>
        /// Erzeugt ein neues Template File aus dem Inhalt einer Datei
        /// </summary>
        /// <param name="fileName">Relativer Pfad zur Datei ausgehend vom bin dir</param>
        /// <returns>Erzeugte TemplateFile Instanz</returns>
        public static TemplateFile From(string fileName)
        {
            var codeBaseUrl = new Uri(Assembly.GetExecutingAssembly().CodeBase);
            var codeBasePath = Uri.UnescapeDataString(codeBaseUrl.AbsolutePath);
            var dirPath = Path.GetDirectoryName(codeBasePath);
            var templateFile = Path.Combine(dirPath ?? throw new InvalidOperationException(), fileName);
            return new TemplateFile(File.ReadAllText(templateFile));
        }
    }
}