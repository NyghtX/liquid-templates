namespace LiquidTemplates.Csharp.Templates.Class.Words.With
{
    public static class ClassTemplateBuilderWithExtension
    {
        public static ClassTemplateWithBuilder With(this IClassTemplateBuilder templateBuilder) =>
            new ClassTemplateWithBuilder(templateBuilder);
    }
}