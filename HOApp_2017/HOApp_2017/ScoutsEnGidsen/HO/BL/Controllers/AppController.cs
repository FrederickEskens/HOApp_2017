using System.Collections.Generic;
using System.Linq;
using HOApp_2017.ScoutsEnGidsen.HO.BL.VO;
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

        List<LocationVO> Locations;
        List<ProgramItemVO> ProgramItems;
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

        public List<ProgramItemVO> GetAllProgramItems(){
            if (ProgramItems == null)
            {
                List<ProgramItemVO> returnValue = new List<ProgramItemVO>();
                var locations = database.GetAllLocations();
                Locations = new List<LocationVO>();
                foreach (var location in locations)
                {
                    LocationVO loc = new LocationVO(location);
                    Locations.Add(loc);
                }
                var progItems = database.GetAllProgramItems();
                ProgramItems = new List<ProgramItemVO>();
                foreach (var progItem in progItems)
                {
                    ProgramItemVO programmaItem = new ProgramItemVO(progItem.ParentID, progItem.ID, progItem.Title, progItem.StartTime, progItem.EndTime);
                    if (progItem.Location != null)
                        programmaItem.Location = Locations.Find(x => x.ID == progItem.Location);
                    var parentItem = ProgramItems.Find(x => x.ID == programmaItem.ParentID);
                    if (parentItem != null)
                    {
                        parentItem.HasChildProgramItems = true;
                        if (parentItem.ChildProgramItems == null)
                            parentItem.ChildProgramItems = new List<ProgramItemVO>();
                        parentItem.ChildProgramItems.Add(programmaItem);
                        if (parentItem.ParentID != 0)
                            programmaItem.HasParentProgramItems = true;
                        else
                            programmaItem.HasParentProgramItems = false;
                        
                            ProgramItems.Insert(ProgramItems.IndexOf(parentItem) + parentItem.ChildProgramItems.Count, programmaItem);
                    }
                    else
                    {
                        ProgramItems.Add(programmaItem);
                    }
                }


            }
                return ProgramItems;


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