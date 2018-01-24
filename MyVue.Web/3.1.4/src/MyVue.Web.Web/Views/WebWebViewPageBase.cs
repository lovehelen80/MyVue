using Abp.Web.Mvc.Views;

namespace MyVue.Web.Web.Views
{
    public abstract class WebWebViewPageBase : WebWebViewPageBase<dynamic>
    {

    }

    public abstract class WebWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected WebWebViewPageBase()
        {
            LocalizationSourceName = WebConsts.LocalizationSourceName;
        }
    }
}