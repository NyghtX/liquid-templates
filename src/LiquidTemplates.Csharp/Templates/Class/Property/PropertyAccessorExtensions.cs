using LiquidTemplates.Csharp.Templates.Class.Property.Words.That.Has;
using LiquidTemplates.Csharp.Templates.Extensions;

namespace LiquidTemplates.Csharp.Templates.Class.Property
{
    public static class PropertyAccessorExtensions
    {
        public static IPropertyTemplateBuilder PrivateSetter(this PropertyTemplateHasBuilder builder)
        {
            builder.PropertyTemplateBuilder.AddReplacement(new PlaceHolderReplacement("SETTER", "private set;"));
            return builder.PropertyTemplateBuilder;
        }
    }
}