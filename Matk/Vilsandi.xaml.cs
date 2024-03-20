using System;
using System.Collections.Generic;
using System.IO;
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
			Title = "Vilsandi";
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
			ImageButton img = new ImageButton {
                BackgroundColor = Color.Transparent,
                HeightRequest = 200,
                WidthRequest = 200,
                Source = ImageSource.FromStream(() => new MemoryStream(Properties.Resources.vilsandi))
			};
			img.Clicked += imgClicked;
			Label kirjeldus = new Label { Text = "Vilsandi saare keskelt vaatetorni alt Bioloogiajaama lähedusest saavad alguse 2 matkarada, pikkustega 6 km ja 8 km." };
			grd.Children.Add(nimetus,0,0);
			grd.Children.Add(img,0,1);
			grd.Children.Add(kirjeldus,0,2);
			Content= grd;
		}

        private void imgClicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.loodusegakoos.ee/kuhuminna/rahvuspargid/vilsandi-rahvuspark/9264"));
        }
    }

}