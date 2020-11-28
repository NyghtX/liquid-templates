using FluentAssertions;
using LiquidTemplates.Csharp.Templates.Base;
using LiquidTemplates.Csharp.Templates.Class.Property.SimpleTypes;
using Xunit;

namespace LiquidTemplates.Csharp.Tests.Templates.Class.Property
{
    public class SimplePropertyBuilderTests
    {
        [Fact]
        public void StringPropertyTemplateBuilder_Simple_Success()
        {
            // => Arrange
            TemplateFiles.PropertyTemplateFile = TemplateFile.From("Templates/Class/Property/Property.template");

            // => Act
            var myStringProperty = StringPropertyTemplateBuilder
                .Create()
                .WithName("Vorname")
                .ThatIs(AccessModifier.Private)
                .Build();

            // => Assert
            myStringProperty.Source.Should().Be("private string Vorname ;");
        }
    }
}