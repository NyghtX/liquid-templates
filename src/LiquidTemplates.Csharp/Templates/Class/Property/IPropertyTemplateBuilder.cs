namespace LiquidTemplates.Csharp.Templates.Class.Property
{
    public interface IPropertyTemplateBuilder : IReplacementBuilder, ITemplateBuilder
    {
        /// <summary>
        ///     Gibt der Property einen Namen
        /// </summary>
        /// <param name="name">Name der Property</param>
        /// <returns>Builder für die Fluent Syntax</returns>
        IPropertyTemplateBuilder WithName(string name);
    }
}