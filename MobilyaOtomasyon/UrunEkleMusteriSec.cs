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
    public partial class UrunEkleMusteriSec : BosSayfa
    {
        public UrunEkleMusteriSec(AnaForm Parent) : base(Parent)
        {
            InitializeComponent();
        }

        public override async void SayfaAcildi()
        {
            dataGridView1.DataSource = await GlobalDatabaseActions.MusterileriCagir();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string key = "Ürün Ekle (Aşama 2)";
            if (UstForm != null && UstForm.FrmList.ContainsKey(key) && UstForm.FrmList[key] != null && UstForm.FrmList[key] is UrunEkleBilgi)
            {
                string? id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string? ad = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string? soyad = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string? telno = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                
                ((UrunEkleBilgi)UstForm.FrmList[key]).UrunEkle(id, ad + " " + soyad);
                UstForm.ShowFormInPanel(key);
            }
        }
    }
}
