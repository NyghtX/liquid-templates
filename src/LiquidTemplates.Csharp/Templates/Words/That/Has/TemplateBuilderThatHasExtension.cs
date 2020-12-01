using LiquidTemplates.Csharp.Templates.Base;

namespace LiquidTemplates.Csharp.Templates.Words.That.Has
{
    public static class TemplateBuilderThatHasExtension
    {
        public static TemplateBuilderThatHasBuilder<TTemplateBuilder> Has<TTemplateBuilder>(
            this TemplateBuilderThatBuilder<TTemplateBuilder> templateThatBuilder)
            where TTemplateBuilder : ITemplateBuilder
        {
            return new TemplateBuilderThatHasBuilder<TTemplateBuilder>(templateThatBuilder.TemplateBuilder);
        }
    }
}