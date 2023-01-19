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
    public partial class Musteriler : BosSayfa
    {
        public Musteriler(AnaForm Parent) : base(Parent)
        {
            InitializeComponent();
        }

        public override async void SayfaAcildi()
        {
            dataGridView1.DataSource = await GlobalDatabaseActions.MusterileriCagir();
        }

        private void DuzenleBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && UstForm != null && UstForm.FrmList.ContainsKey("Müşteri Düzenle") && UstForm.FrmList["Müşteri Düzenle"] != null && UstForm.FrmList["Müşteri Düzenle"] is MusteriDuzenle)
            {
                string? id = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString();
                string? ad = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[1].Value.ToString();
                string? soyad = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[2].Value.ToString();
                string? telno = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[3].Value.ToString();

                ((MusteriDuzenle)UstForm.FrmList["Müşteri Düzenle"]).Duzenle(id, ad, soyad, telno);
            }
        }

        private async void SilBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                await GlobalDatabaseActions.MusteriSil(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                dataGridView1.DataSource = await GlobalDatabaseActions.MusterileriCagir();
            }
        }
    }
}
