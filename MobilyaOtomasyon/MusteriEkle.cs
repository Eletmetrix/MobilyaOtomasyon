using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobilyaOtomasyon
{
    public partial class MusteriEkle : BosSayfa
    {
        // Eğer halihazırda düzenlenen bir değer varsa o değerin ID'si buraya düşecektir.
        private string TutulanID = "-1";

        public MusteriEkle(AnaForm Parent) : base(Parent)
        {
            InitializeComponent();
        }

        // Form kapanırken eğer düzenleme modu varsa, düzenleme modunu iptal ediyoruz.
        public override void SayfaKapandi()
        {
            TutulanID = "-1";
            IptalBtn.Enabled = IptalBtn.Visible = false;
            EkleBtn.Text = "Ekle";

            IsimTxtBox.ResetText();
            SoyisimTxtBox.ResetText();
            TelNoTxtBox.ResetText();
        }

        // Veritabanına verileri işler
        private async void EkleBtn_Click(object sender, EventArgs e)
        {
            bool basarili = false;
            bool duzenleme = false;

            if (TutulanID == "-1")
            {
                basarili = await GlobalDatabaseActions.MusteriEkle(IsimTxtBox.Text, SoyisimTxtBox.Text, TelNoTxtBox.Text);
            }
            else
            {
                basarili = await GlobalDatabaseActions.MusteriDuzenle(TutulanID, IsimTxtBox.Text, SoyisimTxtBox.Text, TelNoTxtBox.Text);
                duzenleme = true;
            }

            string icerik = basarili ? "Müşteri bilgisi kaydedildi!" : "İşlem başarısız oldu. Lütfen bilgileri kontrol ediniz";
            string baslik = basarili ? "Başarılı" : "Başarısız";
            MessageBoxIcon ikon = basarili ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show(icerik, baslik, MessageBoxButtons.OK, ikon);

            IsimTxtBox.ResetText();
            SoyisimTxtBox.ResetText();
            TelNoTxtBox.ResetText();

            TutulanID = "-1";
            IptalBtn.Enabled = IptalBtn.Visible = false;
            EkleBtn.Text = "Ekle";
        }

        // Düzenleme modundan çıkar
        private void IptalBtn_Click(object sender, EventArgs e)
        {
            // Müşteri bilgilerine geri dönüyoruz.
            if (UstForm != null)
            {
                UstForm.SimulateButtonClick(3);
            }
        }

        // Müşteri verilerini güncellemek içn bu fonksiyon kullanılır.
        public void MusteriDuzenle(string? id, string? ad, string? soyad, string? telno)
        {
            if (id != null && ad != null && soyad != null && telno != null && UstForm != null)
            {
                // Verileri işliyoruz.
                TutulanID = id;
                IsimTxtBox.Text = ad;
                SoyisimTxtBox.Text = soyad;
                TelNoTxtBox.Text = telno;

                // Ana formumuzdan bu formun açılması için butonları simulate ediyoruz.
                UstForm.SimulateButtonClick(1);

                // Düzenleme modu aktif. O halde iptal tuşumuzu da aktifleştiriyoruz.
                IptalBtn.Enabled = IptalBtn.Visible = true;
                EkleBtn.Text = "Düzenle";
            }
        }
    }
}
