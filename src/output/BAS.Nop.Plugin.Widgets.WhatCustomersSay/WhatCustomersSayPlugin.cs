using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using System.Collections.Generic;
using System.Web.Routing;

namespace BAS.Nop.Plugin.Widgets.WhatCustomersSay
{
    public class WhatCustomersSayPlugin : BasePlugin, IWidgetPlugin
    {
        #region Fields
        private readonly ISettingService _settingService;
        private readonly WhatCustomersSaySettings _WhatCustomersSaySettings;
        #endregion

        #region Ctor
        public WhatCustomersSayPlugin(
            ISettingService settingService,
            WhatCustomersSaySettings WhatCustomersSaySettings)
        {
            this._settingService = settingService;
            this._WhatCustomersSaySettings = WhatCustomersSaySettings;
        }
        #endregion

        public void GetConfigurationRoute(out string actionName, out string controllerName, out System.Web.Routing.RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "BASWhatCustomersSay";
            routeValues = new RouteValueDictionary { { "Namespaces", "BAS.Nop.Plugin.WidgetsWhatCustomersSay.Controllers" }, { "area", null } };
        }

        public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out System.Web.Routing.RouteValueDictionary routeValues)
        {
            actionName = "PublicInfo";
            controllerName = "BASWhatCustomersSay";
            routeValues = new RouteValueDictionary
            {
                {"Namespaces", "BAS.Nop.Plugin.WidgetsWhatCustomersSay.Controllers"},
                {"area", null},
                {"widgetZone", widgetZone}
            };
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string>() {
                WhatCustomersSaySettings.WidgetZones.what_customers_say_display.ToString()
            };
        }
        
        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            var settings = new WhatCustomersSaySettings
            {
                DisplayWhatCustomersSayWidget = false
            };
            _settingService.SaveSetting(settings);

            this.AddOrUpdatePluginLocaleResource("BAS.Nop.Plugin.Widgets.WhatCustomersSay.Instructions", "Fill out the following information, either sitewide, or by store.");
            this.AddOrUpdatePluginLocaleResource("BAS.Nop.Plugin.Widgets.WhatCustomersSay.DisplayWhatCustomersSayWidget", "Display What Customers Say Widget");

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<WhatCustomersSaySettings>();

            //locales
            this.DeletePluginLocaleResource("BAS.Nop.Plugin.Widgets.WhatCustomersSay.Instructions");
            this.DeletePluginLocaleResource("BAS.Nop.Plugin.Widgets.WhatCustomersSay.DisplayWhatCustomersSayWidget");

            base.Uninstall();
        }
    }
}
