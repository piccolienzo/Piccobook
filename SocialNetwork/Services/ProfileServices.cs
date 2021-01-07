using SocialNetwork.Models.Entidades;
using System.Linq;

namespace SocialNetwork.Services
{
    public class ProfileServices : Service
    {
        public static User GetProfile(int id)
        {
            var profile = (from user in DB.Users
                           where user.iduser == id
                           select user).FirstOrDefault();

            if (profile != null)
            {
                return profile;

            }
            else
            {
                return null;
            }

        }
        public static User GetProfile(string username)
        {
            {
                var profile = (from user in DB.Users
                               where user.username.ToLower() == username.ToLower()
                               select user).FirstOrDefault();

                if (profile != null)
                {
                    return profile;

                }
                else
                {
                    return null;
                }

            }
        }

        public static bool SaveProfileChanges(User saveUser, int idUser, string oldPass, string newPass, byte[] newProfilePic)
        {
            var prof = DB.Users.Find(idUser);


            if (prof != null)
            {
                if (LoginService.ComparePassword(oldPass, prof.password))
                {
                    var pass = Services.LoginService.HashStringPassword(newPass);

                    prof.password = pass;
                    prof.iduser = saveUser.iduser;
                    prof.birthdate = saveUser.birthdate;
                    prof.email = saveUser.email;
                    prof.lastname = saveUser.lastname;
                    prof.name = saveUser.name;

                    if (newProfilePic == null)
                    {
                        prof.profilepic = prof.profilepic;
                    }
                    else
                    {
                        prof.profilepic = newProfilePic;
                    }

                    DB.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }


    }
}