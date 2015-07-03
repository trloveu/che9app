#region
using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
#endregion

namespace CHE9000WAP.Serve
{
    [Activity(Label = "CHE9000")]
    public class ServeUserInfo : Activity
    {
        #region pageLoad
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ServeUserInfo);

            pageInit();

            FindViewById<TextView>(Resource.Id.ServeUserInfo_EXIT).Click += delegate { proOpt("FINISH", ""); };
            FindViewById<TextView>(Resource.Id.ServeUserInfo_AREA).Click += delegate { proOpt("AREA", ""); };
            FindViewById<TextView>(Resource.Id.ServeUserInfo_CARTYPE).Click += delegate { proOpt("CARTYPE", ""); };
            FindViewById<TextView>(Resource.Id.ServeUserInfo_BANK).Click += delegate { proOpt("BANK", ""); };
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
            #region AREA
            if (strCommand == "AREA")
            {
                Intent intent = new Intent();
                intent.SetClass(this, typeof(CHE9000WAP.Login.LoginRegArea));
                Bundle bundle = new Bundle();
                bundle.PutString("ISCHANGE", "1");
                intent.PutExtras(bundle);
                StartActivity(intent);
            }
            #endregion 

            #region CARTYPE
            if (strCommand == "CARTYPE")
            {
                Intent intent = new Intent();
                intent.SetClass(this, typeof(CHE9000WAP.Login.LoginRegCarType));
                Bundle bundle = new Bundle();
                bundle.PutString("ISCHANGE", "1");
                intent.PutExtras(bundle);
                StartActivity(intent);
            }
            #endregion 

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