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
    public partial class Pohja : TabbedPage
    {
        public Pohja()
        {
            InitializeComponent();
            BarBackgroundColor = Color.FromHex("#196b00");
            LooLeht("Käsmu", "Käsmu matkarada (15 km)", "Matkarada teeb ringi ümber poolsaare, sellest 10 km otse piki mereäärt. Sobib neile, kellele meeldivad pikemad jalgsirännakud mere ja metsa piiril.", Properties.Resources.kasmu, "https://www.loodusegakoos.ee/kuhuminna/rahvuspargid/lahemaa-rahvuspark/11692");
            LooLeht("Poruni", "Poruni matkarada (5 km)", "Poruni 10 km (edasi-tagasi) pikk matkarada kulgeb piki Poruni jõe kallast Narva jõeni ja pöördub sealt lähtekohta tagasi. Raja äärde on paigutatud 12 infostendi, mis tutvustavad piirkonna loodust, lammimetsa, põliseid laialehelisi puistuid, juhivad tähelepanu jõe kallastel kohati paljanduvate geoloogilistele kihistutele, käsitlemata ei jää ka piirkonda iseloomustav militaarajalugu.\r\nPoruni matkarada on tähistatud siniste värvitud ristkülikutega puudel ja metall suunaviida postidega", Properties.Resources.poruni, "https://www.loodusegakoos.ee/kuhuminna/rahvuspargid/alutaguse-rahvuspark/1337");
            LooLeht("Järvi-Aegviidu", "Järvi-Aegviidu matkarada (27 km)", "Matkasellide seas juba tuttav Liiapeksi-Aegviidu matkarada pakub oma 27 km (endine 32 km) pikkuse ja mitme telkimisala ning lõkkekohtade matkavõimalusi 2-3 päevaks. Vahelduv ja kaunis maastik tasub kindlasti kogemist. Rada on märgistatud punaste värvitäppidega puudel, hargnemiskohtades viitadega. Rada kattub Oandu-Aegviidu-Ikla matkateega.", Properties.Resources.jarvi_aegviidu, "https://www.loodusegakoos.ee/kuhuminna/puhkealad/aegviidu-korvemaa-puhkeala/1552");
            LooLeht("Vihterpalu-Ohtu", "RMK matkatee Peraküla-Aegviidu-Ähijärve / Vihterpalu-Ohtu (46 km)", "Sellel lõigul kulgeb matkatee peamiselt mööda pinnas- ja kruusateid mõnusate männimetsade vahel. Teele jääb mitu huvitavat ja väga olulist vaatamisväärsust nagu Harju-Risti kirik, Padise klooster, Rummu karjäär ja Vasalemma loss.\r\nHarju-Ristil, Padisel ning Vasalemmas on poed, kus matkaline saab täiendada enda toidumoonavarusid.\r\nRada on tähistatud viitade ja valge-roheline-valge värvimärgistusega puudel.", Properties.Resources.harju, "https://www.loodusegakoos.ee/kuhuminna/puhkealad/tallinna-umbruse-puhkeala/rmk-perakula-aegviidu-ahijarve-matkatee-vihterpalu");
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