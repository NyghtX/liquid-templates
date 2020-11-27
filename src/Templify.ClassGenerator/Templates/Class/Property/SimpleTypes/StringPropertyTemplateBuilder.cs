using System;

namespace Templify.ClassGenerator.Templates.Class.Property.SimpleTypes
{
    public class StringPropertyTemplateBuilder : SimplePropertyBuilderBase<StringPropertyTemplateBuilder, string>
    {
        /// <summary>
        ///     Beginnt den Prozess einr neuen SimpleProperty Template zum Generieren zu erstellen
        /// </summary>
        /// <returns>TPropertyTemplateBuilder, das Fluent genutzt werden soll</returns>
        /// <exception cref="NullReferenceException">Wenn das TemplateFile noch nicht gesetzt wurde</exception>
        public static StringPropertyTemplateBuilder Create() => new StringPropertyTemplateBuilder();

        protected override string PropertyTypeName { get; set; } = "string";
    }
}