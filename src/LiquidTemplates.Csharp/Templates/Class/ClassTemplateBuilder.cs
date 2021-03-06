using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiquidTemplates.Replacement;
using static System.String;

namespace LiquidTemplates.Csharp.Templates.Class
{
    /// <summary>
    ///     Template, auf das Replacements angewendet werden können
    /// </summary>
    public class ClassTemplateBuilder : TemplateBuilderBase, IClassTemplateBuilder
    {
        /// <summary>
        ///     TemplateFile, das für ClassTemplates genutzt werden soll
        /// </summary>
        public static TemplateFile TemplateFile = new TemplateFile(@"[USINGS]

namespace [NAMESPACE]
{
    [ACCESSMODIFIER] class [CLASSNAME][INHERITANCE]
    {
        [PROPERTY]
        
        [METHOD]

    }
}");

        /// <summary>
        ///     Files, die beim Build ausgegeben werden
        /// </summary>
        private readonly List<GeneratedFile> _files = new List<GeneratedFile>();

        /// <summary>
        ///     Name der Klasse
        /// </summary>
        private string _className = Empty;

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
            _className = name;
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
        ///     Fügt dem ClassTemplateBuilder ein neues File hinzu, das beim Build ausgegeben wird
        /// </summary>
        /// <param name="file">File, das dem Builder hinzugefügt werden soll</param>
        public void AddFile(GeneratedFile file)
        {
            _files.Add(file);
        }

        /// <summary>
        ///     Gibt die generierten Files aus
        /// </summary>
        /// <returns>Liste der generierten Files</returns>
        public IEnumerable<GeneratedFile> GetGeneratedFiles()
        {
            return _files;
        }

        /// <summary>
        ///     Beginnt den Prozess ein neues Class Template zum Generieren zu erstellen
        /// </summary>
        /// <returns>ClassTemplate, das Fluent genutzt werden soll</returns>
        /// <exception cref="NullReferenceException">Wenn das TemplateFile noch nicht gesetzt wurde</exception>
        public static IClassTemplateBuilder CreateClass()
        {
            return new ClassTemplateBuilder(TemplateFile);
        }

        public override void BeforeBuild()
        {
            // => Usings Builden
            BuildUsings();

            // => Inheritance
            var inheritanceBuilder = new StringBuilder(" : ");

            // => Prüfen, ob die Klasse eine BaseClass erweitert
            var baseClass = Replacements.Single(x => x.Key == ClassTemplatePlaceholder.Inheritance).Value
                .SingleOrDefault();
            if (baseClass != null)
                inheritanceBuilder.Append($"{baseClass.ReplaceWith}, ");


            // => Prüfen, ob es Interfaces gibt, welche die Klasse implementiert
            var implementsList = new HashSet<string>();
            var implements = Replacements.Single(x => x.Key == ClassTemplatePlaceholder.Implements).Value;
            foreach (var implement in implements.Select(x => x.ReplaceWith))
            {
                implementsList.Add(implement);
                inheritanceBuilder.Append($"{implement}, ");
            }

            // => Inheritance builden
            var inheritance = inheritanceBuilder.ToString().TrimEnd(' ', ',');

            ClearReplacementsFor(ClassTemplatePlaceholder.Inheritance);
            AddReplacement(new PlaceHolderReplacement(ClassTemplatePlaceholder.Inheritance,
                inheritance != " : " ? inheritance : Empty));
        }

        public override void AfterBuild()
        {
            // => Template zur Files hinufügen
            AddFile(new GeneratedFile($"{_className}.generated.cs", BuildResult));
        }

        private void BuildUsings()
        {
            // => Usings
            var usedNamespaces = new HashSet<string>();
            var usingStringBuilder = new StringBuilder();
            var usings = Replacements.Single(x => x.Key == ClassTemplatePlaceholder.Usings).Value;
            foreach (var usedNamespace in usings.Where(usedNamespace =>
                !usedNamespaces.Contains(usedNamespace.ReplaceWith)))
            {
                // => Namespace hinzufügen
                usingStringBuilder.AppendLine($"using {usedNamespace.ReplaceWith};");
                usedNamespaces.Add(usedNamespace.ReplaceWith);
            }

            // => Alte Using Replacements entfernen und neues Replacement hinzufügen
            ClearReplacementsFor(ClassTemplatePlaceholder.Usings);
            AddReplacement(new PlaceHolderReplacement(ClassTemplatePlaceholder.Usings, usingStringBuilder.ToString()));
        }
    }
}