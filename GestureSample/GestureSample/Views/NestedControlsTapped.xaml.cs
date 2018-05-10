using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestureSample.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestureSample.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NestedControlsTapped : ContentPage
	{
		public NestedControlsTapped()
		{
			InitializeComponent();

			BindingContext = new CustomEventArgsViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			
		}

		void Button_OnClicked(object sender, EventArgs e)
		{
			for (int i = 0; i < 2; i++)
			{
				var lbl = new Label() { Text = "A new item!" };
				StackFirst.Children.Add(lbl);

				var entry = new Entry { Placeholder = "Enter something" };
				StackFirst.Children.Add(entry);

				var box = new BoxView { HeightRequest = 60,BackgroundColor = Color.Blue};
				StackFirst.Children.Add(box);

			}
		}
	}
}