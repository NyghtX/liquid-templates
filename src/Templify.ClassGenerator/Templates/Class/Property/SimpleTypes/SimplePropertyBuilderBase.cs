using Templify.ClassGenerator.Templates.Base;

namespace Templify.ClassGenerator.Templates.Class.Property.SimpleTypes
{
    public abstract class
        SimplePropertyBuilderBase<TPropertyTemplateBuilder, TPropertyType> : PropertyTemplateBuilderBase<
            TPropertyTemplateBuilder, TPropertyType>
        where TPropertyTemplateBuilder : TemplateBuilderBase<TPropertyTemplateBuilder>,
        IPropertyTemplateBuilder<TPropertyTemplateBuilder, TPropertyType>
    {
    }
}