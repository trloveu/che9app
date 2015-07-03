#region
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace CHE9000WAP.PUB
{
    public class PUBLogin
    {

        #region 当前用户ID
        /// <summary>
        /// 获取当前用户ID
        /// </summary>  
        public static string getUSERID()
        {
            PUBWap TT = new PUBWap();
            string strUSERID = TT.proDataSqlOne("SELECT USERID FROM T_PUB_USERID");
            return (strUSERID == "0" ? "" : strUSERID);
        }  
        /// <summary>
        /// 设置当前用户ID
        /// </summary>  
        public static string setUSERID(string strUSERID)
        {
            PUBWap TT = new PUBWap();
            return TT.proDataExc("UPDATE T_PUB_USERID SET USERID=" + strUSERID); 
        }
        #endregion

        #region 当前用户电话
        /// <summary>
        /// 获取当前用户电话
        /// </summary>  
        public static string getUSERTELNO()
        {
            PUBWap TT = new PUBWap();
            string strUSERTELNO = TT.proDataSqlOne("SELECT USERTELNO FROM T_PUB_USERTELNO");
            return (strUSERTELNO == "0" ? "" : strUSERTELNO);
        }

        /// <summary>
        /// 设置当前用户电话
        /// </summary>  
        public static string setUSERTELNO(string strUSERTELNO)
        {
            PUBWap TT = new PUBWap();
            return TT.proDataExc("UPDATE T_PUB_USERTELNO SET USERTELNO='" + strUSERTELNO + "'");
        }
        #endregion

        #region 当前用户类别
        /// <summary>
        /// 获取当前用户类别
        /// </summary>  
        public static string getUSERTYPE()
        {
            PUBWap TT = new PUBWap();
            string strUSERTYPE = TT.proDataSqlOne("SELECT USERTYPE FROM T_PUB_USERTYPE");
            return strUSERTYPE;
        }

        /// <summary>
        /// 设置当前用户类别
        /// </summary>  
        public static string setUSERTYPE(string strUSERTYPE)
        {
            PUBWap TT = new PUBWap();
            return TT.proDataExc("UPDATE T_PUB_USERTYPE SET USERTYPE=" + strUSERTYPE);
        }
        #endregion
         


        #region getUserLogin
        /// <summary>
        /// 用户登录校验 返回：USERID+ 0普通用户 1专业用户 2专业用户
        /// </summary>
        /// <param name="strUserName">手机号</param>
        /// <param name="strUserPass">密码</param>
        /// <returns>用户类型 </returns>
        public static string Login(string strUserName, string strUserPass)
        {
            SortedList SDList = new SortedList();
            SDList["@USERLOGIN"] = strUserName;
            SDList["@USERPASS"] = strUserPass;
            PUBWeb TT = new PUBWeb();
            string strBack = TT.WebDBSqlOne("PRO_SYS_USERLOGIN", SDList); 
            

            return strBack;
        }
        #endregion


        #region getCurrArea
        /// <summary>
        /// 当前用户的区域范围
        /// </summary>  
        public static DataTable getCURRAREA()
        {
            SortedList SDList = new SortedList();
            SDList["@USERID"] = getUSERID(); 
            PUBWeb TT = new PUBWeb();
            DataTable dt = TT.WebDBSqlDT("PRO_SYS_USERREGAREAQUERY", SDList); 
            return dt;
        }
        #endregion

        #region getCurrCarType
        /// <summary>
        /// 当前用户的品牌范围
        /// </summary>  
        public static DataTable getCURRCARTYPE()
        {
            SortedList SDList = new SortedList();
            SDList["@USERID"] = getUSERID();
            PUBWeb TT = new PUBWeb();
            DataTable dt = TT.WebDBSqlDT("PRO_SYS_USERREGCARTYPEQUERY", SDList);
            return dt;
        }
        #endregion
    }
}
