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
            var myGeneratedClass = ClassTemplate
                .CreateClass()
                .WithName("MyGeneratedClass")
                .InNamespace("Nyghtx.Generator.Generated")
                .WithProperty(
                    StringPropertyTemplate.Create()
                        .WithName("Vorname")
                );
        }
    }
}