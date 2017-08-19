using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers;
using Android.Support.V7.Widget;
using HOApp_2017.ScoutsEnGidsen.HO.BL.VO;
using Android.Content.Res;

namespace HOApp_2017.Droid
{
    public class ProgramFragment : BaseContentFragmen
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        ProgramAdapter mAdapter;
        ProgramPageController _rulesController
        {
            get
            {
                if (ContentController is ProgramPageController)
                    return ContentController as ProgramPageController;
                else
                    return null;
            }
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Instantiate the adapter and pass in its data source:
            
            
            // Set our view from the "main" layout resource:
            

            // Get our RecyclerView layout:
            
        }

        private void _rulesController_ProgramLoadedEvent(List<ProgramItemVO> ProgramItems)
        {
            
            mAdapter.ProgramItems = ProgramItems;
            Activity.RunOnUiThread(() => mAdapter.NotifyDataSetChanged());

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            var view = inflater.Inflate(Resource.Layout.programmFragmentLayout, container, false);

            mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);

            // Plug the adapter into the RecyclerView:
            mAdapter = new ProgramAdapter();
            mRecyclerView.SetAdapter(mAdapter);
            mLayoutManager = new LinearLayoutManager(Activity);
            mRecyclerView.SetLayoutManager(mLayoutManager);
            DividerItemDecoration dividerItemDecoration = new DividerItemDecoration(mRecyclerView.Context,LinearLayoutManager.Vertical);
            mRecyclerView.AddItemDecoration(dividerItemDecoration);
            if (_rulesController != null)
            {
                _rulesController.ProgramLoadedEvent += _rulesController_ProgramLoadedEvent;
                _rulesController.LoadData();
            }
            return view;
        }
    }

    internal class ProgramAdapter : RecyclerView.Adapter
    {
        List<ProgramItemVO> programItems;
        public List<ProgramItemVO> ProgramItems {
            get {
                if (programItems == null)
                    programItems = new List<ProgramItemVO>();
                return programItems; }
            set {
                programItems = value;
                
            }
        }
        public ProgramAdapter()
        {
      
        }
        public override int ItemCount => ProgramItems.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ProgramItemVO pi = ProgramItems[position];
            if (holder is ProgrammDayViewHolder)
            {
                ProgrammDayViewHolder vh = holder as ProgrammDayViewHolder;
                vh.lblDay.Text = pi.Title;
            }
            else
            {
                ProgrammItemViewHolder vh = holder as ProgrammItemViewHolder;
                vh.lblHour.Text = pi.StartTime+ ((pi.StartTime != null && pi.EndTime!=null) ? " - ":"") + pi.EndTime;
                if (pi.Location != null)
                    vh.lblLocation.Text = pi.Location.Name;
                vh.lblContent.Text = pi.Title;
                if (pi.HasParentProgramItems)
                {
                    vh.vwInset.Visibility = ViewStates.Visible;
                    var lp = vh.lblHour.LayoutParameters as RelativeLayout.LayoutParams;
                    lp.LeftMargin = (int)convertDpToPixel(30,vh.lblHour.Context);
                    vh.lblHour.LayoutParameters = lp;
                }
                else
                {
                    vh.vwInset.Visibility = ViewStates.Gone;
                    var lp = vh.lblHour.LayoutParameters as RelativeLayout.LayoutParams;
                    lp.LeftMargin = (int)convertDpToPixel(20, vh.lblHour.Context);
                    vh.lblHour.LayoutParameters = lp;
                }

            }
        }

        /**
 * This method converts dp unit to equivalent pixels, depending on device density. 
 * 
 * @param dp A value in dp (density independent pixels) unit. Which we need to convert into pixels
 * @param context Context to get resources and device specific display metrics
 * @return A float value to represent px equivalent to dp depending on device density
 */
        public static float convertDpToPixel(float dp, Context context)
        {
            Resources resources = context.Resources;
            DisplayMetrics metrics = resources.DisplayMetrics;
            float px = dp * ((float)metrics.DensityDpi / (float)Android.Util.DisplayMetricsDensity.Default);
            return px;
        }

        /**
         * This method converts device specific pixels to density independent pixels.
         * 
         * @param px A value in px (pixels) unit. Which we need to convert into db
         * @param context Context to get resources and device specific display metrics
         * @return A float value to represent dp equivalent to px value
         */
        public static float convertPixelsToDp(float px, Context context)
        {
            Resources resources = context.Resources;
            DisplayMetrics metrics = resources.DisplayMetrics;
            float dp = px / ((float)metrics.DensityDpi / (float)Android.Util.DisplayMetricsDensity.Default);
            return dp;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (viewType == 1)
            {
                View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_program_ay_layout, parent, false);
                ProgrammDayViewHolder vh = new ProgrammDayViewHolder(itemView);
                return vh;
            }
            else
            {
                View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_programItem_Layout, parent, false);
                ProgrammItemViewHolder vh = new ProgrammItemViewHolder(itemView);
                return vh;
            }
            
            
        }

        public override int GetItemViewType(int position)
        {
            if (ProgramItems[position].ParentID == 0)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }

    internal class ProgrammDayViewHolder : RecyclerView.ViewHolder
    {
        public TextView lblDay { get; private set; }
        public ProgrammDayViewHolder(View itemView) : base(itemView)
        {
            lblDay = itemView.FindViewById<TextView>(Resource.Id.lblDay);
        }

        protected ProgrammDayViewHolder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }

    internal class ProgrammItemViewHolder : RecyclerView.ViewHolder
    {
        public TextView lblHour { get; private set; }
        public TextView lblLocation { get; private set; }
        public TextView lblContent { get; private set; }
        public View vwInset { get; private set; }
        public ProgrammItemViewHolder(View itemView) : base(itemView)
        {
            lblHour = itemView.FindViewById<TextView>(Resource.Id.lblHour);
            lblLocation = itemView.FindViewById<TextView>(Resource.Id.lblLocation);
            lblContent = itemView.FindViewById<TextView>(Resource.Id.lblContent);
            vwInset = itemView.FindViewById<View>(Resource.Id.vwjumpIn);
        }

        protected ProgrammItemViewHolder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
}