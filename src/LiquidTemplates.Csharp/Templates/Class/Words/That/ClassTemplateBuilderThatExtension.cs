namespace LiquidTemplates.Csharp.Templates.Class.Words.That
{
    public static class ClassTemplateBuilderThatExtension
    {
        public static ClassTemplateThatBuilder That(this IClassTemplateBuilder templateBuilder)
        {
            return new ClassTemplateThatBuilder(templateBuilder);
        }
    }
}