﻿using System;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace OnePiece.Infrastructure.Hash
{
    public class MD5Class : IHashEncrypt
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
        /// MD5 算法的哈希值大小为 128 位
        /// 此类型的任何公共static成员都是线程安全的。但不保证所有实例成员都是线程安全的
        /// </summary>
        private static string Encrypt_static(string clearText, Encoding encode)
        {

            MD5 md5 = null;
            try
            {
                byte[] originalBytes = encode.GetBytes(clearText); //Encoding.UTF8.GetBytes(clearText);


                md5 = MD5.Create();
                byte[] data = md5.ComputeHash(originalBytes);


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
