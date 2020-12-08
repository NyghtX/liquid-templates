namespace LiquidTemplates.Csharp.Templates.Class.Property.SimpleTypes
{
    public static class Property
    {
        public static StringPropertyTemplateBuilder String() => StringPropertyTemplateBuilder.Create();
        public static BoolPropertyTemplateBuilder Bool() => BoolPropertyTemplateBuilder.Create();
        public static DoublePropertyTemplateBuilder Double() => DoublePropertyTemplateBuilder.Create();
        public static IntPropertyTemplateBuilder Int() => IntPropertyTemplateBuilder.Create();
        public static FloatPropertyTemplateBuilder Float() => FloatPropertyTemplateBuilder.Create();
    }
}