#region
using System;
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
    public class Login0 : Activity
    {
        #region pageLoad
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Login);

            PUB.PUBWap TT = new PUB.PUBWap();
            TT.proDataCreate();  //初始化本地库
            pageInit(); 

            FindViewById<Button>(Resource.Id.Login_USERLOGIN).Click += delegate { proOpt("USERLOGIN", ""); };
            FindViewById<TextView>(Resource.Id.Login_REGUSER).Click += delegate { proOpt("REGUSER", ""); };
            FindViewById<TextView>(Resource.Id.Login_GETPASS).Click += delegate { proOpt("GETPASS", ""); };
            FindViewById<TextView>(Resource.Id.Login_EXIT).Click += delegate { proOpt("EXIT", ""); };
            FindViewById<TextView>(Resource.Id.Login_REGTYPECLIENT).Click += delegate { proOpt("USERLOGINPASS", "0"); };
            FindViewById<TextView>(Resource.Id.Login_REGTYPESERVE).Click += delegate { proOpt("USERLOGINPASS", "1"); };
            
        }
        #endregion

        #region pageInit
        protected string strVesionUrl = "";
        protected void pageInit()
        {
            #region checkVision
            string strVisionBack = PUB.PUB.getVesionUrl();
            if (strVisionBack != "")
            {
                string[] strVisionS = strVisionBack.Split('$');
                strVesionUrl = strVisionS[1];
                funAlertNewVersion("有新版本" + strVisionS[0] + ",您需要现在就更新吗？");
            }
            #endregion

            #region userFmt
            string strCurrUserTELNO = PUB.PUBLogin.getUSERTELNO();
            if (strCurrUserTELNO != "")  //有登录
            {
                proOpt("USERLOGINPASS", PUB.PUBLogin.getUSERTYPE());
                return;
            }
            string strCurrTelNo = ((TelephonyManager)GetSystemService(TelephonyService)).Line1Number;
            if (strCurrTelNo == "")
            {
                funAlert("读取当前卡号失败，请人工输入！");
            }
            else
            {
                FindViewById<EditText>(Resource.Id.Login_USERNAME).Text = strCurrTelNo;
            }
            #endregion
        }
        #endregion

        #region userOpt
        protected void proOpt(string strCommand, string strKeyID)
        {
            #region USERLOGIN
            if (strCommand == "USERLOGIN" || strCommand == "USERLOGINPASS")
            {
                string strType = strKeyID;
                if (strCommand == "USERLOGIN")
                {
                    string strUserTel = FindViewById<EditText>(Resource.Id.Login_USERNAME).Text;
                    string strUserPass = FindViewById<EditText>(Resource.Id.Login_USERPASS).Text;

                    //strUserTel = "13084403393"; strUserPass = "2";
                    //strUserTel = "18140223393"; strUserPass = "1";

                    string strBack = PUB.PUBLogin.Login(strUserTel, PUB.COMMON.MD5Encrypt(strUserPass));
                    if (strBack == "")
                    {
                        funAlert("登录失败，请检查手机号和密码是否正确，并确认当前账号已审核通过！");
                        return;
                    }
                    //CONVERT(VARCHAR(32),USERID) + '$'+USERTEL+'$'+ CONVERT(VARCHAR(2),USERTYPE)
                    string[] strUSERS = strBack.Split('$');
                    string strTT = PUB.PUBLogin.setUSERID(strUSERS[0]); 
                    PUB.PUBLogin.setUSERTELNO(strUSERS[1]);
                    PUB.PUBLogin.setUSERTYPE(strUSERS[2]);
                    strType = strUSERS[2];

                    //funAlert(strBack + "&" + strTT + "&" + PUB.PUBLogin.getUSERID());
                    //return;
                }
                
                if (strType == "0")
                {
                    Intent intent = new Intent();
                    intent.SetClass(this, typeof(CHE9000WAP.Login.MainClient));
                    StartActivity(intent);
                    Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
                }
                if (strType == "1")
                {
                    Intent intent = new Intent();
                    intent.SetClass(this, typeof(CHE9000WAP.Login.MainServe));
                    StartActivity(intent);
                    Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
                } 
                if (strType == "2")
                {
                    funAlert("系统管理用户不在此登录！"); 
                } 
            } 
            #endregion

            #region REGUSER
            if (strCommand == "REGUSER")
            {
                Intent intent = new Intent();
                intent.SetClass(this, typeof(CHE9000WAP.Login.LoginReg));
                StartActivity(intent);
            }
            #endregion

            #region GETPASS
            if (strCommand == "GETPASS")
            {
                Intent intent = new Intent();
                intent.SetClass(this, typeof(CHE9000WAP.Login.LoginPass));
                StartActivity(intent);
            }
            #endregion

            #region EXIT FINISH
            if (strCommand == "EXIT")
            {
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
            } 
            #endregion
        }
        #endregion 

        #region alertInfo
        public void funAlert(string strInfo)
        {
            var dlgAlert = (new AlertDialog.Builder(this)).Create();
            dlgAlert.SetMessage(strInfo);
            dlgAlert.SetTitle("提示信息");
            dlgAlert.SetButton("确认", funAlertDoNULL);
            dlgAlert.Show();
        }
        public void funAlertDoNULL(object sender, DialogClickEventArgs e) { }
        public void funAlertNewVersion(string strInfo)
        {
            var dlgAlert = (new AlertDialog.Builder(this)).Create();
            dlgAlert.SetMessage(strInfo);
            dlgAlert.SetTitle("提示信息");
            dlgAlert.SetButton("确认", funAlertNewVersionDown);
            dlgAlert.SetButton2("取消", funAlertDoNULL);
            dlgAlert.Show();
        }
        public void funAlertNewVersionDown(object sender, DialogClickEventArgs e) 
        {
            //strVesionUrl
            funAlert("暂不能进行在线升级！");
        } 
        #endregion
    } 
}