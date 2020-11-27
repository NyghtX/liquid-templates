namespace Templify.ClassGenerator.Templates.Base
{
    /// <summary>
    ///     Basis für Templates
    /// </summary>
    public abstract class TemplateBuilderBase<TTemplateType> : ITemplateBuilder<TTemplateType>
        where TTemplateType : TemplateBuilderBase<TTemplateType>
    {
        /// <summary>
        ///     Source Template
        /// </summary>
        protected readonly TemplateFile Source;

        /// <summary>
        ///     Access Modifier, der generiert werden soll
        /// </summary>
        protected AccessModifier AccessModifierValue = Base.AccessModifier.Public;


        public TemplateBuilderBase(TemplateFile templateFile)
        {
            Source = templateFile;
        }

        public TemplateBuilderBase(string templatePath) : this(TemplateFile.From(templatePath))
        {
        }

        /// <summary>
        ///     Name, der generiert werden soll
        /// </summary>
        protected string Name { get; private set; }

        /// <summary>
        ///     Access Modifier
        /// </summary>
        public string AccessModifier => AccessModifierValue.ToString().ToLower();


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
            AccessModifierValue = accessModifier;
            return (TTemplateType) this;
        }
    }
}