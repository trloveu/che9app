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
    public class ClientQueryList : Activity
    {
        #region pageLoad
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Flash);

            pageInit();

            FindViewById<ImageView>(Resource.Id.Flash_ImgEnter).Click += delegate { proOpt("GETPASS", ""); };
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
            #region EXIT FINISH
            if (strCommand == "EXIT")
            {
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
            }
            if (strCommand == "FINISH")
            {
                Finish();
            }
            #endregion
        }
        #endregion 
    }
}