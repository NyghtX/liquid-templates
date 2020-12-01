using System;

namespace LiquidTemplates.Csharp.Templates.Class.Property.SimpleTypes
{
    public class IntPropertyTemplateBuilder : SimplePropertyBuilderBase
    {
        public IntPropertyTemplateBuilder()
        {
            AddReplacement(new PlaceHolderReplacement(PropertyTemplatePlaceholder.PropertyType, "int"));
        }

        /// <summary>
        ///     Beginnt den Prozess einr neuen SimpleProperty Template zum Generieren zu erstellen
        /// </summary>
        /// <returns>TPropertyTemplateBuilder, das Fluent genutzt werden soll</returns>
        /// <exception cref="NullReferenceException">Wenn das TemplateFile noch nicht gesetzt wurde</exception>
        public static IntPropertyTemplateBuilder Create()
        {
            return new IntPropertyTemplateBuilder();
        }
    }
}