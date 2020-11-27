using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Templify.ClassGenerator.Templates
{
    /// <summary>
    /// Template, auf das Replacements angewendet werden können
    /// </summary>
    public class ClassTemplate
    {
        /// <summary>
        /// Quellstring des Templates
        /// </summary>
        private readonly string _source;

        /// <summary>
        /// Namespace, in dem die Klasse angelegt werden soll
        /// </summary>
        private readonly string _namespace;

        /// <summary>
        /// Name der Klasse
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// UsingTemplates für die Klasse
        /// </summary>
        private List<UsingTemplate> _usingTemplates = new List<UsingTemplate>();

        /// <summary>
        /// Inheritance der Klasse
        /// </summary>
        private ClassInheritanceTemplate _inheritance;
        
        public ClassTemplate(string ns, string name) : this(ReadTemplate("Templates/Class.template"), ns, name)
        {}

        /// <summary>
        /// Initialisiert das Template
        /// </summary>
        /// <param name="source">Inhalt des Templates, das initialisiert werden soll</param>
        public ClassTemplate(string source, string ns, string name)
        {
            _source = source;
            _namespace = ns;
            _name = name;

            // => Placeholder finden
        }

        /// <summary>
        /// Fügt ein Template für Using Statements zum Template hinzu
        /// </summary>
        /// <param name="template">Using Template</param>
        /// <returns></returns>
        public ClassTemplate AddUsing(UsingTemplate template)
        {
            if (_usingTemplates.Contains(template))
                return this;
            
            _usingTemplates.Add(template);
            return this;
        }

        /// <summary>
        /// Setzt die Inheritance der Klasse
        /// </summary>
        /// <param name="inheritanceTemplate">Inheritance</param>
        /// <returns></returns>
        public ClassTemplate SetInheritance(ClassInheritanceTemplate inheritanceTemplate)
        {
            _inheritance = inheritanceTemplate;
            return this;
        }


        /// <summary>
        /// Setzt die Base-Class für die zu erzeugende Klasse
        /// </summary>
        /// <param name="baseClass"></param>
        /// <returns></returns>
        public ClassTemplate SetBaseClass(string baseClass)
        {
            return this;
        }

        /// <summary>
        /// Konvertiert das Template und die darauf angewandten Operationen zum einem String, der in den Compiler gegeben werden kann
        /// </summary>
        /// <returns>Ausgefülltes Template</returns>
        public override string ToString()
        {
            var sb = new StringBuilder(_source);
            
            // => Usings Builden
            var usingBuilder = new StringBuilder();
            foreach (var usingTemplate in _usingTemplates)
                usingBuilder.Append(usingTemplate);
            
            // => Usings replacen
            sb.Replace(ClassTemplatePlaceholders.Usings, usingBuilder.ToString());
            
            // => Klassenname replacen
            sb.Replace(ClassTemplatePlaceholders.ClassName, _name);
            
            // => Namespace replacen
            sb.Replace(ClassTemplatePlaceholders.ClassNamespace, _namespace);
            
            // => Inheritance replacen
            sb.Replace(ClassTemplatePlaceholders.ClassInheritance,
                _inheritance != null ? _inheritance.ToString() : string.Empty);

            // => Template erzeugen und zurückgeben
            return sb.ToString();
        }
        
        private static string ReadTemplate(string fileName)
        {
            var codeBaseUrl = new Uri(Assembly.GetExecutingAssembly().CodeBase);
            var codeBasePath = Uri.UnescapeDataString(codeBaseUrl.AbsolutePath);
            var dirPath = Path.GetDirectoryName(codeBasePath);
            var templateFile = Path.Combine(dirPath ?? throw new InvalidOperationException(), fileName);
            return File.ReadAllText(templateFile);
        }
    }
}