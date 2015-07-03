#region
using System;
using System.Collections;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Telephony;
#endregion

namespace CHE9000WAP.Login
{
    [Activity(Label = "CHE9000")]
    public class LoginReg : Activity
    {
        #region pageLoad
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LoginReg);

            pageInit();

            FindViewById<Button>(Resource.Id.LoginReg_GETTELMARK).Click += delegate { proOpt("GETMARK", ""); };
            FindViewById<Button>(Resource.Id.LoginReg_SUBMIT).Click += delegate { proOpt("SUBMIT", ""); };
            FindViewById<TextView>(Resource.Id.LoginReg_Back).Click += delegate { proOpt("FINISH", ""); }; 
        }
        #endregion

        #region pageInit
        protected void pageInit()
        {
            string strCurrTelNo =  ((TelephonyManager)GetSystemService(TelephonyService)).Line1Number;
            FindViewById<EditText>(Resource.Id.LoginReg_USERTEL).Text = strCurrTelNo;
        }
        #endregion

        #region userOpt
        protected void proOpt(string strCommand, string strKeyID)
        { 
            #region GETMARK
            if (strCommand == "GETMARK")
            {
                string strCurrTelNo = FindViewById<EditText>(Resource.Id.LoginReg_USERTEL).Text;
                if (strCurrTelNo == "" || strCurrTelNo.Length != 11)
                {
                    funAlert("请输入有效的手机号！");
                    return;
                }
                PUB.PUB.getCurrMibioMark(strCurrTelNo);
                FindViewById<Button>(Resource.Id.LoginReg_GETTELMARK).Enabled = false;
                funAlert("验证申请已发出，请注意查收！");
            }
            #endregion

            #region SUBMIT
            if (strCommand == "SUBMIT")
            {  
                string strCurrTelNo = FindViewById<EditText>(Resource.Id.LoginReg_USERTEL).Text;
                string strCurrTelMark = FindViewById<EditText>(Resource.Id.LoginReg_USERTELMARK).Text;
                int iUserType = FindViewById<RadioButton>(Resource.Id.LoginReg_REGTYPECLIENT).Checked ? 0 : 1;
                string strUserPassOld = FindViewById<EditText>(Resource.Id.LoginReg_USERPASSWORD).Text;
                string strUserPassConfirm = FindViewById<EditText>(Resource.Id.LoginReg_USERPASSCONFRM).Text;
                string strUserPass = CHE9000WAP.PUB.COMMON.MD5Encrypt(strUserPassOld);
                if (strCurrTelNo == "" || strCurrTelNo.Length != 11)
                {
                    funAlert("请输入有效的手机号！");
                    return;
                }
                if (strUserPassConfirm == "" || strUserPassConfirm != strUserPassOld)
                {
                    funAlert("请输入密码并进行确认输入！");
                    return;
                }

                string strCheckMark = PUB.PUB.getCurrMibioMark(strCurrTelNo, strCurrTelMark);
                if (strCheckMark != "")
                {
                    funAlert(strCheckMark);
                    FindViewById<Button>(Resource.Id.LoginReg_GETTELMARK).Enabled = true;
                    return;
                }

                PUB.PUBWeb TT = new PUB.PUBWeb();
                SortedList SDList = new SortedList();
                SDList["@USERLOGIN"] = strCurrTelNo;
                SDList["@USERTEL"] = strCurrTelNo;
                SDList["@USEREMAIL"] = "";
                SDList["@USERPASS"] = strUserPass;
                SDList["@USERTYPE"] = iUserType; 
                string strBack = TT.WebDBExec("PRO_SYS_USERREG",SDList);
                if (strBack.Substring(0,2) != "OK")
                {
                    funAlert(strBack);
                }
                else
                {
                    int iNEWKEYID = Convert.ToInt32(strBack.Substring(2, strBack.Length - 2)); 
                    PUB.PUBLogin.setUSERID(iNEWKEYID.ToString());
                    PUB.PUBLogin.setUSERTELNO(strCurrTelNo);
                    PUB.PUBLogin.setUSERTYPE(iUserType.ToString()); 
                    funAlert("登记成功", iUserType);
                } 
            }
            #endregion

            #region FINISH 
            if (strCommand == "FINISH")
            {
                Finish();
            }
            #endregion
        }
        #endregion 

        #region alertInfo
        public void funAlert(string strInfo) { funAlert(strInfo, -1); }
        public void funAlert(string strInfo,int iUserType)
        {
            var dlgAlert = (new AlertDialog.Builder(this)).Create();
            dlgAlert.SetMessage(strInfo);
            dlgAlert.SetTitle("提示信息");
            if (iUserType == -1){dlgAlert.SetButton("确认", funAlertDoNULL);}
            if (iUserType == 0) { dlgAlert.SetButton("确认", funAlertDoRegBank); }
            if (iUserType == 1) { dlgAlert.SetButton("确认", funAlertDoRegArea); }
            dlgAlert.Show();
        }
        public void funAlertDoNULL(object sender, DialogClickEventArgs e) { }
        public void funAlertDoRegArea(object sender, DialogClickEventArgs e) {
            Intent intent = new Intent(); 
            intent.SetClass(this, typeof(LoginRegArea)); 
            StartActivity(intent);
            Finish();
        }
        public void funAlertDoRegBank(object sender, DialogClickEventArgs e) {
            Intent intent = new Intent(); 
            intent.SetClass(this, typeof(LoginRegBank)); 
            StartActivity(intent);
            Finish();
        }
        #endregion
    }
}