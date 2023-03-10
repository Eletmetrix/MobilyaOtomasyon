using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;
using static MobilyaOtomasyon.UrunBilgi;
using System.ComponentModel;
using System.Reflection;

namespace MobilyaOtomasyon
{
    static class GlobalDatabaseActions
    {
        // Toplam müşteri sayısı
        public static int ToplamMusteri { get; private set; } = -1;
        // Toplam bekleyen sipariş
        public static int ToplamBekleyenSiparis { get; private set; } = -1;
        // Connection string
        private static string ConnectionStr { get; } = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MobilyaOtomasyon", "Database.mdf") + ";Integrated Security=True;Connect Timeout=30";



        // Program ilk oluşturulduğunda bu fonksiyon çalışarak gereken değer atamalarını yapar.
        public static void Baslatici()
        {
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MobilyaOtomasyon")))
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MobilyaOtomasyon")); 
            }
            if (!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MobilyaOtomasyon", "Database.mdf")))
            {
                File.Copy(Path.Combine(Directory.GetCurrentDirectory(), "Database.mdf"), Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MobilyaOtomasyon", "Database.mdf"));
            }

            using (SqlConnection con = new SqlConnection(ConnectionStr))
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
                using (SqlConnection con = new SqlConnection(ConnectionStr))
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
                using (SqlConnection con = new SqlConnection(ConnectionStr))
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
            using (SqlConnection con = new SqlConnection(ConnectionStr))
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

        // Müşteriyi siler
        public static async Task<bool> MusteriSil(string? ID)
        {
            if (!StrKontrol(ID, -1))
            {
                // Değerler uygunsuzdu
                return false;
            }
            else
            {
                using (SqlConnection con = new SqlConnection(ConnectionStr))
                {
                    await con.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SELECT " +
                        "Musteri.MusteriId as m, Urun.UrunId as u, Ebatlar.EbatId as e " +
                        "FROM " +
                        "Musteri " +
                        "LEFT JOIN Urun ON Urun.MusteriId = Musteri.MusteriId " +
                        "LEFT JOIN Ebatlar ON Ebatlar.UrunId = Urun.UrunId " +
                        "WHERE " +
                        "Musteri.MusteriId = @mid;", con))
                    {
                        cmd.Parameters.Add("@mid", SqlDbType.Int).Value = ID;

                        List<HashSet<int>> IDs = new List<HashSet<int>>
                        {
                            new HashSet<int>(),
                            new HashSet<int>(),
                            new HashSet<int>()
                        };
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                if (!reader.IsDBNull("m"))
                                    IDs[0].Add(reader.GetInt32("m"));
                                if (!reader.IsDBNull("u"))
                                    IDs[1].Add(reader.GetInt32("u"));
                                if (!reader.IsDBNull("e"))
                                    IDs[2].Add(reader.GetInt32("e"));
                            }
                        }
                        if (IDs[2].Count > 0)
                        {
                            using (SqlCommand cmd1 = new SqlCommand("DELETE FROM Ebatlar WHERE EbatId IN (" + string.Join(", ", IDs[2]) + ")", con))
                            {
                                await cmd1.ExecuteNonQueryAsync();
                            }
                        }
                        if (IDs[1].Count > 0)
                        {
                            using (SqlCommand cmd1 = new SqlCommand("DELETE FROM Urun WHERE UrunId IN (" + string.Join(", ", IDs[1]) + ")", con))
                            {
                                await cmd1.ExecuteNonQueryAsync();
                            }
                        }
                        if (IDs[0].Count > 0)
                        {
                            using (SqlCommand cmd1 = new SqlCommand("DELETE FROM Musteri WHERE MusteriId IN (" + string.Join(", ", IDs[0]) + ")", con))
                            {
                                await cmd1.ExecuteNonQueryAsync();
                            }
                        }

                        return true;
                    }
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
                using (SqlConnection con = new SqlConnection(ConnectionStr))
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
            using (SqlConnection con = new SqlConnection(ConnectionStr))
            {
                await con.OpenAsync();
                using (SqlDataAdapter reader = new SqlDataAdapter("SELECT " +
                    "Urun.UrunId as 'ID', " +
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

        // Ürünü siler
        public static async Task<bool> UrunSil(string? ID)
        {
            if (!StrKontrol(ID, -1))
            {
                // Değerler uygunsuzdu
                return false;
            }
            else
            {
                using (SqlConnection con = new SqlConnection(ConnectionStr))
                {
                    await con.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SELECT " +
                        "Urun.UrunId as u, Ebatlar.EbatId as e " +
                        "FROM " +
                        "Urun " +
                        "LEFT JOIN Ebatlar ON Ebatlar.UrunId = Urun.UrunId " +
                        "WHERE " +
                        "Urun.UrunId = @uid;", con))
                    {
                        cmd.Parameters.Add("@uid", SqlDbType.Int).Value = ID;

                        List<HashSet<int>> IDs = new List<HashSet<int>>
                        {
                            new HashSet<int>(),
                            new HashSet<int>()
                        };
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                if (!reader.IsDBNull("u"))
                                    IDs[0].Add(reader.GetInt32("u"));
                                if (!reader.IsDBNull("e"))
                                    IDs[1].Add(reader.GetInt32("e"));
                            }
                        }
                        if (IDs[1].Count > 0)
                        {
                            using (SqlCommand cmd1 = new SqlCommand("DELETE FROM Ebatlar WHERE EbatId IN (" + string.Join(", ", IDs[1]) + ")", con))
                            {
                                await cmd1.ExecuteNonQueryAsync();
                            }
                        }
                        if (IDs[0].Count > 0)
                        {
                            using (SqlCommand cmd1 = new SqlCommand("DELETE FROM Urun WHERE UrunId IN (" + string.Join(", ", IDs[0]) + ")", con))
                            {
                                await cmd1.ExecuteNonQueryAsync();
                            }
                        }

                        return true;
                    }
                }
            }
        }


        // Ürün bilgilerini (ebatlar dahil) çağırır
        public static async Task<UrunBilgisi?> UrunBilgisiGetir(string? ID)
        {
            if (!StrKontrol(ID, -1))
            {
                // Değerler uygunsuzdu
                return null;
            }
            else
            {
                using (SqlConnection con = new SqlConnection(ConnectionStr))
                {
                    await con.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SELECT " +
                        "Urun.UrunAdi, Urun.GirisTarihi, Urun.TeslimTarihi, Urun.TeslimEdildi, Urun.Adres, " +
                        "Ebatlar.EbatIsim, Ebatlar.EbatDeger, Ebatlar.EbatTur " +
                        "FROM Urun " +
                        "JOIN Ebatlar ON Ebatlar.UrunId = Urun.UrunId " +
                        "WHERE Urun.UrunId = @uid; ", con))
                    {
                        cmd.Parameters.Add("@uid", SqlDbType.Int).Value = ID;

                        UrunBilgisi urunBilgi = new UrunBilgisi();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            BindingList<EbatBilgi> ebatBilgileri = new BindingList<EbatBilgi>();
                            while (reader.Read()) 
                            {
                                if (urunBilgi.UrunAdi == "")
                                {
                                    urunBilgi.UrunAdi = reader.GetString("UrunAdi");
                                    urunBilgi.GirisTarihi = reader.GetDateTime("GirisTarihi");
                                    if (!reader.IsDBNull("TeslimTarihi"))
                                        urunBilgi.TeslimTarihi = reader.GetDateTime("TeslimTarihi");
                                    urunBilgi.TeslimEdildi = reader.GetBoolean("TeslimEdildi");
                                    urunBilgi.Adres = reader.GetString("Adres");
                                }

                                ebatBilgileri.Add(new EbatBilgi(reader.GetString("EbatIsim"), reader.GetString("EbatDeger"), reader.GetBoolean("EbatTur")));
                            }

                            urunBilgi.Ebatlar = ebatBilgileri;
                        }

                        return urunBilgi;
                    }
                }
            }
        }

        // Ürünün teslim edildi bilgisini düzenler
        public static async Task<bool> UrununIsaretiDegistir(string? ID, bool TeslimEdildi)
        {
            if (!StrKontrol(ID, -1))
            {
                // Değerler uygunsuzdu
                return false;
            }
            else
            {
                using (SqlConnection con = new SqlConnection(ConnectionStr))
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("UPDATE Urun SET TeslimEdildi = @teslim, TeslimTarihi = @teslimtarih WHERE UrunId = @mid", con))
                    {
                        cmd.Parameters.Add("@mid", SqlDbType.Int).Value = ID;
                        cmd.Parameters.Add("@teslim", SqlDbType.Bit).Value = TeslimEdildi;
                        cmd.Parameters.Add("@teslimtarih", SqlDbType.Date).Value = TeslimEdildi ? DateTime.Now : DBNull.Value;
                        cmd.CommandType = CommandType.Text;
                        return await cmd.ExecuteNonQueryAsync() > 0;
                    }
                }
            }
        }
    }

    public class UrunBilgisi
    {
        public string UrunAdi { get; set; } = "";
        public DateTime GirisTarihi { get; set; } = DateTime.Now;
        public DateTime? TeslimTarihi { get; set; } = DateTime.Now;
        public bool TeslimEdildi { get; set; } = false;
        public string Adres { get; set; } = "";
        public BindingList<EbatBilgi> Ebatlar { get; set; } = new BindingList<EbatBilgi>();
    }
}
