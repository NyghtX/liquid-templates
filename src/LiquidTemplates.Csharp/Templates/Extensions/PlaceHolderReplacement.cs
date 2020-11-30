namespace LiquidTemplates.Csharp.Templates.Extensions
{
    public class PlaceHolderReplacement
    {
        public PlaceHolderReplacement(string placeholder, string replaceWith)
        {
            Placeholder = placeholder;
            ReplaceWith = replaceWith;
        }

        /// <summary>
        /// Placeholder, an dessen Stelle das Replacement eingesetzt werden soll
        /// </summary>
        public string Placeholder { get; }
        
        /// <summary>
        /// String, mit dem der Placeholder ersetzt werden soll
        /// </summary>
        public string ReplaceWith { get; }
        
    }
}