#region
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
#endregion

namespace CHE9000WAP.PUB
{
    public class COMMON
    {
        /// <summary>
        /// 10品牌 50查询51反馈 60鉴定61处理
        /// </summary>
        public static int BASE_FILE_FILETYPE_CARTYPE = 10; 
        public static int BASE_FILE_FILETYPE_ORDERQUERY = 50;
        public static int BASE_FILE_FILETYPE_ORDERCASE = 51;
        public static int BASE_FILE_FILETYPE_CHECKQUERY = 60;
        public static int BASE_FILE_FILETYPE_CHECKCASE = 61; 

        #region 密码加密
        public static string MD5Encrypt(string strIn)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] res = md5.ComputeHash(Encoding.Default.GetBytes(strIn), 0, strIn.Length);
            char[] temp = new char[res.Length];
            System.Array.Copy(res, temp, res.Length);
            return new String(temp);
        }
        #endregion

        #region 字符串转图片
        
        #endregion 
    }
}
 