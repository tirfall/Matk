using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Matk
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Saared : TabbedPage
    {
        public Saared()
        {
            InitializeComponent();
            BarBackgroundColor = Color.FromHex("#196b00");
            LooLeht("Vilsandi", "Vilsandi matkarada", "Vilsandi saare keskelt vaatetorni alt Bioloogiajaama lähedusest saavad alguse 2 matkarada, pikkustega 6 km ja 8 km.", Properties.Resources.vilsandi, "https://www.loodusegakoos.ee/kuhuminna/rahvuspargid/vilsandi-rahvuspark/9264");
            LooLeht("HariLaiu", "Harilaiu matkarada (6 km või 11 km)", "Mitmekesine inimtühi rannikuloodus. Madal silmapiir, avar vaade, tuul, kuldne rannaliiv ja suured lained. Huvitav maastik luidetel, tuultele allutatud puud ja põõsad. Klibuvallid, linnu- ja hülgehääled. Militaarobjektid, Kiipsaare majakas meres. Ringjalt kulgev rada on märgistatud.", Properties.Resources.harilaiu, "https://www.loodusegakoos.ee/kuhuminna/rahvuspargid/vilsandi-rahvuspark/1329");
            LooLeht("Kärdla", "Kärdla matkarada (4 km)", "Kärdla lähiümbruse metsadesse loodud matkarada sobib nii puhkepäevaseks jalutuskäiguks kui ka looduse nautimiseks. Värvimärgiste ja suunaviitadega tähistatud rada kulgeb läbi mitmesuguste metsakoosluste ja ümber väikeste soolapikeste. Matkamiseks sobib igal aastaajal, kuid tuleb arvestada, et rajal on märjemaid ja vesiseid kohti. Kuival ja põuasel kevadel ning suvel läbitav kuiva jalaga, märjemal aastaajal tuleks rajale minnes jalga panna vettpidavad jalanõud. Kraavide ületamiseks on rajal 4 purret. Raja läbimiseks kulub rahulikus tempos umbes tund. ", Properties.Resources.kardla, "https://www.loodusegakoos.ee/kuhuminna/puhkealad/hiiumaa-puhkeala/1594");
            LooLeht("Heltermaa-Ristna-Sarve", "RMK matkatee Heltermaa-Ristna-Sarve/Kärdla-Ristna (107 km)", " Hiiumaa, Hiiumaa puhkeala RMK matkatee Hiiumaa haru II lõik algab Kärdla kesklinnast. Kui matkatee I lõik kulges peaasjalikult mööda küla- ja maanteid, siis selle lõigu ilme on aga hoopis teistsugune. Olles ühtekokku 107 km pikkune on see ka matkatee Hiiumaa haru kõige pikem lõik. Kärdla keskväljakult alates läheb matkatee mööda Tiigi tänavat, kuni jõuab linna servas oleva Kärdla matkarajani  ning läheb mööda seda linnast välja. Kärdla matkaraja ääres asub ka Autobaasi lõkkekoht. ", Properties.Resources.ristna, "https://www.loodusegakoos.ee/kuhuminna/puhkealad/hiiumaa-puhkeala/kardla-ristna-107-km");
        }

        private void LooLeht(string nimiTitle, string nimi, string kirjeldus1, byte[] image, string url)
        {
            ContentPage page = new ContentPage
            {
                Title = nimiTitle
            };

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

            Label nimetus = new Label { Text = nimi, FontSize = 30 };
            ImageButton img = new ImageButton
            {
                BackgroundColor = Color.Transparent,
                HeightRequest = 200,
                WidthRequest = 200,
                Source = ImageSource.FromStream(() => new MemoryStream(image))
            };
            img.Clicked += imgClicked;
            img.CommandParameter = url;
            Label kirjeldus = new Label { Text = kirjeldus1 };

            grd.Children.Add(nimetus, 0, 0);
            grd.Children.Add(img, 0, 1);
            grd.Children.Add(kirjeldus, 0, 2);

            page.Content = grd;
            Children.Add(page);
        }

        private void imgClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton imgButton && imgButton.CommandParameter is string url)
            {
                Device.OpenUri(new Uri(url));
            }
        }
    }
}