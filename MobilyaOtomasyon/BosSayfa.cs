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
    public partial class BosSayfa : Form
    {
        protected AnaForm UstForm = null;

        public BosSayfa()
        {
            InitializeComponent();
        }

        public BosSayfa(AnaForm Parent)
        {
            InitializeComponent();

            UstForm = Parent;
        }

        public virtual void SayfaAcildi()
        {
            // Burası, sayfanın açılmasında çalışacak.
        }

        public virtual void SayfaKapandi()
        {
            // Burası, sayfanın kapanmasında çalışacak.
        }
    }
}
