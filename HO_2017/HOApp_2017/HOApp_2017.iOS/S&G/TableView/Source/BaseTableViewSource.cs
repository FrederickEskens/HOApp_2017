//
// BaseTableViewSource.cs
//
// Author:
//       Wim Van Renterghem <vrwim@bazookas.be>
//
// Copyright (c) 2015 Wim Van Renterghem
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using TableView.Cell;
using UIKit;

namespace TableView.Source
{
	/// <summary>
	/// The base table view source.
	/// Please implement an enum next to this, where you have cellIdentifiers equal an integer, to have all cellIdentifiers in one place
	/// </summary>
	public abstract class BaseTableViewSource : UITableViewSource
	{
		#region delegates

		public event EventHandler OnDecelerationEnded;
		public event EventHandler OnDecelerationStarted;
		public event EventHandler OnDidZoom;
		public event EventHandler OnDraggingStarted;
		public event EventHandler OnDraggingEnded;
		public event EventHandler OnScrollAnimationEnded;
		public event EventHandler OnScrolled;
		public event EventHandler OnScrolledToTop;

		#endregion

		#region variables

		/// <summary>
		/// Optimization: so it does not iterate over visible cells looking for parallax cells, when it hasn't returned a parallaxing cell
		/// </summary>
		bool _hasParallaxCells;

		#endregion

		#region properties

		/// <summary>
		/// Number of sections to display.
		/// </summary>
		protected virtual int Sections
		{
			get
			{
				return 1;
			}
		}

		/// <summary>
		/// The data objects, make a list of IEnumerable to display sections.
		/// </summary>
		protected abstract IEnumerable<object> DataObjects { get; }

		/// <summary>
		/// A list of cell identifiers
		/// </summary>
		protected virtual IEnumerable<string> Identifiers { get; }

		/// <summary>
		/// The alternating backgroundColor of each cell.
		/// </summary>
		protected virtual IEnumerable<UIColor> AlternatingColors
		{
			get
			{
				return null;
			}
		}

		#endregion

		#region public methods

		protected abstract string GetCellIdentifier(object vo);

		/// <summary>
		/// This can be overridden to have a list of objects that represent sections
		/// </summary>
		/// <returns>The cell data.</returns>
		/// <param name="indexPath">The indexpath for which to return the data.</param>
		public virtual object GetCellData(NSIndexPath indexPath)
		{
			return Sections == 1 ? DataObjects.ElementAt(indexPath.Row) : (DataObjects.ElementAt(indexPath.Section) as IEnumerable<object>).ElementAt(indexPath.Row);
		}

		#region overridden methods

		public override nint NumberOfSections(UITableView tableView)
		{
			return Sections;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			if (DataObjects == null)
				return 0;
			else
				return Sections == 1 ? DataObjects.Count() : (DataObjects as IEnumerable<object>).Count();
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			object cellInfo = GetCellData(indexPath);

			var identifier = GetCellIdentifier(cellInfo);
			var uiTableViewCell = tableView.DequeueReusableCell(identifier);
			if (uiTableViewCell == null)
			{
				throw new ArgumentException("No cell found with the identifier " + identifier);
			}
			else if (!(uiTableViewCell is BaseTableViewCell))
			{
				throw new ArgumentException("Cell with the identifier " + identifier + " is not a BaseTableViewCell");
			}
			BaseTableViewCell cell = uiTableViewCell as BaseTableViewCell;

			if (AlternatingColors != null)
			{
				cell.BackgroundColor = AlternatingColors.ElementAt(indexPath.Row % AlternatingColors.Count());
			}

			cell.SetData(cellInfo);

			return cell;
		}

		#region events

		public override void DecelerationEnded(UIScrollView scrollView)
		{
			if (OnDecelerationEnded != null)
				OnDecelerationEnded(scrollView, EventArgs.Empty);
		}

		public override void DecelerationStarted(UIScrollView scrollView)
		{
			if (OnDecelerationStarted != null)
				OnDecelerationStarted(scrollView, EventArgs.Empty);
		}

		public override void DidZoom(UIScrollView scrollView)
		{
			if (OnDidZoom != null)
				OnDidZoom(scrollView, EventArgs.Empty);
		}

		public override void DraggingEnded(UIScrollView scrollView, bool willDecelerate)
		{
			if (OnDraggingEnded != null)
				OnDraggingEnded(scrollView, EventArgs.Empty);
		}

		public override void DraggingStarted(UIScrollView scrollView)
		{
			if (OnDraggingStarted != null)
				OnDraggingStarted(scrollView, EventArgs.Empty);
		}

		public override void ScrollAnimationEnded(UIScrollView scrollView)
		{
			if (OnScrollAnimationEnded != null)
				OnScrollAnimationEnded(scrollView, EventArgs.Empty);
		}

		public override void Scrolled(UIScrollView scrollView)
		{
			if (OnScrolled != null)
				OnScrolled(scrollView, EventArgs.Empty);
		}

		public override void ScrolledToTop(UIScrollView scrollView)
		{
			if (OnScrolledToTop != null)
				OnScrolledToTop(scrollView, EventArgs.Empty);
		}

		#endregion

		#endregion

		#endregion
	}
}

