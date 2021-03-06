using System.Collections.Generic;

namespace LiquidTemplates.Csharp.Templates.Class.Inheritance.Implements
{
    public interface IInterfaceImplementationRegistry
    {
        /// <summary>
        ///     Gibt alle registrierten InterfaceImplementations wieder
        /// </summary>
        /// <returns>Alle registrierten InterfaceImplementationes</returns>
        public IEnumerable<InterfaceImplementation> GetAll();

        /// <summary>
        ///     Liest Informationen zu einer Registrierten InterfaceImplementation
        /// </summary>
        /// <param name="className">Name der InterfaceImplementation</param>
        /// <param name="ns">Namespace, in dem die InterfaceImplementation zu finden ist</param>
        /// <returns>Informationen zu der gesuchten InterfaceImplementation</returns>
        public InterfaceImplementation Get(string className, string ns);

        /// <summary>
        ///     Registriert eine weitere InterfaceImplementation
        /// </summary>
        /// <param name="interfaceImplementation">InterfaceImplementation, die registriert werden soll</param>
        public void Register(InterfaceImplementation interfaceImplementation);
    }
}