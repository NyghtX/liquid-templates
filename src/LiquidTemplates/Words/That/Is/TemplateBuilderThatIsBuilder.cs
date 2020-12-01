namespace LiquidTemplates.Words.That.Is
{
    public class TemplateBuilderThatIsBuilder<TTemplateBuilder> where TTemplateBuilder : ITemplateBuilder
    {
        public readonly TTemplateBuilder TemplateBuilder;

        public TemplateBuilderThatIsBuilder(TTemplateBuilder templateBuilder)
        {
            TemplateBuilder = templateBuilder;
        }
    }
}