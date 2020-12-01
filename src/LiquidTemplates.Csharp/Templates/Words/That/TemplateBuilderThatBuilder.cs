namespace LiquidTemplates.Csharp.Templates.Words.That
{
    public class TemplateBuilderThatBuilder<TTemplateBuilder> where TTemplateBuilder : ITemplateBuilder
    {
        public readonly TTemplateBuilder TemplateBuilder;

        public TemplateBuilderThatBuilder(TTemplateBuilder templateBuilder)
        {
            TemplateBuilder = templateBuilder;
        }
    }
}