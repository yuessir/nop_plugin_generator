using Nop.Core.Configuration;

namespace BAS.Nop.Plugin.Widgets.WhatCustomersSay
{
    public class WhatCustomersSaySettings : ISettings
    {
        public const string PluginPath = "~/Plugins/Widgets.WhatCustomersSay";

        public enum WidgetZones
        {
            what_customers_say_display
        };

        public bool DisplayWhatCustomersSayWidget { get; set; }
    }
}
