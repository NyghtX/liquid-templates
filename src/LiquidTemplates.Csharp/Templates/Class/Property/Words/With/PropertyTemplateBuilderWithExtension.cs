namespace LiquidTemplates.Csharp.Templates.Class.Property.Words.With
{
    public static class PropertyTemplateBuilderWithExtension
    {
        public static IPropertyTemplateBuilder With(this IPropertyTemplateBuilder templateBuilder,
            IPropertyTemplateBuilderWithBuilder builder)
        {
            templateBuilder.AddReplacement(builder.GetReplacement());
            return templateBuilder;
        }
    }
}