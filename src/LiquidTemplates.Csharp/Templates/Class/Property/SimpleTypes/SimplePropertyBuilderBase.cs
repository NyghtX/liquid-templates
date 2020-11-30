using LiquidTemplates.Csharp.Templates.Base;

namespace LiquidTemplates.Csharp.Templates.Class.Property.SimpleTypes
{
    public abstract class
        SimplePropertyBuilderBase<TPropertyTemplateBuilder, TPropertyType> : PropertyTemplateBuilderBase<
            TPropertyTemplateBuilder, TPropertyType>
        where TPropertyTemplateBuilder : TemplateBuilderBase,
        IPropertyTemplateBuilder<TPropertyTemplateBuilder, TPropertyType>
    {
    }
}