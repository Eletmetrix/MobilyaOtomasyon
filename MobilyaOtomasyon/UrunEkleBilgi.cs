using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobilyaOtomasyon
{
    public partial class UrunEkleBilgi : BosSayfa
    {
        // İlişkili müşterinin ID'sini tutar
        private string TutulanMusteriID = "-1";

        // Ebatların bilgisi
        private BindingList<EbatBilgi> Ebatlar = new BindingList<EbatBilgi>();

        public UrunEkleBilgi(AnaForm Parent) : base(Parent)
        {
            InitializeComponent();

            // BindingList değişkenimizi listbox'un datasource'una atayarak referans vermiş oluyoruz.
            // Böylece Ebatlar değişkeninde yaptığımız her değişiklik, listbox'umuza da geçecek.
            EbatListesi.DataSource = Ebatlar;
        }

        // Belirli bir müşterinin bilgilerini gereken yerlere iliştirir. Sayfanın açılmasından önce çalıştırılması önemlidir
        public void UrunEkle(string? id, string? advesoyad)
        {
            if (id != null && advesoyad != null && UstForm != null)
            {
                TutulanMusteriID = id;
                IsimTxtBox.Text = advesoyad;
            }
        }

        private void EbatCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EbatCmbBox.SelectedIndex == 4)
            {
                EbatIsimTxtBox.ReadOnly = false;
                EbatIsimTxtBox.Text = "";
            }
            else if (EbatCmbBox.SelectedIndex != -1) 
            {
                EbatIsimTxtBox.Text = (string)EbatCmbBox.SelectedItem;
                EbatIsimTxtBox.ReadOnly = true;
            }
            else
            {
                EbatIsimTxtBox.Text = "";
                EbatIsimTxtBox.ReadOnly = true;
            }
        }

        private void SantimChckBx_CheckedChanged(object sender, EventArgs e)
        {
            EbatLbl.Text = "Ebat Uzunluğu (" + (SantimChckBx.Checked ? "m" : "cm") + ")";
        }

        private void EkleBtn_Click(object sender, EventArgs e)
        {
            if (EbatTxtBox.Text != "" && EbatIsimTxtBox.Text != "")
            {
                Ebatlar.Add(new EbatBilgi(EbatIsimTxtBox.Text, EbatTxtBox.Text.Trim(), SantimChckBx.Checked));
                EbatTxtBox.ResetText();
                EbatIsimTxtBox.ResetText();
                EbatCmbBox.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Lütfen bilgileri eksiksiz doldurunuz!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SilBtn.Enabled = (EbatListesi.SelectedIndex != -1);
        }

        private void SilBtn_Click(object sender, EventArgs e)
        {
            if (EbatListesi.SelectedIndex != -1)
            {
                Ebatlar.RemoveAt(EbatListesi.SelectedIndex);
            }
        }

        private async void UrunEkleBtn_Click(object sender, EventArgs e)
        {
            if (TutulanMusteriID != "-1" && UrunİsimTxtBox.Text != "" && AdresTxtBox.Text != "" && EbatListesi.Items.Count > 0)
            {
                bool basarili = false;

                basarili = await GlobalDatabaseActions.UrunEkle(TutulanMusteriID, UrunİsimTxtBox.Text, AdresTxtBox.Text, Ebatlar.ToList());

                string icerik = basarili ? "Ürün bilgisi kaydedildi!" : "İşlem başarısız oldu. Lütfen bilgileri kontrol ediniz";
                string baslik = basarili ? "Başarılı" : "Başarısız";
                MessageBoxIcon ikon = basarili ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                MessageBox.Show(icerik, baslik, MessageBoxButtons.OK, ikon);

                IsimTxtBox.ResetText();
                UrunİsimTxtBox.ResetText();
                AdresTxtBox.ResetText();
                EbatTxtBox.ResetText();
                EbatIsimTxtBox.ResetText();
                EbatCmbBox.SelectedIndex = -1;
                Ebatlar.Clear();

                TutulanMusteriID = "-1";
                UrunEkleBtn.Text = "Ürün Ekle";

                UstForm.SimulateButtonClick(4);
            }
        }
    }

    public class EbatBilgi
    {
        public string EbatIsmi { get; private set; } = "";
        public string EbatDegeri { get; private set; } = "";
        public bool EbatTuruMetre { get; private set; } = false;

        public EbatBilgi(string _EbatIsmi, string _EbatDegeri, bool _EbatTuruMetre) 
        {
            EbatIsmi = _EbatIsmi;
            EbatDegeri = _EbatDegeri;
            EbatTuruMetre = _EbatTuruMetre;
        }

        public override string ToString()
        {
            return EbatIsmi + ": " + EbatDegeri + " " + (EbatTuruMetre ? "m" : "cm");
        }
    }
}
