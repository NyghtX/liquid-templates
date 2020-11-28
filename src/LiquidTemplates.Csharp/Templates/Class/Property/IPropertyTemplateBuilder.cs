namespace LiquidTemplates.Csharp.Templates.Class.Property
{
    public interface
        IPropertyTemplateBuilder<TPropertyTemplate, TPropertyType> : IPropertyTemplateBuilderUngenericAction where
        TPropertyTemplate : IPropertyTemplateBuilder<TPropertyTemplate, TPropertyType>
    {
        /// <summary>
        ///     Standard Wert, der von der Property genutzt wird
        /// </summary>
        /// <param name="value">Standard Wert</param>
        /// <returns>Instanz für Fluent Usage</returns>
        TPropertyTemplate WithDefaultValue(TPropertyType value);

        /// <summary>
        ///     Gibt an, dass die Property nur innerhalb der Klasse geändert werden können soll
        /// </summary>
        /// <returns>Instanz für Fluent Usage</returns>
        TPropertyTemplate WithPrivateSetter();

        /// <summary>
        ///     Gibt an, dass die Property nur innerhalb der Klasse und ihren Children geändert werden können soll
        /// </summary>
        /// <returns>Instanz für Fluent Usage</returns>
        TPropertyTemplate WithProtectedSetter();
    }
}