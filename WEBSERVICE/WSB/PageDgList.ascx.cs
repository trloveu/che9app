#region
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
#endregion

namespace CHE9000NEW.WSB
{
    public partial class PageDgList : System.Web.UI.UserControl
    {
        #region Curr
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrPageIndex
        {
            get { return Convert.ToInt32(lblPageCurr.Text); }
            set { lblPageCurr.Text = value.ToString(); }
        }
        /// <summary>
        /// 当前页面控制
        /// </summary>
        public int CurrPageSize
        {
            get { return Convert.ToInt32(lblPageCount.Text); }
            set { lblPageCount.Text = value.ToString(); }
        }
        /// <summary>
        /// 当前页面控制
        /// </summary>
        public int CurrPageSizeRowCount
        {
            set { lBtnPgCurrRowCount.Visible = value > 0; lBtnPgCurrRowCount.Text = "共" + value.ToString() + "行"; }
        }
        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        #endregion

        #region lBtnPg
        protected void lBtnPgFirst_Click(object sender, EventArgs e)
        {
            int iShowPage = 0;
            CurrPageIndex = iShowPage;
            zxDataBinding(null, null);
        }

        protected void lBtnPgPervi_Click(object sender, EventArgs e)
        {
            int iShowPage = CurrPageIndex;
            iShowPage = (iShowPage > 0 ? iShowPage - 1 : 0);
            CurrPageIndex = iShowPage;
            zxDataBinding(null, null);
        }

        protected void lBtnPgNext_Click(object sender, EventArgs e)
        {
            int iShowPage = CurrPageIndex;
            if (iShowPage < _dg.PageCount - 1)
            {
                iShowPage++;
            }
            CurrPageIndex = iShowPage;
            zxDataBinding(null, null);
        }

        protected void lBtnPgLast_Click(object sender, EventArgs e)
        {
            int iShowPage = (_dg.PageCount == 0 ? 0 : _dg.PageCount - 1);
            CurrPageIndex = iShowPage;
            zxDataBinding(null, null);
        }

        protected void lBtnPgGo_Click(object sender, EventArgs e)
        {
            int iShowPage = 0;
            try { iShowPage = Convert.ToInt32(tbPage.Text) - 1; }
            catch { return; }
            if (iShowPage <= _dg.PageCount - 1 && iShowPage >= 0)
            {
                CurrPageIndex = iShowPage;
                zxDataBinding(null, null);
            }
        }
        #endregion

        #region 具体委托
        public delegate void BindDataDelegate();
        public BindDataDelegate BindData1;
        private GridView _dg;
        public void SetTarget(GridView adg, BindDataDelegate aBindData1)
        {
            BindData1 = aBindData1;
            _dg = adg;
            //邦定事件 
            //_dg.DataBinding += new System.EventHandler(this.zxDataBinding);
        }
        private void zxDataBinding(object sender, System.EventArgs e)
        {
            if (_dg == null || _dg.Rows.Count < 1)
            {
                lBtnPgCurr.Text = "当前查询无记录";
                return;
            }
            lBtnPgCurr.Text = (CurrPageIndex + 1).ToString() + "/" + _dg.PageCount.ToString() + "页";
            _dg.PageIndex = CurrPageIndex;
            BindData1();
        }
        public void proDataBind(int iPageRowCount, SortedList SDList, string DB_PackName)
        {
            lBtnExpAll.Enabled = true;
            if (_dg == null || _dg.Rows.Count < 1)
            {
                lBtnPgCurr.Text = "当前查询无记录";

                lBtnExpAll.Enabled = false; 
                return;
            }
            lBtnPgCurr.Text = (CurrPageIndex + 1).ToString() + "/" + _dg.PageCount.ToString() + "页";
            _dg.PageIndex = CurrPageIndex;

            if (iPageRowCount > 0)
            {
                CurrPageSizeRowCount = iPageRowCount;
                Session.Add(DB_PackName, SDList);
                lblPackName.Text = DB_PackName;
                lBtnExpAll.Visible = true; 
            }
            else
            {
                lBtnExpAll.Visible = false; 
            }
        }
        public void SetStyle()
        {
            _dg.AllowPaging = true;
            _dg.PagerSettings.Visible = false;
            int iCurrPageSize = CurrPageSize;
            if (iCurrPageSize == 0)
            {
                CurrPageSize = 0;
                iCurrPageSize = 15; // Convert.ToInt32(objPageSize);
                CurrPageSize = iCurrPageSize;
            }
            _dg.PageSize = iCurrPageSize;
            _dg.PagerSettings.Mode = PagerButtons.Numeric;
            _dg.PagerStyle.HorizontalAlign = HorizontalAlign.Right;
        }
        #endregion

        #region 导出
        protected void lBtnExpAll_Click(object sender, EventArgs e)
        {
            DataTable dtExp = getExpDataSouse();
            if (dtExp != null)
            {
                ExceptExcelAll(dtExp, _dg);
            }
        } 
        protected DataTable getExpDataSouse()
        { 
            DataTable dtExp = WSBDB.proGetDT((SortedList)Session[lblPackName.Text], lblPackName.Text);
            return dtExp;
        }
        /// <summary>
        /// 导出全部数据
        /// </summary>
        /// <param name="dt">原始数据</param>
        /// <param name="gv">显示格式</param>
        protected void ExceptExcelAll(DataTable dt, GridView gv)
        {
            try
            {
                GridView gvOut = new GridView();
                gvOut.AutoGenerateColumns = false;
                gvOut.AllowPaging = false;
                gvOut.CssClass = gv.CssClass;
                gvOut.HeaderStyle.CssClass = gvOut.HeaderStyle.CssClass;
                gvOut.RowStyle.CssClass = gvOut.RowStyle.CssClass;
                gvOut.AlternatingRowStyle.CssClass = gvOut.AlternatingRowStyle.CssClass;
                for (int i = 0; i < gv.Columns.Count; i++)
                {
                    if (gv.Columns[i].GetType().Name == "BoundField")  //肯定是可以显示的数据帮定字段 BoundField
                    {
                        BoundField bf = new BoundField();
                        bf.HeaderText = gv.Columns[i].HeaderText;
                        bf.DataField = ((BoundField)gv.Columns[i]).DataField;
                        gvOut.Columns.Add(bf);
                    }
                }
                gvOut.DataSource = dt;
                gvOut.DataBind();
                foreach (GridViewRow dr in gvOut.Rows)
                {
                    foreach (TableCell tc in dr.Cells)
                    {
                        tc.Attributes.Add("style", "vnd.ms-excel.numberformat:@");
                    }
                } 
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "GB2312";
                string expFileName = "attachment;filename=" + "XLS" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                //if (rExecTypeDoc.Checked)
                //{
                //    expFileName = "attachment;filename=" + "DOC" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".doc";
                //}
                Response.AppendHeader("Content-Disposition", expFileName);
                Response.ContentType = "application/ms-excel";
                this.EnableViewState = false;
                System.IO.StringWriter swOut = new System.IO.StringWriter();
                HtmlTextWriter hTw = new HtmlTextWriter(swOut);
                gvOut.RenderControl(hTw);
                Response.Write(swOut.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                base.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script language=javascript>alert('导出数据失败:" + ex.ToString() + "');</script>");
            }
        }
        #endregion
    }
}