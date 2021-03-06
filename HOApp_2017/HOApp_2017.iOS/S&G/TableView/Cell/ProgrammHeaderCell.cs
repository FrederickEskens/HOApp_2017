// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using HOApp_2017.ScoutsEnGidsen.HO.BL.VO;
using TableView.Cell;
using UIKit;

namespace HOApp_2017.iOS
{
	public partial class ProgrammHeaderCell : BaseTableViewCell
	{
		public ProgrammHeaderCell (IntPtr handle) : base (handle)
		{
		}
        public static readonly NSString Key = new NSString("ProgrammHeaderCell");
        public override void SetData(object data)
        {
            lblTitle.Text = (data as ProgramItemVO).Title;
        }

        protected override void Initialize()
        {
            Console.WriteLine("initialize");
            lblTitle.Font = UIFont.FromName("Roboto-Bold", 21);
        }
    }
}
