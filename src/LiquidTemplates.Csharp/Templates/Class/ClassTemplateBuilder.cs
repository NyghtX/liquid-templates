using System;
using LiquidTemplates.Replacement;

namespace LiquidTemplates.Csharp.Templates.Class
{
    /// <summary>
    ///     Template, auf das Replacements angewendet werden können
    /// </summary>
    public class ClassTemplateBuilder : TemplateBuilderBase, IClassTemplateBuilder
    {
        /// <summary>
        /// TemplateFile, das für ClassTemplates genutzt werden soll
        /// </summary>
        public static TemplateFile TemplateFile = TemplateFile.From("Templates/Class/Class.template");
        
        public ClassTemplateBuilder(TemplateFile templateFile) : base(templateFile,
            ClassTemplatePlaceholder.Placeholders)
        {
        }

        /// <summary>
        ///     Gibt an, wie die Klasse heißen soll
        /// </summary>
        /// <param name="name">Name, den die Klasse haben soll</param>
        /// <returns>ClassBuilder für Fluent Syntax</returns>
        public IClassTemplateBuilder WithName(string name)
        {
            AddReplacement(new PlaceHolderReplacement(ClassTemplatePlaceholder.Classname, name));
            return this;
        }

        /// <summary>
        ///     Definiert den Namespace, in dem die Klasse angelegt werden soll
        /// </summary>
        /// <param name="inNamespace">Namespace, in dem die Klasse angelegt werden soll</param>
        /// <returns>ClassTemplate für Fluent Building</returns>
        public IClassTemplateBuilder InNamespace(string inNamespace)
        {
            AddReplacement(new PlaceHolderReplacement(ClassTemplatePlaceholder.Namespace, inNamespace));
            return this;
        }

        /// <summary>
        ///     Beginnt den Prozess ein neues Class Template zum Generieren zu erstellen
        /// </summary>
        /// <returns>ClassTemplate, das Fluent genutzt werden soll</returns>
        /// <exception cref="NullReferenceException">Wenn das TemplateFile noch nicht gesetzt wurde</exception>
        public static IClassTemplateBuilder CreateClass() =>
            new ClassTemplateBuilder(TemplateFile);
    }
}