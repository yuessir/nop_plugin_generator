using Nop.Web.Framework;

namespace {{NAMESPACE_PREFIX}}.{{PROJECT_NAME}}.Models
{
    public class ConfigurationModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        public ConfigurationModel()
        {

        }

        [NopResourceDisplayName("{{NAMESPACE_PREFIX}}.{{PROJECT_NAME}}.Display{{PROJECT_NAME}}Widget")]
        public bool Display{{PROJECT_NAME}}Widget { get; set; }
        public bool Display{{PROJECT_NAME}}Widget_OverrideForStore { get; set; }
    }
}
