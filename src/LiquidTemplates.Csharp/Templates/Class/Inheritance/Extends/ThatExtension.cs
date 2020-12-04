using LiquidTemplates.Words.That;

namespace LiquidTemplates.Csharp.Templates.Class.Inheritance.Extends
{
    public static class ThatExtension
    {
        public static TTemplateBuilder Extends<TTemplateBuilder>(
            this TemplateBuilderThatBuilder<TTemplateBuilder> thatBuilder,
            BaseClass baseClass) where TTemplateBuilder : ITemplateBuilder
        {
            thatBuilder.TemplateBuilder.AddReplacements(baseClass.GetReplacements());
            return thatBuilder.TemplateBuilder;
        }
    }
}