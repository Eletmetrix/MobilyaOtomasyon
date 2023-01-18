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

        // Müşteri bilgilerini düzenler
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

        // Müşterileri çağırır
        public static async Task<DataTable> MusterileriCagir()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\VisualStudioProjects\MobilyaOtomasyon\MobilyaOtomasyon\Veritabani.mdf; Integrated Security = True"))
            {
                await con.OpenAsync();
                using (SqlDataAdapter reader = new SqlDataAdapter("SELECT MusteriID as ID, Ad, Soyad, TelefonNum as 'Telefon Numarası' FROM Musteri", con))
                {
                    var dt = new DataTable();
                    reader.Fill(dt);
                    return dt;
                }
            }
        }

        // Ürün ve ebat bilgilerini ekler
        public static async Task<bool> UrunEkle(string? MusteriID, string? Urunİsmi, string? Adres, List<EbatBilgi>? Ebatlar)
        {
            if (!StrKontrol(MusteriID, -1) || !StrKontrol(Urunİsmi, 50) || !StrKontrol(Adres, 100) || Ebatlar == null || Ebatlar.Count <= 0)
            {
                // Değerler uygunsuz.
                return false;
            }
            else
            {
                using (SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\VisualStudioProjects\MobilyaOtomasyon\MobilyaOtomasyon\Veritabani.mdf; Integrated Security = True"))
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Urun (MusteriId, UrunAdi, Adres) VALUES (@mid, @urunisim, @adres); SELECT SCOPE_IDENTITY();", con))
                    {
                        cmd.Parameters.Add("@mid", SqlDbType.Int).Value = MusteriID;
                        cmd.Parameters.Add("@urunisim", SqlDbType.NVarChar).Value = Urunİsmi;
                        cmd.Parameters.Add("@adres", SqlDbType.NVarChar).Value = Adres;
                        cmd.CommandType = CommandType.Text;
                        decimal UrunID = -1;
                        UrunID = (decimal)await cmd.ExecuteScalarAsync();

                        if (UrunID == -1)
                        {
                            // Veri işlenemedi.
                            return false;
                        }

                        foreach (var item in Ebatlar)
                        {
                            using (SqlCommand cmd1 = new SqlCommand("INSERT INTO Ebatlar (UrunID, EbatIsim, EbatDeger, EbatTur) VALUES (@uid, @ebatisim, @ebatdeger, @ebattur)", con))
                            {
                                cmd1.Parameters.Add("@uid", SqlDbType.Int).Value = UrunID;
                                cmd1.Parameters.Add("@ebatisim", SqlDbType.NVarChar).Value = item.EbatIsmi;
                                cmd1.Parameters.Add("@ebatdeger", SqlDbType.NVarChar).Value = item.EbatDegeri;
                                cmd1.Parameters.Add("@ebattur", SqlDbType.Bit).Value = item.EbatTuruMetre;
                                cmd1.CommandType = CommandType.Text;
                                await cmd1.ExecuteNonQueryAsync();
                            }
                        }

                        return true;
                    }
                }
            }
        }

        // Ürünleri çağırır
        public static async Task<DataTable> UrunleriCagir()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\VisualStudioProjects\MobilyaOtomasyon\MobilyaOtomasyon\Veritabani.mdf; Integrated Security = True"))
            {
                await con.OpenAsync();
                using (SqlDataAdapter reader = new SqlDataAdapter("SELECT " +
                    "Urun.UrunAdi as 'Ürün Adı', " +
                    "Urun.GirisTarihi as 'Giriş Tarihi', " +
                    "Urun.TeslimTarihi as 'Teslim Tarihi', " +
                    "Urun.TeslimEdildi as 'Teslim Edildi?', " +
                    "Urun.Adres, " +
                    "Musteri.Ad as 'Müşteri Adı', " +
                    "Musteri.Soyad as 'Müşteri Soyadı', " +
                    "Musteri.TelefonNum as 'Müşteri Telefon Numarası' " +
                    "FROM Urun JOIN Musteri ON Musteri.MusteriId = Urun.MusteriId", con)) //"SELECT Urun.UrunAdi as 'Ürün Adı', Urun.TeslimEdildi as 'Teslim Edildi?', Urun.GirisTarihi as 'Giriş Tarihi', Urun.TeslimTarihi as 'Teslim Tarihi', Urun.Adres, Ebatlar.EbatId as 'Ebat Miktarı', Musteri.Ad as 'Müşteri Adı', Musteri.Soyad as 'Müşteri Soyadı' FROM Musteri JOIN Urun ON Musteri.MusteriId = Urun.MusteriId JOIN Ebatlar ON Urun.UrunId = Ebatlar.UrunId"
                {
                    var dt = new DataTable();
                    reader.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
