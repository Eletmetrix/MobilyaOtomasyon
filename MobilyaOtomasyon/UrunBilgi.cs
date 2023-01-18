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
    public partial class UrunBilgi : BosSayfa
    {
        // Ürünün ID bilgisi
        public string? UrunID { get; set; } = "-1";
        private bool TeslimEdildi = false;

        public UrunBilgi(AnaForm Parent) : base(Parent)
        {
            InitializeComponent();
        }

        public override async void SayfaAcildi()
        {
            if (UrunID != null && UrunID != "-1")
            {
                UrunBilgisi? urunBilgi = await GlobalDatabaseActions.UrunBilgisiGetir(UrunID);

                if (urunBilgi != null)
                {
                    UrunIsimLbl.Text = "Ürün İsmi: " + urunBilgi.UrunAdi;
                    SiparisTarihLbl.Text = "Sipariş Tarihi: " + urunBilgi.GirisTarihi.ToString("dd-MM-yyyy");
                    TeslimTarihLbl.Text = "Teslim Tarihi: " + (urunBilgi.TeslimEdildi ? urunBilgi.TeslimTarihi.GetValueOrDefault().ToString("dd-MM-yyyy") : "TESLİM EDİLMEDİ");
                    AdresLbl.Text = "Adres: " + urunBilgi.Adres;

                    EbatListesi.DataSource = urunBilgi.Ebatlar;

                    TeslimEdildiBtn.Text = urunBilgi.TeslimEdildi ? "Teslim Edildi İşaretini Kaldır" : "Teslim Edildi Olarak İşaretle";
                    TeslimEdildi = urunBilgi.TeslimEdildi;

                    return;
                }
            }

            if (UstForm != null)
            {
                UstForm.ShowFormInPanel("Ana Sayfa");
            }
        }

        public override void SayfaKapandi()
        {
            UrunID = "-1";
        }

        private async void TeslimEdildiBtn_Click(object sender, EventArgs e)
        {
            bool basarili = false;

            basarili = await GlobalDatabaseActions.UrununIsaretiDegistir(UrunID, !TeslimEdildi);

            string icerik = basarili ? "Ürün bilgisi değiştirildi!" : "İşlem başarısız oldu. Lütfen bilgileri kontrol ediniz";
            string baslik = basarili ? "Başarılı" : "Başarısız";
            MessageBoxIcon ikon = basarili ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show(icerik, baslik, MessageBoxButtons.OK, ikon);

            SayfaAcildi();
        }
    }
}
