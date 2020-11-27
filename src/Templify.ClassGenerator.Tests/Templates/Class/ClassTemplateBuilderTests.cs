using FluentAssertions;
using Templify.ClassGenerator.Templates.Base;
using Templify.ClassGenerator.Templates.Class;
using Xunit;

namespace Templify.ClassGenerator.Tests.Templates.Class
{
    public class ClassTemplateBuilderTests
    {
        [Fact]
        public void ClassTemplate_Simple_Example()
        {
            // => Arrange
            ClassTemplateBuilder.TemplateFile = TemplateFile.From("Templates/Class/Class.template");

            // => Act
            var myGeneratedClass = ClassTemplateBuilder
                .CreateClass()
                .WithName("MyGeneratedClass")
                .InNamespace("Nyghtx.Generator.Generated")
                .ThatIs(AccessModifier.Private)
                .Build();

            // => Assert

            // Klassenname
            myGeneratedClass.Name.Should().Be("MyGeneratedClass");
            myGeneratedClass.Source.Should().Contain("MyGeneratedClass");

            // Namespace
            myGeneratedClass.Namespace.Should().Be("Nyghtx.Generator.Generated");
            myGeneratedClass.Source.Should().Contain("namespace Nyghtx.Generator.Generated");

            // Access
            myGeneratedClass.AccessModifier.Should().Be(AccessModifier.Private);
            myGeneratedClass.Source.Should().Contain("private class");
        }
    }
}