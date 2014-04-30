using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ORBITA.BLL;
using ORBITA.Model;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ArticleCollection list = ArticleManage.GetList(0);
        }
    }
}
