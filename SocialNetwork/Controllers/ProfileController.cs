using SocialNetwork.Models.Entidades;
using SocialNetwork.Services;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile

        [HttpGet]
        public ActionResult Username(string username)
        {

            var profile = ProfileServices.GetProfile(username);
            if (profile != null)
            {
                return View("Profile", profile);
            }
            else
            {
                return View("Error");
            }

        }

        [HttpGet]
        public ActionResult Settings()
        {
            if (Session["User"] == null)
            {
                return View("Login");
            }
            else
            {
                var user = (Models.Entidades.User)Session["User"];
                return View(user);
            }


        }
        [HttpPost]
        public ActionResult Settings(User saveUser)
        {
            if (Session["User"] == null)
            {
                return View("Login");
            }
            else
            {
                var p = (string)Request.Form["TextBoxPasswordOld"];
                var x = (string)Request.Form["TextBoxPasswordnew"];

                HttpPostedFileBase file = Request.Files["NewProfilePic"];
                byte[] profPic;
                if (file.FileName == "")
                {
                    profPic = null;
                }
                else
                {
                    profPic = SocialNetwork.Services.MediaService.ConvertToBytes(file);
                }

                if (Services.ProfileServices.SaveProfileChanges(saveUser, saveUser.iduser, p, x, profPic))
                {
                    return View("Error");
                }
                else
                {
                    return View("Error");
                }







            }


        }
    }
}