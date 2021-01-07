using SocialNetwork.Models.Entidades;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        [HttpGet]
        public ActionResult UserSetting(int id)
        {
            User user;
            using (Models.Entidades.SocialNetworkEntities db = new SocialNetworkEntities())
            {
                user = db.Users.Find(id);


            }
            string imreBase64Data = Convert.ToBase64String(user.profilepic);
            string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            ViewBag.IMAGEN = imgDataURL;

            return View(user);
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserEntity user)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            //create an array of bytes we will use to store the encrypted password
            Byte[] hashedBytes;
            //Create a UTF8Encoding object we will use to convert our password string to a byte array
            UTF8Encoding encoder = new UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(user.Password));

            HttpPostedFileBase file = Request.Files["NewProfilePic"];
            byte[] img;
            if (file.FileName == "")
            {
                 img = null;
            }
            else
            {
                 img = SocialNetwork.Services.MediaService.ConvertToBytes(file);
            }

            

            using (Models.Entidades.SocialNetworkEntities db = new SocialNetworkEntities())
            {
                Models.Entidades.User usr = new User();
                usr.profilepic = img;
                usr.password = hashedBytes;
                usr.name = user.Name;
                usr.lastname = user.Lastname;
                usr.username = user.Username;
                usr.email = user.Email;
                usr.birthdate = user.Birthdate;

                db.Users.Add(usr);
                db.SaveChanges();

            }

            return View();
        }



    }
}