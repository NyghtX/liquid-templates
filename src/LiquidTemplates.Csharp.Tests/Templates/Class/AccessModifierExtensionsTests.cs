using System.Linq;
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
            var classTemplateBuilder = ClassTemplateBuilder.CreateClass()
                .WithName("Testname")
                .InNamespace("Testnamespace")

                // => Act
                .That().Is().Private();
            classTemplateBuilder.Build();
            var generatedClass = classTemplateBuilder.GetGeneratedFiles().First();
            var generatedClassContent = generatedClass.Conent;

            // => Assert
            generatedClassContent.Should().Contain("private class Testname");
        }

        [Fact]
        public void Public()
        {
            // => Arrange
            var classTemplateBuilder = ClassTemplateBuilder.CreateClass()
                .WithName("Testname")
                .InNamespace("Testnamespace")

                // => Act
                .That().Is().Public();
            classTemplateBuilder.Build();
            var generatedClass = classTemplateBuilder.GetGeneratedFiles().First();
            var generatedClassContent = generatedClass.Conent;

            // => Assert
            generatedClassContent.Should().Contain("public class Testname");
        }

        [Fact]
        public void Internal()
        {
            // => Arrange
            var classTemplateBuilder = ClassTemplateBuilder.CreateClass()
                .WithName("Testname")
                .InNamespace("Testnamespace")

                // => Act
                .That().Is().Internal();

            classTemplateBuilder.Build();
            var generatedClass = classTemplateBuilder.GetGeneratedFiles().First();
            var generatedClassContent = generatedClass.Conent;

            // => Assert
            generatedClassContent.Should().Contain("internal class Testname");
        }
    }
}