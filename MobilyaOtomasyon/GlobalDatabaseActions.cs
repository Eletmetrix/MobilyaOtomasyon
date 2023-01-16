using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MobilyaOtomasyon
{
    static class GlobalDatabaseActions
    {
        // Toplam müşteri sayısı
        public static int ToplamMusteri { get; private set; } = -1;
        // Toplam bekleyen sipariş
        public static int ToplamBekleyenSiparis { get; private set; } = -1;

        // Program ilk oluşturulduğunda bu fonksiyon çalışarak gereken değer atamalarını yapar.
        public static void Baslatici()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\VisualStudioProjects\MobilyaOtomasyon\MobilyaOtomasyon\Veritabani.mdf; Integrated Security = True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Musteri", con))
                {
                    ToplamMusteri = (int)cmd.ExecuteScalar();
                }
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Urun WHERE TeslimEdildi = 0", con))
                {
                    ToplamBekleyenSiparis = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
