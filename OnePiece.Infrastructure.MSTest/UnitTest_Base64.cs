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


    [TestClass]
    public class UnitTest_Base64
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


        private Base64 base64 = null;

        [TestInitialize]
        public void initialize()
        {
            base64 = new Base64();
        }

        [TestCleanup]
        public void finalize()
        {
            base64 = null;
        }



        [TestMethod]
        public void TestMethod1_EncodeBase64()
        {
            string clearText = "abc123";
            string result = base64.EncodeBase64(clearText);

            string expected = "YWJjMTIz"; //期望值


            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod2_DecodeBase64()
        {
            string enString = "YWJjMTIz";
            string result = base64.DecodeBase64(enString);

            string expected = "abc123"; //期望值


            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void TestMethodAll()
        {

            string clearText = Guid.NewGuid().ToString("N") + "abc123" + Guid.NewGuid().ToString();

            string enString = base64.EncodeBase64(clearText);
            string deString = base64.DecodeBase64(enString);


//#if DEBUG
//            Console.WriteLine("加密后：{0}", enString);
//            Console.WriteLine("解密后：{0}", deString);
//            Console.WriteLine("原始文：{0}", clearText);

//            Console.WriteLine(clearText.Equals(deString));
//#endif


            Assert.AreEqual(clearText, deString);
        }





        [TestMethod]
        public void TestMethod3_EncodeBase64_static()
        {
            string clearText = "abc123";
            string result = Base64.EncodeBase64_static(clearText);

            string expected = "YWJjMTIz"; //期望值


            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod4_DecodeBase64_static()
        {
            string enString = "YWJjMTIz";
            string result = Base64.DecodeBase64_static(enString);

            string expected = "abc123"; //期望值


            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void TestMethodAll_static()
        {
            string clearText = Guid.NewGuid().ToString("N") + "abc123" + Guid.NewGuid().ToString();

            string enString = Base64.EncodeBase64_static(clearText);
            string deString = Base64.DecodeBase64_static(enString);


            Assert.AreEqual(clearText, deString);
        }


    }
}
