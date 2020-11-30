using System;
using System.Collections.Generic;
using System.Text;
using LiquidTemplates.Csharp.Templates.Base;
using LiquidTemplates.Csharp.Tools;

namespace LiquidTemplates.Csharp.Templates.Class.Property
{
    public abstract class PropertyTemplateBuilderBase<TPropertyBuilderTemplate, TPropertyType> :
        TemplateBuilderBase,
        IPropertyTemplateBuilder<TPropertyBuilderTemplate, TPropertyType>
        where TPropertyBuilderTemplate : TemplateBuilderBase,
        IPropertyTemplateBuilder<TPropertyBuilderTemplate, TPropertyType>
    {
        public PropertyTemplateBuilderBase() : this(TemplateFiles.PropertyTemplateFile)
        {
            if (TemplateFiles.PropertyTemplateFile == null)
                throw new NullReferenceException(
                    "Es wurde noch kein Template für das Generieren von Properties gesetzt.");
        }

        //TODO Richtige Placeholder einsetzen
        protected PropertyTemplateBuilderBase(TemplateFile templateFile) : base(templateFile, new Dictionary<string, TemplatePlaceholder>())
        {
        }

        /// <summary>
        ///     TypeName der Property, die generiert werden soll
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
        

        public override string ToString()
        {
            var sb = new StringBuilder(Source.Content);

            // => Access Modifier
            //sb.ReplacePlaceholder(PropertyTemplatePlaceholder.AccessModifier, AccessModifier);

            // => Type
            sb.ReplacePlaceholder(PropertyTemplatePlaceholder.PropertyType, PropertyTypeName);

            // => Name
            //sb.ReplacePlaceholder(PropertyTemplatePlaceholder.PropertyName, Name);

            // => End
            sb.ReplacePlaceholder(PropertyTemplatePlaceholder.PropertyEnd, ";");

            return sb.ToString();
        }
    }
}