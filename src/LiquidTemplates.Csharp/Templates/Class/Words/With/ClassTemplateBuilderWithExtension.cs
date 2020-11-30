namespace LiquidTemplates.Csharp.Templates.Class.Words.With
{
    public static class ClassTemplateBuilderWithExtension
    {
        public static IClassTemplateBuilder With(this IClassTemplateBuilder templateBuilder,
            IClassTemplateBuilderWithBuilder builder)
        {
            templateBuilder.AddReplacement(builder.GetReplacement());
            return templateBuilder;
        }
    }
}