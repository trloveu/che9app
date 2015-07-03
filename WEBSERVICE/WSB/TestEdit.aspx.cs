#region
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

namespace CHE9000NEW.WSB
{
    public partial class TestEdit : System.Web.UI.Page
    {
        #region pageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pageInit();
                pageBind();
            }
        }

        #region userBtn
        protected void lbtn_Click(object sender, EventArgs e)
        {
            pageOpt(((LinkButton)(sender)).CommandName, ((LinkButton)(sender)).CommandArgument);
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            pageOpt(((Button)(sender)).CommandName, ((Button)(sender)).CommandArgument);
        } 
        #endregion


        #endregion

        #region pageInit
        protected void pageInit()
        {
             
        }
        #endregion

        #region pageBind
        protected void pageBind()
        {
            if (Request["KEYID"].ToString() == "") { return; }

            #region getData
            SortedList SDList = new SortedList();
            SDList["@ORDERID"] = Request["KEYID"].ToString(); 
            string strPackName = "PRO_ORDER_QUERY";
            DataTable dt = WSBDB.proGetDT(SDList, strPackName);
            if (dt == null || dt.Rows.Count < 1) { return; }
            DataRow dr = dt.Rows[0];
            #endregion

            #region showData

            #endregion 
        }
        #endregion

        #region pageOpt
        protected void pageOpt(string strCommand, string strKeyID)
        {
            #region 保存
            if (strCommand == "保存")
            {
                pageBind();
            }
            #endregion

            #region 关闭
            if (strCommand == "关闭")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script language=javascript>window.close();</script>"); 
            }
            #endregion
        }
        #endregion
    }
}