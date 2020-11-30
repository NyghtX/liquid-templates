namespace LiquidTemplates.Csharp.Templates.Class.Words.That.Is
{
    public static class ClassTemplateThatBuilderIsExtension
    {
        public static ClassTemplateIsBuilder Is(this ClassTemplateThatBuilder templateThatBuilder) =>
            new ClassTemplateIsBuilder(templateThatBuilder.ClassTemplateBuilder);
    }
}