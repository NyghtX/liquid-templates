using System.Collections.Generic;

namespace LiquidTemplates.Csharp.Templates.Class.Inheritance.Extends
{
    /// <summary>
    /// Registry, in der Informationen zu Baseclasses gespeichert werden
    /// </summary>
    public interface IBaseClassRegistry
    {
        /// <summary>
        /// Gibt alle registrierten BaseClasses wieder
        /// </summary>
        /// <returns>Alle registrierten Baseclasses</returns>
        public IEnumerable<BaseClass> GetAll();

        /// <summary>
        /// Liest Informationen zu einer Registrierten Baseclass
        /// </summary>
        /// <param name="className">Name der Baseclass</param>
        /// <param name="ns">Namespace, in dem die Baseclass zu finden ist</param>
        /// <returns>Informationen zu der gesuchten Baseclass</returns>
        public BaseClass Get(string className, string ns);

        /// <summary>
        /// Registriert eine weitere Baseclass
        /// </summary>
        /// <param name="baseClass">Baseclass, die registriert werden soll</param>
        public void Register(BaseClass baseClass);
    }
}