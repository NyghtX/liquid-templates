using FluentValidation;

namespace LiquidTemplates.Csharp.Templates.Class
{
    public class ClassTemplateValidator : AbstractValidator<ClassTemplate>
    {
        public ClassTemplateValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3);
        }
    }
}