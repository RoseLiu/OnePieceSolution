using System;

namespace OnePiece.Infrastructure
{

    public interface ISecurityCryptography
    {
        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="toEncryptString">明文：未加密字符串</param>
        String Encrypt(string toEncryptString);



        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="toDecryptString">密文：已加密的字符串</param>
        String Decrypt(string toDecryptString);
    }

}
