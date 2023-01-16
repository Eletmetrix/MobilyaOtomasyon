﻿using System;
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
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            // Global database sınıfından değerleri alıp ana formumuza iliştiriyoruz
            ToplamMusteriLbl.Text = GlobalDatabaseActions.ToplamMusteri.ToString();
            ToplamAktifSiparisLbl.Text = GlobalDatabaseActions.ToplamBekleyenSiparis.ToString();
        }
    }
}
