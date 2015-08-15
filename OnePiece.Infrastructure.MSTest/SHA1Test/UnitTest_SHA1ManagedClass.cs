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
    public class UnitTest_SHA1ManagedClass
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
            _md5 = new SHA1ManagedClass();
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

            string expected = "6367C48DD193D56EA7B0BAAD25B19455E529F5EE"; //预测值


            Assert.AreEqual(expected.ToUpper(), result.ToUpper());
        }





    }
}
