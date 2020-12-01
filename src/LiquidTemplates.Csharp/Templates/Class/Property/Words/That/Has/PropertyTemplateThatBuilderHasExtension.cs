namespace LiquidTemplates.Csharp.Templates.Class.Property.Words.That.Has
{
    public static class PropertyTemplateThatBuilderHasExtension
    {
        public static PropertyTemplateHasBuilder Has(this PropertyTemplateThatBuilder templateThatBuilder)
        {
            return new PropertyTemplateHasBuilder(templateThatBuilder.PropertyTemplateBuilder);
        }
    }
}