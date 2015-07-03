#region
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Telephony;
#endregion

namespace CHE9000WAP.PUB
{
    public class PUB
    {
        static string STRCURRVESION = "1.00";

        #region getVesionUrl
        /// <summary>
        /// 获取最新版本号路径 版本号$HTTP路径 空表示未更新
        /// </summary> 
        public static string getVesionUrl()
        {
            PUBWeb TT = new PUBWeb();
            SortedList SDList =  new SortedList();
            SDList["@CURRVERSION"] = STRCURRVESION;
            string strBack = TT.WebDBSqlOne("PRO_SYS_CONFIGQUERY_VERSION", SDList );
            return strBack;
        }
        #endregion 



        #region getBaseArea
        public static DataTable getBaseArea()
        {
            //SELECT 'dr = dt.NewRow(); dr["AREAID"] = '+CONVERT(VARCHAR(32),AREAID)
            // +'; dr["AREACODE"] = "'+AREACODE+'"; dr["AREANAME"] = "'+AREANAME+'"; dt.Rows.Add(dr);' FROM T_BASE_AREA 
            DataTable dt = new DataTable(); DataRow dr = dt.NewRow();
            dt.Columns.Add("AREAID",typeof(Int32));dt.Columns.Add("AREACODE",typeof(String));dt.Columns.Add("AREANAME",typeof(String));
            //dr = dt.NewRow(); dr["AREAID"] = 1010; dr["AREACODE"] = "10"; dr["AREANAME"] = "华北地区"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1011; dr["AREACODE"] = "11"; dr["AREANAME"] = "北京"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1012; dr["AREACODE"] = "12"; dr["AREANAME"] = "天津"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1013; dr["AREACODE"] = "13"; dr["AREANAME"] = "河北"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1014; dr["AREACODE"] = "14"; dr["AREANAME"] = "山西"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1015; dr["AREACODE"] = "15"; dr["AREANAME"] = "内蒙"; dt.Rows.Add(dr);
            //dr = dt.NewRow(); dr["AREAID"] = 1020; dr["AREACODE"] = "20"; dr["AREANAME"] = "东北地区"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1021; dr["AREACODE"] = "21"; dr["AREANAME"] = "辽宁"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1022; dr["AREACODE"] = "22"; dr["AREANAME"] = "吉林"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1023; dr["AREACODE"] = "23"; dr["AREANAME"] = "黑龙江"; dt.Rows.Add(dr);
            //dr = dt.NewRow(); dr["AREAID"] = 1030; dr["AREACODE"] = "30"; dr["AREANAME"] = "华东地区"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1031; dr["AREACODE"] = "31"; dr["AREANAME"] = "上海"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1032; dr["AREACODE"] = "32"; dr["AREANAME"] = "江苏"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1033; dr["AREACODE"] = "33"; dr["AREANAME"] = "浙江"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1034; dr["AREACODE"] = "34"; dr["AREANAME"] = "安徽"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1035; dr["AREACODE"] = "35"; dr["AREANAME"] = "福建"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1036; dr["AREACODE"] = "36"; dr["AREANAME"] = "江西"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1037; dr["AREACODE"] = "37"; dr["AREANAME"] = "山东"; dt.Rows.Add(dr);
            //dr = dt.NewRow(); dr["AREAID"] = 1040; dr["AREACODE"] = "40"; dr["AREANAME"] = "华中地区"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1041; dr["AREACODE"] = "41"; dr["AREANAME"] = "河南"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1042; dr["AREACODE"] = "42"; dr["AREANAME"] = "湖北"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1043; dr["AREACODE"] = "43"; dr["AREANAME"] = "湖南"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1044; dr["AREACODE"] = "44"; dr["AREANAME"] = "广东"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1045; dr["AREACODE"] = "45"; dr["AREANAME"] = "广西"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1046; dr["AREACODE"] = "46"; dr["AREANAME"] = "海南"; dt.Rows.Add(dr);
            //dr = dt.NewRow(); dr["AREAID"] = 1050; dr["AREACODE"] = "50"; dr["AREANAME"] = "西南地区"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1051; dr["AREACODE"] = "51"; dr["AREANAME"] = "重庆"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1052; dr["AREACODE"] = "52"; dr["AREANAME"] = "四川"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1053; dr["AREACODE"] = "53"; dr["AREANAME"] = "贵州"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1054; dr["AREACODE"] = "54"; dr["AREANAME"] = "云南"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1055; dr["AREACODE"] = "55"; dr["AREANAME"] = "西藏"; dt.Rows.Add(dr);
            //dr = dt.NewRow(); dr["AREAID"] = 1060; dr["AREACODE"] = "60"; dr["AREANAME"] = "西北地区"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1061; dr["AREACODE"] = "61"; dr["AREANAME"] = "陕西"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1062; dr["AREACODE"] = "62"; dr["AREANAME"] = "甘肃"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1063; dr["AREACODE"] = "63"; dr["AREANAME"] = "青海"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1064; dr["AREACODE"] = "64"; dr["AREANAME"] = "宁夏"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1065; dr["AREACODE"] = "65"; dr["AREANAME"] = "新疆"; dt.Rows.Add(dr);
            //dr = dt.NewRow(); dr["AREAID"] = 1070; dr["AREACODE"] = "70"; dr["AREANAME"] = "港澳台"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1071; dr["AREACODE"] = "71"; dr["AREANAME"] = "台湾"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1072; dr["AREACODE"] = "72"; dr["AREANAME"] = "香港"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["AREAID"] = 1073; dr["AREACODE"] = "73"; dr["AREANAME"] = "澳门"; dt.Rows.Add(dr); 
            return dt;
        }
        #endregion

        #region getBaseCarType
        public static DataTable getBaseCarType()
        {
            //SELECT  CONCAT('INSERT INTO T_BASE_CARTYPE (TYPEID,TYPECODE,TYPENAME,TYPEVERSION,TYPESTATE) VALUES ('
	        // ,CAST(1000+F_STOREID AS CHAR),',',CAST(F_STOREID AS CHAR),',','''',F_STORENAME,''',','100,1);') FROM T_BASE_CARSTORE
            //SELECT 'dr = dt.NewRow(); dr["TYPEID"] = '+CONVERT(VARCHAR(32),TYPEID)
            // +'; dr["TYPECODE"] = "'+TYPECODE+'"; dr["TYPENAME"] = "'+TYPENAME+'"; dt.Rows.Add(dr);' FROM T_BASE_CARTYPE 
            DataTable dt = new DataTable(); DataRow dr = dt.NewRow();
            dt.Columns.Add("TYPEID", typeof(Int32)); dt.Columns.Add("TYPECODE", typeof(String)); dt.Columns.Add("TYPENAME", typeof(String));
            dr = dt.NewRow(); dr["TYPEID"] = 1099; dr["TYPECODE"] = "099"; dr["TYPENAME"] = "一汽大众"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1101; dr["TYPECODE"] = "101"; dr["TYPENAME"] = "奥迪"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1102; dr["TYPECODE"] = "102"; dr["TYPENAME"] = "本田-广州本田"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1103; dr["TYPECODE"] = "103"; dr["TYPENAME"] = "本田-东风本田"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1105; dr["TYPECODE"] = "105"; dr["TYPENAME"] = "别克"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1106; dr["TYPECODE"] = "106"; dr["TYPENAME"] = "宝马"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1107; dr["TYPECODE"] = "107"; dr["TYPENAME"] = "奔驰"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1108; dr["TYPECODE"] = "108"; dr["TYPENAME"] = "标致"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1110; dr["TYPECODE"] = "110"; dr["TYPENAME"] = "上海大众"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1111; dr["TYPECODE"] = "111"; dr["TYPENAME"] = "进口大众"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1114; dr["TYPECODE"] = "114"; dr["TYPENAME"] = "广汽丰田"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1116; dr["TYPECODE"] = "116"; dr["TYPENAME"] = "福特"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1117; dr["TYPECODE"] = "117"; dr["TYPENAME"] = "凯迪拉克"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1120; dr["TYPECODE"] = "120"; dr["TYPENAME"] = "雷克萨斯"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1122; dr["TYPECODE"] = "122"; dr["TYPENAME"] = "MG"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1126; dr["TYPECODE"] = "126"; dr["TYPENAME"] = "起亚"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1127; dr["TYPECODE"] = "127"; dr["TYPENAME"] = "启辰"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1128; dr["TYPECODE"] = "128"; dr["TYPENAME"] = "日产-东风日产"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1129; dr["TYPECODE"] = "129"; dr["TYPENAME"] = "荣威"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1130; dr["TYPECODE"] = "130"; dr["TYPENAME"] = "斯柯达"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1135; dr["TYPECODE"] = "135"; dr["TYPENAME"] = "雪铁龙"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1136; dr["TYPECODE"] = "136"; dr["TYPENAME"] = "雪佛兰"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1140; dr["TYPECODE"] = "140"; dr["TYPENAME"] = "路虎"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1141; dr["TYPECODE"] = "141"; dr["TYPENAME"] = "现代"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1142; dr["TYPECODE"] = "142"; dr["TYPENAME"] = "斯巴鲁"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1143; dr["TYPECODE"] = "143"; dr["TYPENAME"] = "保时捷"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1145; dr["TYPECODE"] = "145"; dr["TYPENAME"] = "克莱斯勒"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1146; dr["TYPECODE"] = "146"; dr["TYPENAME"] = "一汽马自达"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1147; dr["TYPECODE"] = "147"; dr["TYPENAME"] = "长安马自达"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1148; dr["TYPECODE"] = "148"; dr["TYPENAME"] = "海南马自达"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["TYPEID"] = 1149; dr["TYPECODE"] = "149"; dr["TYPENAME"] = "一汽丰田"; dt.Rows.Add(dr);
            return dt;
        }
        #endregion

        #region getBaseCarClass
        public static DataTable getBaseCarClass()
        {
            //SELECT  CONCAT('INSERT INTO T_BASE_CARCLASS (CLASSID,TYPEID,CLASSCODE,CLASSNAME,CLASSVERSION,CLASSSTATE) VALUES ('
            //    ,CAST(1000+ID AS CHAR),',',CAST(1000+STOREID AS CHAR),','
            //    ,CAST(ID AS CHAR),',','''',CARTYPE,''',','100,1);') 
            //FROM TB_CAR_TYPE
            //SELECT 'dr = dt.NewRow(); dr["CLASSID"] = '+CONVERT(VARCHAR(32),CLASSID)+';dr["TYPEID"] = '+CONVERT(VARCHAR(32),TYPEID)
            //    +'; dr["CLASSCODE"] = "'+CLASSCODE+'"; dr["CLASSNAME"] = "'+CLASSNAME+'"; dt.Rows.Add(dr);' FROM T_BASE_CARCLASS 

            DataTable dt = new DataTable(); DataRow dr = dt.NewRow();
            dt.Columns.Add("CLASSID", typeof(Int32)); dt.Columns.Add("TYPEID", typeof(Int32));
            dt.Columns.Add("CLASSCODE", typeof(String)); dt.Columns.Add("CLASSNAME", typeof(String));
            dr = dt.NewRow(); dr["CLASSID"] = 1584; dr["TYPEID"] = 1099; dr["CLASSCODE"] = "584"; dr["CLASSNAME"] = "宝来"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1585; dr["TYPEID"] = 1099; dr["CLASSCODE"] = "585"; dr["CLASSNAME"] = "宝来经典"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1586; dr["TYPEID"] = 1099; dr["CLASSCODE"] = "586"; dr["CLASSNAME"] = "CC"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1587; dr["TYPEID"] = 1099; dr["CLASSCODE"] = "587"; dr["CLASSNAME"] = "开迪"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1588; dr["TYPEID"] = 1099; dr["CLASSCODE"] = "588"; dr["CLASSNAME"] = "捷达"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1589; dr["TYPEID"] = 1099; dr["CLASSCODE"] = "589"; dr["CLASSNAME"] = "速腾"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1590; dr["TYPEID"] = 1099; dr["CLASSCODE"] = "590"; dr["CLASSNAME"] = "迈腾"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1591; dr["TYPEID"] = 1099; dr["CLASSCODE"] = "591"; dr["CLASSNAME"] = "高尔夫"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1592; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "592"; dr["CLASSNAME"] = "A6L"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1593; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "593"; dr["CLASSNAME"] = "A4L"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1594; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "594"; dr["CLASSNAME"] = "A4"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1595; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "595"; dr["CLASSNAME"] = "A8"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1596; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "596"; dr["CLASSNAME"] = "Q5"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1597; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "597"; dr["CLASSNAME"] = "Q7"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1598; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "598"; dr["CLASSNAME"] = "A6"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1599; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "599"; dr["CLASSNAME"] = "A5  "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1600; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "600"; dr["CLASSNAME"] = "TT"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1601; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "601"; dr["CLASSNAME"] = "R8"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1602; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "602"; dr["CLASSNAME"] = "A7"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1603; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "603"; dr["CLASSNAME"] = "A1"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1604; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "604"; dr["CLASSNAME"] = "S5"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1605; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "605"; dr["CLASSNAME"] = "A3(进口)"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1606; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "606"; dr["CLASSNAME"] = "A4(进口)"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1607; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "607"; dr["CLASSNAME"] = "RS5"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1608; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "608"; dr["CLASSNAME"] = "S8"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1609; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "609"; dr["CLASSNAME"] = "100"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1610; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "610"; dr["CLASSNAME"] = "200"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1611; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "611"; dr["CLASSNAME"] = "S6"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1612; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "612"; dr["CLASSNAME"] = "S7 Allroad"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1613; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "613"; dr["CLASSNAME"] = "SQ5"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1614; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "614"; dr["CLASSNAME"] = "S3"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1615; dr["TYPEID"] = 1101; dr["CLASSCODE"] = "615"; dr["CLASSNAME"] = "RS7"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1635; dr["TYPEID"] = 1105; dr["CLASSCODE"] = "635"; dr["CLASSNAME"] = "君威"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1636; dr["TYPEID"] = 1105; dr["CLASSCODE"] = "636"; dr["CLASSNAME"] = " 凯越"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1637; dr["TYPEID"] = 1105; dr["CLASSCODE"] = "637"; dr["CLASSNAME"] = "君越"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1638; dr["TYPEID"] = 1105; dr["CLASSCODE"] = "638"; dr["CLASSNAME"] = "GL8"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1639; dr["TYPEID"] = 1105; dr["CLASSCODE"] = "639"; dr["CLASSNAME"] = "英朗"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1640; dr["TYPEID"] = 1105; dr["CLASSCODE"] = "640"; dr["CLASSNAME"] = "昂科雷  "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1641; dr["TYPEID"] = 1105; dr["CLASSCODE"] = "641"; dr["CLASSNAME"] = "林荫大道 "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1642; dr["TYPEID"] = 1105; dr["CLASSCODE"] = "642"; dr["CLASSNAME"] = "昂科拉"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1643; dr["TYPEID"] = 1105; dr["CLASSCODE"] = "643"; dr["CLASSNAME"] = "新世纪"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1644; dr["TYPEID"] = 1105; dr["CLASSCODE"] = "644"; dr["CLASSNAME"] = "荣御"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1645; dr["TYPEID"] = 1105; dr["CLASSCODE"] = "645"; dr["CLASSNAME"] = "昂科威"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1646; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "646"; dr["CLASSNAME"] = "5系"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1647; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "647"; dr["CLASSNAME"] = "3系"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1648; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "648"; dr["CLASSNAME"] = "7系"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1649; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "649"; dr["CLASSNAME"] = "X5"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1650; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "650"; dr["CLASSNAME"] = "3系  (进口))"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1651; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "651"; dr["CLASSNAME"] = "X6"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1652; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "652"; dr["CLASSNAME"] = "Z4"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1653; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "653"; dr["CLASSNAME"] = "X3"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1654; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "654"; dr["CLASSNAME"] = "1系"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1655; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "655"; dr["CLASSNAME"] = "M3"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1656; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "656"; dr["CLASSNAME"] = "5系(进口)"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1657; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "657"; dr["CLASSNAME"] = "5系GT"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1658; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "658"; dr["CLASSNAME"] = "X1"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1659; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "659"; dr["CLASSNAME"] = "6系 "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1660; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "660"; dr["CLASSNAME"] = "X1(进口)"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1661; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "661"; dr["CLASSNAME"] = "3系GT"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1662; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "662"; dr["CLASSNAME"] = "X5 M "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1663; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "663"; dr["CLASSNAME"] = "1系M"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1664; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "664"; dr["CLASSNAME"] = "M5"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1665; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "665"; dr["CLASSNAME"] = "X6 M"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1666; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "666"; dr["CLASSNAME"] = "4系"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1667; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "667"; dr["CLASSNAME"] = "M6"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1668; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "668"; dr["CLASSNAME"] = "2系"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1669; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "669"; dr["CLASSNAME"] = "X4"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1670; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "670"; dr["CLASSNAME"] = "i8 "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1671; dr["TYPEID"] = 1106; dr["CLASSCODE"] = "671"; dr["CLASSNAME"] = "M4"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1672; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "672"; dr["CLASSNAME"] = "S级"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1673; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "673"; dr["CLASSNAME"] = "C级"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1674; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "674"; dr["CLASSNAME"] = "M级"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1675; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "675"; dr["CLASSNAME"] = "E级"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1676; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "676"; dr["CLASSNAME"] = "SLK级"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1678; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "678"; dr["CLASSNAME"] = "E级(进口) "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1679; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "679"; dr["CLASSNAME"] = "R级"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1680; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "680"; dr["CLASSNAME"] = "CLS级"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1681; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "681"; dr["CLASSNAME"] = "GL级"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1682; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "682"; dr["CLASSNAME"] = "G级"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1683; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "683"; dr["CLASSNAME"] = "GLK级"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1684; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "684"; dr["CLASSNAME"] = "奔驰C级(进口) "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1685; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "685"; dr["CLASSNAME"] = "A级"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1686; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "686"; dr["CLASSNAME"] = "GLK级(进口)"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1687; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "687"; dr["CLASSNAME"] = "B级"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1688; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "688"; dr["CLASSNAME"] = "唯雅诺"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1689; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "689"; dr["CLASSNAME"] = "C级AMG"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1690; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "690"; dr["CLASSNAME"] = "威霆 "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1691; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "691"; dr["CLASSNAME"] = "CLK级"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1692; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "692"; dr["CLASSNAME"] = "G级AMG"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1693; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "693"; dr["CLASSNAME"] = "SL级"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1694; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "694"; dr["CLASSNAME"] = "SLS级AMG"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1695; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "695"; dr["CLASSNAME"] = "唯雅诺(进口)"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1696; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "696"; dr["CLASSNAME"] = "Sprinter"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1697; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "697"; dr["CLASSNAME"] = "S级AMG"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1698; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "698"; dr["CLASSNAME"] = "M级AMG  "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1699; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "699"; dr["CLASSNAME"] = "CLS级AMG "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1700; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "700"; dr["CLASSNAME"] = "凌特"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1702; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "702"; dr["CLASSNAME"] = "CLA级 "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1703; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "703"; dr["CLASSNAME"] = "A级AMG"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1704; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "704"; dr["CLASSNAME"] = " 威霆(进口)"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1705; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "705"; dr["CLASSNAME"] = "E级AMG "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1706; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "706"; dr["CLASSNAME"] = "GL级AMG"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1707; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "707"; dr["CLASSNAME"] = "CLA级 AMG"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1708; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "708"; dr["CLASSNAME"] = "SL级AMG"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1709; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "709"; dr["CLASSNAME"] = "CL级"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1710; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "710"; dr["CLASSNAME"] = "SLK级AMG"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1711; dr["TYPEID"] = 1107; dr["CLASSCODE"] = "711"; dr["CLASSNAME"] = "GLA级(进口)"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1734; dr["TYPEID"] = 1110; dr["CLASSCODE"] = "734"; dr["CLASSNAME"] = "Passat领驭"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1735; dr["TYPEID"] = 1110; dr["CLASSCODE"] = "735"; dr["CLASSNAME"] = "帕萨特"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1736; dr["TYPEID"] = 1110; dr["CLASSCODE"] = "736"; dr["CLASSNAME"] = "途观 "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1737; dr["TYPEID"] = 1110; dr["CLASSCODE"] = "737"; dr["CLASSNAME"] = "朗逸桑塔纳经典"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1738; dr["TYPEID"] = 1110; dr["CLASSCODE"] = "738"; dr["CLASSNAME"] = "桑塔纳志俊"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1739; dr["TYPEID"] = 1110; dr["CLASSCODE"] = "739"; dr["CLASSNAME"] = "途安"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1740; dr["TYPEID"] = 1110; dr["CLASSCODE"] = "740"; dr["CLASSNAME"] = "桑塔纳2000"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1741; dr["TYPEID"] = 1110; dr["CLASSCODE"] = "741"; dr["CLASSNAME"] = "高尔"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1742; dr["TYPEID"] = 1110; dr["CLASSCODE"] = "742"; dr["CLASSNAME"] = "朗境"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1743; dr["TYPEID"] = 1110; dr["CLASSCODE"] = "743"; dr["CLASSNAME"] = "帕萨特B4"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1744; dr["TYPEID"] = 1110; dr["CLASSCODE"] = "744"; dr["CLASSNAME"] = "POLO"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1745; dr["TYPEID"] = 1110; dr["CLASSCODE"] = "745"; dr["CLASSNAME"] = "朗行"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1777; dr["TYPEID"] = 1114; dr["CLASSCODE"] = "777"; dr["CLASSNAME"] = "YARiS L 致炫"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1778; dr["TYPEID"] = 1114; dr["CLASSCODE"] = "778"; dr["CLASSNAME"] = "雷凌 "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1779; dr["TYPEID"] = 1114; dr["CLASSCODE"] = "779"; dr["CLASSNAME"] = "凯美瑞"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1780; dr["TYPEID"] = 1114; dr["CLASSCODE"] = "780"; dr["CLASSNAME"] = "汉兰达"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1781; dr["TYPEID"] = 1114; dr["CLASSCODE"] = "781"; dr["CLASSNAME"] = "雅力士"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1799; dr["TYPEID"] = 1116; dr["CLASSCODE"] = "799"; dr["CLASSNAME"] = "福克斯"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1800; dr["TYPEID"] = 1116; dr["CLASSCODE"] = "800"; dr["CLASSNAME"] = "蒙迪欧-致胜"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1801; dr["TYPEID"] = 1116; dr["CLASSCODE"] = "801"; dr["CLASSNAME"] = "蒙迪欧 "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1802; dr["TYPEID"] = 1116; dr["CLASSCODE"] = "802"; dr["CLASSNAME"] = "嘉年华 "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1803; dr["TYPEID"] = 1116; dr["CLASSCODE"] = "803"; dr["CLASSNAME"] = "F-150 "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1804; dr["TYPEID"] = 1116; dr["CLASSCODE"] = "804"; dr["CLASSNAME"] = "锐界(进口)"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1805; dr["TYPEID"] = 1116; dr["CLASSCODE"] = "805"; dr["CLASSNAME"] = "经典全顺"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1806; dr["TYPEID"] = 1116; dr["CLASSCODE"] = "806"; dr["CLASSNAME"] = "翼虎"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1807; dr["TYPEID"] = 1116; dr["CLASSCODE"] = "807"; dr["CLASSNAME"] = "野马"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1808; dr["TYPEID"] = 1116; dr["CLASSCODE"] = "808"; dr["CLASSNAME"] = "E350 "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1809; dr["TYPEID"] = 1116; dr["CLASSCODE"] = "809"; dr["CLASSNAME"] = "麦柯斯"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1810; dr["TYPEID"] = 1116; dr["CLASSCODE"] = "810"; dr["CLASSNAME"] = "翼虎/Kuga"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1811; dr["TYPEID"] = 1116; dr["CLASSCODE"] = "811"; dr["CLASSNAME"] = "新世代全顺"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1812; dr["TYPEID"] = 1116; dr["CLASSCODE"] = "812"; dr["CLASSNAME"] = "探险者 "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1813; dr["TYPEID"] = 1116; dr["CLASSCODE"] = "813"; dr["CLASSNAME"] = "福克斯(进口) "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1814; dr["TYPEID"] = 1116; dr["CLASSCODE"] = "814"; dr["CLASSNAME"] = "翼搏 "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1815; dr["TYPEID"] = 1116; dr["CLASSCODE"] = "815"; dr["CLASSNAME"] = "致胜"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1816; dr["TYPEID"] = 1116; dr["CLASSCODE"] = "816"; dr["CLASSNAME"] = "嘉年华(进口)"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1817; dr["TYPEID"] = 1116; dr["CLASSCODE"] = "817"; dr["CLASSNAME"] = "GT"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1927; dr["TYPEID"] = 1128; dr["CLASSCODE"] = "927"; dr["CLASSNAME"] = "天籁"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1928; dr["TYPEID"] = 1128; dr["CLASSCODE"] = "928"; dr["CLASSNAME"] = "骐达"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1929; dr["TYPEID"] = 1128; dr["CLASSCODE"] = "929"; dr["CLASSNAME"] = "逍客 "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1930; dr["TYPEID"] = 1128; dr["CLASSCODE"] = "930"; dr["CLASSNAME"] = "轩逸 "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1931; dr["TYPEID"] = 1128; dr["CLASSCODE"] = "931"; dr["CLASSNAME"] = "骊威"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1932; dr["TYPEID"] = 1128; dr["CLASSCODE"] = "932"; dr["CLASSNAME"] = "蓝鸟"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1933; dr["TYPEID"] = 1128; dr["CLASSCODE"] = "933"; dr["CLASSNAME"] = "阳光"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1934; dr["TYPEID"] = 1128; dr["CLASSCODE"] = "934"; dr["CLASSNAME"] = "奇骏"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1935; dr["TYPEID"] = 1128; dr["CLASSCODE"] = "935"; dr["CLASSNAME"] = "颐达"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1936; dr["TYPEID"] = 1128; dr["CLASSCODE"] = "936"; dr["CLASSNAME"] = "玛驰"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1937; dr["TYPEID"] = 1128; dr["CLASSCODE"] = "937"; dr["CLASSNAME"] = "骏逸 "; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 1938; dr["TYPEID"] = 1128; dr["CLASSCODE"] = "938"; dr["CLASSNAME"] = "楼兰"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2118; dr["TYPEID"] = 1143; dr["CLASSCODE"] = "1118"; dr["CLASSNAME"] = "暂不开通"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2119; dr["TYPEID"] = 1141; dr["CLASSCODE"] = "1119"; dr["CLASSNAME"] = "暂不开通"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2122; dr["TYPEID"] = 1140; dr["CLASSCODE"] = "1122"; dr["CLASSNAME"] = "暂不开通"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2123; dr["TYPEID"] = 1142; dr["CLASSCODE"] = "1123"; dr["CLASSNAME"] = "暂不开通"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2124; dr["TYPEID"] = 1145; dr["CLASSCODE"] = "1124"; dr["CLASSNAME"] = "暂不开通"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2130; dr["TYPEID"] = 1147; dr["CLASSCODE"] = "1130"; dr["CLASSNAME"] = "全部"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2131; dr["TYPEID"] = 1148; dr["CLASSCODE"] = "1131"; dr["CLASSNAME"] = "全部"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2137; dr["TYPEID"] = 1118; dr["CLASSCODE"] = "1137"; dr["CLASSNAME"] = "所有"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2138; dr["TYPEID"] = 1130; dr["CLASSCODE"] = "1138"; dr["CLASSNAME"] = "所有"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2140; dr["TYPEID"] = 1127; dr["CLASSCODE"] = "1140"; dr["CLASSNAME"] = "所有"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2141; dr["TYPEID"] = 1126; dr["CLASSCODE"] = "1141"; dr["CLASSNAME"] = "所有"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2142; dr["TYPEID"] = 1122; dr["CLASSCODE"] = "1142"; dr["CLASSNAME"] = "所有"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2143; dr["TYPEID"] = 1146; dr["CLASSCODE"] = "1143"; dr["CLASSNAME"] = "所有"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2144; dr["TYPEID"] = 1120; dr["CLASSCODE"] = "1144"; dr["CLASSNAME"] = "所有"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2145; dr["TYPEID"] = 1117; dr["CLASSCODE"] = "1145"; dr["CLASSNAME"] = "所有"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2147; dr["TYPEID"] = 1108; dr["CLASSCODE"] = "1147"; dr["CLASSNAME"] = "所有"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2148; dr["TYPEID"] = 1103; dr["CLASSCODE"] = "1148"; dr["CLASSNAME"] = "所有"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2149; dr["TYPEID"] = 1102; dr["CLASSCODE"] = "1149"; dr["CLASSNAME"] = "所有"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2151; dr["TYPEID"] = 1111; dr["CLASSCODE"] = "1151"; dr["CLASSNAME"] = "暂不开通"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2153; dr["TYPEID"] = 1129; dr["CLASSCODE"] = "1153"; dr["CLASSNAME"] = "所有"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2154; dr["TYPEID"] = 1113; dr["CLASSCODE"] = "1154"; dr["CLASSNAME"] = "所有"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2155; dr["TYPEID"] = 1135; dr["CLASSCODE"] = "1155"; dr["CLASSNAME"] = "所有"; dt.Rows.Add(dr);
            dr = dt.NewRow(); dr["CLASSID"] = 2156; dr["TYPEID"] = 1136; dr["CLASSCODE"] = "1156"; dr["CLASSNAME"] = "所有"; dt.Rows.Add(dr);
            return dt;
        }
        #endregion

        #region getBaseOrderPrice
        public static DataTable getBaseOrderPrice()
        {
            //SELECT CONCAT('INSERT INTO T_BASE_ORDERPRICE (PRICEID,TYPEID,CLASSID,GOLDPRICE,SHAREPRICE) VALUES ('
            //            ,rownum,',',TYPEID,',',CLASSID,','
            //            ,ORDERGOLD,',',SEARCHPRICE,');') 
            //FROM (
            //SELECT 1000+ @rownum:=@rownum+1 AS rownum , 1000+T.ID TYPEID,1000+TT.ID CLASSID,T.ORDERGOLD,T.SEARCHPRICE 
            //  FROM   (SELECT @rownum:=0) r,TB_STORE_TYPE T
            //LEFT JOIN TB_CAR_TYPE TT ON TT.STOREID = T.ID
            //LEFT JOIN T_BASE_CARSTORE S ON T.STORENAME = S.F_STORENAME
            //) TT;
            return null;
        }
        #endregion


        #region getBankList
        public static string[] getBankList()
        {
            string[] strS = new string[] {
                "中国工商银行","中国招商银行","中国农业银行","中国建设银行", 
                "中国银行","民生银行","光大银行","中信银行",
                "交通银行","兴业银行","华夏银行",
                "深圳发展银行","广东发展银行","中国农业发展银行","上海浦东发展银行",
                "北京银行","上海银行","中国邮政储蓄银行" };
            return strS;
        }
        public static int getBankListIndex(string strName)
        {
            string[] TT = getBankList();
            for (int i = 0; i < TT.Length; i++)
            {
                if (TT[i] == strName) { return i; }
            }
            return -1;
        }
        #endregion


        #region MibioMark
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public static void getCurrMibioMark(string strMibioNo)
        {
            PUBWeb TT = new PUBWeb();
            SortedList SDList = new SortedList();
            SDList["@PHOTENO"] = strMibioNo;
            TT.WebDBExec("PRO_SYS_PHOTEMARK", SDList);
        }
         
        /// <summary>
        /// 判断验证码
        /// </summary>
        /// <returns></returns>
        public static string getCurrMibioMark(string strMibioNo,string strMarkNo)
        {
            PUBWeb TT = new PUBWeb();
            SortedList SDList = new SortedList();
            SDList["@PHOTENO"] = strMibioNo;
            SDList["@MARKNO"] = strMarkNo;
            string strBack = TT.WebDBSqlOne("PRO_SYS_PHOTEMARK", SDList);
            return strBack;
        }
        #endregion 
         
    } 

}
