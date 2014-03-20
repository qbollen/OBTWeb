using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ORBITA.Model
{
    /// <summary>
    /// Article model
    /// </summary>
    public class Article
    {
        #region Public Properties

        [DataObjectFieldAttribute(true, true, false)]
        public int art_id { get; set;}

        public string art_title { get; set; }

        public string art_author { get; set; }

        public string art_from { get; set; }

        public string art_content { get; set; }

        public string art_description { get; set; }

        public string art_image { get; set; }

        public string art_date { get; set; }

        public int art_click { get; set; }

        public bool istop { get; set; }

        public bool iscommend { get; set; }

        public int ac_id { get; set; }

        #endregion
    }
}
