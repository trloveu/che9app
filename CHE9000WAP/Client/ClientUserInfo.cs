#region
using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
#endregion

namespace CHE9000WAP.Client
{
    [Activity(Label = "CHE9000")]
    public class ClientUserInfo : Activity
    {
        #region pageLoad
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ClientUserInfo);

            pageInit();

            FindViewById<TextView>(Resource.Id.ClientUserInfo_EXIT).Click += delegate { proOpt("FINISH", ""); };
            FindViewById<TextView>(Resource.Id.ClientUserInfo_BANK).Click += delegate { proOpt("BANK", ""); };
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
            #region BANK
            if (strCommand == "BANK")
            {
                Intent intent = new Intent();
                intent.SetClass(this, typeof(CHE9000WAP.Login.LoginRegBank));
                Bundle bundle = new Bundle();
                bundle.PutString("ISCHANGE", "1");
                intent.PutExtras(bundle);
                StartActivity(intent);
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
    }
}