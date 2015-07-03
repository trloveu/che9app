#region
//版权所属：王世博 2015.05.12 重新整理 
using System;
using System.Collections.Generic; 
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Text;
using System.IO;

using System.Drawing;
using System.Drawing.Imaging;
#endregion

namespace CHE9000NEW.WSB
{
    public class WSBDB
    {
        #region 数据库操作

        #region dt opt
        public static DataSet proGetDS(SortedList SLData, string spName)
        {
            DataSet ds = HelperQuery(spName, SLData);
            return ds;
        }
        public static DataTable proGetDT(SortedList SLData, string spName)
        {
            DataSet ds = proGetDS(SLData, spName);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        public static string proGetDTOne(SortedList SLData, string spName)
        {
            DataSet ds = proGetDS(SLData, spName);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }
        public static string proSetDT(SortedList SLData, string spName)
        {
            object objBack = HelperExec(spName, SLData);
            return objBack == null ? "" : objBack.ToString();
        }
        #endregion

        #region 执行
        private static object HelperExec(string cmdText, SortedList SLData)
        {
            string connStr = ConfigurationManager.AppSettings["CHE9000_CONN"].ToString();
            SqlConnection conn = null;
            object objBack = null;
            try
            {
                #region cmdExec
                SqlCommand cmd = new SqlCommand();
                conn = new SqlConnection(connStr);
                conn.Open();
                if (SLData == null)
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = cmdText;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    SqlParameter[] commandParameters = getParame(conn, cmdText);
                    setParame(SLData, ref commandParameters);

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = cmdText;
                    if (commandParameters != null)
                    {
                        foreach (SqlParameter parm in commandParameters)
                        {
                            cmd.Parameters.Add(parm);
                        }
                    }
                    cmd.ExecuteNonQuery();
                    for (int i = 0; i < commandParameters.Length; i++)
                    {
                        if (commandParameters[i].Direction == ParameterDirection.Output
                            || commandParameters[i].Direction == ParameterDirection.InputOutput)
                        {
                            objBack = commandParameters[i].Value;
                        }
                    }
                }
                return objBack;
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                #region connClose
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    try
                    {
                        conn.Close();
                    }
                    catch
                    { }
                }
                #endregion
            }
        }
        #endregion

        #region 查询
        private static DataSet HelperQuery(string cmdText, SortedList SLData)
        {
            string connStr = ConfigurationManager.AppSettings["CHE9000_CONN"].ToString();
            SqlConnection conn = null;
            DataSet dsBack = new DataSet();
            try
            {
                #region cmdExec
                SqlCommand cmd = new SqlCommand();
                conn = new SqlConnection(connStr);
                conn.Open();
                if (SLData == null)
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = cmdText;
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.TableMappings.Add("JIEYUANTABLE", "JIEYUANTABLE");
                    da.Fill(dsBack);
                }
                else
                {
                    SqlParameter[] commandParameters = getParame(conn, cmdText);
                    setParame(SLData, ref commandParameters);

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = cmdText;
                    if (commandParameters != null)
                    {
                        foreach (SqlParameter parm in commandParameters)
                        {
                            cmd.Parameters.Add(parm);
                        }
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.TableMappings.Add("JIEYUANTABLE", "JIEYUANTABLE");
                    da.Fill(dsBack);
                }
                return dsBack;
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                #region connClose
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    try
                    {
                        conn.Close();
                    }
                    catch
                    { }
                }
                #endregion
            }
        }
        #endregion

        #region 参数
        private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());
        private static void ClearCash()
        {
            paramCache.Clear();
        }
        private static SqlParameter[] getParame(SqlConnection connection, string spName)
        {
            string hashKey = connection.ConnectionString + ":" + spName;
            SqlParameter[] cachedParameters;
            cachedParameters = paramCache[hashKey] as SqlParameter[];
            //if (cachedParameters == null)
            {
                SqlCommand cmd = new SqlCommand(spName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmd);
                SqlParameter[] discoveredParameters = new SqlParameter[cmd.Parameters.Count];
                cmd.Parameters.CopyTo(discoveredParameters, 0);
                foreach (SqlParameter discoveredParameter in discoveredParameters)
                {
                    discoveredParameter.Value = DBNull.Value;
                }
                paramCache[hashKey] = discoveredParameters;
                cachedParameters = discoveredParameters;
            }

            SqlParameter[] clonedParameters = new SqlParameter[cachedParameters.Length];
            for (int i = 0, j = cachedParameters.Length; i < j; i++)
            {
                clonedParameters[i] = (SqlParameter)((ICloneable)cachedParameters[i]).Clone();
            }
            return clonedParameters;
        }

        private static void setParame(SortedList SLParamsTT, ref SqlParameter[] myParams)
        {
            SortedList SLParams = new SortedList();
            foreach (DictionaryEntry element in SLParamsTT)
            {
                SLParams[element.Key.ToString().ToUpper()] = element.Value;
            }

            for (int i = 0; i < myParams.Length; i++)
            {
                if (myParams[i].Direction == ParameterDirection.Output) { continue; }
                string paramName = myParams[i].ParameterName.ToUpper();//参数名
                object paramValue = SLParams[paramName];

                if (paramValue == null || paramValue.ToString() == "" )
                {
                    continue;
                }

                SqlDbType dataType = myParams[i].SqlDbType;//数据类型
                if (dataType == SqlDbType.Int)
                {
                    try { myParams[i].Value = Convert.ToInt32(paramValue); }
                    catch { throw new Exception("转换整数格式字段出错！"); }
                }
                else if (dataType == SqlDbType.Decimal || dataType == SqlDbType.Money || dataType == SqlDbType.Float)
                {
                    try { myParams[i].Value = Convert.ToDecimal(paramValue); }
                    catch { throw new Exception("转换浮点数格式字段出错！"); }
                }
                else if (dataType == SqlDbType.DateTime)
                {
                    try { myParams[i].Value = Convert.ToDateTime(paramValue); }
                    catch { throw new Exception("转换日期格式字段出错！"); }
                }
                else if (dataType == SqlDbType.UniqueIdentifier)
                {
                    try { myParams[i].Value = Guid.Parse(paramValue.ToString()); }
                    catch { throw new Exception("转换GUID类型字段出错！"); }
                }
                else
                {
                    myParams[i].Value = paramValue.ToString().Trim();
                }
            }
        }
        #endregion

        #endregion

        #region 防注入
        public static string sqlGetPro(string strIn)
        {
            strIn = strIn.Trim();
            string strKeyS = "and|exec|insert|select|delete|update|chr|mid|master|or|truncate|char|declare|join|cmd|;|'|--";// 
            foreach (string strKey in strKeyS.Split('|'))
            {
                strIn = strIn.Replace(strKey, "");
            }
            return strIn;
        }
        #endregion
          
        #region 文件操作
        public static string txtReadFromFile(string fileName, string strFileDirt)
        {
            if (fileName == "")
            {
                return "";
            }
            string strPath = ConfigurationManager.AppSettings["CHE9000_FILE"].ToString()
                    + (strFileDirt == "" ? "" : "/" + strFileDirt + "/") + fileName;
            strPath = System.Web.HttpContext.Current.Server.MapPath(strPath);
            if (!File.Exists(strPath))
            {
                return "";
            }
            if (File.Exists(strPath))
            {
                //读取指定的文本文件,并支持中文编码字符
                StreamReader objReader = new StreamReader(strPath, System.Text.Encoding.GetEncoding("gb2312"));
                string aa = objReader.ReadToEnd();
                objReader.Close();//关闭流 
                return aa;
            }
            else
            {
                return "";
            }
        }
        public static void txtSaveToFile(string strText, string fileName, string strFileDirt)
        {
            string strPath = ConfigurationManager.AppSettings["CHE9000_FILE"].ToString()
                    + (strFileDirt == "" ? "" : "/" + strFileDirt + "/");
            strPath = System.Web.HttpContext.Current.Server.MapPath(strPath);
            if (Directory.Exists(strPath) == false)
            {
                Directory.CreateDirectory(strPath);
            }
            strPath = strPath + fileName;
            if (File.Exists(strPath) && strFileDirt != "ERRO")
            {
                File.Delete(strPath);
            }
            FileStream fs = new FileStream(strPath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter m_streamWriter = new StreamWriter(fs);
            m_streamWriter.Flush();  // 使用StreamWriter来往文件中写入内容
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.Write(strText);
            m_streamWriter.Close();
        }
        public static void txtSaveErro(string strErro)
        {
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtSaveToFile(strDateTime + "日志错误：" + strErro, strDateTime.Substring(0, 10) + ".txt", "ERRO");
        }
        #endregion

        #region 图片处理

        #region 图片保存
        public static string PicSave(int iBillID, int iType, string strFileName, string strFILEByte)
        {
            string strPath = ConfigurationManager.AppSettings["CHE9000_FILE"].ToString() + iType.ToString() + "/";
            string strPathM = System.Web.HttpContext.Current.Server.MapPath(strPath); 
            try
            {
                if (!Directory.Exists(strPathM)) {  Directory.CreateDirectory(strPathM); }   

                //byte[] bytes = Convert.FromBase64String(strFILE64);
                //MemoryStream memStream = new MemoryStream(bytes);
                //Image img = Image.FromStream(memStream);
                //img.Save(System.Web.HttpContext.Current.Server.MapPath(strPathName)); 
                byte[] bytes = System.Text.Encoding.Default.GetBytes(strFILEByte);
                MemoryStream memStream = new MemoryStream(bytes);
                Image img = Image.FromStream(memStream);
                img.Save(strPathM + strFileName);

                SortedList SDList = new SortedList();
                SDList["@BILLID"] = iBillID;
                SDList["@FILETYPE"] = iType;
                SDList["@FILESIZE"] = bytes.Length;
                string[] strEXTENSIONS = strFileName.Split('.');
                SDList["@EXTENSION"] =strEXTENSIONS[strEXTENSIONS.Length-1];
                SDList["@FILEPATH"] = strPath+strFileName; 
                string strBack = proSetDT(SDList,"PRO_BASE_FILESAVE"); 
                return strBack; 
            }
            catch (Exception Ex)
            {
                txtSaveErro("图片保存失败" + strPathM + strFileName+":"+Ex.ToString());
                return "图片保存失败";
            }
        }
        #endregion

        #region 图片读取
        public static string PicRead(int iFILEID, int iBILLID, int iTYPEID)
        {
            try
            {
                SortedList SDList = new SortedList();
                if (iFILEID != 0) 
                { 
                    SDList["@FILEID"] = iFILEID; 
                }
                else
                {
                    SDList["@BILLID"] = iBILLID;
                    SDList["@FILETYPE"] = iTYPEID;
                }
                DataTable dt = proGetDT(SDList,"PRO_BASE_FILEQUERY");
                 
                string strFilePath = "";
                if (dt != null && dt.Rows.Count > 0)
                {
                    strFilePath = dt.Rows[0]["FILEPATH"].ToString();
                    strFilePath = System.Web.HttpContext.Current.Server.MapPath(strFilePath);
                    if (!File.Exists(strFilePath))
                    {
                        txtSaveErro("单据" + iBILLID.ToString() + "类别" + iTYPEID + " ID" + iFILEID + ":"
                            + dt.Rows[0]["FILEPATH"].ToString() + "$" + strFilePath + "无文件可读取！");
                        return null;
                    }

                    Bitmap myBitmap = new Bitmap(strFilePath);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Bitmap bmp = new Bitmap(strFilePath);
                        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] imageBytes = new byte[ms.Length];
                        ms.Position = 0;
                        ms.Read(imageBytes, 0, Convert.ToInt32(ms.Length));
                        bmp.Dispose();
                        // return Convert.ToBase64String(imageBytes);
                        return System.Text.Encoding.Default.GetString(imageBytes);
                    }
                }
                else
                {
                    return null;
                } 
            }
            catch (Exception ex)
            {
                txtSaveErro("单据" + iBILLID.ToString() + "类别" + iTYPEID + " ID" + iFILEID + "读取文件失败:" + ex.ToString());
                return null;
            } 
        }
        #endregion

        #region eg
        private Bitmap GetPictureTostring()
        {
            //把字符串转字节
            byte[] bytes = System.Text.Encoding.Default.GetBytes("ssss");
            //把图片转成字节
            FileStream fs = new FileStream("tel.png", FileMode.Open, FileAccess.Read);
            Byte[] b = new Byte[fs.Length];
            fs.Read(b, 0, b.Length);
            fs.Close();
            //再把字节转成图片，输出
            MemoryStream ms = new MemoryStream(b);
            Bitmap bmpt = new Bitmap(ms);
            return bmpt;
        }
        #endregion

        #endregion
    }
}