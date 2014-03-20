using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ORBITA.Model
{
    /// <summary>
    /// SiteProperty模型
    /// </summary>
    public class SiteProperty
    {
        #region Public Properties

        [DataObjectFieldAttribute(true,true,false)]
        public int site_id { get; set; }

        public string site_name { get; set; }

        public string site_url { get; set; }

        public string site_logo { get; set; }

        public string site_keyword { get; set; }
        #endregion
    }
}
