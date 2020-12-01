using LiquidTemplates.Csharp.Templates.Base;

namespace LiquidTemplates.Csharp.Templates.Words.That
{
    public static class TemplateBuilderThatExtension
    {
        public static TemplateBuilderThatBuilder<TTemplateBuilder>
            That<TTemplateBuilder>(this TTemplateBuilder templateBuilder) where TTemplateBuilder : ITemplateBuilder =>
            new TemplateBuilderThatBuilder<TTemplateBuilder>(templateBuilder);
    }
}