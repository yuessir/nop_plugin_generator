using Nop.Web.Framework;

namespace __NAMESPACE_PREFIX__.__PROJECT_NAME__.Models
{
    public class ConfigurationModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        public ConfigurationModel()
        {

        }

        [NopResourceDisplayName("__NAMESPACE_PREFIX__.__PROJECT_NAME__.Display__PROJECT_NAME__Widget")]
        public bool Display__PROJECT_NAME__Widget { get; set; }
        public bool Display__PROJECT_NAME__Widget_OverrideForStore { get; set; }
    }
}
