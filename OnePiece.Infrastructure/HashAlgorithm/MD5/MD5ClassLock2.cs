using System;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace OnePiece.Infrastructure.Hash
{
   
    public class MD5ClassLock2
    {

        private static object _syncObj = new object();


        //private static object _syncCache = new object();
        //private static Dictionary<string, string> _cache = new Dictionary<string, string>();
        private static ConcurrentDictionary<string, string> _cache = new ConcurrentDictionary<string, string>();

        /// <summary>
        /// 最大缓存条数
        /// </summary>
        private static int _maxCacheNum = 100000;


        private static MD5ClassLock2 _md5Class;
        public static MD5ClassLock2 GetInstance()
        {
            if (null == _md5Class)
            {
                lock (_syncObj)
                {
                    if (null == _md5Class)
                    {
                        _md5Class = new MD5ClassLock2();
                    }
                }
            }

            return _md5Class;
        }


        public string GetMd5Hash(string clearText)
        {
            if (String.IsNullOrEmpty(clearText) == true) return "";


            if (_cache.ContainsKey(clearText)) return _cache[clearText];

            return Encrypt(clearText);
        }



        private string Encrypt(string clearText)
        {
            return Encrypt(clearText, Encoding.UTF8);
        }


        /// <summary>
        /// MD5
        /// 此类型的任何公共static成员都是线程安全的。但不保证所有实例成员都是线程安全的
        /// </summary>
        private string Encrypt(string clearText, Encoding encode)
        {

            MD5 md5 = null;
            try
            {
                byte[] originalBytes = encode.GetBytes(clearText); //Encoding.UTF8.GetBytes(clearText);


                md5 = MD5.Create();
                byte[] data = md5.ComputeHash(originalBytes);

                StringBuilder builder = new StringBuilder();
                foreach (var item in data)
                {
                    builder.Append(item.ToString("X2"));
                }


                string result = builder.ToString();



                #region

                if (_cache.Count > _maxCacheNum)
                {
                    string outString = "";
                    foreach (var item in _cache.Take(_maxCacheNum / 5))
                    {
                        _cache.TryRemove(item.Key, out outString);
                    }
                }
                _cache.TryAdd(clearText, result);

                #endregion


                return result;
            }
            catch (ArgumentNullException) { return clearText; }
            catch (EncoderFallbackException) { return clearText; }
            catch (TargetInvocationException) { return clearText; }
            catch (ObjectDisposedException) { return clearText; }
            catch (Exception) { return clearText; }
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
