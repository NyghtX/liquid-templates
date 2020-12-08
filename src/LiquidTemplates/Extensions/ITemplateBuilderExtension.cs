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
        /// <param name="builder">Template Builder, auf dem die Extension ausgeführt wird</param>
        void Execute(ITemplateBuilder builder);

        /// <summary>
        /// Führt den BuildProzess aus
        /// <param name="builder">Template Builder, auf dem die Extension ausgeführt wird</param>
        /// </summary>
        void Build(ITemplateBuilder builder);
    }
}