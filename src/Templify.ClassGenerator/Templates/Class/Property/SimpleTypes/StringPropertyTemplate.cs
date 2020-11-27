using System;
using Templify.ClassGenerator.Templates.Base;

namespace Templify.ClassGenerator.Templates.Class.Property.SimpleTypes
{
    public class StringPropertyTemplate : PropertyTemplateBase<StringPropertyTemplate>
    {
        
        public StringPropertyTemplate(TemplateFile templateFile) : base(templateFile)
        {
        }

        /// <summary>
        /// TemplateFile, das zur Generierung der einer StringProperty genutzt werden soll
        /// Muss gesetzt werden, um die Fluent Generierung einer StringProperty nutzen zu können
        /// </summary>
        public static TemplateFile TemplateFile;
        
        /// <summary>
        /// Beginnt den Prozess ein neues StringProperty Template zum Generieren zu erstellen
        /// </summary>
        /// <returns>StringPropertyTemplate, das Fluent genutzt werden soll</returns>
        /// <exception cref="NullReferenceException">Wenn das TemplateFile noch nicht gesetzt wurde</exception>
        public static StringPropertyTemplate Create()
        {
            if(TemplateFile == null)
                throw new NullReferenceException("Es wurde noch kein Template für das Generieren von String Properties gesetzt.");
            
            return new StringPropertyTemplate(TemplateFile);
        }
    }
}