using FluentAssertions;
using Templify.ClassGenerator.Templates.Base;
using Templify.ClassGenerator.Templates.Class.Property.SimpleTypes;
using Xunit;

namespace Templify.ClassGenerator.Tests.Templates.Class.Property
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