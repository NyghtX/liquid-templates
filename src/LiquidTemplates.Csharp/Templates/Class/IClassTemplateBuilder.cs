using System.Collections.Generic;

namespace LiquidTemplates.Csharp.Templates.Class
{
    public interface IClassTemplateBuilder : ITemplateBuilder
    {
        /// <summary>
        ///     Gibt an, wie die Klasse heißen soll
        /// </summary>
        /// <param name="name">Name, den die Klasse haben soll</param>
        /// <returns>ClassBuilder für Fluent Syntax</returns>
        public IClassTemplateBuilder WithName(string name);

        /// <summary>
        ///     Gibt an, in welchem Namespace die Klasse angelegt werden soll
        /// </summary>
        /// <param name="inNamespace">Namespace, in dem die Klasse angelegt werden soll</param>
        /// <returns>ClassBuilder für Fluent Syntax</returns>
        public IClassTemplateBuilder InNamespace(string inNamespace);

        /// <summary>
        ///     Fügt dem ClassTemplateBuilder ein neues File hinzu, das beim Build ausgegeben wird
        /// </summary>
        /// <param name="file">File, das dem Builder hinzugefügt werden soll</param>
        public void AddFile(GeneratedFile file);

        /// <summary>
        ///     Gibt die generierten Files aus
        /// </summary>
        /// <returns>Liste der generierten Files</returns>
        public IEnumerable<GeneratedFile> GetGeneratedFiles();
    }
}