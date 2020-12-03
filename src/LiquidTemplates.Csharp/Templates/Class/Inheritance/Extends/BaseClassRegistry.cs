using System.Collections.Generic;

namespace LiquidTemplates.Csharp.Templates.Class.Inheritance.Extends
{
    /// <inheritdoc />
    public class BaseClassRegistry : IBaseClassRegistry
    {
        /// <summary>
        /// Liste der registrierten Baseclasses, geordnet nach Namespace:Class
        /// </summary>
        private readonly Dictionary<string, BaseClass> _baseClasses = new Dictionary<string, BaseClass>();
        
        /// <summary>
        /// Gibt alle registrierten BaseClasses wieder
        /// </summary>
        /// <returns>Alle registrierten Baseclasses</returns>
        public IEnumerable<BaseClass> GetAll() => _baseClasses.Values;

        /// <summary>
        /// Liest Informationen zu einer Registrierten Baseclass
        /// </summary>
        /// <param name="className">Name der Baseclass</param>
        /// <param name="ns">Namespace, in dem die Baseclass zu finden ist</param>
        /// <returns>Informationen zu der gesuchten Baseclass</returns>
        public BaseClass Get(string className, string ns) => _baseClasses[$"{ns}:{className}"];

        /// <summary>
        /// Registriert eine weitere Baseclass
        /// </summary>
        /// <param name="baseClass">Baseclass, die registriert werden soll</param>
        public void Register(BaseClass baseClass) => _baseClasses.Add($"{baseClass.Namespace}:{baseClass.ClassName}", baseClass);
    }
}