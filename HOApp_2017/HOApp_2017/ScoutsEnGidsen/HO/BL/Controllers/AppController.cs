using System.Collections.Generic;
using System.Linq;
using HOApp_2017.ScoutsEnGidsen.HO.DAL.DO;
using HOApp_2017.ScoutsEnGidsen.HO.DL;

namespace HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers {
	public class AppController {
		#region delegates

		#endregion

		#region variables
		static readonly AppController _instance = new AppController();
		readonly Database database = DatabaseHelper.GetInstance();
		NavigationController _navigationController;

		List<CopyDO> copyItems;
		#endregion

		#region constructor
		public AppController()
		{
			_navigationController = new NavigationController();
			copyItems = database.GetAllCopy();
		}
		#endregion

		#region properties
		public static AppController Instance
		{
			get
			{
				return _instance;
			}
		}

		public NavigationController NavigationController
		{
			get
			{
				return _navigationController;
			}
		}
		#endregion

		#region public methods
		public string GetCopy(string copyKey)
		{
			string returnValue = copyKey;
			var copyItem = copyItems.Find(x => x.CopyKey == copyKey);
			if (copyItem != null)
				returnValue = copyItem.CopyValue_NL;
			return returnValue;
		}
		#region override methods

		#region Viewcycle

		#endregion

		#endregion

		#endregion

		#region private methods

		#endregion







		/* ------------------------------ PROPERTIES ------------------------------ */





		/* ------------------------------ DATABASE ------------------------------ */




        /* ------------------------------ CLICK EVENTS ------------------------------ */


		/* ------------------------------ MISC ------------------------------ */


	}
}