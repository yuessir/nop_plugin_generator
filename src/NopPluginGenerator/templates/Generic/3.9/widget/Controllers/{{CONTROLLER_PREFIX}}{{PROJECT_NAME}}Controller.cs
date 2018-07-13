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
using __NAMESPACE_PREFIX__.__PROJECT_NAME__.Models;

namespace __NAMESPACE_PREFIX__.__PROJECT_NAME__.Controllers
{
    public class __CONTROLLER_PREFIX____PROJECT_NAME__Controller : BasePluginController
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
        public __CONTROLLER_PREFIX____PROJECT_NAME__Controller(
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

            return View(__PROJECT_NAME__Settings.PluginPath + "/Views/__CONTROLLER_PREFIX____PROJECT_NAME__/Configure.cshtml", model);
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
            return View(__PROJECT_NAME__Settings.PluginPath + "/Views/__CONTROLLER_PREFIX____PROJECT_NAME__/PublicInfo.cshtml", model);
        }
        #endregion

        #region List
        [AdminAuthorize]
        public ActionResult List()
        {
            return View(__PROJECT_NAME__Settings.PluginPath + "/Views/__CONTROLLER_PREFIX____PROJECT_NAME__/List.cshtml");
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
            return View(__PROJECT_NAME__Settings.PluginPath + "/Views/__CONTROLLER_PREFIX____PROJECT_NAME__/Test.cshtml");
        }
        #endregion
    }
}
