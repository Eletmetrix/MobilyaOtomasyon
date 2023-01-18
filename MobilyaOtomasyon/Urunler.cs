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

        private async void SilBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                await GlobalDatabaseActions.UrunSil(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                dataGridView1.DataSource = await GlobalDatabaseActions.UrunleriCagir();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && UstForm != null && UstForm.FrmList.ContainsKey("Ürün Detayları") && UstForm.FrmList["Ürün Detayları"] != null && UstForm.FrmList["Ürün Detayları"] is UrunBilgi)
            {
                ((UrunBilgi)UstForm.FrmList["Ürün Detayları"]).UrunID = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString();
                UstForm.ShowFormInPanel("Ürün Detayları");
            }
        }
    }
}
