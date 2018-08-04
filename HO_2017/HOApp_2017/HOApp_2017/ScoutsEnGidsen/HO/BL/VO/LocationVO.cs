using System;
using HOApp_2017.ScoutsEnGidsen.HO.DAL.DO;

namespace HOApp_2017.ScoutsEnGidsen.HO.BL.VO
{
    public class LocationVO
    {
        public LocationVO()
        {
        }

        public LocationVO(LocationDO location)
        {
            XPosition = location.LocationX;
            YPosition = location.LocationY;
            Name = location.Title;
            ID = location.ID;
        }

        public int XPosition
        {
            get;
            set;
        }

        public int YPosition
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int ID
        {
            get;
            set;
        }
    }
}
