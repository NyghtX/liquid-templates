using LiquidTemplates.Words.That.Has;

namespace LiquidTemplates.Csharp.Templates.Class.Property
{
    public static class PropertyAccessorExtensions
    {
        public static IPropertyTemplateBuilder PrivateSetter(
            this TemplateBuilderThatHasBuilder<IPropertyTemplateBuilder> builder)
        {
            builder.TemplateBuilder.AddReplacement(
                new PlaceHolderReplacement(PropertyTemplatePlaceholder.PropertySetter, "private set;"));
            return builder.TemplateBuilder;
        }
    }
}