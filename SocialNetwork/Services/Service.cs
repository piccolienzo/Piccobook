namespace SocialNetwork.Services
{
    public class Service
    {
        private static Models.Entidades.SocialNetworkEntities _db;
        public static Models.Entidades.SocialNetworkEntities DB
        {
            get
            {
                if (_db == null)
                {
                    _db = new Models.Entidades.SocialNetworkEntities();
                }
                return _db;
            }
        }
    }
}