using System;
using HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers;
using UIKit;

namespace TableView.Cell
{
	public abstract class BaseTableViewCell : UITableViewCell
	{
		#region variables

		protected bool _isDisposed;
		readonly protected AppController _appController = AppController.Instance;

		#endregion

		#region constructor

		public BaseTableViewCell()
		{
		}

		public BaseTableViewCell(IntPtr handle) : base(handle)
		{
			SelectionStyle = UITableViewCellSelectionStyle.None;
		}

		#endregion

		#region properties

		public object Controller
		{
			get;
			set;
		}

		#endregion

		#region public methods

		public bool IsDisposed()
		{
			return _isDisposed;
		}

		protected override void Dispose(bool disposing)
		{
			_isDisposed = true;
			base.Dispose(disposing);
		}

		#region view life cycle

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			Initialize();
		}

		#endregion

		#region abstract methods

		abstract public void SetData(object data);

		abstract protected void Initialize();

		#endregion

		#endregion
	}
}