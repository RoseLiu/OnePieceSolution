using System;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace OnePiece.Infrastructure.Hash
{
    public class MD5AsyncClass : IHashEncrypt
    {
        public string GetHashSring(string clearText)
        {
            if (String.IsNullOrEmpty(clearText) == true) return "";


            return GetMd5Hash(clearText).Result;
        }



        public async Task<string> GetMd5Hash(string clearText)
        {
            return await Encrypt(clearText);
        }



        private async static Task<string> Encrypt(string clearText)
        {

            return await Encrypt(clearText, Encoding.UTF8);
        }

        /// <summary>
        /// MD5 算法的哈希值大小为 128 位
        /// 此类型的任何公共static成员都是线程安全的。但不保证所有实例成员都是线程安全的
        /// </summary>
        private async static Task<string> Encrypt(string clearText, Encoding encode)
        {

            MD5 md5 = null;
            try
            {
                byte[] originalBytes = encode.GetBytes(clearText); //Encoding.UTF8.GetBytes(clearText);



                md5 = MD5.Create();

                return await ByteToString(md5.ComputeHash(originalBytes));
            }
            catch (ArgumentNullException) { return clearText; }
            catch (EncoderFallbackException) { return clearText; }
            catch (TargetInvocationException) { return clearText; }
            catch (ObjectDisposedException) { return clearText; }
            catch (ArgumentException) { return clearText; }
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



        /// <summary>
        /// 异步获取返回的数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static async Task<string> ByteToString(byte[] data)
        {
            //StringBuilder builder = new StringBuilder();
            //foreach (var item in data)
            //{
            //    builder.Append(item.ToString("X2"));
            //}
            //return builder.ToString();





            StringBuilder builder = new StringBuilder();

            return await Task.Factory.StartNew(() =>
            {
                //Task.Delay(100);

                foreach (var item in data)
                {
                    builder.Append(item.ToString("X2"));
                }

                return builder.ToString();
            });





            //StringBuilder builder = new StringBuilder();

            //return await Task.Run(() =>
            //{
            //    //Task.Delay(100);

            //    foreach (var item in data)
            //    {
            //        builder.Append(item.ToString("X2"));
            //    }

            //    return builder.ToString();
            //});
        }
    }
}
