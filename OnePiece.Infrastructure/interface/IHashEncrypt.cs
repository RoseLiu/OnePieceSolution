using System;

namespace OnePiece.Infrastructure
{


    public interface IHashEncrypt
    {
        /// <summary>
        /// 字符串哈希算法
        /// </summary>
        /// <param name="clearText">明文：未加密字符串</param>
        string GetHashSring(string clearText);
    }

}
