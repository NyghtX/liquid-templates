namespace Templify.ClassGenerator.Templates.Base
{
    /// <summary>
    ///     Basis für Templates
    /// </summary>
    public abstract class TemplateBase<TTemplateType> : ITemplate<TTemplateType>
        where TTemplateType : TemplateBase<TTemplateType>
    {
        /// <summary>
        ///     Source Template
        /// </summary>
        protected readonly TemplateFile Source;


        public TemplateBase(TemplateFile templateFile)
        {
            Source = templateFile;
        }

        public TemplateBase(string templatePath) : this(TemplateFile.From(templatePath))
        {
        }

        /// <summary>
        ///     Name, der generiert werden soll
        /// </summary>
        protected string Name { get; private set; }

        /// <summary>
        ///     Access Modifier, der generiert werden soll
        /// </summary>
        protected AccessModifier AccessModifier { get; private set; } = AccessModifier.Public;


        /// <summary>
        ///     Name des zu generierenden.. Etwas
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Instanz für Fluent Usage</returns>
        public TTemplateType WithName(string name)
        {
            Name = name;
            return (TTemplateType) this;
        }

        /// <summary>
        ///     Setzt den Access Modifier für das zu generierende.. Etwas
        /// </summary>
        /// <param name="accessModifier">Access Modifier</param>
        /// <returns>Instanz für Fluent Usage</returns>
        public TTemplateType ThatIs(AccessModifier accessModifier)
        {
            AccessModifier = accessModifier;
            return (TTemplateType) this;
        }
    }
}