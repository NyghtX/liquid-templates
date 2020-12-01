using FluentAssertions;
using LiquidTemplates.Csharp.Templates.Class;
using LiquidTemplates.Words.That;
using LiquidTemplates.Words.That.Is;
using Xunit;

namespace LiquidTemplates.Csharp.Tests.Templates.Class
{
    public class AccessModifierExtensionsTests
    {
        [Fact]
        public void Private()
        {
            // => Arrange
            TemplateFiles.ClassTemplateFile = TemplateFile.From("Templates/Class/Class.template");
            var template = ClassTemplateBuilder.CreateClass()
                .WithName("Testname")
                .InNamespace("Testnamespace")

                // => Act
                .That().Is().Private().ToString();

            // => Assert
            template.Should().Contain("private class Testname");
        }

        [Fact]
        public void Public()
        {
            // => Arrange
            TemplateFiles.ClassTemplateFile = TemplateFile.From("Templates/Class/Class.template");
            var template = ClassTemplateBuilder.CreateClass()
                .WithName("Testname")
                .InNamespace("Testnamespace")

                // => Act
                .That().Is().Public().ToString();

            // => Assert
            template.Should().Contain("public class Testname");
        }

        [Fact]
        public void Internal()
        {
            // => Arrange
            TemplateFiles.ClassTemplateFile = TemplateFile.From("Templates/Class/Class.template");
            var template = ClassTemplateBuilder.CreateClass()
                .WithName("Testname")
                .InNamespace("Testnamespace")

                // => Act
                .That().Is().Internal().ToString();

            // => Assert
            template.Should().Contain("internal class Testname");
        }
    }
}