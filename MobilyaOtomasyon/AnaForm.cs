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

        // Panel butonlar�n�n t�klanmas�n� simulate eder (e�er verilen de�er ge�erliyse).
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
            // Panel butonlar�ndaki yaz�dan formlar� bulabilmek i�in bu listeyi olu�turuyoruz
            FrmList = new Dictionary<string, BosSayfa> {
                { "Ana Sayfa", new AnaSayfa(this) },
                { "M��teri Ekle", new MusteriEkle(this) },
                { "M��teri Bilgisi", new Musteriler(this) },
                { "M��teri D�zenle", new MusteriDuzenle(this) },
                { "�r�n Ekle", new UrunEkleMusteriSec(this) },
                { "�r�n Ekle (A�ama 2)", new UrunEkleBilgi(this) },
                { "�r�n Bilgisi", new Urunler(this) }
            };


            // Dictionary'deki t�m formlar� panele ekliyoruz
            foreach (var item in FrmList.Values)
            {
                item.TopLevel = false;
                item.AutoScroll = false;
                FormPanel.Controls.Add(item);
                item.Hide();
            }

            // Ana sayfan�n a��lmas�n� istedi�imiz i�in ana sayfa butonunun click event'ini simulate edece�iz
            SimulateButtonClick(0);
        }

        #region DRAG & DROP ��LEMLER�
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        // DllImport sayesinde windows'un i�inde gelen user32.dll dosyas�ndan belirli fonksiyonlar� �a��rabiliyoruz.
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Panele t�kland���nda
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // T�klama tu�u LMB (Left Mouse Button) ise
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        // T�m paneldeki butonlar bu fonksiyondan ge�iyor
        private void PanelButtonsClick(object sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn != null)
            {
                ShowFormInPanel(btn.Text);
            }
        }

        // E�er verilen key de�erine uygun form mevcut ise onu g�sterir
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

        // Program� kapat�r
        private void KapatBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}