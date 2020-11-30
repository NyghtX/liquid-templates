namespace LiquidTemplates.Csharp.Templates.Class.Words.That
{
    public static class TemplateBuilderThatExtension
    {
        public static ClassTemplateThatBuilder That(this IClassTemplateBuilder templateBuilder) =>
            new ClassTemplateThatBuilder(templateBuilder);
    }
}