using SocialNetwork.Models.Entidades;
using SocialNetwork.Services;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    public class PostsController : Controller
    {
        // GET: Posts
        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return View("Error");
            }
            List<Post> posts = Services.PostService.GetPostForUser(((User)Session["User"]).iduser);
            return View(posts);

        }

        [HttpGet]
        public ViewResult Publish()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Publish(Post post)
        {
            User usr = (User)Session["User"];
            post.User = usr;
            HttpPostedFileBase file = Request.Files["PostImage"];
            
            PostService.CreatePostObject(post, file);

            return View();
        }


        public ViewResult Post(int id)
        {

            return View(Services.PostService.GetPost(id));
        }
    }
}