using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siakad.unc.bimbingan
{
    public class MenuBimbingan
    {
        private List<Bimbingan> daftarBimbingan = new List<Bimbingan>();
        private int nextId = 1;

        public void TampilkanMenuBimbingan()
        {
            int pilihan;
            do
            {
                Console.WriteLine("\nMenu Bimbingan dan Dukungan");
                Console.WriteLine("1. Tambah Sesi Bimbingan");
                Console.WriteLine("2. Daftar Sesi Bimbingan");
                Console.WriteLine("3. Ubah Sesi Bimbingan");
                Console.WriteLine("4. Hapus Sesi Bimbingan");
                Console.WriteLine("5. Kembali ke Menu Utama");
                Console.Write("Pilih Menu: ");

                if (!int.TryParse(Console.ReadLine(), out pilihan))
                {
                    Console.WriteLine("Input tidak valid. Masukkan angka 1-5.");
                    continue;
                }

                switch (pilihan)
                {
                    case 1:
                        TambahSesiBimbingan();
                        break;
                    case 2:
                        DaftarSesiBimbingan();
                        break;
                    case 3:
                        UbahSesiBimbingan();
                        break;
                    case 4:
                        HapusSesiBimbingan();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid. Masukkan angka 1-5.");
                        break;
                }
            } while (pilihan != 5);
        }

        private void TambahSesiBimbingan()
        {
            Console.Write("Masukkan ID Mahasiswa: ");
            string mahasiswaId = Console.ReadLine();
            Console.Write("Masukkan Topik Bimbingan: ");
            string topik = Console.ReadLine();
            Console.Write("Masukkan Tanggal Bimbingan (yyyy-MM-dd): ");

            if (DateTime.TryParse(Console.ReadLine(), out DateTime tanggal))
            {
                daftarBimbingan.Add(new Bimbingan(nextId++, mahasiswaId, tanggal, topik));
                Console.WriteLine("Sesi bimbingan berhasil ditambahkan.");
            }
            else
            {
                Console.WriteLine("Format tanggal tidak valid.");
            }
        }

        private void DaftarSesiBimbingan()
        {
            Console.WriteLine("\nDaftar Sesi Bimbingan:");
            if (daftarBimbingan.Count == 0)
            {
                Console.WriteLine("Tidak ada sesi bimbingan.");
                return;
            }

            foreach (var sesi in daftarBimbingan)
            {
                Console.WriteLine(sesi);
            }
        }

        private void UbahSesiBimbingan()
        {
            Console.Write("Masukkan ID Sesi Bimbingan yang Ingin Diubah: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var sesi = daftarBimbingan.Find(b => b.Id == id);
                if (sesi != null)
                {
                    Console.Write("Masukkan Topik Baru: ");
                    sesi.Topik = Console.ReadLine();
                    Console.Write("Masukkan Tanggal Baru (yyyy-MM-dd): ");

                    if (DateTime.TryParse(Console.ReadLine(), out DateTime tanggal))
                    {
                        sesi.Tanggal = tanggal;
                        Console.WriteLine("Data sesi bimbingan berhasil diubah.");
                    }
                    else
                    {
                        Console.WriteLine("Format tanggal tidak valid.");
                    }
                }
                else
                {
                    Console.WriteLine("Sesi bimbingan dengan ID tersebut tidak ditemukan.");
                }
            }
            else
            {
                Console.WriteLine("Input tidak valid. Masukkan angka untuk ID.");
            }
        }

        private void HapusSesiBimbingan()
        {
            Console.Write("Masukkan ID Sesi Bimbingan yang Ingin Dihapus: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var sesi = daftarBimbingan.Find(b => b.Id == id);
                if (sesi != null)
                {
                    daftarBimbingan.Remove(sesi);
                    Console.WriteLine("Sesi bimbingan berhasil dihapus.");
                }
                else
                {
                    Console.WriteLine("Sesi bimbingan dengan ID tersebut tidak ditemukan.");
                }
            }
            else
            {
                Console.WriteLine("Input tidak valid. Masukkan angka untuk ID.");
            }
        }
    }

    public class Bimbingan
    {
        public int Id { get; }
        public string MahasiswaId { get; set; }
        public DateTime Tanggal { get; set; }
        public string Topik { get; set; }

        public Bimbingan(int id, string mahasiswaId, DateTime tanggal, string topik)
        {
            Id = id;
            MahasiswaId = mahasiswaId;
            Tanggal = tanggal;
            Topik = topik;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Mahasiswa ID: {MahasiswaId}, Tanggal: {Tanggal.ToShortDateString()}, Topik: {Topik}";
        }
    }
}
