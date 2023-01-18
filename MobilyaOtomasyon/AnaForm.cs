using System.Windows.Forms;

namespace MobilyaOtomasyon
{
    public partial class AnaForm : Form
    {
        public Dictionary<string, BosSayfa> FrmList { get; private set; } = new Dictionary<string, BosSayfa>();

        public AnaForm()
        {
            InitializeComponent();
        }

        // Panel butonlarýnýn týklanmasýný simulate eder (eðer verilen deðer geçerliyse).
        public void SimulateButtonClick(int ID)
        {
            switch (ID)
            {
                case 0: AnaSayfaBtn.PerformClick(); break;
                case 1: MusteriEkleBtn.PerformClick(); break;
                case 2: UrunEkleBtn.PerformClick(); break;
                case 3: MusteriBilgisiBtn.PerformClick(); break;
                case 4: UrunBilgisiBtn.PerformClick(); break;
            }
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            // Panel butonlarýndaki yazýdan formlarý bulabilmek için bu listeyi oluþturuyoruz
            FrmList = new Dictionary<string, BosSayfa> {
                { "Ana Sayfa", new AnaSayfa(this) },
                { "Müþteri Ekle", new MusteriEkle(this) },
                { "Müþteri Bilgisi", new Musteriler(this) },
                { "Müþteri Düzenle", new MusteriDuzenle(this) },
                { "Ürün Ekle", new UrunEkleMusteriSec(this) },
                { "Ürün Ekle (Aþama 2)", new UrunEkleBilgi(this) },
                { "Ürün Bilgisi", new Urunler(this) }
            };


            // Dictionary'deki tüm formlarý panele ekliyoruz
            foreach (var item in FrmList.Values)
            {
                item.TopLevel = false;
                item.AutoScroll = false;
                FormPanel.Controls.Add(item);
                item.Hide();
            }

            // Ana sayfanýn açýlmasýný istediðimiz için ana sayfa butonunun click event'ini simulate edeceðiz
            SimulateButtonClick(0);
        }

        #region DRAG & DROP ÝÞLEMLERÝ
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        // DllImport sayesinde windows'un içinde gelen user32.dll dosyasýndan belirli fonksiyonlarý çaðýrabiliyoruz.
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Panele týklandýðýnda
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // Týklama tuþu LMB (Left Mouse Button) ise
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        // Tüm paneldeki butonlar bu fonksiyondan geçiyor
        private void PanelButtonsClick(object sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn != null)
            {
                ShowFormInPanel(btn.Text);
            }
        }

        // Eðer verilen key deðerine uygun form mevcut ise onu gösterir
        public void ShowFormInPanel(string key)
        {
            if (FrmList.ContainsKey(key))
            {
                foreach (var item in FormPanel.Controls)
                {
                    BosSayfa? frm = item as BosSayfa;
                    if (frm != null && frm.Visible)
                    {
                        frm.Hide();
                        frm.SayfaKapandi();
                    }
                }

                BosSayfa form = FrmList[key];
                form.Show();
                form.SayfaAcildi();

                AnaLabel.Text = key;
            }
        }

        // Programý kapatýr
        private void KapatBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}