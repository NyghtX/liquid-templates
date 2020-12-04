using LiquidTemplates.Words.That;

namespace LiquidTemplates.Csharp.Templates.Class.Inheritance.Implements
{
    public static class ThatExtension
    {
        public static TTemplateBuilder Implements<TTemplateBuilder>(
            this TemplateBuilderThatBuilder<TTemplateBuilder> thatBuilder,
            InterfaceImplementation interfaceImplementation) where TTemplateBuilder : ITemplateBuilder
        {
            thatBuilder.TemplateBuilder.AddReplacements(interfaceImplementation.GetReplacements());
            return thatBuilder.TemplateBuilder;
        }

    }
}