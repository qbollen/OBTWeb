using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ORBITA.Model
{
    /// <summary>
    /// ArticleClass Model
    /// </summary>
    public class ArticleClass
    {
        #region Public Properties

        [DataObjectFieldAttribute(true, true, false)]
        public int ac_id { get; set; }

        public string ac_name { get; set; }

        public int parent_id { get; set; }

        public int ac_order { get; set; }

        #endregion
    }
}
