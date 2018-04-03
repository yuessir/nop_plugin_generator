using System.Collections.Generic;
using System.Xml.Serialization;

namespace NopPluginTemplator.Configuration
{
    public class TemplateConfig {      
        [XmlArrayItem("Map")]
        public List<TemplateMapping> Templates {get; set;}

        public TemplateConfig()
        {
            Templates=new  List<TemplateMapping>();
        }
    }
}