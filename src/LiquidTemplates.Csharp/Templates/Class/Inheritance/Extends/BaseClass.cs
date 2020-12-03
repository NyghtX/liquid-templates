namespace LiquidTemplates.Csharp.Templates.Class.Inheritance.Extends
{
    /// <summary>
    /// Base Class Builder
    /// </summary>
    public class BaseClass
    {
        public BaseClass(string className, string ns)
        {
            ClassName = className;
            Namespace = ns;
        }

        /// <summary>
        /// Name der Baseclass
        /// </summary>
        public string ClassName { get; }

        /// <summary>
        /// Namespace, in dem die Baseclass sich befindet
        /// </summary>
        public string Namespace { get; }
        
        
    }
}