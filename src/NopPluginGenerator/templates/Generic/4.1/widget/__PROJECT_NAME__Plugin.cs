using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Infrastructure;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Web.Framework.Infrastructure;

namespace __NAMESPACE_PREFIX__.__PROJECT_NAME__
{
    public class __PROJECT_NAME__Plugin : BasePlugin, IWidgetPlugin
    {
        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;
        private readonly INopFileProvider _fileProvider;

        public __PROJECT_NAME__Plugin(ILocalizationService localizationService,
            ISettingService settingService,
            IWebHelper webHelper,
            INopFileProvider fileProvider)
        {
            this._localizationService = localizationService;
            this._settingService = settingService;
            this._webHelper = webHelper;
            this._fileProvider = fileProvider;
        }

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            return new List<string> { PublicWidgetZones.HomePageTop };
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/Widgets__PROJECT_NAME__/Configure";
        }

        /// <summary>
        /// Gets a name of a view component for displaying widget
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <returns>View component name</returns>
        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "Widgets__PROJECT_NAME__";
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            //settings
            var settings = new __PROJECT_NAME__Settings
            {
     
            };

            _settingService.SaveSetting(settings);


            //_localizationService.AddOrUpdatePluginLocaleResource(".", "");
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

            //_localizationService.DeletePluginLocaleResource("");

            base.Uninstall();
        }
    }
}