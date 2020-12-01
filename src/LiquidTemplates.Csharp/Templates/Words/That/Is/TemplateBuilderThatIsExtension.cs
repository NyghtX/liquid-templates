using LiquidTemplates.Csharp.Templates.Base;

namespace LiquidTemplates.Csharp.Templates.Words.That.Is
{
    public static class TemplateBuilderThatIsExtension
    {
        public static TemplateBuilderThatIsBuilder<TTemplateBuilder> Is<TTemplateBuilder>(
            this TemplateBuilderThatBuilder<TTemplateBuilder> templateThatBuilder)
            where TTemplateBuilder : ITemplateBuilder
        {
            return new TemplateBuilderThatIsBuilder<TTemplateBuilder>(templateThatBuilder.TemplateBuilder);
        }
    }
}