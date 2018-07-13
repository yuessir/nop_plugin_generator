using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace __NAMESPACE_PREFIX__.__PROJECT_NAME__.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }
      
        [NopResourceDisplayName("__NAMESPACE_PREFIX__.__PROJECT_NAME__.XXXXX")]
        public string XXXXX { get; set; }
        public bool XXXXX_OverrideForStore { get; set; }
    }
}