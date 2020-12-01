using System;

namespace LiquidTemplates.Csharp.Templates.Class.Property.SimpleTypes
{
    public class FloatPropertyTemplateBuilder : SimplePropertyBuilderBase
    {
        public FloatPropertyTemplateBuilder()
        {
            AddReplacement(new PlaceHolderReplacement(PropertyTemplatePlaceholder.PropertyType, "float"));
        }

        /// <summary>
        ///     Beginnt den Prozess einr neuen SimpleProperty Template zum Generieren zu erstellen
        /// </summary>
        /// <returns>TPropertyTemplateBuilder, das Fluent genutzt werden soll</returns>
        /// <exception cref="NullReferenceException">Wenn das TemplateFile noch nicht gesetzt wurde</exception>
        public static FloatPropertyTemplateBuilder Create()
        {
            return new FloatPropertyTemplateBuilder();
        }
    }
}