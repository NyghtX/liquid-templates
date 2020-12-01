using LiquidTemplates.Csharp.Templates.Base;

namespace LiquidTemplates.Csharp.Templates.Words.That.Has
{
    public class TemplateBuilderThatHasBuilder<TTemplateBuilder> where TTemplateBuilder : ITemplateBuilder
    {
        public readonly TTemplateBuilder TemplateBuilder;

        public TemplateBuilderThatHasBuilder(TTemplateBuilder templateBuilder)
        {
            TemplateBuilder = templateBuilder;
        }
    }
}