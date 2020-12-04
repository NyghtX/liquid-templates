using FluentAssertions;
using LiquidTemplates.Csharp.Templates.Class;
using LiquidTemplates.Csharp.Templates.Class.Inheritance.Extends;
using LiquidTemplates.Words.That;
using LiquidTemplates.Words.That.Is;
using Xunit;

namespace LiquidTemplates.Csharp.Tests.Templates.Class.Inheritance.Extends
{
    public class ClassExtendsTests
    {
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
                .That().Extends(new BaseClass("TestBase", "MyTestbaseNamespace"))
                .ToString();

            // => Assert

            // Klassenname
            myGeneratedClass.Should().Contain("MyGeneratedClass : TestBase");
        }
        [Fact]
        public void Overrides()
        {
            // => Arrange
            var baseClass = new BaseClass("TestBase", "MyTestbaseNamespace");
            

            // => Act
            var myGeneratedClass = ClassTemplateBuilder
                .CreateClass()
                .WithName("MyGeneratedClass")
                .InNamespace("Nyghtx.Generator.Generated")
                .That().Is().Public()
                .That().Extends(baseClass)
                .ToString();

            // => Assert

            // Klassenname
            myGeneratedClass.Should().Contain("MyGeneratedClass : TestBase");
        }
    }
}