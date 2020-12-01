namespace LiquidTemplates.Replacement
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