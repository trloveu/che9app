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
    public class LoginRegCarType : ListActivity
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
            DataTable dt = PUB.PUB.getBaseCarType();
            DataTable dtUser = PUB.PUBLogin.getCURRCARTYPE();

            List<LoginRegCarType_ITEM> CURR_ITEMS = new List<LoginRegCarType_ITEM>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string strID = dr["TypeID"].ToString();
                if ((strID.Substring((strID.Length - 1), 1) == "0" && strID != "1000")) { continue; }
                CURR_ITEMS.Add(new LoginRegCarType_ITEM()
                {
                    ITEM_KEYID = dr["TypeID"].ToString(),
                    ITEM_SHOWINFO = dr["TypeCODE"].ToString() + " " + dr["TypeNAME"].ToString(),
                    ITEM_STATE = (dtUser.Select("TypeID=" + dr["TypeID"].ToString()).Length > 0 ? "1" : "0")
                });
            }
            this.ListAdapter = new LoginRegCarType_Adapter(this, CURR_ITEMS);
        }
        #endregion
    }

    #region ITEMINFO
    public class LoginRegCarType_ITEM
    {
        public LoginRegCarType_ITEM() { }
        public string ITEM_KEYID { get; set; }
        public string ITEM_SHOWINFO { get; set; }
        public string ITEM_STATE { get; set; }
    }
    #endregion

    public class LoginRegCarType_Adapter : BaseAdapter<LoginRegCarType_ITEM>
    {
        #region ListOverride
        private string ISCHANGE = "";
        private Activity context = null;
        public List<LoginRegCarType_ITEM> list = null;

        public LoginRegCarType_Adapter() { }
        public LoginRegCarType_Adapter(Activity context, List<LoginRegCarType_ITEM> list)
            : base()
        {
            this.context = context;
            this.list = list;
            ISCHANGE = context.Intent.GetStringExtra("ISCHANGE");
        }
        public override int Count { get { return this.list.Count; } }
        public override LoginRegCarType_ITEM this[int position] { get { return this.list[position]; } }
        public override long GetItemId(int position) { return position; }
        #endregion

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            int iLayoutID = Resource.Layout.LoginRegCarType;

            #region fmt
            var item = this.list[position];
            var view = convertView;
            if (convertView == null || !(convertView is LinearLayout))
            {
                view = context.LayoutInflater.Inflate(iLayoutID, parent, false);
            }
            #endregion

            #region opt
            TextView tvNext = view.FindViewById<TextView>(Resource.Id.LoginRegCarType_Next);
            TextView tvBack = view.FindViewById<TextView>(Resource.Id.LoginRegCarType_Back);
            CheckBox cbCheck = view.FindViewById<CheckBox>(Resource.Id.LoginRegCarType_USERCHECK);

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
            cbCheck.CheckedChange += delegate
            {
                proOpt(context, "CarType",
                    item.ITEM_KEYID + "$" + (cbCheck.Checked ? "1" : "0"));
            };

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
                intent.SetClass(context, typeof(Login.LoginRegBank));
                context.StartActivity(intent);
            }
            #endregion

            #region CarType
            if (strCommand == "CarType")
            {
                SortedList SDList = new SortedList();
                SDList["@USERID"] = PUB.PUBLogin.getUSERID();
                SDList["@TypeID"] = strKeyID.Split('$')[0];
                SDList["@ISCHECK"] = strKeyID.Split('$')[1];
                PUB.PUBWeb TT = new PUB.PUBWeb();
                string strBack = TT.WebDBExec("PRO_SYS_USERREGCARTYPE_ONE", SDList);

                Toast.MakeText(context, (strBack == "" ? "…Ë÷√≥…π¶" : strBack), ToastLength.Long).Show();
            }
            #endregion
        }
        #endregion
    }
}