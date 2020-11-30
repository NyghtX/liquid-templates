using LiquidTemplates.Csharp.Templates.Base;

namespace LiquidTemplates.Csharp.Templates.Class
{
    public interface IClassTemplateBuilder : ITemplateBuilder
    {
        /// <summary>
        /// Gibt an, wie die Klasse heißen soll
        /// </summary>
        /// <param name="name">Name, den die Klasse haben soll</param>
        /// <returns>ClassBuilder für Fluent Syntax</returns>
        public IClassTemplateBuilder WithName(string name);
        
        /// <summary>
        /// Gibt an, in welchem Namespace die Klasse angelegt werden soll
        /// </summary>
        /// <param name="inNamespace">Namespace, in dem die Klasse angelegt werden soll</param>
        /// <returns>ClassBuilder für Fluent Syntax</returns>
        public IClassTemplateBuilder InNamespace(string inNamespace);
    }
}