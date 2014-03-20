using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORBITA.Model
{
    /// <summary>
    /// Product 模型
    /// </summary>
    public class Product
    {
        public int Prod_Id { get; set; }

        public string Prod_Name { get; set; }

        public string Prod_Number { get; set; }

        public decimal Prod_Price { get; set; }

        public string Prod_Image { get; set; }

        public string Prod_Content { get; set; }

        public DateTime Prod_Date { get; set; }

        public int Prod_Click { get; set; }

        public bool IsTop { get; set; }

        public bool IsCommend { get; set; }

        public int Pc_Id { get; set; }
    }
}
