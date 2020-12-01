using LiquidTemplates.Csharp.Templates.Class.Words.That.Is;
using LiquidTemplates.Csharp.Templates.Extensions;

namespace LiquidTemplates.Csharp.Templates.Class
{
    public static class AccessModifierExtensions
    {
        public static IClassTemplateBuilder Private(this ClassTemplateIsBuilder classTemplateIsBuilder)
        {
            classTemplateIsBuilder.ClassTemplateBuilder.AddReplacement(
                new PlaceHolderReplacement(ClassTemplatePlaceholder.AccessModifier, "private"));
            return classTemplateIsBuilder.ClassTemplateBuilder;
        }

        public static IClassTemplateBuilder Public(this ClassTemplateIsBuilder classTemplateIsBuilder)
        {
            classTemplateIsBuilder.ClassTemplateBuilder.AddReplacement(
                new PlaceHolderReplacement(ClassTemplatePlaceholder.AccessModifier, "public"));
            return classTemplateIsBuilder.ClassTemplateBuilder;
        }

        public static IClassTemplateBuilder Internal(this ClassTemplateIsBuilder classTemplateIsBuilder)
        {
            classTemplateIsBuilder.ClassTemplateBuilder.AddReplacement(
                new PlaceHolderReplacement(ClassTemplatePlaceholder.AccessModifier, "internal"));
            return classTemplateIsBuilder.ClassTemplateBuilder;
        }
    }
}