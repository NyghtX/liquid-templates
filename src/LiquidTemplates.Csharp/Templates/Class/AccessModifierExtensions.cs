using LiquidTemplates.Csharp.Templates.Extensions;
using LiquidTemplates.Csharp.Templates.Words.That.Is;

namespace LiquidTemplates.Csharp.Templates.Class
{
    public static class AccessModifierExtensions
    {
        public static IClassTemplateBuilder Private(
            this TemplateBuilderThatIsBuilder<IClassTemplateBuilder> templateBuilderThatIsBuilder)
        {
            templateBuilderThatIsBuilder.TemplateBuilder.AddReplacement(
                new PlaceHolderReplacement(ClassTemplatePlaceholder.AccessModifier, "private"));
            return templateBuilderThatIsBuilder.TemplateBuilder;
        }

        public static IClassTemplateBuilder Public(
            this TemplateBuilderThatIsBuilder<IClassTemplateBuilder> templateBuilderThatIsBuilder)
        {
            templateBuilderThatIsBuilder.TemplateBuilder.AddReplacement(
                new PlaceHolderReplacement(ClassTemplatePlaceholder.AccessModifier, "public"));
            return templateBuilderThatIsBuilder.TemplateBuilder;
        }

        public static IClassTemplateBuilder Internal(
            this TemplateBuilderThatIsBuilder<IClassTemplateBuilder> templateBuilderThatIsBuilder)
        {
            templateBuilderThatIsBuilder.TemplateBuilder.AddReplacement(
                new PlaceHolderReplacement(ClassTemplatePlaceholder.AccessModifier, "internal"));
            return templateBuilderThatIsBuilder.TemplateBuilder;
        }
    }
}