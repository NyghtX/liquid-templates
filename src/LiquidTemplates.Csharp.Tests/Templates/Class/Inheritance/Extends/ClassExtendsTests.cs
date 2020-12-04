using System.Collections.Generic;
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
            
            myGeneratedClass.Should().Contain("public override void Test() {int i = 5;}");

        }
    }
}