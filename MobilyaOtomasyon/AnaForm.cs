using System.Windows.Forms;

namespace MobilyaOtomasyon
{
    public partial class AnaForm : Form
    {
        protected Dictionary<string, Form> FrmList;
        protected string SuAnkiForm;

        public AnaForm()
        {
            InitializeComponent();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            // Deðerlerin oluþumu için bu fonksiyonu çaðýrýyoruz
            GlobalDatabaseActions.Baslatici();

            // Panel butonlarýndaki yazýdan formlarý bulabilmek için bu listeyi oluþturuyoruz
            FrmList = new Dictionary<string, Form> {
                { "Ana Sayfa", new AnaSayfa() }
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
            AnaSayfaBtn.PerformClick();
        }

        // BURADA DRAG&DROP ÝÞLEMLERÝNE BAÞLIYORUZ
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

        // BURADA DRAG&DROP ÝÞLEMLERÝ BÝTÝYOR

        // Tüm paneldeki butonlar bu fonksiyondan geçiyor
        private void PanelButtonsClick(object sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn != null && FrmList.ContainsKey(btn.Text))
            {
                foreach (var item in FormPanel.Controls)
                {
                    Form? frm = item as Form;
                    if (frm != null)
                    {
                        frm.Hide();
                    }
                }

                Form form = FrmList[btn.Text];
                form.Show();

                AnaLabel.Text = btn.Text;
            }
        }

        // Programý kapatýr
        private void KapatBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}