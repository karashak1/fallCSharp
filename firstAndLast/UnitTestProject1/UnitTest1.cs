using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var json = firstAndLast.Program.GetProfile("jewpaltz");
            Assert.IsNotNull(json);
            Assert.IsTrue(json.Contains("Moshe"));
        }
    }
}
