using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using __NAMESPACE_PREFIX__.__PROJECT_NAME__.Models;

namespace __NAMESPACE_PREFIX__.__PROJECT_NAME__.Controllers
{
    [Area(AreaNames.Admin)]
    public class Widgets__PROJECT_NAME__Controller : BasePluginController
    {
        private readonly IStoreContext _storeContext;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;

        public Widgets__PROJECT_NAME__Controller(IStoreContext storeContext,
            IPermissionService permissionService, 
            ISettingService settingService,
            ICacheManager cacheManager,
            ILocalizationService localizationService)
        {
            this._storeContext = storeContext;
            this._permissionService = permissionService;
            this._settingService = settingService;
            this._localizationService = localizationService;
        }

        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var __PROJECT_NAME__Settings = _settingService.LoadSetting<__PROJECT_NAME__Settings>(storeScope);
            var model = new ConfigurationModel
            {
                ActiveStoreScopeConfiguration = storeScope
            };

            if (storeScope > 0)
            {
                //model.XXXX= _settingService.SettingExists(__PROJECT_NAME__Settings, x => x.AltText5, storeScope);
            }

            return View("~/Plugins/Widgets.__PROJECT_NAME__/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public IActionResult Configure(ConfigurationModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var settings = _settingService.LoadSetting<__PROJECT_NAME__Settings>(storeScope);
    
            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            //_settingService.SaveSettingOverridablePerStore(__PROJECT_NAME__Settings, x => x.Picture1Id, model.Picture1Id_OverrideForStore, storeScope, false);

            //now clear settings cache
            _settingService.ClearCache();
            
            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            return Configure();
        }
    }
}