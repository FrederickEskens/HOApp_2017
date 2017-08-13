using System;
using SQLite;

namespace HOApp_2017.ScoutsEnGidsen.HO.DAL.DO
{
    public class LocationDO
    {
        public LocationDO()
        {
        }

		[PrimaryKey, NotNull]
		[Column("ID")]
		public int ID
		{
			get;
			set;
		}

		[Column("Name")]
		public string Title
		{
			get;
			set;
		}

		[Column("LocationX")]
		public int LocationX
		{
			get;
			set;
		}

		[Column("LocationY")]
		public int LocationY
		{
			get;
			set;
		}


	}
}
