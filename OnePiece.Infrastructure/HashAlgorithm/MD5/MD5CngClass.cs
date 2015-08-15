using System;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace OnePiece.Infrastructure.Hash
{
    public class MD5CngClass : IHashEncrypt
    {
        public string GetHashSring(string clearText)
        {
            return GetMd5Hash(clearText);
        }

        public string GetMd5Hash(string clearText)
        {
            if (String.IsNullOrEmpty(clearText) == true) return "";

            return Encrypt_static(clearText);
        }



        private static string Encrypt_static(string clearText)
        {

            return Encrypt_static(clearText, Encoding.UTF8);
        }

        private static string Encrypt_static2(string clearText)
        {

            return Encrypt_static(clearText, Encoding.Unicode);
        }

        /// <summary>
        /// MD5Cng
        /// 此类型的任何公共static成员都是线程安全的。但不保证所有实例成员都是线程安全的
        /// </summary>
        private static string Encrypt_static(string clearText, Encoding encode)
        {

            MD5 md5 = null;
            try
            {
                byte[] originalBytes = encode.GetBytes(clearText); //Encoding.UTF8.GetBytes(clearText);


                md5 = new MD5Cng();
                byte[] data = md5.ComputeHash(originalBytes);

                StringBuilder builder = new StringBuilder();
                foreach (var item in data)
                {
                    builder.Append(item.ToString("X2"));
                }

                return builder.ToString();
            }
            catch (ArgumentNullException) { return clearText; }
            catch (EncoderFallbackException) { return clearText; }
            //catch (TargetInvocationException) { return clearText; }
            catch (ObjectDisposedException) { return clearText; }
            catch (InvalidOperationException) { return clearText; }

            catch { return clearText; }
            finally
            {
                if (md5 != null)
                {
                    md5.Clear();
                    md5.Dispose();
                }

                md5 = null;
            }
        }
    }
}
