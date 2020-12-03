using System.Collections.Generic;

namespace LiquidTemplates.Replacement
{
    public interface IReplacementBuilder
    {
        /// <summary>
        ///     Holt das Replacement aus dem Builder
        /// </summary>
        /// <returns></returns>
        IEnumerable<PlaceHolderReplacement> GetReplacements();
    }
}