using System.Linq;
using FluentAssertions;
using LiquidTemplates.Csharp.Templates.Class;
using LiquidTemplates.Csharp.Templates.Class.Inheritance.Extends;
using LiquidTemplates.Csharp.Templates.Class.Inheritance.Implements;
using LiquidTemplates.Csharp.Templates.Class.Property;
using LiquidTemplates.Csharp.Templates.Class.Property.SimpleTypes;
using LiquidTemplates.Words.That;
using LiquidTemplates.Words.That.Has;
using LiquidTemplates.Words.That.Is;
using LiquidTemplates.Words.With;
using Xunit;

namespace LiquidTemplates.Csharp.Tests.Templates.Class
{
    public class ClassTemplateBuilderTests
    {
        [Fact]
        public void ClassTemplate_Simple_Example()
        {
            // => Arrange

            // => Act
            var classTemplateBuilder = ClassTemplateBuilder
                .CreateClass()
                .WithName("MyGeneratedClass")
                .InNamespace("Nyghtx.Generator.Generated")
                .That().Is().Public()
                .With(
                    StringPropertyTemplateBuilder
                        .Create()
                        .WithName("Vorname")
                        .That().Has().PrivateSetter()
                );
            
            classTemplateBuilder.Build();

            // => Assert
            var generatedClass = classTemplateBuilder.GetGeneratedFiles().First();
            var generatedClassContent = generatedClass.Conent;
            
            // Filename
            generatedClass.Filename.Should().Be("MyGeneratedClass.generated.cs");

            // Klassenname
            generatedClassContent.Should().Contain("MyGeneratedClass");

            // Namespace
            generatedClassContent.Should().Contain("namespace Nyghtx.Generator.Generated");

            // Access
            generatedClassContent.Should().Contain("public class");

            // Property
            generatedClassContent.Should().Contain("public string Vorname {get; private set;}");
        }


        [Fact]
        public void ClassTemplate_WithBaseAndInterface()
        {
            // => Arrange

            // => Act
            var classTemplateBuilder = ClassTemplateBuilder
                .CreateClass()
                .WithName("MyGeneratedClass")
                .InNamespace("Nyghtx.Generator.Generated")
                .That().Is().Public()
                .That().Extends(new BaseClass("TestBase", "MyTestbaseNamespace"))
                .That().Implements(new InterfaceImplementation("Testinterface", "My.Interface.Namespace"));

            classTemplateBuilder.Build();

            // => Assert
            var generatedClass = classTemplateBuilder.GetGeneratedFiles().First();
            var generatedClassContent = generatedClass.Conent;
            // => Assert

            // Klassenname
            generatedClassContent.Should().Contain("MyGeneratedClass : TestBase, Testinterface");
        }
    }
}