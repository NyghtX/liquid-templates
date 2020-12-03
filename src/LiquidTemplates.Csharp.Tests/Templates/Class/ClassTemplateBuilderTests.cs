using FluentAssertions;
using LiquidTemplates.Csharp.Templates.Class;
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
            var myGeneratedClass = ClassTemplateBuilder
                .CreateClass()
                .WithName("MyGeneratedClass")
                .InNamespace("Nyghtx.Generator.Generated")
                .That().Is().Public()
                .With(
                    StringPropertyTemplateBuilder
                        .Create()
                        .WithName("Vorname")
                        .That().Has().PrivateSetter()
                )
                .ToString();

            // => Assert

            // Klassenname
            myGeneratedClass.Should().Contain("MyGeneratedClass");

            // Namespace
            myGeneratedClass.Should().Contain("namespace Nyghtx.Generator.Generated");

            // Access
            myGeneratedClass.Should().Contain("public class");

            // Property
            myGeneratedClass.Should().Contain("public string Vorname {get; private set;}");
        }
        
        [Fact]
        public void ClassTemplate_WithBase()
        {
            // => Arrange

            // => Act
            var myGeneratedClass = ClassTemplateBuilder
                .CreateClass()
                .WithName("MyGeneratedClass")
                .InNamespace("Nyghtx.Generator.Generated")
                .That().Is().Public()
               
                .ToString();

            // => Assert

            // Klassenname
            myGeneratedClass.Should().Contain("MyGeneratedClass : MyBase");
        }
    }
}