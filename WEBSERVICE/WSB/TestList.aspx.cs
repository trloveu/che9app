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
    public partial class TestList : System.Web.UI.Page
    {
        #region pageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            pgShow.SetTarget(dgList, new PageDgList.BindDataDelegate(pageBind));
            pgShow.SetStyle();
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
        protected void dgList_Sorting(object sender, GridViewSortEventArgs e)
        {
            ViewState.Add("SortExpression", e.SortExpression);
            ViewState.Add("SortDirection", (ViewState["SortDirection"] == null || ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC"));
            pageBind();
        }
        #endregion
              

        #endregion

        #region pageInit
        protected void pageInit()
        {
            ddlQORDERSTATE.Items.Add(new ListItem("=选择=",""));
            ddlQORDERSTATE.Items.Add(new ListItem("创建","1"));
            ddlQORDERSTATE.Items.Add(new ListItem("支付","2"));
            ddlQORDERSTATE.Items.Add(new ListItem("审核","3"));
            ddlQORDERSTATE.Items.Add(new ListItem("受理","4"));
            ddlQORDERSTATE.Items.Add(new ListItem("完成","5"));
            ddlQORDERSTATE.Items.Add(new ListItem("过期","8"));
            ddlQORDERSTATE.Items.Add(new ListItem("撤销","9")); 
        }
        #endregion

        #region pageBind
        protected void pageBind()
        {
            #region getData
            SortedList SDList = new SortedList();
            SDList["@ORDERNO"] = txtQORDERNO.Text;
            SDList["@QUERYUSER"] = txtQQUERYUSER.Text;
            SDList["@CREATETIMEB"] = txtQCREATETIMEB.Text;
            SDList["@CREATETIMEE"] = txtQCREATETIMEE.Text;
            SDList["@ORDERSTATE"] = ddlQORDERSTATE.Text;
            SDList["@CASEUSER"] = txtQCASEUSER.Text;
            SDList["@ORDERSHAREB"] = txtQORDERSHAREB.Text;
            SDList["@ORDERSHAREE"] = txtQORDERSHAREE.Text; 
            string strPackName = "PRO_ORDER_QUERY";
            DataTable dt = WSBDB.proGetDT(SDList, strPackName);
            DataView dv = dt.DefaultView;
            if (ViewState["SortExpression"] != null)
            {
                dv.Sort = ViewState["SortExpression"].ToString() + " " + ViewState["SortDirection"].ToString();
            }
            dgList.DataSource = dv;
            dgList.DataBind(); 
            pgShow.proDataBind(dt.Rows.Count, SDList, strPackName);
            #endregion

            #region setShow
            foreach (GridViewRow gr in dgList.Rows)
            {
                string strOrderState = dgList.DataKeys[gr.RowIndex]["ORDERSTATE"].ToString();
                string strOrderID = dgList.DataKeys[gr.RowIndex]["ORDERID"].ToString();
                if (strOrderID == "2")
                {
                    ((LinkButton)(gr.FindControl("lbtnAduit1"))).Enabled = true;
                }
                if (strOrderID == "4")
                {
                    ((LinkButton)(gr.FindControl("lbtnAduit2"))).Enabled = true;
                    ((LinkButton)(gr.FindControl("lbtnAduit2"))).Attributes.Add("onclick", "return confirm('您确定？');"); 
                } 
            }
            #endregion 
        }
        #endregion

        #region pageOpt
        protected void pageOpt(string strCommand, string strKeyID)
        {  
            #region 查询
            if (strCommand == "查询")
            {
                pageBind();  
            }
            #endregion  

            #region 查看
            if (strCommand == "查看")
            {
                string strPath = "TestEdit.ASPX?KEYID="+strKeyID;
                string script = "window.open('" + strPath + "'"
                    + ",'','dialogWidth=1000px,dialogheight=760px,toolbar=no,menubar=no,titlebar=yes,"
                    + "directories=no,resizable=yes,status=yes,fullscreen=no,scrollbars=no');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script language=javascript>" + script + "</script>");
            
            }
            #endregion  
        }
        #endregion
    }
}