namespace LiquidTemplates.Csharp.Templates.Class.Property
{
    public interface
        IPropertyTemplateBuilder<TPropertyTemplate, TPropertyType>
    {
        /// <summary>
        ///     Standard Wert, der von der Property genutzt wird
        /// </summary>
        /// <param name="value">Standard Wert</param>
        /// <returns>Instanz für Fluent Usage</returns>
        TPropertyTemplate WithDefaultValue(TPropertyType value);
    }
}