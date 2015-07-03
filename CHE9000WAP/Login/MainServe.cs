#region
using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
#endregion

namespace CHE9000WAP.Login
{
    [Activity(Label = "CHE9000")]
    public class MainServe : Activity
    {
        #region pageLoad
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainServe);

            pageInit();

            FindViewById<Button>(Resource.Id.MainServe_QUERY).Click += delegate { proOpt("QUERY", ""); };
            FindViewById<Button>(Resource.Id.MainServe_QUERYLIST).Click += delegate { proOpt("QUERYLIST", ""); };
            FindViewById<Button>(Resource.Id.MainServe_CHECK).Click += delegate { proOpt("CHECK", ""); };
            FindViewById<Button>(Resource.Id.MainServe_CHECKLIST).Click += delegate { proOpt("CHECKLIST", ""); };

            FindViewById<TextView>(Resource.Id.MainServe_USERINFO).Click += delegate { proOpt("USERINFO", ""); };
            FindViewById<TextView>(Resource.Id.MainServe_USERMONEY).Click += delegate { proOpt("USERMONEY", ""); };
            FindViewById<TextView>(Resource.Id.MainServe_CHANGEPASS).Click += delegate { proOpt("CHANGEPASS", ""); };
            FindViewById<TextView>(Resource.Id.MainServe_EXITALL).Click += delegate { proOpt("EXITALL", ""); };
            FindViewById<TextView>(Resource.Id.MainServe_EXIT).Click += delegate { proOpt("EXIT", ""); };  

        }
        #endregion

        #region pageInit
        protected void pageInit()
        {
        }
        #endregion

        #region userOpt
        protected void proOpt(string strCommand, string strKeyID)
        { 
            #region QUERY
            if (strCommand == "QUERY")
            {
                Intent intent = new Intent();
                intent.SetClass(this, typeof(CHE9000WAP.Serve.ServeQueryGrab));
                StartActivity(intent);
            }
            #endregion

            #region ORDERLIST
            if (strCommand == "QUERYLIST")
            {
                Intent intent = new Intent();
                intent.SetClass(this, typeof(CHE9000WAP.Serve.ServeQueryList));
                StartActivity(intent);
            }
            #endregion

            #region CHECK
            if (strCommand == "CHECK")
            {
                Intent intent = new Intent();
                intent.SetClass(this, typeof(CHE9000WAP.Serve.ServeCheckGrab));
                StartActivity(intent);
            }
            #endregion

            #region ORDERLIST
            if (strCommand == "CHECKLIST")
            {
                Intent intent = new Intent();
                intent.SetClass(this, typeof(CHE9000WAP.Serve.ServeCheckList));
                StartActivity(intent);
            }
            #endregion

            #region USERINFO
            if (strCommand == "USERINFO")
            {
                Intent intent = new Intent();
                intent.SetClass(this, typeof(CHE9000WAP.Serve.ServeUserInfo));
                StartActivity(intent);
            }
            #endregion

            #region USERMONEY
            if (strCommand == "USERMONEY")
            {
                Intent intent = new Intent();
                intent.SetClass(this, typeof(CHE9000WAP.Serve.ServeMoneyMain));
                StartActivity(intent);
            }
            #endregion

            #region CHANGEPASS
            if (strCommand == "CHANGEPASS")
            {
                Intent intent = new Intent();
                intent.SetClass(this, typeof(CHE9000WAP.Login.LoginPass));
                StartActivity(intent);
            }
            #endregion

            #region EXIT
            if (strCommand == "EXITALL")
            {
                PUB.PUBLogin.setUSERID("0");
                PUB.PUBLogin.setUSERTELNO("");
                PUB.PUBLogin.setUSERTYPE("0");
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
            }
            if (strCommand == "EXIT")
            {
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
            }
            #endregion 
        }
        #endregion 
    }
}