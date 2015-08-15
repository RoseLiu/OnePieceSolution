using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece.Infrastructure
{

    public interface IZipString
    {
        /// <summary>
        /// 压缩字符串
        /// </summary>
        /// <param name="toCompressString">未压缩的字符串</param>
        /// <returns>返回：已压缩的字符串</returns>
        String StringCompress(string toCompressString);



        /// <summary>
        /// 解压字符串
        /// </summary>
        /// <param name="toDeCompressString">已压缩的字符串</param>
        /// <returns>返回：原始字符串</returns>
        String StringDeCompress(string toDeCompressString);
    }
}
