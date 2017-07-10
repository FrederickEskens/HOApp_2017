using System;
using System.Collections.Generic;
using HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers;
using HOApp_2017.ScoutsEnGidsen.HO.BL.VO;
using TableView.Source;

namespace HOApp_2017.iOS.SG.TableView.Source
{
    public class ProgramTableViewSource:BaseTableViewSource
    {
        
        public ProgramTableViewSource(ProgramPageController Controller)
        {
            
        }
        public List<ProgramItemVO> ProgramDays
        {
            get;
            set;
        }

        protected override IEnumerable<object> DataObjects => ProgramDays;



        protected override string GetCellIdentifier(object vo)
        {
            var programItem = vo as ProgramItemVO;
            if (programItem.ParentID == 0){
                return ProgrammHeaderCell.Key;
            }
            if (programItem.HasChildProgramItems)
                return ProgramMultiCell.Key;
            else
                return ProgrammSingleCell.Key;
        }

        public override nfloat GetHeightForRow(UIKit.UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var programItem = ProgramDays[indexPath.Row];
			if (programItem.ParentID == 0)
			{
				return 50;
			}
			if (programItem.HasChildProgramItems)
				return 100;
			else
				return 75;
        }
    }
}
