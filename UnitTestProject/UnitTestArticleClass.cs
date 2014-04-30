using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ORBITA.BLL;
using ORBITA.Model;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestArticleClass
    {
        [TestMethod]
        public void TestGetList()
        {
            ProductCollection list = ProductManage.GetCommend();
        }
       

    }
}
