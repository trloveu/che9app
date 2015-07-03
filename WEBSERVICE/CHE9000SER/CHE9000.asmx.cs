#region
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Collections;
using System.Data;
using System.IO;
using System.Text;
#endregion

namespace CHE9000NEW.WSB
{
    /// <summary>
    /// CHE9000 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class CHE9000 : System.Web.Services.WebService
    {  
        #region 数据方法
        [WebMethod]
        public string ServerDBQueryOne(string strProcName, DataSet dsIN)
        {
            DataSet ds = ServerDBQuery(strProcName,dsIN);
            if (ds != null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }

        [WebMethod]
        public DataSet ServerDBQuery(string strProcName, DataSet dsIN)
        {
            try
            { 
                SortedList SDList = new SortedList();
                if (dsIN.Tables.Count > 0 && dsIN.Tables[0].Rows.Count > 0)
                {
                    DataRow dR = dsIN.Tables[0].Rows[0];
                    for (int i = 0; i < dsIN.Tables[0].Columns.Count; i++)
                    {
                        SDList[dsIN.Tables[0].Columns[i].ColumnName] = dR[i];
                    }
                }
                return WSBDB.proGetDS(SDList, strProcName); 
            }
            catch (Exception Ex)
            { 
                #region 错误日志 
                string strSDList = "";
                if (dsIN.Tables.Count > 0 && dsIN.Tables[0].Rows.Count > 0)
                {
                    DataRow dR = dsIN.Tables[0].Rows[0];
                    for (int i = 0; i < dsIN.Tables[0].Columns.Count; i++)
                    {
                        strSDList += dsIN.Tables[0].Columns[i].ColumnName + ":" + dR[i] + "$";
                    }
                }
                string strErrEx = "出现未知错误，请联系系统管理员查询日志，方法" + strProcName + "参数：" + strSDList + "错误ID：" + Guid.NewGuid().ToString();
                WSBDB.txtSaveErro(strErrEx + ":" + Ex.ToString()); 
                #endregion

                return null; 
            }
            
        }

        [WebMethod]
        public string ServerDBExec(string strProcName, DataSet dsIN)
        {
            try
            { 
                SortedList SDList = new SortedList();
                if (dsIN.Tables.Count > 0 && dsIN.Tables[0].Rows.Count > 0)
                {
                    DataRow dR = dsIN.Tables[0].Rows[0];
                    for (int i = 0; i < dsIN.Tables[0].Columns.Count; i++)
                    {
                        SDList[dsIN.Tables[0].Columns[i].ColumnName] = dR[i];
                    }
                }
                return WSBDB.proSetDT(SDList, strProcName); 
            }
            catch (Exception Ex)
            { 
                #region 错误日志 
                string strSDList = "";
                if (dsIN.Tables.Count > 0 && dsIN.Tables[0].Rows.Count > 0)
                {
                    DataRow dR = dsIN.Tables[0].Rows[0];
                    for (int i = 0; i < dsIN.Tables[0].Columns.Count; i++)
                    {
                        strSDList += dsIN.Tables[0].Columns[i].ColumnName + ":" + dR[i] + "$";
                    }
                }
                string strErrEx = "出现未知错误，请联系系统管理员查询日志，方法" + strProcName + "参数：" + strSDList + "错误ID：" + Guid.NewGuid().ToString();
                WSBDB.txtSaveErro(strErrEx + ":" + Ex.ToString()); 
                #endregion

                return "出现未知错误，请联系系统管理员查询日志!";
            } 
        } 
        #endregion

        #region 图片处理
        [WebMethod]
        public string ServerPICSave(int iBillID, int iType, string strFileName, string strFILEByte)
        {
            return WSBDB.PicSave(iBillID, iType, strFileName, strFILEByte);
        }

        [WebMethod]
        public string ServerPICReadByID(int iFileID)
        {
            return WSBDB.PicRead(iFileID, 0, 0);
        }

        [WebMethod]
        public string ServerPICReadByType(int iBillID, int iType)
        {
            return WSBDB.PicRead(0, iBillID, iType);
        }
        #endregion
         
    }
}
