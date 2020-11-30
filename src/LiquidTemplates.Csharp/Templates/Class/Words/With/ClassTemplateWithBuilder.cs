namespace LiquidTemplates.Csharp.Templates.Class.Words.With
{
    public class ClassTemplateWithBuilder
    {
        public readonly IClassTemplateBuilder ClassTemplateBuilder;

        public ClassTemplateWithBuilder(IClassTemplateBuilder classTemplateBuilder)
        {
            ClassTemplateBuilder = classTemplateBuilder;
        }
    }
}