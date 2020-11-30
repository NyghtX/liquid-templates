using LiquidTemplates.Csharp.Templates.Extensions;

namespace LiquidTemplates.Csharp.Templates.Class.Words.With
{
    public interface IClassTemplateBuilderWithBuilder
    {
        /// <summary>
        /// Holt das Replacement aus dem Builder
        /// </summary>
        /// <returns></returns>
        PlaceHolderReplacement GetReplacement();
    }
}