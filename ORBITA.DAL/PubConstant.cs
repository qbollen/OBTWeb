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
            return ConfigurationManager.ConnectionStrings["mysqlconn"].ConnectionString;
        }
    }
}
