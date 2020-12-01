using LiquidTemplates.Replacement;

namespace LiquidTemplates.Csharp.Templates.Class.Property
{
    public abstract class PropertyTemplateBuilderBase : TemplateBuilderBase, IPropertyTemplateBuilder
    {
        /// <summary>
        /// TemplateFile, das für PropertyTemplates genutzt werden soll
        /// </summary>
        public static TemplateFile TemplateFile = TemplateFile.From("Templates/Class/Property/Property.template");
        
        public PropertyTemplateBuilderBase() : this(TemplateFile)
        {
        }

        protected PropertyTemplateBuilderBase(TemplateFile templateFile) : base(templateFile,
            PropertyTemplatePlaceholder.Placeholders)
        {
            // => Default Getter und Setter setzen
            AddReplacement(new PlaceHolderReplacement(PropertyTemplatePlaceholder.PropertyGetter, "get;"));
            AddReplacement(new PlaceHolderReplacement(PropertyTemplatePlaceholder.PropertySetter, "set;"));
        }


        /// <summary>
        ///     Holt das Replacement aus dem Builder
        /// </summary>
        /// <returns></returns>
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