//
// CopyDO.cs
//
// Author:
//       Jeroen Crevits <jeroen@bazookas.be>
//
// Copyright (c) 2017 Bazookas
//
using System;
using SQLite;

namespace HOApp_2017.ScoutsEnGidsen.HO.DAL.DO
{
	public class CopyDO
	{
		public CopyDO()
		{
		}
		[PrimaryKey, NotNull]
		[Column("copyKey")]
		public string CopyKey
		{
			get;
			set;
		}

		[Column("copyValue_NL")]
		public string CopyValue_NL
		{
			get;
			set;
		}

	}
}
