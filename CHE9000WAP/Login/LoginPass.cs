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
    public class LoginPass : Activity
    {
        #region pageLoad
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LoginPass);

            pageInit();

            FindViewById<Button>(Resource.Id.LoginPass_GETTELMARK).Click += delegate { proOpt("GETMARK", ""); };
            FindViewById<Button>(Resource.Id.LoginPass_SUBMIT).Click += delegate { proOpt("SUBMIT", ""); };
            FindViewById<TextView>(Resource.Id.LoginPass_BACK).Click += delegate { proOpt("FINISH", ""); }; 
        }
        #endregion

        #region pageInit
        protected void pageInit()
        {
            string strCurrUserTELNO = PUB.PUBLogin.getUSERTELNO();
            if (strCurrUserTELNO != "")  //有登录
            {
                FindViewById<EditText>(Resource.Id.LoginPass_USERTEL).Text = strCurrUserTELNO; 
            }
            else
            {
                string strCurrTelNo = ((TelephonyManager)GetSystemService(TelephonyService)).Line1Number;
                FindViewById<EditText>(Resource.Id.LoginPass_USERTEL).Text = strCurrTelNo;
            } 
        }
        #endregion

        #region userOpt
        protected void proOpt(string strCommand, string strKeyID)
        {
            #region GETMARK
            if (strCommand == "GETMARK")
            {
                string strCurrTelNo = FindViewById<EditText>(Resource.Id.LoginPass_USERTEL).Text;
                if (strCurrTelNo == "" || strCurrTelNo.Length != 11)
                {
                    funAlert("请输入有效的手机号！");
                    return;
                }
                PUB.PUB.getCurrMibioMark(strCurrTelNo);
                FindViewById<Button>(Resource.Id.LoginPass_GETTELMARK).Enabled = false;
                funAlert("验证申请已发出，请注意查收！");
            }
            #endregion

            #region SUBMIT
            if (strCommand == "SUBMIT")
            {
                string strCurrTelNo = FindViewById<EditText>(Resource.Id.LoginPass_USERTEL).Text;
                string strCurrTelMark = FindViewById<EditText>(Resource.Id.LoginPass_USERTELMARK).Text;
                string strUserPassOld = FindViewById<EditText>(Resource.Id.LoginPass_USERPASSWORD).Text;
                string strUserPassConfirm = FindViewById<EditText>(Resource.Id.LoginPass_USERPASSCONFRM).Text;
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
                    FindViewById<Button>(Resource.Id.LoginPass_GETTELMARK).Enabled = true;
                    return;
                }

                PUB.PUBWeb TT = new PUB.PUBWeb();
                SortedList SDList = new SortedList(); 
                SDList["@USERTEL"] = strCurrTelNo; 
                SDList["@USERPASS"] = strUserPass;
                string strBack = TT.WebDBExec("PRO_SYS_USERCHANGEPASS", SDList);
                if (strBack != "")
                {
                    funAlert(strBack);
                }
                else
                { 
                    funAlert("更新成功", 1);
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
        public void funAlert(string strInfo, int iUserType)
        {
            var dlgAlert = (new AlertDialog.Builder(this)).Create();
            dlgAlert.SetMessage(strInfo);
            dlgAlert.SetTitle("提示信息");
            if (iUserType == -1) { dlgAlert.SetButton("确认", funAlertDoNULL); }
            if (iUserType == 1) { dlgAlert.SetButton("确认", funAlertDoClose); }
            dlgAlert.Show();
        }
        public void funAlertDoNULL(object sender, DialogClickEventArgs e) { }
        public void funAlertDoClose(object sender, DialogClickEventArgs e){ Finish(); } 

        #endregion
    }
}