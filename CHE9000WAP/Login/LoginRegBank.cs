#region
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
#endregion

namespace CHE9000WAP.Login
{
    [Activity(Label = "CHE9000")]
    public class LoginRegBank : Activity
    {
        string ISCHANGE = "";

        #region pageLoad
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LoginRegBank);
            ISCHANGE = Intent.GetStringExtra("ISCHANGE");
            pageInit();

            FindViewById<Button>(Resource.Id.LoginRegBank_USERSKIP).Click += delegate { proOpt("SKIP", ""); };
            FindViewById<TextView>(Resource.Id.LoginRegBank_BACK).Click += delegate { proOpt("FINISH", ""); }; 
            FindViewById<Button>(Resource.Id.LoginRegBank_USERSUBMIT).Click += delegate { proOpt("SUBMIT", ""); }; 
        }
        #endregion

        #region pageInit
        protected void pageInit()
        {
            string[] DDLSOURCE = PUB.PUB.getBankList(); 
            ArrayAdapter ddlADP = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, DDLSOURCE);
            ddlADP.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            FindViewById<Spinner>(Resource.Id.LoginRegBank_BANKLIST).Adapter = ddlADP;
            
            if (ISCHANGE != null && ISCHANGE != "")
            {
                FindViewById<Button>(Resource.Id.LoginRegBank_USERSKIP).Visibility = ViewStates.Gone;
                SortedList SDList = new SortedList();
                SDList["@USERID"] = PUB.PUBLogin.getUSERID();
                PUB.PUBWeb TT = new PUB.PUBWeb();
                DataTable dt = TT.WebDBSqlDT("PRO_SYS_USERQUERY", SDList);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    string strUSERBANK = dr["USERBANK"].ToString();
                    string strUSERBANKNO = dr["USERBANKNO"].ToString();
                    int iBANKINDEX = PUB.PUB.getBankListIndex(strUSERBANK);
                    if (iBANKINDEX >= 0)
                    {
                        FindViewById<Spinner>(Resource.Id.LoginRegBank_BANKLIST).SetSelection(iBANKINDEX, true);
                    }
                    FindViewById<TextView>(Resource.Id.LoginRegBank_USERBANKNO).Text = strUSERBANKNO;
                }
            }
            else
            {
                FindViewById<TextView>(Resource.Id.LoginRegBank_BACK).Visibility = ViewStates.Gone;
            }
        }
        #endregion

        #region userOpt
        protected void proOpt(string strCommand, string strKeyID)
        {
            #region SKIP
            if (strCommand == "SKIP")
            {
                string strUserType = PUB.PUBLogin.getUSERTYPE();
                Intent intent = new Intent(); 
                if (strUserType == "0")
                {
                    intent.SetClass(this, typeof(MainClient)); 
                }
                if (strUserType == "1")
                {
                    intent.SetClass(this, typeof(MainServe)); 
                }
                StartActivity(intent);
                Finish();
            }
            #endregion
               
            #region SUBMIT
            if (strCommand == "SUBMIT")
            { 
                int ddlIndex = FindViewById<Spinner>(Resource.Id.LoginRegBank_BANKLIST).SelectedItemPosition; 
                string[] DDLSOURCE = PUB.PUB.getBankList();
                SortedList SDList = new SortedList();
                SDList["@USERID"] = PUB.PUBLogin.getUSERID();
                SDList["@USERBANK"] = DDLSOURCE[ddlIndex];
                SDList["@USERBANKNO"] = FindViewById<EditText>(Resource.Id.LoginRegBank_USERBANKNO).Text;
                PUB.PUBWeb TT = new PUB.PUBWeb(); 
                string strBack = TT.WebDBExec("PRO_SYS_USERREGBANK",SDList);
                funAlert(strBack);
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
        public void funAlert(string strInfo)
        {
            var dlgAlert = (new AlertDialog.Builder(this)).Create();
            dlgAlert.SetMessage(strInfo == ""?"编辑成功":strInfo);
            dlgAlert.SetTitle("提示信息");
            if (strInfo != "") { dlgAlert.SetButton("确认", funAlertDoNULL); }
            else { dlgAlert.SetButton("确认", funAlertDoMain); } 
            dlgAlert.Show();
        }
        public void funAlertDoNULL(object sender, DialogClickEventArgs e) { }
        public void funAlertDoMain(object sender, DialogClickEventArgs e)
        {
            proOpt("SKIP", "");
        } 
        #endregion
    }
}