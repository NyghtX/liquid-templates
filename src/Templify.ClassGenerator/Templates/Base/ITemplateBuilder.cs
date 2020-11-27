namespace Templify.ClassGenerator.Templates.Base
{
    public interface ITemplateBuilder<TTemplate> where TTemplate : ITemplateBuilder<TTemplate>
    {
        /// <summary>
        ///     Name des zu generierenden.. Etwas
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Instanz für Fluent Usage</returns>
        TTemplate WithName(string name);

        /// <summary>
        ///     Setzt den Access Modifier für das zu generierende.. Etwas
        /// </summary>
        /// <param name="accessModifier">Access Modifier</param>
        /// <returns>Instanz für Fluent Usage</returns>
        TTemplate ThatIs(AccessModifier accessModifier);
    }
}