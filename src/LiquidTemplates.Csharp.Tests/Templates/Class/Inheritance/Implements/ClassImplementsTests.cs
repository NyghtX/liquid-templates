using System.Linq;
using FluentAssertions;
using LiquidTemplates.Csharp.Templates.Class;
using LiquidTemplates.Csharp.Templates.Class.Inheritance.Implements;
using LiquidTemplates.Words.That;
using LiquidTemplates.Words.That.Is;
using Xunit;

namespace LiquidTemplates.Csharp.Tests.Templates.Class.Inheritance.Implements
{
    public class ClassImplementsTests
    {
        [Fact]
        public void ClassTemplate_WithInterface()
        {
            // => Arrange

            // => Act
            var classTemplateBuilder = ClassTemplateBuilder
                .CreateClass()
                .WithName("MyGeneratedClass")
                .InNamespace("Nyghtx.Generator.Generated")
                .That().Is().Public()
                .That().Implements(new InterfaceImplementation("IMyInterface", "My.Interface.Namespace"));

            classTemplateBuilder.Build();
            var generatedClass = classTemplateBuilder.GetGeneratedFiles().First();
            var generatedClassContent = generatedClass.Conent;
            // => Assert

            // Klassenname
            generatedClassContent.Should().Contain("MyGeneratedClass : IMyInterface");
        }

        [Fact]
        public void Implements_Success()
        {
            // => Arrange
            var interfaceImplementation = new InterfaceImplementation("IMyInterface", "My.Interface.Namespace");
            interfaceImplementation.AddImplementation("public void Test() {};");

            // => Act

            var classTemplateBuilder = ClassTemplateBuilder
                .CreateClass()
                .WithName("MyGeneratedClass")
                .InNamespace("Nyghtx.Generator.Generated")
                .That().Is().Public()
                .That().Implements(interfaceImplementation);

            classTemplateBuilder.Build();
            var generatedClass = classTemplateBuilder.GetGeneratedFiles().First();
            var generatedClassContent = generatedClass.Conent;
            // => Assert

            // Klassenname
            generatedClassContent.Should().Contain("MyGeneratedClass : IMyInterface");

            // Implementierung
            generatedClassContent.Should().Contain("public void Test() {};");
        }
    }
}