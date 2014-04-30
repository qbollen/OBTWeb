using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ORBITA.Common;
using ORBITA.BLL;
using System.Data;

namespace ORBITA.UI
{
    public partial class ProductList : System.Web.UI.Page
    {
        public string pcnav { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string parentID = null;
            try
            {
                parentID = Request.QueryString["id"].ToString();
            }
            catch (Exception ex)
            {
            }

            if (BaseCommon.ValidQueryString(parentID))
            {
                pcnav = ProductClassManage.ProductClassNav(Convert.ToInt32(parentID), pcnav);
                if (!IsPostBack)
                {
                    this.ObjectDataSourceProduct.SelectParameters["pc_id"].DefaultValue = parentID;
                    AspNetPager1.RecordCount = ProductManage.GetList(Convert.ToInt32(parentID)).Count;
                }
            }
            else
            {
                AspNetPager1.RecordCount = ProductManage.GetList(0).Count;
            }
        }

        protected void ObjectDataSourceProduct_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (!e.ExecutingSelectCount)
            {
                e.Arguments.StartRowIndex = this.AspNetPager1.StartRecordIndex;
                e.Arguments.MaximumRows = this.AspNetPager1.PageSize;
            }
        }
    }
}