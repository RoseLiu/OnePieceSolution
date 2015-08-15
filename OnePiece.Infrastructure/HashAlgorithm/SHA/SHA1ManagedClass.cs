using System;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace OnePiece.Infrastructure.Hash
{
    public class SHA1ManagedClass : IHashEncrypt
    {

        public string GetHashSring(string clearText)
        {
            return GetSHA1Hash(clearText);
        }



        public string GetSHA1Hash(string clearText)
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
        /// SHA1Managed 算法的哈希值大小为 160 位
        /// 此类型的任何公共static成员都是线程安全的。但不保证所有实例成员都是线程安全的
        /// </summary>
        private static string Encrypt_static(string clearText, Encoding encode)
        {

            SHA1 sha = null;
            try
            {
                byte[] originalBytes = encode.GetBytes(clearText); //Encoding.UTF8.GetBytes(clearText);


                sha = new SHA1Managed();
                byte[] data = sha.ComputeHash(originalBytes);


                //return BitConverter.ToString(data); //将指定的字节数组的每个元素的数值转换为它的等效十六进制字符串表示形式
                StringBuilder builder = new StringBuilder();
                foreach (var item in data)
                {
                    builder.Append(item.ToString("X2"));//将该哈希作为 32 字符的十六进制格式字符串返回
                }

                return builder.ToString();
            }
            catch (ArgumentNullException) { return clearText; }
            catch (EncoderFallbackException) { return clearText; }
            catch (ObjectDisposedException) { return clearText; }
            catch (InvalidOperationException) { return clearText; }
            catch (Exception) { return clearText; }
            finally
            {
                if (sha != null)
                {
                    sha.Clear();
                    sha.Dispose();
                }

                sha = null;
            }

        }
    }
}
