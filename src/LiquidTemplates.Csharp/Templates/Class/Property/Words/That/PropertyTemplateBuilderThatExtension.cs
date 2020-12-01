namespace LiquidTemplates.Csharp.Templates.Class.Property.Words.That
{
    public static class PropertyTemplateBuilderThatExtension
    {
        public static PropertyTemplateThatBuilder That(this IPropertyTemplateBuilder templateBuilder)
        {
            return new PropertyTemplateThatBuilder(templateBuilder);
        }
    }
}