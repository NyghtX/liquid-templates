using LiquidTemplates.Csharp.Templates.Class.Words.With;

namespace LiquidTemplates.Csharp.Templates.Class.Property
{
    public interface
        IPropertyTemplateBuilder : IClassTemplateBuilderWithBuilder


    {
        IPropertyTemplateBuilder WithName(string name);
    }
}