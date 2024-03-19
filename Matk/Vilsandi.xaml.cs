using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Matk
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Vilsandi : ContentPage
	{
		public Vilsandi ()
		{
            InitializeComponent();
            Grid grd = new Grid
			{
				RowDefinitions =
				{
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(3, GridUnitType.Star) }
				},
				ColumnDefinitions =
				{
					new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)}
				}
            };
			Label nimetus = new Label { Text = "Vilsandi matkarada", FontSize = 30 };
			Image img = new Image { Source = "jaanuar.jpg" };
			Label kirjeldus = new Label { Text = "Matkarada" };
			grd.Children.Add(nimetus,0,0);
			grd.Children.Add(img,0,1);
			grd.Children.Add(kirjeldus,0,2);
			Content= grd;
		}
	}
}