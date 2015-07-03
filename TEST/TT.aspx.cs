using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TEST
{
    public partial class TT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PUBWebMY TT = new PUBWebMY();
            //PUBWeb TT = new PUBWeb();
            SortedList SDList = new SortedList();
            SDList["@PHOTENO"] = "13084403393";
            SDList["@MARKNO"] = "111111";
            string strBack = TT.WebDBSqlOne("PRO_SYS_PHOTEMARK", SDList); 


            Response.Write(strBack);
        }
    }
}