namespace LiquidTemplates.Words.That
{
    public static class TemplateBuilderThatExtension
    {
        public static TemplateBuilderThatBuilder<TTemplateBuilder>
            That<TTemplateBuilder>(this TTemplateBuilder templateBuilder) where TTemplateBuilder : ITemplateBuilder
        {
            return new TemplateBuilderThatBuilder<TTemplateBuilder>(templateBuilder);
        }
    }
}