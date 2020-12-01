using LiquidTemplates.Csharp.Templates.Extensions;

namespace LiquidTemplates.Csharp.Templates.Base
{
    public interface IReplacementBuilder
    {
        /// <summary>
        ///     Holt das Replacement aus dem Builder
        /// </summary>
        /// <returns></returns>
        PlaceHolderReplacement GetReplacement();
    }
}