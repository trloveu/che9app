#region
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.Content;
#endregion

namespace CHE9000WAP.PUB
{
    public class PUB_ITEM
    {
        #region ITEMINFO
        public PUB_ITEM() { }
        public int ITEM_IMGID { get; set; }
        public string ITEM_KEYID { get; set; }
        public string ITEM_SHOWINFO { get; set; }
        public string ITEM_DATETIME { get; set; }
        public string ITEM_STATE { get; set; }
        public string ITEM_STATENAME { get; set; }
        #endregion
    }
     
    public class ITEM_Adapter : BaseAdapter<PUB_ITEM>
    {
        #region ListOverride
        private int LayoutID = 0;
        private Activity context = null;
        public List<PUB_ITEM> list = null;

        public ITEM_Adapter() { }
        public ITEM_Adapter(int iLayoutID, Activity context, List<PUB_ITEM> list)
            : base()
        {
            this.LayoutID = iLayoutID;
            this.context = context;
            this.list = list;
        } 
        public override int Count { get { return this.list.Count; } }
        public override PUB_ITEM this[int position] { get { return this.list[position]; } }
        public override long GetItemId(int position) { return position; }

        #endregion

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            #region fmt
            var item = this.list[position];
            var view = convertView;
            if (convertView == null || !(convertView is LinearLayout))
            {
                view = context.LayoutInflater.Inflate(LayoutID, parent, false);
            }
            #endregion

            switch (LayoutID)
            {
                case Resource.Layout.LoginRegArea:
                    #region
                    TextView LoginRegArea_tvBack = view.FindViewById<TextView>(Resource.Id.LoginRegArea_Back);
                    if (position != 0) { LoginRegArea_tvBack.Visibility = ViewStates.Gone; }
                    LoginRegArea_tvBack.Click += delegate { proOpt(context, "FINISH", item.ITEM_KEYID); };

                    TextView LoginRegArea_tvNext = view.FindViewById<TextView>(Resource.Id.LoginRegArea_Next);
                    if (position != 0) { LoginRegArea_tvNext.Visibility = ViewStates.Gone; }
                    LoginRegArea_tvNext.Click += delegate { proOpt(context, "USERREG_AREANEXT", item.ITEM_KEYID); };
                    CheckBox LoginRegArea_cbCheck = view.FindViewById<CheckBox>(Resource.Id.LoginRegArea_USERCHECK);
                    LoginRegArea_cbCheck.Text = item.ITEM_SHOWINFO;
                    LoginRegArea_cbCheck.CheckedChange += delegate { LoginOpt(context, "USERREG_AREA",
                        item.ITEM_KEYID + "$" + (LoginRegArea_cbCheck.Checked ? "1" : "0")); };

                    
                    break;
                    #endregion
                case Resource.Layout.LoginRegCarType:
                    #region
                    TextView LoginRegCarType_tvBack = view.FindViewById<TextView>(Resource.Id.LoginRegCarType_Back);
                    if (position != 0) { LoginRegCarType_tvBack.Visibility = ViewStates.Gone; }
                    LoginRegCarType_tvBack.Click += delegate { proOpt(context, "FINISH", item.ITEM_KEYID); };

                    TextView LoginRegCarType_tvNext = view.FindViewById<TextView>(Resource.Id.LoginRegCarType_Next);
                    if (position != 0) { LoginRegCarType_tvNext.Visibility = ViewStates.Gone; }
                    LoginRegCarType_tvNext.Click += delegate { proOpt(context, "USERREG_AREANEXT", item.ITEM_KEYID); };
                    CheckBox LoginRegCarType_cbCheck = view.FindViewById<CheckBox>(Resource.Id.LoginRegCarType_USERCHECK);
                    LoginRegCarType_cbCheck.Text = item.ITEM_SHOWINFO;
                    LoginRegCarType_cbCheck.CheckedChange += delegate { LoginOpt(context, "USERREG_CARTYPE",
                        item.ITEM_KEYID + "$" + (LoginRegCarType_cbCheck.Checked ? "1" : "0"));
                    };
                    break;
                    #endregion
            } 
            return view;
        }
         
        #region PubOpt
        protected void proOpt(Activity context, string strCommand, string strKeyID)
        {
            #region FINISH
            if (strCommand == "FINISH")
            {
                context.Finish();
            }
            #endregion
        }
        #endregion

        #region LoginOpt
        protected void LoginOpt(Activity context, string strCommand, string strKeyID)
        {
            #region USERREG_AREANEXT
            if (strCommand == "USERREG_AREANEXT")
            {
                Intent intent = new Intent();
                intent.SetClass(context, typeof(Login.LoginRegCarType)); 
                context.StartActivity(intent);
            }
            #endregion
            
            #region USERREG_AREA
            if (strCommand == "USERREG_AREA")
            {
                SortedList SDList = new SortedList();
                SDList["@USERID"] = PUBLogin.getUSERID();
                SDList["@AREAID"] = strKeyID.Split('$')[0];
                SDList["@ISCHECK"] = strKeyID.Split('$')[1];
                PUBWeb TT = new PUBWeb();
                string strBack = TT.WebDBExec("PRO_SYS_USERREGAREA_ONE",SDList);

                Toast.MakeText(context, (strBack == "" ? "设置成功" : strBack), ToastLength.Long).Show(); 
            }
            #endregion


            #region USERREG_CARTYPENEXT
            if (strCommand == "USERREG_CARTYPENEXT")
            {
                Intent intent = new Intent();
                intent.SetClass(context, typeof(Login.LoginRegBank));
                context.StartActivity(intent);
            }
            #endregion

            #region USERREG_CARTYPE
            if (strCommand == "USERREG_CARTYPE")
            {
                SortedList SDList = new SortedList();
                SDList["@USERID"] = PUBLogin.getUSERID();
                SDList["@CARTYPE"] = strKeyID.Split('$')[0];
                SDList["@ISCHECK"] = strKeyID.Split('$')[1];
                PUBWeb TT = new PUBWeb();
                string strBack = TT.WebDBExec("PRO_SYS_USERREGCARTYPE_ONE", SDList);

                Toast.MakeText(context, (strBack == "" ? "设置成功" : strBack), ToastLength.Long).Show(); 
            }
            #endregion 
        }
        #endregion
    } 
}
