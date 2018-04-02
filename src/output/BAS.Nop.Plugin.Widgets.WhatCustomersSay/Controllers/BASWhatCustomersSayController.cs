using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Customers;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Stores;
using Nop.Web.Framework.Controllers;
using System.Linq;
using System.Web.Mvc;
using BAS.Nop.Plugin.Widgets.WhatCustomersSay.Models;

namespace BAS.Nop.Plugin.Widgets.WhatCustomersSay.Controllers
{
    public class BASWhatCustomersSayController : BasePluginController
    {
        #region Fields
        private readonly ILocalizationService _localizationService;

        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;

        private readonly ICustomerService _customerService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IStoreService _storeService;
        private readonly ISettingService _settingService;
        #endregion

        #region ctor
        public BASWhatCustomersSayController(
            IStoreContext storeContext,
            IWorkContext workContext,

            ICustomerService customerService,
            ICustomerActivityService customerActivityService,
            IGenericAttributeService genericAttributeService,
            ILocalizationService localizationService,
            IStoreService storeService,
            ISettingService settingService
            )
        {
            this._storeContext = storeContext;
            this._workContext = workContext;

            this._customerService = customerService;
            this._customerActivityService = customerActivityService;
            this._genericAttributeService = genericAttributeService;
            this._localizationService = localizationService;
            this._storeService = storeService;
            this._settingService = settingService;

        }
        #endregion

        #region Configure
        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure()
        {
            var model = new ConfigurationModel();

            return View(WhatCustomersSaySettings.PluginPath + "/Views/BASWhatCustomersSay/Configure.cshtml", model);
        }

        [HttpPost]
        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure(ConfigurationModel model)
        {
            return Configure();
        }
        #endregion

        #region PublicInfo
        [ChildActionOnly]
        public ActionResult PublicInfo()
        {

            PublicInfoViewModel model = new PublicInfoViewModel();

            // Display the View
            return View(WhatCustomersSaySettings.PluginPath + "/Views/BASWhatCustomersSay/PublicInfo.cshtml", model);
        }
        #endregion

        #region List
        [AdminAuthorize]
        public ActionResult List()
        {
            return View(WhatCustomersSaySettings.PluginPath + "/Views/BASWhatCustomersSay/List.cshtml");
        }
        #endregion

        #region Test
        /// <summary>
        /// Action for testing purposes only
        /// </summary>
        /// <returns></returns>
        [AdminAuthorize]
        public ActionResult Test()
        {
            return View(WhatCustomersSaySettings.PluginPath + "/Views/BASWhatCustomersSay/Test.cshtml");
        }
        #endregion
    }
}
