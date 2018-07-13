using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using System.Collections.Generic;
using System.Web.Routing;

namespace {{NAMESPACE_PREFIX}}.{{PROJECT_NAME}}
{
    public class {{PROJECT_NAME}}Plugin : BasePlugin, IWidgetPlugin
    {
        #region Fields
        private readonly ISettingService _settingService;
        private readonly {{PROJECT_NAME}}Settings _{{PROJECT_NAME}}Settings;
        #endregion

        #region Ctor
        public {{PROJECT_NAME}}Plugin(
            ISettingService settingService,
            {{PROJECT_NAME}}Settings {{PROJECT_NAME}}Settings)
        {
            this._settingService = settingService;
            this._{{PROJECT_NAME}}Settings = {{PROJECT_NAME}}Settings;
        }
        #endregion

        public void GetConfigurationRoute(out string actionName, out string controllerName, out System.Web.Routing.RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "{{CONTROLLER_PREFIX}}{{PROJECT_NAME}}";
            routeValues = new RouteValueDictionary { { "Namespaces", "{{NAMESPACE_PREFIX}}{{PROJECT_NAME}}.Controllers" }, { "area", null } };
        }

        public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out System.Web.Routing.RouteValueDictionary routeValues)
        {
            actionName = "PublicInfo";
            controllerName = "{{CONTROLLER_PREFIX}}{{PROJECT_NAME}}";
            routeValues = new RouteValueDictionary
            {
                {"Namespaces", "{{NAMESPACE_PREFIX}}{{PROJECT_NAME}}.Controllers"},
                {"area", null},
                {"widgetZone", widgetZone}
            };
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string>() {
                {{PROJECT_NAME}}Settings.WidgetZones.{{WIDGET_ZONE}}.ToString()
            };
        }
        
        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            var settings = new {{PROJECT_NAME}}Settings
            {
                Display{{PROJECT_NAME}}Widget = false
            };
            _settingService.SaveSetting(settings);

            this.AddOrUpdatePluginLocaleResource("{{NAMESPACE_PREFIX}}.{{PROJECT_NAME}}.Instructions", "Fill out the following information, either sitewide, or by store.");
            this.AddOrUpdatePluginLocaleResource("{{NAMESPACE_PREFIX}}.{{PROJECT_NAME}}.Display{{PROJECT_NAME}}Widget", "Display {{DESCRIPTION_FriendlyName}} Widget");

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<{{PROJECT_NAME}}Settings>();

            //locales
            this.DeletePluginLocaleResource("{{NAMESPACE_PREFIX}}.{{PROJECT_NAME}}.Instructions");
            this.DeletePluginLocaleResource("{{NAMESPACE_PREFIX}}.{{PROJECT_NAME}}.Display{{PROJECT_NAME}}Widget");

            base.Uninstall();
        }
    }
}
