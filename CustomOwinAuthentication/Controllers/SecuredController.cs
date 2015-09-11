using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SecurityAddons;

namespace CustomOwinAuthentication.Controllers
{
    [Authorize]
    public class SecuredController : Controller
    {
        public StringBuilder _sb;
        ClaimsPrincipal _principal;

        public SecuredController()
        {
            _sb = new StringBuilder();
            _principal = (ClaimsPrincipal)Thread.CurrentPrincipal;
            _sb.Append("My UserName is " + _principal.GetStringValue(ClaimTypes.Name) + ". ");
            _sb.Append("My real name is " + _principal.GetStringValue(ClaimTypes.GivenName) + ". ");
            _sb.Append("My email address is " + _principal.GetStringValue(ClaimTypes.Email) + ". ");
        }
        //
        // GET: /Secured/
        public ActionResult Index()
        {
            _sb.Append("This page is available to any authorized user");
            return Content(_sb.ToString());
        }

        //
        // GET: /Secured/
        [Authorize(Roles="Admin , Edit")]
        public ActionResult Edit()
        {
            
            _sb.Append("This page is available to admin and edit users. ");
            return Content(_sb.ToString());
        }

        //
        // GET: /Secured/
        [Authorize(Roles="Admin")]
        public ActionResult Admin()
        {
            _sb.Append("This page is only available to admin users");
            return Content(_sb.ToString());
        }
	}
}