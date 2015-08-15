using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


/// <summary>
/// [ClassInitialize()]  在运行类的第一个测试前先运行代码
/// [ClassCleanup()]     在运行完类中的所有测试后再运行代码
/// 
/// [TestInitialize()]   在运行每个测试(方法)前先运行代码
/// [TestCleanup()]      在运行完每个测试(方法)后运行代码
/// </summary>
namespace OnePiece.Infrastructure.MSTest
{
    using OnePiece.Infrastructure;
    using OnePiece.Infrastructure.Hash;


    [TestClass]
    public class UnitTest_MD5ClassLock
    {
        /// <summary>
        /// 获取或设置测试上下文
        /// 上下文提供有关当前测试运行以及功能的信息
        /// </summary>
        private TestContext _context;
        public TestContext Context
        {
            get { return _context; }
            set { _context = value; }
        }



        private IHashEncrypt _md5 = null;

        [TestInitialize]
        public void initialize()
        {
            _md5 = MD5ClassLock.GetInstance();
        }

        [TestCleanup]
        public void finalize()
        {
            _md5 = null;
        }







        [TestMethod]
        public void TestMethod1_Encrypt()
        {
            string clearText = "abc123";
            string result = _md5.GetHashSring(clearText);

            Console.WriteLine(result);

            //E99A18C428CB38D5F260853678922E03
            string expected = "e99a18c428cb38d5f260853678922e03"; //预测值


            Assert.AreEqual(expected.ToUpper(), result.ToUpper());
        }




        [TestMethod]
        public void TestMethod1_Encrypt2()
        {
            string clearText = "abc123";

            MD5ClassLock2 md5 = MD5ClassLock2.GetInstance();

            string result = md5.GetMd5Hash(clearText);

            Console.WriteLine(result);

            //E99A18C428CB38D5F260853678922E03
            string expected = "e99a18c428cb38d5f260853678922e03"; //预测值


            Assert.AreEqual(expected.ToUpper(), result.ToUpper());
        }


    }
}
