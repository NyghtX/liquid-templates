using System;
using System.Text;
using Templify.ClassGenerator.Templates.Base;
using Templify.ClassGenerator.Tools;

namespace Templify.ClassGenerator.Templates.Class.Property
{
    public abstract class PropertyTemplateBuilderBase<TPropertyBuilderTemplate, TPropertyType> : TemplateBuilderBase<TPropertyBuilderTemplate>,
        IPropertyTemplateBuilder<TPropertyBuilderTemplate, TPropertyType> where TPropertyBuilderTemplate : TemplateBuilderBase<TPropertyBuilderTemplate>, IPropertyTemplateBuilder<TPropertyBuilderTemplate, TPropertyType>
    {
        public PropertyTemplateBuilderBase() : this(TemplateFiles.PropertyTemplateFile)
        {
            if (TemplateFiles.PropertyTemplateFile == null)
                throw new NullReferenceException("Es wurde noch kein Template für das Generieren von Properties gesetzt.");
        }
        
        protected PropertyTemplateBuilderBase(TemplateFile templateFile) : base(templateFile)
        {
        }

        /// <summary>
        /// TypeName der Property, die generiert werden soll
        /// </summary>
        protected abstract string PropertyTypeName { get; set; }

        /// <summary>
        ///     Standard Wert, der von der Property genutzt wird
        /// </summary>
        /// <param name="value">Standard Wert</param>
        /// <returns>Instanz für Fluent Usage</returns>
        public TPropertyBuilderTemplate WithDefaultValue(TPropertyType value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gibt an, dass die Property nur innerhalb der Klasse geändert werden können soll
        /// </summary>
        /// <returns>Instanz für Fluent Usage</returns>
        public TPropertyBuilderTemplate WithPrivateSetter()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gibt an, dass die Property nur innerhalb der Klasse und ihren Children geändert werden können soll
        /// </summary>
        /// <returns>Instanz für Fluent Usage</returns>
        public TPropertyBuilderTemplate WithProtectedSetter()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var sb = new StringBuilder(Source.Content);
            
            // => Access Modifier
            sb.ReplacePlaceholder(PropertyTemplatePlaceholder.AccessModifier, AccessModifier);
            
            // => Type
            sb.ReplacePlaceholder(PropertyTemplatePlaceholder.PropertyType, PropertyTypeName);
            
            // => Name
            sb.ReplacePlaceholder(PropertyTemplatePlaceholder.PropertyName, Name);
            
            // => End
            sb.ReplacePlaceholder(PropertyTemplatePlaceholder.PropertyEnd, ";");

            return sb.ToString();
        }

        /// <summary>
        /// Builded das Template für die Property
        /// </summary>
        /// <returns>Gebuildetes Template</returns>
        public PropertyTemplate Build()
        {
            return new PropertyTemplate(ToString())
            {
                Name = Name,
                AccessModifier = AccessModifierValue,
                PropertyTypeName = PropertyTypeName
            };
        }
    }
}