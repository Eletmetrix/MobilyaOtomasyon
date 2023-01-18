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
    public partial class Urunler : BosSayfa
    {
        public Urunler(AnaForm Parent) : base(Parent)
        {
            InitializeComponent();
        }

        public override async void SayfaAcildi()
        {
            dataGridView1.DataSource = await GlobalDatabaseActions.UrunleriCagir();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (UstForm != null && UstForm.FrmList.ContainsKey("Müşteri Ekle") && UstForm.FrmList["Müşteri Ekle"] != null && UstForm.FrmList["Müşteri Ekle"] is MusteriEkle)
            {
                string? id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string? ad = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string? soyad = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string? telno = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                
                ((MusteriEkle)UstForm.FrmList["Müşteri Ekle"]).MusteriDuzenle(id, ad, soyad, telno);
            }*/
        }
    }
}
