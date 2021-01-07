using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(SocialNetwork.Models.Entidades.UserEntity usuario)
        {

            SocialNetwork.Models.Entidades.User usrLogin = Services.LoginService.UserAuthentication(usuario);
            if (usrLogin != null)
            {
                Session["User"] = usrLogin;
                Session.Timeout = 30;
                return View("Index");
            }
            return View();
        }
        [HttpGet]
        public RedirectResult Logout()
        {
            if (Session["User"] != null)
            {
                Session["User"] = null;
                
            }

            return Redirect("/Login");
            
        }

    }
}