using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace OnePiece.Infrastructure.ZipString
{
    public class GZipString : IZipString
    {
        static void Main_GZipString()
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



            Console.WriteLine("\n\n压缩GZip字符串长度：");
            String gZip = StringCompress_static(builder.ToString());
            Console.WriteLine(gZip.Length);
            //Console.WriteLine(gZip);

            String unGZip = StringDeCompress_static(gZip);
            Console.WriteLine(unGZip.Length);

            Console.WriteLine(String.Equals(builder.ToString(), unGZip));
        }




        public string StringCompress(string toCompressString)
        {
            if (String.IsNullOrEmpty(toCompressString) == true) return "";

            return StringCompress_static(toCompressString);
        }

        public string StringDeCompress(string toDeCompressString)
        {
            if (String.IsNullOrEmpty(toDeCompressString) == true) return "";

            return StringDeCompress_static(toDeCompressString);
        }







        /// <summary>
        /// 压缩字符串
        /// </summary>
        /// <param name="toCompressString">字符串</param>
        public static string StringCompress_static(string toCompressString)
        {
            //byte[] byteArray = new byte[toCompressString.Length];
            //int index = 0;

            //foreach (char item in toCompressString.ToCharArray())
            //{
            //    byteArray[index++] = Convert.ToByte(item); //byteArray[index++] = (byte)item;
            //}


            //MemoryStream ms = new MemoryStream();
            //GZipStream zipStream = new GZipStream(ms, CompressionMode.Compress);//压缩基础流


            //zipStream.Write(byteArray, 0, byteArray.Length);
            //zipStream.Close();


            //byte[] dataArray = ms.ToArray();
            //StringBuilder builder = new StringBuilder(dataArray.Length);
            //foreach (byte item in dataArray)
            //{
            //    builder.Append((char)item);
            //}



            //ms.Close();
            ////zipStream.Close();

            //ms.Dispose();
            //zipStream.Dispose();

            //return builder.ToString();






            byte[] byteArray = new byte[toCompressString.Length];
            int index = 0;

            foreach (char item in toCompressString.ToCharArray())
            {
                byteArray[index++] = (byte)item; //Convert.ToByte(item);
            }


            MemoryStream memory = null;
            GZipStream zipStream = null;
            try
            {
                memory = new MemoryStream();
                zipStream = new GZipStream(memory, CompressionMode.Compress);//压缩基础流


                zipStream.Write(byteArray, 0, byteArray.Length);
                zipStream.Close();



                byte[] dataArray = memory.ToArray();
                StringBuilder builder = new StringBuilder(dataArray.Length);
                foreach (byte item in dataArray)
                {
                    builder.Append((char)item);
                }


                //zipStream.Dispose();
                //memory.Close();
                //memory.Dispose();


                return builder.ToString();
            }
            catch (ArgumentNullException) { return ""; }
            catch (ArgumentException) { return ""; }
            catch (ObjectDisposedException) { return ""; }
            catch (Exception) { return ""; }
            finally
            {
                if (zipStream != null) { zipStream.Dispose(); }
                if (memory != null) { memory.Close(); memory.Dispose(); }
            }


        }


        /// <summary>
        /// 解压字符串
        /// </summary>
        /// <param name="toDeCompressString">字符串</param>
        public static string StringDeCompress_static(string toDeCompressString)
        {
            //byte[] byteArray = new byte[toDeCompressString.Length];
            //int index = 0;

            //foreach (char item in toDeCompressString.ToCharArray())
            //{
            //    byteArray[index++] = Convert.ToByte(item); //byteArray[index++] = (byte)item;
            //}


            //MemoryStream ms = new MemoryStream(byteArray);
            //GZipStream zipStream = new GZipStream(ms, CompressionMode.Decompress);//解压缩基础流
            //StreamReader reader = new StreamReader(zipStream);

            //string result = reader.ReadToEnd();


            //ms.Close();
            //zipStream.Close();

            //ms.Dispose();
            //zipStream.Dispose();

            //reader.Close();
            //reader.Dispose();

            //return result;





            byte[] byteArray = new byte[toDeCompressString.Length];
            int index = 0;

            foreach (char item in toDeCompressString.ToCharArray())
            {
                byteArray[index++] = (byte)item; //Convert.ToByte(item);
            }


            MemoryStream memory = null;
            GZipStream zipStream = null;
            StreamReader reader = null;
            try
            {
                memory = new MemoryStream(byteArray);
                zipStream = new GZipStream(memory, CompressionMode.Decompress);//解压缩基础流
                reader = new StreamReader(zipStream);

                string result = reader.ReadToEnd();




                //memory.Close();
                //zipStream.Close();

                //memory.Dispose();
                //zipStream.Dispose();

                //reader.Close();
                //reader.Dispose();

                return result;
            }
            catch (ArgumentNullException) { return ""; }
            catch (ArgumentException) { return ""; }
            catch (IOException) { return ""; }
            catch (OutOfMemoryException) { return ""; }
            catch (Exception) { return ""; }
            finally
            {
                if (reader != null) { reader.Close(); reader.Dispose(); }
                if (zipStream != null) { zipStream.Close(); zipStream.Dispose(); }
                if (memory != null) { memory.Close(); memory.Dispose(); }
            }

        }



    }
}
