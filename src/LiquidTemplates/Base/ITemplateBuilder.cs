namespace LiquidTemplates
{
    public interface ITemplateBuilder
    {
        /// <summary>
        ///     Fügt der List der Replacements einen Eintrag hinzu
        /// </summary>
        /// <param name="replacement">Replacement, dass an den Placeholder gebracht wird</param>
        public void AddReplacement(PlaceHolderReplacement replacement);
    }
}