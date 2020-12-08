namespace LiquidTemplates.Addition
{
    /// <summary>
    ///     Addition, die zu einem TemplateBuilder hinzugefügt werden kann
    /// </summary>
    public interface ITemplateBuilderAddition
    {
        /// <summary>
        /// Führt den Build-Prozess der Addition aus
        /// </summary>
        void Build();
    }
}