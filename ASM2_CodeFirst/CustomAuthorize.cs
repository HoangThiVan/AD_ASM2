using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASM2_CodeFirst
{
    public class CustomAuthorize:AuthorizeAttribute
    {
        //Khai báo prop ViewName để gọi đến View tương ứng
        public string ViewName { get; set; }
        public CustomAuthorize()
        {
            ViewName = "AuthorizeFail";


        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            isUserAuthorized(filterContext);
        }
        void isUserAuthorized(AuthorizationContext filterContext)
        {
            if (filterContext.Result == null)
                return;
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                ViewDataDictionary dic = new ViewDataDictionary();
                dic.Add("Message", "Bạn ko có quyền truy cập trang này");
                var result = new ViewResult() { ViewName = this.ViewName, ViewData = dic };
                filterContext.Result = result;
            }
        }
    }
}