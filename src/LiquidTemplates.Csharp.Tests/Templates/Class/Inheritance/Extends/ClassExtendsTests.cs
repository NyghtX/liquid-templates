using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using LiquidTemplates.Csharp.Templates.Class;
using LiquidTemplates.Csharp.Templates.Class.Inheritance.Extends;
using LiquidTemplates.Replacement;
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
            var implementations = new List<string>()
            {
                "public override void Test() {int i = [IVALUE];}"
            };
            var templatePlaceholders = new List<TemplatePlaceholder>()
            {
                new TemplatePlaceholder("IVALUE", true, false)
            };
            var replacements = new Dictionary<string, List<PlaceHolderReplacement>>()
            {
                {"IVALUE", new List<PlaceHolderReplacement>()
                {
                    new PlaceHolderReplacement("IVALUE", "5")
                }}
            };
            
            var baseClass = new BaseClass("TestBase", "MyTestbaseNamespace", implementations, templatePlaceholders, replacements);
            var classTemplateBuilder = ClassTemplateBuilder
                .CreateClass()
                .WithName("MyGeneratedClass")
                .InNamespace("Nyghtx.Generator.Generated")
                .That().Is().Public()
                .That().Extends(baseClass);
            
            classTemplateBuilder.Build();
            var generatedClass = classTemplateBuilder.GetGeneratedFiles().First();
            var generatedClassContent = generatedClass.Conent;

            // => Assert

            // Klassenname
            generatedClassContent.Should().Contain("MyGeneratedClass : TestBase");
            
            generatedClassContent.Should().Contain("public override void Test() {int i = 5;}");

        }
    }
}