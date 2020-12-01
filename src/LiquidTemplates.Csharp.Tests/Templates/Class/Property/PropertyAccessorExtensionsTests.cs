using FluentAssertions;
using LiquidTemplates.Csharp.Templates.Class.Property;
using LiquidTemplates.Csharp.Templates.Class.Property.SimpleTypes;
using LiquidTemplates.Words.That;
using LiquidTemplates.Words.That.Has;
using Xunit;

namespace LiquidTemplates.Csharp.Tests.Templates.Class.Property
{
    public class PropertyAccessorExtensionsTests
    {
        [Fact]
        public void PrivateSetter()
        {
            // => Arrange
            TemplateFiles.PropertyTemplateFile = TemplateFile.From("Templates/Class/Property/Property.template");
            var replacement = StringPropertyTemplateBuilder.Create()
                .WithName("Testname")

                // => Act
                .That().Has().PrivateSetter().GetReplacement();

            // => Assert
            replacement.ReplaceWith.Should().Contain("private set;");
        }
    }
}