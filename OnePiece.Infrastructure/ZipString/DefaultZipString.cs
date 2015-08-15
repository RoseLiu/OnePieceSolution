using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace OnePiece.Infrastructure.ZipString
{
    public class DefaultZipString : IZipString
    {
        public static void Main_DefaultZipString()
        {
            const int numTest = 1000;

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < numTest; i++)
            {
                builder.Append("0123456789");
                builder.Append("abcdefghijklmnopqrstuvwxyz");
                builder.Append("~!@#$%^&*(){}:';,./<>?[]");
                builder.Append("zyxwvutsrqponmlkjihgfedcba");
                builder.Append("9876543210");
            }
            Console.WriteLine("原始字符串长度：");
            Console.WriteLine(builder.Length);





            Console.WriteLine("\n\n压缩UTF8字符串长度：");
            String UTF8 = StringCompress_static(builder.ToString(), Encoding.UTF8);
            Console.WriteLine(UTF8.Length);
            //Console.WriteLine(UTF8);

            String unUTF8 = StringDeCompress_static(UTF8, Encoding.UTF8);
            Console.WriteLine(unUTF8.Length);

            Console.WriteLine(String.Equals(builder.ToString(), unUTF8));





            Console.WriteLine("\n\n压缩Unicode字符串长度：");
            String Unicode = StringCompress_static(builder.ToString(), Encoding.Unicode);
            Console.WriteLine(Unicode.Length);
            //Console.WriteLine(Unicode);

            String unUnicode = StringDeCompress_static(Unicode, Encoding.Unicode);
            Console.WriteLine(unUnicode.Length);

            Console.WriteLine(String.Equals(builder.ToString(), unUnicode));






            Console.WriteLine("\n\n压缩ASCII字符串长度：");
            String ASCII = StringCompress_static(builder.ToString(), Encoding.ASCII);
            Console.WriteLine(ASCII.Length);
            //Console.WriteLine(ASCII);

            String unASCII = StringDeCompress_static(ASCII, Encoding.ASCII);
            Console.WriteLine(unASCII.Length);

            Console.WriteLine(String.Equals(builder.ToString(), unASCII));






            Console.WriteLine("\n\n压缩DefaultANSI字符串长度：");
            String Default = StringCompress_static(builder.ToString(), Encoding.Default);//ANSI
            Console.WriteLine(Default.Length);
            //Console.WriteLine(Default);

            String unDefault = StringDeCompress_static(Default, Encoding.Default);
            Console.WriteLine(unDefault.Length);

            Console.WriteLine(String.Equals(builder.ToString(), unDefault));






            Console.WriteLine("\n\n压缩BigEndianUnicode字符串长度：");
            String BigEndianUnicode = StringCompress_static(builder.ToString(), Encoding.BigEndianUnicode);
            Console.WriteLine(BigEndianUnicode.Length);
            //Console.WriteLine(BigEndianUnicode);

            String unBigEndianUnicode = StringDeCompress_static(BigEndianUnicode, Encoding.BigEndianUnicode);
            Console.WriteLine(unBigEndianUnicode.Length);

            Console.WriteLine(String.Equals(builder.ToString(), unBigEndianUnicode));






            Console.WriteLine("\n\n压缩UTF32字符串长度：");
            String UTF32 = StringCompress_static(builder.ToString(), Encoding.UTF32);
            Console.WriteLine(UTF32.Length);
            //Console.WriteLine(UTF32);

            String unUTF32 = StringDeCompress_static(UTF32, Encoding.UTF32);
            Console.WriteLine(unUTF32.Length);

            Console.WriteLine(String.Equals(builder.ToString(), unUTF32));




            //Console.ReadKey();
        }



        public string StringCompress(string toCompressString)
        {
            if (String.IsNullOrEmpty(toCompressString) == true) return "";

            return StringCompress_static(toCompressString, Encoding.UTF8);
        }

        public string StringDeCompress(string toDeCompressString)
        {
            if (String.IsNullOrEmpty(toDeCompressString) == true) return "";

            return StringDeCompress_static(toDeCompressString, Encoding.UTF8);
        }





        /// <summary>
        /// 压缩字符串
        /// </summary>
        /// <param name="toCompressString"> 未压缩的字符串 </param>
        /// <returns> 压缩的字符串 </returns>
        private static string StringCompress_static(string toCompressString, Encoding encode)
        {
            //byte[] byteData = encode.GetBytes(toCompressString);

            //MemoryStream memory = new MemoryStream();

            //Stream stream = new GZipStream(memory, CompressionMode.Compress);
            //stream.Write(byteData, 0, byteData.Length);
            //stream.Close();

            //byte[] dataCompressed = (byte[])memory.ToArray();



            //stream.Dispose();
            //memory.Close();
            //memory.Dispose();


            //return Convert.ToBase64String(dataCompressed, 0, dataCompressed.Length);






            MemoryStream memory = null;
            Stream stream = null;
            try
            {
                byte[] byteData = encode.GetBytes(toCompressString);

                memory = new MemoryStream();

                stream = new GZipStream(memory, CompressionMode.Compress);
                stream.Write(byteData, 0, byteData.Length);
                stream.Close();

                byte[] result = memory.ToArray();


                return Convert.ToBase64String(result, 0, result.Length);
            }
            catch (ArgumentNullException) { return ""; }
            catch (EncoderFallbackException) { return ""; }
            catch (ArgumentOutOfRangeException) { return ""; }
            catch (ArgumentException) { return ""; }
            catch (Exception) { return ""; }
            finally
            {
                if (stream != null) { stream.Dispose(); }
                if (memory != null) { memory.Close(); memory.Dispose(); }

                //stream = null; memory = null;
            }

        }


        /// <summary>
        /// 解压缩字符串
        /// </summary>
        /// <param name="toDeCompressString"> 压缩的字符串 </param>
        /// <returns> 未压缩的字符串 </returns>
        private static string StringDeCompress_static(string toDeCompressString, Encoding encode)
        {
            //StringBuilder builder = new StringBuilder();

            //int totalLength = 0;

            //byte[] byteArray = Convert.FromBase64String(toDeCompressString); ;
            //byte[] dataWrite = new byte[toDeCompressString.Length];


            //MemoryStream memory = new MemoryStream(byteArray);
            //Stream stream = new GZipStream(memory, CompressionMode.Decompress);
            //while (true)
            //{
            //    int size = stream.Read(dataWrite, 0, dataWrite.Length);
            //    if (size > 0)
            //    {
            //        totalLength += size;
            //        builder.Append(encode.GetString(dataWrite, 0, size)); //编码要一致
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            //stream.Close();
            //stream.Dispose();

            //memory.Close();
            //memory.Dispose();


            //return builder.ToString();






            StringBuilder builder = new StringBuilder();
            int totalLength = 0;


            MemoryStream memory = null;
            Stream stream = null;
            try
            {
                byte[] byteArray = Convert.FromBase64String(toDeCompressString); ;
                byte[] dataWrite = new byte[toDeCompressString.Length];

                memory = new MemoryStream(byteArray);
                stream = new GZipStream(memory, CompressionMode.Decompress);
                while (true)
                {
                    int size = stream.Read(dataWrite, 0, dataWrite.Length);
                    if (size > 0)
                    {
                        totalLength += size;
                        builder.Append(encode.GetString(dataWrite, 0, size)); //编码要一致
                    }
                    else
                    {
                        break;
                    }
                }


                //stream.Close();
                //stream.Dispose();

                //memory.Close();
                //memory.Dispose();

                return builder.ToString();
            }
            catch (ArgumentNullException) { return ""; }
            catch (FormatException) { return ""; }
            catch (ArgumentOutOfRangeException) { return ""; }
            catch (ArgumentException) { return ""; }
            catch (IOException) { return ""; }
            catch (NotSupportedException) { return ""; }
            catch (ObjectDisposedException) { return ""; }
            catch (Exception) { return ""; }
            finally
            {
                if (stream != null) { stream.Close(); stream.Dispose(); }
                if (memory != null) { memory.Close(); memory.Dispose(); }

                //stream = null; memory = null;
            }


        }


    }
}
