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
        public MusteriEkle(AnaForm Parent) : base(Parent)
        {
            InitializeComponent();
        }

        // Form kapanırken eğer düzenleme modu varsa, düzenleme modunu iptal ediyoruz.
        public override void SayfaKapandi()
        {
            IsimTxtBox.ResetText();
            SoyisimTxtBox.ResetText();
            TelNoTxtBox.ResetText();
        }

        // Veritabanına verileri işler
        private async void EkleBtn_Click(object sender, EventArgs e)
        {
            bool basarili = await GlobalDatabaseActions.MusteriEkle(IsimTxtBox.Text, SoyisimTxtBox.Text, TelNoTxtBox.Text);

            string icerik = basarili ? "Müşteri bilgisi kaydedildi!" : "İşlem başarısız oldu. Lütfen bilgileri kontrol ediniz";
            string baslik = basarili ? "Başarılı" : "Başarısız";
            MessageBoxIcon ikon = basarili ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show(icerik, baslik, MessageBoxButtons.OK, ikon);

            UstForm.SimulateButtonClick(3);
        }
    }
}
