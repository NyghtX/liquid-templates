using System;
using LiquidTemplates.Replacement;

namespace LiquidTemplates.Csharp.Templates.Class.Property.SimpleTypes
{
    public class BoolPropertyTemplateBuilder : SimplePropertyBuilderBase
    {
        public BoolPropertyTemplateBuilder()
        {
            AddReplacement(new PlaceHolderReplacement(PropertyTemplatePlaceholder.PropertyType, "bool"));
        }

        /// <summary>
        ///     Beginnt den Prozess einr neuen SimpleProperty Template zum Generieren zu erstellen
        /// </summary>
        /// <returns>TPropertyTemplateBuilder, das Fluent genutzt werden soll</returns>
        /// <exception cref="NullReferenceException">Wenn das TemplateFile noch nicht gesetzt wurde</exception>
        public static BoolPropertyTemplateBuilder Create()
        {
            return new BoolPropertyTemplateBuilder();
        }
    }
}