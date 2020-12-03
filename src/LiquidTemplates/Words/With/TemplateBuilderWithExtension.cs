using LiquidTemplates.Replacement;

namespace LiquidTemplates.Words.With
{
    public static class TemplateBuilderWithExtension
    {
        public static TTemplateBuilder With<TTemplateBuilder>(this TTemplateBuilder templateBuilder,
            IReplacementBuilder builder) where TTemplateBuilder : ITemplateBuilder
        {
            templateBuilder.AddReplacements(builder.GetReplacements());
            return templateBuilder;
        }
    }
}