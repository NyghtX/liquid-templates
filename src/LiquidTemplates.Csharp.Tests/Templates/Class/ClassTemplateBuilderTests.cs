using FluentAssertions;
using LiquidTemplates.Csharp.Templates.Base;
using LiquidTemplates.Csharp.Templates.Class;
using LiquidTemplates.Csharp.Templates.Class.AccessModifier;
using LiquidTemplates.Csharp.Templates.Class.Words.That;
using LiquidTemplates.Csharp.Templates.Class.Words.That.Is;
using Xunit;

namespace LiquidTemplates.Csharp.Tests.Templates.Class
{
    public class ClassTemplateBuilderTests
    {
        [Fact]
        public void ClassTemplate_Simple_Example()
        {
            // => Arrange
            TemplateFiles.ClassTemplateFile = TemplateFile.From("Templates/Class/Class.template");

            // => Act
            var myGeneratedClass = ClassTemplateBuilder
                .CreateClass()
                .WithName("MyGeneratedClass")
                .InNamespace("Nyghtx.Generator.Generated")
                .That().Is().Public()
                .ToString();

            // => Assert

            // Klassenname
            myGeneratedClass.Should().Contain("MyGeneratedClass");

            // Namespace
            myGeneratedClass.Should().Contain("namespace Nyghtx.Generator.Generated");

            // Access
            myGeneratedClass.Should().Contain("public class");
        }
    }
}