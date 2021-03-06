using System.Collections.Generic;
using LiquidTemplates.Replacement;

namespace LiquidTemplates.Csharp.Templates.Class.Property
{
    public abstract class PropertyTemplateBuilderBase : TemplateBuilderBase, IPropertyTemplateBuilder
    {
        /// <summary>
        ///     TemplateFile, das für PropertyTemplates genutzt werden soll
        /// </summary>
        public static TemplateFile TemplateFile = new TemplateFile(@"public [PROPERTYTYPE] [PROPERTYNAME] {[GETTER] [SETTER]}");

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
        public IEnumerable<PlaceHolderReplacement> GetReplacements()
        {
            return new[]
            {
                new PlaceHolderReplacement(ClassTemplatePlaceholder.Property, ToString())
            };
        }

        public IPropertyTemplateBuilder WithName(string name)
        {
            AddReplacement(new PlaceHolderReplacement(PropertyTemplatePlaceholder.PropertyName, name));
            return this;
        }

        public override string ToString()
        {
            Build();
            return BuildResult;
        }
    }
}