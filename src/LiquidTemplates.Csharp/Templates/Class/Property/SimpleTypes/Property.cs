namespace LiquidTemplates.Csharp.Templates.Class.Property.SimpleTypes
{
    public static class Property
    {
        public static StringPropertyTemplateBuilder String()
        {
            return StringPropertyTemplateBuilder.Create();
        }

        public static BoolPropertyTemplateBuilder Bool()
        {
            return BoolPropertyTemplateBuilder.Create();
        }

        public static DoublePropertyTemplateBuilder Double()
        {
            return DoublePropertyTemplateBuilder.Create();
        }

        public static IntPropertyTemplateBuilder Int()
        {
            return IntPropertyTemplateBuilder.Create();
        }

        public static FloatPropertyTemplateBuilder Float()
        {
            return FloatPropertyTemplateBuilder.Create();
        }
    }
}