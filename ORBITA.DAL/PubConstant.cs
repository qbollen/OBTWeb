using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;

namespace ORBITA.DAL
{
    public class PubConstant
    {
        public static string GetConnection()
        {
            //return ConfigurationManager.ConnectionStrings["mysqlconn"].ConnectionString;
            return "server=127.0.0.1;uid=root;pwd=123456;database=obtdb;";
        }
    }
}
