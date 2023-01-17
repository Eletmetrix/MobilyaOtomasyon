using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

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

        // verilen string ifadenin null, boş veya değerden fazla uzun olması durumlarda false verir
        // aksi taktirde true verecektir
        public static bool StrKontrol(string? deger, int maksimum)
        {
            if (deger == null || deger == "" || maksimum >= 0 && deger.Count() > maksimum)
            {
                return false;
            }

            return true;
        }

        // Veritabanına müşteri ekler
        public static async Task<bool> MusteriEkle(string? isim, string? soyisim, string? telno)
        {
            if (!StrKontrol(isim, 50) || !StrKontrol(soyisim, 50) || !StrKontrol(telno, 11))
            {
                // Değerler uygunsuz.
                return false;
            }
            else
            {
                using (SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\VisualStudioProjects\MobilyaOtomasyon\MobilyaOtomasyon\Veritabani.mdf; Integrated Security = True"))
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Musteri (Ad, Soyad, TelefonNum) VALUES (@isim, @soyisim, @telno)", con))
                    {
                        cmd.Parameters.Add("@isim", SqlDbType.NVarChar).Value = isim;
                        cmd.Parameters.Add("@soyisim", SqlDbType.NVarChar).Value = soyisim;
                        cmd.Parameters.Add("@telno", SqlDbType.Char).Value = telno;
                        cmd.CommandType = CommandType.Text;
                        return await cmd.ExecuteNonQueryAsync() > 0;
                    }
                }
            }
        }

        public static async Task<bool> MusteriDuzenle(string? id, string? isim, string? soyisim, string? telno)
        {
            if (!StrKontrol(id, -1) || !StrKontrol(isim, 50) || !StrKontrol(soyisim, 50) || !StrKontrol(telno, 11))
            {
                // Değerler uygunsuz.
                return false;
            }
            else
            {
                using (SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\VisualStudioProjects\MobilyaOtomasyon\MobilyaOtomasyon\Veritabani.mdf; Integrated Security = True"))
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("UPDATE Musteri SET Ad = @isim, Soyad = @soyisim, TelefonNum = @telno WHERE MusteriID = @id", con))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        cmd.Parameters.Add("@isim", SqlDbType.NVarChar).Value = isim;
                        cmd.Parameters.Add("@soyisim", SqlDbType.NVarChar).Value = soyisim;
                        cmd.Parameters.Add("@telno", SqlDbType.Char).Value = telno;
                        cmd.CommandType = CommandType.Text;
                        return await cmd.ExecuteNonQueryAsync() > 0;
                    }
                }
            }
        }

        public static async Task<DataTable> MusterileriCagir()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\VisualStudioProjects\MobilyaOtomasyon\MobilyaOtomasyon\Veritabani.mdf; Integrated Security = True"))
            {
                await con.OpenAsync();
                using (SqlDataAdapter reader = new SqlDataAdapter("SELECT * FROM Musteri", con))
                {
                    var dt = new DataTable();
                    reader.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
