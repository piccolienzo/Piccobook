using System;
using System.Collections;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SocialNetwork.Services
{
    public class LoginService : Service
    {
        public enum Results
        {
            Found = 1,
            BadPassword,
            UserNorFound,


        }


        public static Models.Entidades.User UserAuthentication(Models.Entidades.UserEntity user)
        {
            bool result = false;
            Models.Entidades.User log = null;
            try
            {
                log = (Models.Entidades.User)
                    (from userlogin in DB.Users.ToList()
                     where userlogin.email.Trim() == user.Email.Trim()
                     select userlogin
                    ).FirstOrDefault();

                if (log == null)
                {
                    result = false;
                }
                else
                {
                    if (ComparePassword(user.Password, log.password))
                        result = true;

                }


            }
            catch (NullReferenceException e)
            {
                result = false;
            }
            catch (Exception e)
            {
                result = false;
            }
            finally
            {

            }
            if (result == false)
            {
                log = null;
            }
            return log;
        }

        public static bool ComparePassword(string password, byte[] savedPassword)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            //create an array of bytes we will use to store the encrypted password
            Byte[] hashedBytes;
            //Create a UTF8Encoding object we will use to convert our password string to a byte array
            UTF8Encoding encoder = new UTF8Encoding();

            //encrypt the password and store it in the hashedBytes byte array
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(password));

            byte[] hashedPassword = new byte[savedPassword.Length];

            for (int x = 0; x <= savedPassword.Length; x++)
            {

                hashedPassword[x] = hashedBytes[x];
                if (x == hashedBytes.Length - 1)
                {
                    break;
                }

            }


            if (StructuralComparisons.StructuralEqualityComparer.Equals(savedPassword, hashedPassword))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public static byte[] HashStringPassword(string password)
        {

            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            //create an array of bytes we will use to store the encrypted password
            Byte[] hashedBytes;
            //Create a UTF8Encoding object we will use to convert our password string to a byte array
            UTF8Encoding encoder = new UTF8Encoding();

            //encrypt the password and store it in the hashedBytes byte array
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(password));
            return hashedBytes;

        }



    }
}