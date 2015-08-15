using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece.Infrastructure
{
    public class Base64
    {

        public string EncodeBase64(string clearText)
        {
            if (String.IsNullOrEmpty(clearText) == true) return "";

            return EncodeBase64_static(clearText);
        }

        public string DecodeBase64(string enString)
        {
            if (String.IsNullOrEmpty(enString) == true) return "";

            return DecodeBase64_static(enString);
        }




        public static string EncodeBase64_static(string clearText)
        {

            return EncodeBase64(clearText, Encoding.UTF8);
        }

        public static string DecodeBase64_static(string enString)
        {

            return DecodeBase64(enString, Encoding.UTF8);
        }






        /// <summary>
        /// Base64 解密
        /// </summary>
        /// <param name="result">要解密的密文</param>
        /// <param name="encode">解密采用的编码方式 （注意：加密与解密要采用一致的编码方式）</param>      
        private static string DecodeBase64(string ensource, Encoding encode)
        {
            dynamic result = "";

            try
            {
                dynamic data = Convert.FromBase64String(ensource);

                result = encode.GetString(data);

                return result;
            }
            catch (DecoderFallbackException) { return ensource; }
            catch (ArgumentNullException) { return ensource; }
            catch (FormatException) { return ensource; }
            catch (ArgumentException) { return ensource; }
            catch (Exception)
            {
                return ensource;
            }

        }

        /// <summary>
        /// Base64 加密
        /// </summary>
        /// <param name="source">要加密的明文字符串</param>
        /// <param name="encode">加密采用的编码方式</param>
        private static string EncodeBase64(string source, Encoding encode)
        {
            dynamic result = "";

            try
            {
                dynamic data = encode.GetBytes(source);

                result = Convert.ToBase64String(data);

                return result;
            }
            catch (ArgumentNullException) { return source; }
            catch (EncoderFallbackException) { return source; }
            catch (Exception)
            {
                return source;
            }

        }

    }
}
