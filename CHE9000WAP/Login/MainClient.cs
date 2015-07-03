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
    public class MainClient : Activity
    {
        #region pageLoad
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainClient);

            pageInit();
             
            FindViewById<Button>(Resource.Id.MainClient_QUERY).Click += delegate { proOpt("QUERY", ""); };
            FindViewById<Button>(Resource.Id.MainClient_CHECK).Click += delegate { proOpt("CHECK", ""); };
            FindViewById<Button>(Resource.Id.MainClient_ORDERLIST).Click += delegate { proOpt("ORDERLIST", ""); };

            FindViewById<TextView>(Resource.Id.MainClient_USERINFO).Click += delegate { proOpt("USERINFO", ""); };
            FindViewById<TextView>(Resource.Id.MainClient_USERMONEY).Click += delegate { proOpt("USERMONEY", ""); };
            FindViewById<TextView>(Resource.Id.MainClient_CHANGEPASS).Click += delegate { proOpt("CHANGEPASS", ""); };
            FindViewById<TextView>(Resource.Id.MainClient_EXITALL).Click += delegate { proOpt("EXITALL", ""); };
            FindViewById<TextView>(Resource.Id.MainClient_EXIT).Click += delegate { proOpt("EXIT", ""); }; 
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
                intent.SetClass(this, typeof(CHE9000WAP.Client.ClientQueryApply));
                StartActivity(intent);
            }
            #endregion

            #region CHECK
            if (strCommand == "CHECK")
            {
                Intent intent = new Intent();
                intent.SetClass(this, typeof(CHE9000WAP.Client.ClientCheckApply));
                StartActivity(intent);
            }
            #endregion

            #region ORDERLIST
            if (strCommand == "ORDERLIST")
            {
                Intent intent = new Intent();
                intent.SetClass(this, typeof(CHE9000WAP.Client.ClientOrderList));
                StartActivity(intent);
            }
            #endregion

            #region USERINFO
            if (strCommand == "USERINFO")
            {
                Intent intent = new Intent();
                intent.SetClass(this, typeof(CHE9000WAP.Client.ClientUserInfo));
                StartActivity(intent);
            }
            #endregion

            #region USERMONEY
            if (strCommand == "USERMONEY")
            {
                Intent intent = new Intent();
                intent.SetClass(this, typeof(CHE9000WAP.Client.ClientMoneyList));
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