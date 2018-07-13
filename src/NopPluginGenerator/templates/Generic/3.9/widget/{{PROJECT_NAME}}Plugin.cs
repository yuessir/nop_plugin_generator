using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using System.Collections.Generic;
using System.Web.Routing;

namespace __NAMESPACE_PREFIX__.__PROJECT_NAME__
{
    public class __PROJECT_NAME__Plugin : BasePlugin, IWidgetPlugin
    {
        #region Fields
        private readonly ISettingService _settingService;
        private readonly __PROJECT_NAME__Settings ___PROJECT_NAME__Settings;
        #endregion

        #region Ctor
        public __PROJECT_NAME__Plugin(
            ISettingService settingService,
            __PROJECT_NAME__Settings __PROJECT_NAME__Settings)
        {
            this._settingService = settingService;
            this.___PROJECT_NAME__Settings = __PROJECT_NAME__Settings;
        }
        #endregion

        public void GetConfigurationRoute(out string actionName, out string controllerName, out System.Web.Routing.RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "__CONTROLLER_PREFIX____PROJECT_NAME__";
            routeValues = new RouteValueDictionary { { "Namespaces", "__NAMESPACE_PREFIX____PROJECT_NAME__.Controllers" }, { "area", null } };
        }

        public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out System.Web.Routing.RouteValueDictionary routeValues)
        {
            actionName = "PublicInfo";
            controllerName = "__CONTROLLER_PREFIX____PROJECT_NAME__";
            routeValues = new RouteValueDictionary
            {
                {"Namespaces", "__NAMESPACE_PREFIX____PROJECT_NAME__.Controllers"},
                {"area", null},
                {"widgetZone", widgetZone}
            };
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string>() {
                __PROJECT_NAME__Settings.WidgetZones.__WIDGET_ZONE__.ToString()
            };
        }
        
        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            var settings = new __PROJECT_NAME__Settings
            {
                Display__PROJECT_NAME__Widget = false
            };
            _settingService.SaveSetting(settings);

            this.AddOrUpdatePluginLocaleResource("__NAMESPACE_PREFIX__.__PROJECT_NAME__.Instructions", "Fill out the following information, either sitewide, or by store.");
            this.AddOrUpdatePluginLocaleResource("__NAMESPACE_PREFIX__.__PROJECT_NAME__.Display__PROJECT_NAME__Widget", "Display __DESCRIPTION_FriendlyName__ Widget");

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<__PROJECT_NAME__Settings>();

            //locales
            this.DeletePluginLocaleResource("__NAMESPACE_PREFIX__.__PROJECT_NAME__.Instructions");
            this.DeletePluginLocaleResource("__NAMESPACE_PREFIX__.__PROJECT_NAME__.Display__PROJECT_NAME__Widget");

            base.Uninstall();
        }
    }
}
