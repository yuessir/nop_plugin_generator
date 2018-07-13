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
using {{NAMESPACE_PREFIX}}.{{PROJECT_NAME}}.Models;

namespace {{NAMESPACE_PREFIX}}.{{PROJECT_NAME}}.Controllers
{
    public class {{CONTROLLER_PREFIX}}{{PROJECT_NAME}}Controller : BasePluginController
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
        public {{CONTROLLER_PREFIX}}{{PROJECT_NAME}}Controller(
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

            return View({{PROJECT_NAME}}Settings.PluginPath + "/Views/{{CONTROLLER_PREFIX}}{{PROJECT_NAME}}/Configure.cshtml", model);
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
            return View({{PROJECT_NAME}}Settings.PluginPath + "/Views/{{CONTROLLER_PREFIX}}{{PROJECT_NAME}}/PublicInfo.cshtml", model);
        }
        #endregion

        #region List
        [AdminAuthorize]
        public ActionResult List()
        {
            return View({{PROJECT_NAME}}Settings.PluginPath + "/Views/{{CONTROLLER_PREFIX}}{{PROJECT_NAME}}/List.cshtml");
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
            return View({{PROJECT_NAME}}Settings.PluginPath + "/Views/{{CONTROLLER_PREFIX}}{{PROJECT_NAME}}/Test.cshtml");
        }
        #endregion
    }
}
