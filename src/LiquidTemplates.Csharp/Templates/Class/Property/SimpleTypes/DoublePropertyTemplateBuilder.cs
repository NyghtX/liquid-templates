using System;

namespace LiquidTemplates.Csharp.Templates.Class.Property.SimpleTypes
{
    public class DoublePropertyTemplateBuilder : SimplePropertyBuilderBase
    {
        public DoublePropertyTemplateBuilder()
        {
            AddReplacement(new PlaceHolderReplacement(PropertyTemplatePlaceholder.PropertyType, "double"));
        }

        /// <summary>
        ///     Beginnt den Prozess einr neuen SimpleProperty Template zum Generieren zu erstellen
        /// </summary>
        /// <returns>TPropertyTemplateBuilder, das Fluent genutzt werden soll</returns>
        /// <exception cref="NullReferenceException">Wenn das TemplateFile noch nicht gesetzt wurde</exception>
        public static DoublePropertyTemplateBuilder Create()
        {
            return new DoublePropertyTemplateBuilder();
        }
    }
}