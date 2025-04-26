using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire.Dashboard;
namespace Services
{
    



public class MyAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        // هنا تتحكم في من يسمح له بالدخول للـ Dashboard
        var httpContext = context.GetHttpContext();

        // مثال بسيط: السماح فقط لو المستخدم مسجل دخوله
        return httpContext.User.Identity.IsAuthenticated;

        // تقدر كمان تحدد شروط إضافية زي:
        // السماح فقط لمستخدمين رول محددة مثلاً "Admin"
        // return httpContext.User.Identity.IsAuthenticated && httpContext.User.IsInRole("Admin");
    }
}
}