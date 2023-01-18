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
    }
}
