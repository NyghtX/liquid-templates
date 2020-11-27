using System;
using System.Collections.Generic;
using System.Text;
using Templify.ClassGenerator.Templates.Base;
using Templify.ClassGenerator.Templates.Class.Property;

namespace Templify.ClassGenerator.Templates.Class
{
    /// <summary>
    ///     Template, auf das Replacements angewendet werden können
    /// </summary>
    public class ClassTemplate : TemplateBase<ClassTemplate>
    {
        /// <summary>
        ///     TemplateFile, das zur Generierung der einer Klasse genutzt werden soll
        ///     Muss gesetzt werden, um die Fluent Generierung einer Klasse nutzen zu können
        /// </summary>
        public static TemplateFile TemplateFile;

        /// <summary>
        ///     UsingTemplates für die Klasse
        /// </summary>
        private readonly List<UsingTemplate> _usingTemplates = new List<UsingTemplate>();

        /// <summary>
        ///     Namespace, in dem die Klasse angelegt werden soll
        /// </summary>
        private string _namespace;

        public ClassTemplate(TemplateFile templateFile) : base(templateFile)
        {
        }

        /// <summary>
        ///     Fügt ein Template für Using Statements zum Template hinzu
        /// </summary>
        /// <param name="template">Using Template</param>
        /// <returns>ClassTemplate für Fluent Building</returns>
        public ClassTemplate ThatUses(UsingTemplate template)
        {
            if (_usingTemplates.Contains(template))
                return this;

            _usingTemplates.Add(template);
            return this;
        }

        /// <summary>
        ///     Fügt der zu generierenden Klasse einen Namespace hinzu, der genutzt werden soll
        /// </summary>
        /// <param name="useNamespace">Namespace, der in die Klasse eingebunden werden soll</param>
        /// <returns>ClassTemplate für Fluent Building</returns>
        public ClassTemplate ThatUses(string useNamespace)
        {
            ThatUses(new UsingTemplate(useNamespace));
            return this;
        }


        /// <summary>
        ///     Fügt der Klasse eine Property hinzu
        /// </summary>
        /// <param name="property">Property, die der Klasse hinzugefügt werden soll</param>
        /// <returns>ClassTemplate für Fluent Building</returns>
        public ClassTemplate WithProperty(IPropertyTemplate property)
        {
            //TODO Property hinzufügen
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
            sb.Replace(ClassTemplatePlaceholders.ClassName, Name);

            // => Namespace replacen
            sb.Replace(ClassTemplatePlaceholders.ClassNamespace, _namespace);

            // => Template erzeugen und zurückgeben
            return sb.ToString();
        }

        /// <summary>
        ///     Beginnt den Prozess ein neues Class Template zum Generieren zu erstellen
        /// </summary>
        /// <returns>ClassTemplate, das Fluent genutzt werden soll</returns>
        /// <exception cref="NullReferenceException">Wenn das TemplateFile noch nicht gesetzt wurde</exception>
        public static ClassTemplate CreateClass()
        {
            if (TemplateFile == null)
                throw new NullReferenceException("Es wurde noch kein Template für das Generieren von Klassen gesetzt.");

            return new ClassTemplate(TemplateFile);
        }
    }
}