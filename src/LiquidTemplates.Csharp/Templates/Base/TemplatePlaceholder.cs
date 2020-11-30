namespace LiquidTemplates.Csharp.Templates.Base
{
    public class TemplatePlaceholder
    {

        public TemplatePlaceholder(string identifier, bool required = false, bool multiple = true)
        {
            Required = required;
            Identifier = identifier;
            Multiple = multiple;
        }

        /// <summary>
        /// Identifier des Placeholders
        /// </summary>
        public string Identifier { get; }

        /// <summary>
        /// Gibt an, ob auf diesem Plaeholder mehrere Values replaced werden können
        /// </summary>
        public bool Multiple { get; }
        
        /// <summary>
        /// Gibt an, ob dieser Placeholder zwingend ersetzt werden muss
        /// </summary>
        public bool Required { get; }

    }
}