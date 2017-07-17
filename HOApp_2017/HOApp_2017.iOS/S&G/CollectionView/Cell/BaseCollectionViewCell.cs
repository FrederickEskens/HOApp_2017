using System;
using HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers;
using UIKit;

namespace HOApp_2017.iOS.SG.CollectionView.Cell
{
    public abstract class BaseCollectionViewCell:UICollectionViewCell
    {
		#region variables

		protected bool _isDisposed;
		readonly protected AppController _appController = AppController.Instance;

		#endregion
		public BaseCollectionViewCell()
        {
        }

		public BaseCollectionViewCell(IntPtr handle) : base(handle)
        {
			
		}

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
