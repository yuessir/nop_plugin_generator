using Nop.Web.Framework;

namespace BAS.Nop.Plugin.Widgets.WhatCustomersSay.Models
{
    public class ConfigurationModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        public ConfigurationModel()
        {

        }

        [NopResourceDisplayName("BAS.Nop.Plugin.Widgets.WhatCustomersSay.DisplayWhatCustomersSayWidget")]
        public bool DisplayWhatCustomersSayWidget { get; set; }
        public bool DisplayWhatCustomersSayWidget_OverrideForStore { get; set; }
    }
}
