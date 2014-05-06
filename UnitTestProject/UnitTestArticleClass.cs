using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using ORBITA.Model;
using ORBITA.DAL;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestArticleClass
    {
        [TestMethod]
        public void TestGetList()
        {
            User user = new User();
            user.UID = 1;
            User myuser = UserService.GetItem(user);
        }
       

    }
}
