#region
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace TEST
{
    public class PUBWeb
    {

        #region SDList转成DataSet
        private DataSet SDListToDS(SortedList SDList)
        {
            DataSet dsIn = new DataSet();
            if (SDList == null || SDList.Count < 1) { return dsIn; }
            DataTable dt = new DataTable();
            foreach (DictionaryEntry element in SDList) { dt.Columns.Add(element.Key.ToString()); }
            DataRow dr = dt.NewRow();
            foreach (DictionaryEntry element in SDList) { dr[element.Key.ToString()] = element.Value; }
            dt.Rows.Add(dr);
            dsIn.Tables.Add(dt);
            return dsIn;
        }
        #endregion


        #region 服务器单数据查询
        public string WebDBSqlOne(string strProcName, SortedList SDList)
        {
            DataSet dsIn = SDListToDS(SDList);
            TEST.CHE9000.CHE9000SoapClient TT = new TEST.CHE9000.CHE9000SoapClient();
            string strBack = TT.ServerDBQueryOne(strProcName, dsIn);
            return strBack;
        }
        #endregion

        #region 服务器多数据查询
        public DataTable WebDBSqlDT(string strProcName, SortedList SDList)
        {
            DataSet dsIn = SDListToDS(SDList);
            TEST.CHE9000.CHE9000SoapClient TT = new TEST.CHE9000.CHE9000SoapClient();
            DataSet dsOut = TT.ServerDBQuery(strProcName, dsIn);
            if (dsOut != null && dsOut.Tables.Count > 0)
            {
                return dsOut.Tables[0];
            }
            else
            {
                return null;
            }
        }
        public DataSet WebDBSqlDS(string strProcName, SortedList SDList)
        {
            DataSet dsIn = SDListToDS(SDList);
            TEST.CHE9000.CHE9000SoapClient TT = new TEST.CHE9000.CHE9000SoapClient();
            DataSet dsOut = TT.ServerDBQuery(strProcName, dsIn);
            return dsOut;
        }
        #endregion

        #region 服务器数据执行
        public string WebDBExec(string strProcName, SortedList SDList)
        {
            DataSet dsIn = SDListToDS(SDList);
            TEST.CHE9000.CHE9000SoapClient TT = new TEST.CHE9000.CHE9000SoapClient();
            string strBack = TT.ServerDBExec(strProcName, dsIn);
            return strBack;
        }
        #endregion


        #region 图片保存和读取
        public string picUP(int iBillID, int iTYPE, string strFileName, string strPicData)
        {
            TEST.CHE9000.CHE9000SoapClient TT = new TEST.CHE9000.CHE9000SoapClient();
            string strBack = TT.ServerPICSave(iBillID, iTYPE, strFileName, strPicData);
            return strBack;
        }
        public string picDown(int iFILEID)
        {
            TEST.CHE9000.CHE9000SoapClient TT = new TEST.CHE9000.CHE9000SoapClient();
            string strBack = TT.ServerPICReadByID(iFILEID);
            return strBack;
        }
        #endregion

    }
}
