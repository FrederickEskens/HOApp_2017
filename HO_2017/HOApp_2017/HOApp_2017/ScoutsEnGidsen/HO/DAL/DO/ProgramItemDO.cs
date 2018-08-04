using System;
using SQLite;

namespace HOApp_2017.ScoutsEnGidsen.HO.DAL.DO
{
    public class ProgramItemDO
    {
        public ProgramItemDO()
        {
        }

        [Column("ParentID")]
		public int ParentID
		{
			get;
			set;
		}

		[PrimaryKey, NotNull]
		[Column("ID")]
		public int ID
		{
			get;
			set;
		}

		[Column("Title")]
		public string Title
		{
			get;
			set;
		}

		[Column("TimeBegin")]
		public string StartTime
		{
			get;
			set;
		}

		[Column("TimeEnd")]
		public string EndTime
		{
			get;
			set;
		}

		[Column("LocationID")]
		public int Location
		{
			get;
			set;
		}
    }
}
