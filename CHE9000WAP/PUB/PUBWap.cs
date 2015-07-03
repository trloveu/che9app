#region
using System;
using System.IO;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;
#endregion

namespace CHE9000WAP.PUB
{
    public class PUBWap
    {
        #region 建库初始化
        private string[] proDataCreateFmt()
        {
            var commands = new[] {
                    "CREATE TABLE IF NOT EXISTS T_PUB_USERID (USERID INT);",
                    "CREATE TABLE IF NOT EXISTS T_PUB_USERTELNO (USERTELNO TEXT);",
                    "CREATE TABLE IF NOT EXISTS T_PUB_USERTYPE (USERTYPE INT);",
                };
            return commands;
        }
        #endregion

        #region 建库
        public string proDataCreate()
        {
            string DatabaseName = "PUB.db3";
            string documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db = System.IO.Path.Combine(documents, DatabaseName);
            bool BFile = File.Exists(db);
            if (!BFile) { SqliteConnection.CreateFile(db); }

            var conn = new SqliteConnection("Data Source=" + db);
            string[] commands = proDataCreateFmt();
            try
            {
                foreach (var cmd in commands)
                {
                    var sqlitecmd = conn.CreateCommand();
                    sqlitecmd.CommandText = cmd;
                    sqlitecmd.CommandType = CommandType.Text;
                    conn.Open();
                    sqlitecmd.ExecuteNonQuery();
                    conn.Close();
                }
                if (!BFile) // 初始化
                {
                    var sqlitecmd = conn.CreateCommand();
                    conn.Open();
                    sqlitecmd.CommandType = CommandType.Text;
                    sqlitecmd.CommandText = "INSERT INTO T_PUB_USERID (USERID) VALUES (0);"; 
                    sqlitecmd.ExecuteNonQuery();
                    sqlitecmd.CommandText = "INSERT INTO T_PUB_USERTELNO (USERTELNO) VALUES ('');";
                    sqlitecmd.ExecuteNonQuery();
                    sqlitecmd.CommandText = "INSERT INTO T_PUB_USERTYPE (USERTYPE) VALUES (0);";
                    sqlitecmd.ExecuteNonQuery();
                    conn.Close();
                }
                conn.Dispose();
                return "";
            }
            catch (System.Exception sysExc)
            {
                return "创建数据出错: " + sysExc.Message;
            }
        }
        #endregion

        #region 操作

        #region dataSql
        public string proDataSqlOne(string strSql)
        {
            DataTable dt = proDataSql(strSql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }
        public DataTable proDataSql(string strSql)
        {
            string DatabaseName = "PUB.db3";
            string documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db = System.IO.Path.Combine(documents, DatabaseName);
            var conn = new SqliteConnection("Data Source=" + db);
            var cmd = new SqliteCommand(strSql, conn);
            cmd.CommandType = CommandType.Text;
            try
            {
                conn.Open();
                SqliteDataReader sdr = cmd.ExecuteReader();
                System.Data.DataTable dtBack = new System.Data.DataTable();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    dtBack.Columns.Add(sdr.GetName(i));
                }
                while (sdr.Read())
                {
                    DataRow dr = dtBack.NewRow();
                    for (int j = 0; j < dtBack.Columns.Count; j++)
                    {
                        dr[j] = sdr[j].ToString();
                    }
                    dtBack.Rows.Add(dr);
                }
                return dtBack;
            }
            catch // (System.Exception sysExc)
            {
                return null;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed) { conn.Close(); }
                conn.Dispose();
            }
        }
        #endregion

        #region dataExc
        public string proDataExc(string strSql)
        {
            return proDataExc(new string[] { strSql });
        }
        public string proDataExc(string[] strTT)
        {
            try
            {
                if (strTT.Length < 1) { return "No SQL"; }
                string DatabaseName = "PUB.db3";
                string documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string db = System.IO.Path.Combine(documents, DatabaseName);
                var conn = new SqliteConnection("Data Source=" + db);
                var sqlitecmd = conn.CreateCommand();
                conn.Open();
                sqlitecmd.CommandType = CommandType.Text;
                for (int j = 0; j < strTT.Length; j++)
                {
                    if (strTT[j] == "") { continue; }
                    sqlitecmd.CommandText = strTT[j];
                    sqlitecmd.ExecuteNonQuery();
                }
                conn.Close();
                conn.Dispose();
                return "";
            }
            catch (Exception Ex)
            {
                return Ex.ToString();
            }
        }
        #endregion

        #endregion 
         
    } 
}
