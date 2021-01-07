using SocialNetwork.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.Services
{
    public class PostService : Service
    {
        public static bool CreatePostObject(Post post, HttpPostedFileBase file)
        {
            //HttpPostedFileBase file = Request.Files["ImageData"];
            byte[] img;
            if (file.FileName == "")
            {
                img = null;
            }
            else
            {
                img = SocialNetwork.Services.MediaService.ConvertToBytes(file);
            }

            Post postToPublish = new Post();
            postToPublish.datepost = DateTime.Now.Date;
            postToPublish.timepost = DateTime.Now.TimeOfDay;
            postToPublish.text = post.text;
            postToPublish.image = img;
            postToPublish.User = post.User;
            postToPublish.iduser = post.User.iduser;
            post.type = 1;

            try
            {
                DB.Posts.Add(postToPublish);
                DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public static Post GetPost(int id)
        {
            return DB.Posts.Find(id);
        }

        public static List<Post> GetPostForUser(int idUser)
        {
            var postList = (from post in DB.Posts

                            where post.iduser == idUser
                            select post).OrderBy(x => x.datepost).ToList();

            return postList;
        }

        public static void GetPostForUserAndFriends(int idUser)
        {
            var postList = (from post in DB.Posts
                            join friend in DB.Friends on post.iduser equals friend.idfriend2
                            where post.iduser == idUser || post.iduser == friend.idfriend2
                            select post).OrderBy(x => x.datepost).ToList();


        }
    }
}