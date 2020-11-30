using System;
using LiquidTemplates.Csharp.Templates.Base;
using LiquidTemplates.Csharp.Templates.Extensions;

namespace LiquidTemplates.Csharp.Templates.Class.Property
{
    public abstract class PropertyTemplateBuilderBase :
        TemplateBuilderBase,
        IPropertyTemplateBuilder
    {
        public PropertyTemplateBuilderBase() : this(TemplateFiles.PropertyTemplateFile)
        {
            if (TemplateFiles.PropertyTemplateFile == null)
                throw new NullReferenceException(
                    "Es wurde noch kein Template für das Generieren von Properties gesetzt.");
        }

        //TODO Richtige Placeholder einsetzen
        protected PropertyTemplateBuilderBase(TemplateFile templateFile) : base(templateFile,
            PropertyTemplatePlaceholder.Placeholders)
        {
        }


        public PlaceHolderReplacement GetReplacement()
        {
            return new PlaceHolderReplacement(ClassTemplatePlaceholder.Property, ToString());
        }

        public IPropertyTemplateBuilder WithName(string name)
        {
            AddReplacement(new PlaceHolderReplacement(PropertyTemplatePlaceholder.PropertyName, name));
            return this;
        }
    }
}