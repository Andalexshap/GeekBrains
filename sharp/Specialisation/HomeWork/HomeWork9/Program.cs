using System;
using System.Text.Json;
using System.Xml;

class Program
{
    static void Main()
    {
        // Пример JSON данных с двойными кавычками
        string jsonData = @"{
            ""name"": ""John Doe"",
            ""age"": 30,
            ""city"": ""New York"",
            ""skills"": [""C#"", ""JavaScript"", ""SQL""]
        }";

        // Конвертирование JSON в XML
        string xmlData = ConvertJsonToXml(jsonData);

        // Вывод результата
        Console.WriteLine(xmlData);
    }

    static string ConvertJsonToXml(string jsonData)
    {
        // Парсинг JSON
        JsonDocument jsonDoc = JsonDocument.Parse(jsonData);

        // Создание XML-документа с корневым элементом "root"
        var xmlDoc = new XmlDocument();
        var rootElement = xmlDoc.CreateElement("root");
        xmlDoc.AppendChild(rootElement);

        // Рекурсивное добавление элементов в XML
        ParseJson(xmlDoc, rootElement, jsonDoc.RootElement);

        // Преобразование XML в строку
        return xmlDoc.OuterXml;
    }

    static void ParseJson(XmlDocument xmlDoc, XmlNode parentNode, JsonElement jsonElement)
    {
        switch (jsonElement.ValueKind)
        {
            case JsonValueKind.Object:
                foreach (var property in jsonElement.EnumerateObject())
                {
                    var subElement = xmlDoc.CreateElement(property.Name);
                    parentNode.AppendChild(subElement);
                    ParseJson(xmlDoc, subElement, property.Value);
                }
                break;
            case JsonValueKind.Array:
                int index = 1;
                foreach (var item in jsonElement.EnumerateArray())
                {
                    var subElement = xmlDoc.CreateElement("item");
                    parentNode.AppendChild(subElement);
                    ParseJson(xmlDoc, subElement, item);
                    index++;
                }
                break;
            default:
                parentNode.InnerText = jsonElement.ToString();
                break;
        }
    }
}