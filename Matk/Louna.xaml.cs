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
    public partial class Louna : TabbedPage
    {
        public Louna()
        {
            InitializeComponent();
            BarBackgroundColor = Color.FromHex("#196b00");
            LooLeht("Rõuge ürgoru", "Rõuge ürgoru matkarada (10 km)", "Edasi-tagasi liikumissuunaga  (üks suund 10 km, kokku 20 km) matkarada laskub kiige juurest Rõuge ürgorgu, möödub pisikesest tiigist ja kulgeb mööda allikaterikast oru nõlva. Liinjärve kaldal töötavad kaks vesioinast. Vesioinas on „igiliikurist\" pump, mis kasutab vaid vee-energiat ja on võimeline vett pumpama kümnete meetrite kõrgusele. Rada kulgeb edasi mööda külateed Liinjärve ja Valgjärve vahelt läbi ning pakub vaateid Ööbikuoru ja Linnamäe suunas. Edasi kulgeb rada mööda Rõuge Suurjärve – Eesti sügavaima järve edelakallast. Seejärel kulgeb piki järvedeahelat (Ratasjärv, Tõugjärv, Kahrila järv) Hinni kanjonini. See rajalõik võib olla kohati kitsas ja raskesti läbitav.", Properties.Resources.rouge, "https://www.loodusegakoos.ee/kuhuminna/kaitsealad/haanja-looduspark/1218");
            LooLeht("Kütioru", "Kütioru matkarada (9,6 km)", "9,6 km pikkune rada algab Kütioru mäesuusakeskuse lähedal olevast parklast, on varustatud suunaviitadega. Rada on väga vaheldusrikas, maastik küllaltki järsk ja raske. Seetõttu tuleks raja läbimiseks varuda neli-viis tundi. Rada on väljatöötatud nii, et matkaja saab parima ülevaate Eesti suurimast ja võimsamast ürgorust – Kütiorust, tutvub vanade veskikohtadega ja teiste pärandkultuuriobjektidega. Kütioru nõlvadel metsas on enam kui sajandivanuseid kuusikuid ning haruldaselt jämedad ja kõrged haavapuud.", Properties.Resources.kytioru, "https://www.loodusegakoos.ee/kuhuminna/kaitsealad/haanja-looduspark/1216");
            LooLeht("Kiidjärve-Taevaskoja-Kiidjärve", "Kiidjärve-Taevaskoja-Kiidjärve matkarada (11,8 km)", "Kiidjärve külastuskeskuse juurest algav 11,8 km pikkune matkarada kulgeb maalilise Ahja jõe kallastel, kust on hästi vaadeldavad erinevad liivakivipaed (Sõnajalamägi, Palanumägi, Oosemägi, Laaritsamägi, Mõsumägi jne). Rada kulgeb ühte kallast mööda Saesaare paisuni, sealt üle silla ning teist kallast mööda tagasi. Rajale jääb Sõnajala lõkkekoht, kus on lubatud ka telkida.\r\nMistahes sõidukiga rajal liiklemine keelatud!", Properties.Resources.taevaskoja, "https://www.loodusegakoos.ee/kuhuminna/puhkealad/kiidjarve-kooraste-puhkeala/kiidjarve-taevaskoja-kiidjarve-matkarada");
            LooLeht("Karula pikk", "Karula pikk jalgsimatkarada (36 km)", "Rada asub Karula rahvuspargi territooriumil, rajal kindlat algus- ega lõpp-punkti ei ole. Rada kulgeb ringikujuliselt ja on viidastatud nii, et on võimalik liikuda mõlemas suunas, aga soovitav liikumissuund on siiski vastupäeva. Tähistatud on rada kollaste värvimärkidega puudel, postidel olevate plastikust matkaja piktogrammidega ja suuremate teede ääres plekist suunaviitadega.", Properties.Resources.karula, "https://www.loodusegakoos.ee/kuhuminna/rahvuspargid/karula-rahvuspark/1311");
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