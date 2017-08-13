// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace HOApp_2017.iOS
{
	[Register ("ProgramViewController")]
	partial class ProgramViewController
	{
		[Outlet]
		UIKit.UITableView tblProgram { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tblProgram != null) {
				tblProgram.Dispose ();
				tblProgram = null;
			}
		}
	}
}
