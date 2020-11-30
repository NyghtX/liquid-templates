namespace LiquidTemplates.Csharp.Templates.Class.Words.That
{
    public static class TemplateBuilderThatExtension
    {
        public static ClassTemplateThatBuilder That(this IClassTemplateBuilder templateBuilder)
        {
            return new ClassTemplateThatBuilder(templateBuilder);
        }
    }
}