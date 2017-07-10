using System;
using System.Collections.Generic;

namespace HOApp_2017.ScoutsEnGidsen.HO.BL.VO
{
    public class ProgramItemVO
    {
        public ProgramItemVO()
        {
        }
        public ProgramItemVO(int parentID, int iD, string title, string startTime, string endTime)
        {
            ParentID = parentID;
            ID = iD;
            Title = title;
            StartTime = startTime;
            EndTime = endTime;
        }

        public int ParentID
        {
            get;
            set;
        }

        public int ID
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string StartTime
        {
            get;
            set;
        }

        public string EndTime
        {
            get;
            set;
        }

        public LocationVO Location
        {
            get;
            set;
        }

        public List<ProgramItemVO> ChildProgramItems
        {
            get;
            set;
        }

        public bool HasChildProgramItems
        {
            get;
            set;
        }
    }
}
