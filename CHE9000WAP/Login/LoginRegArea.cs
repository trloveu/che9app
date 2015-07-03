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
    public class LoginRegArea : ListActivity
    {
        #region pageCreate
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            pageInit();
        }
        #endregion

        #region pageInit
        public void pageInit()
        {
            DataTable dt = PUB.PUB.getBaseArea();
            DataTable dtUser = PUB.PUBLogin.getCURRAREA();

            List<LoginRegArea_ITEM> CURR_ITEMS = new List<LoginRegArea_ITEM>(); 
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string strID = dr["AREAID"].ToString();
                if ((strID.Substring((strID.Length-1),1) == "0" && strID != "1000")) {continue;}
                CURR_ITEMS.Add(new LoginRegArea_ITEM()
                { 
                    ITEM_KEYID = dr["AREAID"].ToString(),
                    ITEM_SHOWINFO = dr["AREACODE"].ToString() + " " +dr["AREANAME"].ToString(),
                    ITEM_STATE = (dtUser.Select("AREAID="+dr["AREAID"].ToString()).Length>0?"1":"0")
                });
            }
            this.ListAdapter = new LoginRegArea_Adapter(this, CURR_ITEMS); 
        }
        #endregion
    }

    #region ITEMINFO
    public class LoginRegArea_ITEM
    { 
        public LoginRegArea_ITEM() { } 
        public string ITEM_KEYID { get; set; }
        public string ITEM_SHOWINFO { get; set; }
        public string ITEM_STATE { get; set; }
    }
    #endregion

    public class LoginRegArea_Adapter : BaseAdapter<LoginRegArea_ITEM>
    {
        #region ListOverride 
        private string ISCHANGE = "";
        private Activity context = null;
        public List<LoginRegArea_ITEM> list = null;

        public LoginRegArea_Adapter() { }
        public LoginRegArea_Adapter(Activity context, List<LoginRegArea_ITEM> list)
            : base()
        { 
            this.context = context;
            this.list = list;
            ISCHANGE = context.Intent.GetStringExtra("ISCHANGE");
        }
        public override int Count { get { return this.list.Count; } }
        public override LoginRegArea_ITEM this[int position] { get { return this.list[position]; } }
        public override long GetItemId(int position) { return position; } 
        #endregion

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            int iLayoutID = Resource.Layout.LoginRegArea;

            #region fmt
            var item = this.list[position];
            var view = convertView;
            if (convertView == null || !(convertView is LinearLayout))
            {
                view = context.LayoutInflater.Inflate(iLayoutID, parent, false);
            }
            #endregion

            #region opt
            TextView tvNext = view.FindViewById<TextView>(Resource.Id.LoginRegArea_Next);
            TextView tvBack = view.FindViewById<TextView>(Resource.Id.LoginRegArea_Back);
            CheckBox cbCheck = view.FindViewById<CheckBox>(Resource.Id.LoginRegArea_USERCHECK);

            if (position == 0)
            { 
                if (ISCHANGE != null && ISCHANGE != "")
                {
                    tvNext.Visibility = ViewStates.Gone;
                    tvBack.Click += delegate { proOpt(context, "FINISH", item.ITEM_KEYID); }; 
                }
                else
                {
                    tvNext.Click += delegate { proOpt(context, "NEXT", item.ITEM_KEYID); };
                    tvBack.Visibility = ViewStates.Gone; 
                } 
            }
            if (position != 0)
            {
                tvNext.Visibility = ViewStates.Gone;
                tvBack.Visibility = ViewStates.Gone;
            }

            cbCheck.Text = item.ITEM_SHOWINFO;
            cbCheck.Checked = (item.ITEM_STATE == "1"); 
            cbCheck.CheckedChange += delegate{proOpt(context, "AREA",
                item.ITEM_KEYID + "$" + (cbCheck.Checked ? "1" : "0")); }; 

            #endregion

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

            #region NEXT
            if (strCommand == "NEXT")
            {
                Intent intent = new Intent();
                intent.SetClass(context, typeof(Login.LoginRegCarType));
                context.StartActivity(intent);
            }
            #endregion

            #region AREA
            if (strCommand == "AREA")
            {
                SortedList SDList = new SortedList();
                SDList["@USERID"] = PUB.PUBLogin.getUSERID();
                SDList["@AREAID"] = strKeyID.Split('$')[0];
                SDList["@ISCHECK"] = strKeyID.Split('$')[1];
                PUB.PUBWeb TT = new PUB.PUBWeb();
                string strBack = TT.WebDBExec("PRO_SYS_USERREGAREA_ONE", SDList);

                Toast.MakeText(context, (strBack == "" ? "…Ë÷√≥…π¶" : strBack), ToastLength.Long).Show();
            }
            #endregion 
        }
        #endregion
    } 
}