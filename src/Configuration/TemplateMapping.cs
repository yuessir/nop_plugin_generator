using System.Xml.Serialization;

namespace NopPluginTemplator.Configuration
{
    public class TemplateMapping
    {
        [XmlAttribute]
        public string TemplateName { get; set; }
        [XmlAttribute]
        public string TemplateFolder { get; set; }

    }
}