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

            // Panel butonlar�ndaki yaz�dan formlar� bulabilmek i�in bu listeyi olu�turuyoruz
            FrmList = new Dictionary<string, Form> {
                { "Ana Sayfa", new AnaSayfa() }
            };

            // Dictionary'deki t�m formlar� panele ekliyoruz
            foreach (var item in FrmList.Values)
            {
                item.TopLevel = false;
                item.AutoScroll = false;
                FormPanel.Controls.Add(item);
                item.Hide();
            }
        }

        // BURADA DRAG&DROP ��LEMLER�NE BA�LIYORUZ
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

        // BURADA DRAG&DROP ��LEMLER� B�T�YOR

        // T�m paneldeki butonlar bu fonksiyondan ge�iyor
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
            }
        }

        // Program� kapat�r
        private void KapatBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}