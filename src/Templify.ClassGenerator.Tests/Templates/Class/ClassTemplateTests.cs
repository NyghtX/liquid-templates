using Templify.ClassGenerator.Templates.Class;
using Templify.ClassGenerator.Templates.Class.Property.SimpleTypes;
using Xunit;

namespace Templify.ClassGenerator.Tests.Templates.Class
{
    public class ClassTemplateTests
    {
        [Fact]
        public void ClassTemplate_Example()
        {
            var myGeneratedClass = ClassTemplateBuilder
                .CreateClass()
                .WithName("MyGeneratedClass")
                .InNamespace("Nyghtx.Generator.Generated")
                .WithProperty(
                    StringPropertyTemplateBuilder.Create()
                        .WithName("Vorname")
                );
        }
    }
}