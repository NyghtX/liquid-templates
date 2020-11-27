using System.Collections.Generic;
using System.Text;
using Templify.ClassGenerator.Templates.Base;

namespace Templify.ClassGenerator.Templates.Class
{
    /// <summary>
    ///     Template, auf das Replacements angewendet werden können
    /// </summary>
    public class ClassTemplate : TemplateBase
    {
        /// <summary>
        ///     Inheritance der Klasse
        /// </summary>
        private ClassInheritanceTemplate _inheritance;

        /// <summary>
        ///     Name der Klasse
        /// </summary>
        private string _name;

        /// <summary>
        ///     Namespace, in dem die Klasse angelegt werden soll
        /// </summary>
        private string _namespace;

        /// <summary>
        ///     UsingTemplates für die Klasse
        /// </summary>
        private readonly List<UsingTemplate> _usingTemplates = new List<UsingTemplate>();

        public ClassTemplate(TemplateFile templateFile) : base(templateFile)
        {
        }

        public ClassTemplate(string templatePath) : base(templatePath)
        {
        }


        /// <summary>
        ///     Fügt ein Template für Using Statements zum Template hinzu
        /// </summary>
        /// <param name="template">Using Template</param>
        /// <returns></returns>
        public ClassTemplate ThatUses(UsingTemplate template)
        {
            if (_usingTemplates.Contains(template))
                return this;

            _usingTemplates.Add(template);
            return this;
        }

        /// <summary>
        ///     Setzt die Inheritance der Klasse
        /// </summary>
        /// <param name="inheritanceTemplate">Inheritance</param>
        /// <returns></returns>
        public ClassTemplate ThatInheritsFrom(ClassInheritanceTemplate inheritanceTemplate)
        {
            _inheritance = inheritanceTemplate;
            return this;
        }


        /// <summary>
        ///     Setzt die Base-Class für die zu erzeugende Klasse
        /// </summary>
        /// <param name="baseClass"></param>
        /// <returns></returns>
        public ClassTemplate WithBaseClass(string baseClass)
        {
            return this;
        }

        /// <summary>
        ///     Setzt den Namen, den die generierte Klasse erhalten soll
        /// </summary>
        /// <param name="className">Name der Klassem, die generiert werden soll</param>
        /// <returns>ClassTemplate für Fluent Building</returns>
        public ClassTemplate WithName(string className)
        {
            _name = className;
            return this;
        }

        /// <summary>
        ///     Definiert den Namespace, in dem die Klasse angelegt werden soll
        /// </summary>
        /// <param name="inNamespace">Namespace, in dem die Klasse angelegt werden soll</param>
        /// <returns>ClassTemplate für Fluent Building</returns>
        public ClassTemplate InNamespace(string inNamespace)
        {
            _namespace = inNamespace;
            return this;
        }

        /// <summary>
        ///     Konvertiert das Template und die darauf angewandten Operationen zum einem String, der in den Compiler gegeben
        ///     werden kann
        /// </summary>
        /// <returns>Ausgefülltes Template</returns>
        public override string ToString()
        {
            var sb = new StringBuilder(Source.Content);

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

        public static ClassTemplate Create()
        {
            return new ClassTemplate(string.Empty); //TODO Füllen
        }
    }
}