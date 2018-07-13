using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Configuration;
using Nop.Web.Framework.Components;
using __NAMESPACE_PREFIX__.__PROJECT_NAME__;
using __NAMESPACE_PREFIX__.__PROJECT_NAME__.Models;

namespace __NAMESPACE_PREFIX__.PROJECT_NAME.Components
{
    [ViewComponent(Name = "Widgets__PROJECT_NAME__")]
    public class Widgets__PROJECT_NAME__ViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly ISettingService _settingService;

        public Widgets__PROJECT_NAME__ViewComponent(IStoreContext storeContext, 
            ISettingService settingService)
        {
            this._storeContext = storeContext;
            this._settingService = settingService;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            var settings = _settingService.LoadSetting<__PROJECT_NAME__Settings>(_storeContext.CurrentStore.Id);

            var model = new PublicInfoModel
            {
       
            };

            return View("~/Plugins/Widgets.__PROJECT_NAME__/Views/PublicInfo.cshtml", model);
        }

       
    }
}
