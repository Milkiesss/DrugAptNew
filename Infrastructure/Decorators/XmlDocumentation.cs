using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace DrugsApt.Infrastructure.Decorators;
/// <summary>
/// Класс получения комментариев
/// </summary>
public static class XmlDocumentation
{
    /// <summary>
    /// извлечение комментов из Xml
    /// </summary>
    /// <param name="propertyName">Имя свойствва</param>
    /// <typeparam name="Type">Сущность</typeparam>
    /// <returns></returns>
    public static string GetXmlComments<Type>(string propertyName)
    {
        var xmlContent = File.ReadAllText(Path.ChangeExtension(typeof(Type).Assembly.Location, ".xml"));
        var doc = XDocument.Parse(xmlContent);
        var targetclass = $"P:{typeof(Type).FullName}.{propertyName}";
        Console.WriteLine(typeof(Type).FullName);
        var comment = doc.Descendants("member")
            .Where(x=> (string)x.Attribute("name") == targetclass)
            .Select(x=> x.Element("summary")?.Value.Trim())
            .FirstOrDefault();
        Console.WriteLine(comment);
        return comment;
    }
}