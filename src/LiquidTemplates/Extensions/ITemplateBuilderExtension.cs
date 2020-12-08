namespace LiquidTemplates.Extensions
{
    /// <summary>
    ///     Extension, die vom ITemplateBuiler ausgeführt wird
    /// </summary>
    public interface ITemplateBuilderExtension
    {
        /// <summary>
        ///     Führt die Extension aus
        /// </summary>
        void Execute();
    }
}