using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;

namespace EssetteCM.CustomControls
{
	public class AccordionNodeViewModel : BaseViewModel
	{
		#region Private Properties 

		private bool _isExpanded = false;
		private string _headerText;


		//What the height should be when expanded
		private int _expandedContentHeight;

		//What's the current height
		private int _currentContentHeight = 0;

		//These Could Be Images instead of text
		//What should display when the nodes is expanded
		private string _iconExpandButtonText;

		//What should display when the nodes is contracted
		private string _iconContractButtonText;

		//What is currrently displaying to the user
		private string _currentIconButtonText = "+";

		private int locationID { get; set; }



		public enum AccordionObjectType
		{
			Nothing,
			EmergencyContact,
			Contractor,
			ControlRoom,
			InventoryPipe,
			Facilities,
			Personnel,
			PoeplineSegement,
			ToolsEquipment,
			EmergencyNumber,
			CustomerNumber,
			EmergenceyDetails,
			DrivingDirections

		}

		private int objectTypeVal { get; set; }
		#endregion

		public AccordionNodeViewModel(string headerText, int expandedContentHeight, Color headerBackgroundColor, Color headerTextColor, Color? lineColor = null, string iconExpandText = "+", string icondeContractText = "-")
		{
			//if(objectTypeVal==Convert.ToInt32(objectType.EmergencyContact))

			HeaderText = headerText;
			_expandedContentHeight = expandedContentHeight;
			_iconExpandButtonText = iconExpandText;
			_iconContractButtonText = icondeContractText;
			HeaderBackGroundColor = headerBackgroundColor;
			HeaderTextColor = headerTextColor;
			LineColor = lineColor ?? headerTextColor;
		}

		public int ContentHeight
		{
			get { return _currentContentHeight; }
			private set
			{
				_currentContentHeight = value;
				OnPropertyChanged();
			}
		}

		public string HeaderText
		{
			get
			{
				return _headerText;
			}
			private set
			{
				_headerText = value;
				OnPropertyChanged();
			}
		}

		public bool IsExpanded
		{
			get
			{
				return _isExpanded;
			}
			private set
			{
				_isExpanded = value;
				OnPropertyChanged();
			}
		}

		public string IconText
		{
			get { return _currentIconButtonText; }
			private set
			{
				_currentIconButtonText = value;
				OnPropertyChanged();
			}
		}

		public Color HeaderBackGroundColor { get; private set; }

		public Color HeaderTextColor { get; private set; }

		public Color LineColor { get; private set; }


		public ICommand ExpandContractAccordion
		{
			get
			{
				return new Command(async () =>
				{
					//The values here are counter-intuitive
					if (IsExpanded)
					{
						IsExpanded = false;
						IconText = _iconExpandButtonText;
						ContentHeight = 0;
					}
					else
					{
						IsExpanded = true;
						IconText = _iconContractButtonText;
						ContentHeight = _expandedContentHeight;
					}
				});
			}
		}
	}

}

