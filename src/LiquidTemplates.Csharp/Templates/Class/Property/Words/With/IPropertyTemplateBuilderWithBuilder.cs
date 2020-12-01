using LiquidTemplates.Csharp.Templates.Extensions;

namespace LiquidTemplates.Csharp.Templates.Class.Property.Words.With
{
    public interface IPropertyTemplateBuilderWithBuilder
    {
        /// <summary>
        ///     Holt das Replacement aus dem Builder
        /// </summary>
        /// <returns></returns>
        PlaceHolderReplacement GetReplacement();
    }
}