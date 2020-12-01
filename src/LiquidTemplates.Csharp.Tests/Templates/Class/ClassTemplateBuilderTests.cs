using FluentAssertions;
using LiquidTemplates.Csharp.Templates;
using LiquidTemplates.Csharp.Templates.Class;
using LiquidTemplates.Csharp.Templates.Class.Property;
using LiquidTemplates.Csharp.Templates.Class.Property.SimpleTypes;
using LiquidTemplates.Csharp.Templates.Words.That;
using LiquidTemplates.Csharp.Templates.Words.That.Has;
using LiquidTemplates.Csharp.Templates.Words.That.Is;
using LiquidTemplates.Csharp.Templates.Words.With;
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
            TemplateFiles.PropertyTemplateFile = TemplateFile.From("Templates/Class/Property/Property.template");

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
    }
}