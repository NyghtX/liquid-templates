using FluentValidation;

namespace Templify.ClassGenerator.Templates.Class
{
    public class ClassTemplateValidator : AbstractValidator<ClassTemplate>
    {
        public ClassTemplateValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3);
        }
    }
}