using System.Drawing;

namespace SocialNetwork.Models.Entidades
{
    public class UserEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Image ProfilePic { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int IdUser { get; set; }
        public System.DateTime Birthdate { get; set; }
    }
}