using System;
using System.Collections.Generic;
using HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers;
using HOApp_2017.ScoutsEnGidsen.HO.BL.VO;
using TableView.Source;

namespace HOApp_2017.iOS.SG.TableView.Source
{
    public class ProgramTableViewSource:BaseTableViewSource
    {
        ProgramPageController Controller;   
        public ProgramTableViewSource(ProgramPageController Controller)
        {
            this.Controller = Controller;
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
            if (programItem.HasParentProgramItems)
                return ProgramMultiCell.Key;
            else
                return ProgrammSingleCell.Key;
        }

        public override nfloat GetHeightForRow(UIKit.UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var programItem = ProgramDays[indexPath.Row];
            if (programItem.ParentID == 0)
                return 45;
            
            return 60;
        }

        public override void RowSelected(UIKit.UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var programItem = ProgramDays[indexPath.Row];
            if (programItem.Location != null && programItem.Location.XPosition!= 0){
                Controller.ShowLocationOnMap(programItem.Location);
            }
        }
    }
}
