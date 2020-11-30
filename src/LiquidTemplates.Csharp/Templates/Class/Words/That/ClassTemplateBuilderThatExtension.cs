namespace LiquidTemplates.Csharp.Templates.Class.Words.That
{
    public static class ClassTemplateBuilderThatExtension
    {
        public static ClassTemplateThatBuilder That(this IClassTemplateBuilder templateBuilder) =>
            new ClassTemplateThatBuilder(templateBuilder);
    }
}