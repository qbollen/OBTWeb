using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORBITA.Model
{
    /// <summary>
    /// ProductClass 模型
    /// </summary>
    public class ProductClass
    {
        #region Public Properties

        public int PC_Id { get; set; }

        public string PC_Name { get; set; }

        public int Parent_Id { get; set; }

        public int PC_Order { get; set; }

        #endregion
    }
}
