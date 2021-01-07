using System.IO;
using System.Web;

namespace SocialNetwork.Services
{
    public class MediaService
    {
        public static byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;

        }

    }
}