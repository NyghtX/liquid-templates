using Templify.ClassGenerator.Templates.Base;

namespace Templify.ClassGenerator.Templates.Class.Property
{
    public abstract class PropertyTemplateBuilderBase<TPropertyTemplate> : TemplateBuilderBase<TPropertyTemplate>,
        IPropertyTemplate
        where TPropertyTemplate : TemplateBuilderBase<TPropertyTemplate>
    {
        protected PropertyTemplateBuilderBase(TemplateFile templateFile) : base(templateFile)
        {
        }

        protected PropertyTemplateBuilderBase(string templatePath) : base(templatePath)
        {
        }
    }
}