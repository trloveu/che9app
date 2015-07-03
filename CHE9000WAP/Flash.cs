#region
using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
#endregion

namespace CHE9000WAP
{
    [Activity(Label = "CHE9000", MainLauncher = true, Icon = "@drawable/icon")]
    public class Flash : Activity
    {
        #region pageLoad
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle); 
            SetContentView(Resource.Layout.Flash);

            pageInit();

            FindViewById<ImageView>(Resource.Id.Flash_ImgEnter).Click += delegate { proOpt("ENTER", ""); };  
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
            #region ENTER
            if (strCommand == "ENTER")
            {
                Intent intent = new Intent();
                intent.SetClass(this, typeof(Login.Login0));
                StartActivity(intent);
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
            } 
            #endregion
        }
        #endregion 

    }
}

