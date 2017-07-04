//
// SideMenuTableViewSource.cs
//
// Author:
//       Jeroen Crevits <jeroen@bazookas.be>
//
// Copyright (c) 2017 Bazookas
//
using System;
using System.Collections.Generic;
using HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers;
using HOApp_2017.ScoutsEnGidsen.HO.BL.VO;
using TableView.Source;

namespace HOApp_2017.iOS.SG.TableView.Source
{
	public class SideMenuTableViewSource:BaseTableViewSource
	{
		public SideMenuTableViewSource()
		{
		}

		public List<MenuItemVO> Items
		{
			get;
			set;
		}

		protected override IEnumerable<object> DataObjects
		{
			get
			{
				return Items;
			}
		}

		protected override string GetCellIdentifier(object vo)
		{
			return SideMenuTableViewCell.Key;
		}

		public override UIKit.UITableViewCell GetCell(UIKit.UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = base.GetCell(tableView, indexPath) as SideMenuTableViewCell;
			return cell;
		}

		public override UIKit.UIView GetViewForHeader(UIKit.UITableView tableView, nint section)
		{
            var footer = tableView.DequeueReusableCell(SideMenuFooterLogo.Key) as SideMenuFooterLogo;
			return footer;
		}

		public override UIKit.UIView GetViewForFooter(UIKit.UITableView tableView, nint section)
		{
			var footer = tableView.DequeueReusableCell(SideMenuFooterLogo.Key) as SideMenuFooterLogo;
			return footer;
		}
		public override nfloat GetHeightForFooter(UIKit.UITableView tableView, nint section)
		{
			return 200;
		}

		public override void RowSelected(UIKit.UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var selectedItem = Items[indexPath.Row];
			AppController.Instance.NavigationController.SideMenuButtonClicked(selectedItem.Page);
		}
	}
}
