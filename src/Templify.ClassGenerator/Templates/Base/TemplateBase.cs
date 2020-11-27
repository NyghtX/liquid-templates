namespace Templify.ClassGenerator.Templates.Base
{
    /// <summary>
    ///     Basis für Templates
    /// </summary>
    public abstract class TemplateBase
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
    }
}