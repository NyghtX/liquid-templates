namespace LiquidTemplates.Csharp.Templates.Words.With
{
    public static class TemplateBuilderWithExtension
    {
        public static TTemplateBuilder With<TTemplateBuilder>(this TTemplateBuilder templateBuilder,
            IReplacementBuilder builder) where TTemplateBuilder : ITemplateBuilder
        {
            templateBuilder.AddReplacement(builder.GetReplacement());
            return templateBuilder;
        }
    }
}