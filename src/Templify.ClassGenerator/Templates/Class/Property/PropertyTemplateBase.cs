using Templify.ClassGenerator.Templates.Base;

namespace Templify.ClassGenerator.Templates.Class.Property
{
    public abstract class PropertyTemplateBase<TPropertyTemplate> : TemplateBase<TPropertyTemplate>, IPropertyTemplate where TPropertyTemplate : TemplateBase<TPropertyTemplate>
    {
        protected PropertyTemplateBase(TemplateFile templateFile) : base(templateFile)
        {
        }

        protected PropertyTemplateBase(string templatePath) : base(templatePath)
        {
        }
    }
}