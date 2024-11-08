using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siakad.unc.jadwal

{
    public class Jadwal
    {
        public int Id { get; set; }
        public string MataKuliah { get; set; }
        public string Ruangan { get; set; }
        public DateTime Tanggal { get; set; }
        public string JamMulai { get; set; }
        public string JamSelesai { get; set; }

        public Jadwal(int id, string mataKuliah, string ruangan, DateTime tanggal, string jamMulai, string jamSelesai)
        {
            Id = id;
            MataKuliah = mataKuliah;
            Ruangan = ruangan;
            Tanggal = tanggal;
            JamMulai = jamMulai;
            JamSelesai = jamSelesai;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Mata Kuliah: {MataKuliah}, Ruangan: {Ruangan}, Tanggal: {Tanggal.ToShortDateString()}, " +
                   $"Waktu: {JamMulai} - {JamSelesai}";
        }
    }

    public class MenuJadwal
    {
        private List<Jadwal> daftarJadwal = new List<Jadwal>();
        private int nextId = 1;

        public void TampilkanMenuJadwal()
        {
            int pilihan;
            do
            {
                Console.WriteLine("\nMenu Jadwal Kuliah dan Ruangan");
                Console.WriteLine("1. Tambah Jadwal");
                Console.WriteLine("2. Daftar Jadwal");
                Console.WriteLine("3. Ubah Jadwal");
                Console.WriteLine("4. Hapus Jadwal");
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
                        TambahJadwal();
                        break;
                    case 2:
                        DaftarJadwal();
                        break;
                    case 3:
                        UbahJadwal();
                        break;
                    case 4:
                        HapusJadwal();
                        break;
                    case 5:
                        Console.WriteLine("Kembali ke Menu Utama.");
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid. Masukkan angka 1-5.");
                        break;
                }
            } while (pilihan != 5);
        }

        private void TambahJadwal()
        {
            Console.Write("Masukkan Mata Kuliah: ");
            string mataKuliah = Console.ReadLine();
            Console.Write("Masukkan Ruangan: ");
            string ruangan = Console.ReadLine();
            Console.Write("Masukkan Tanggal (yyyy-MM-dd): ");

            if (DateTime.TryParse(Console.ReadLine(), out DateTime tanggal))
            {
                Console.Write("Masukkan Jam Mulai (HH:mm): ");
                string jamMulai = Console.ReadLine();
                Console.Write("Masukkan Jam Selesai (HH:mm): ");
                string jamSelesai = Console.ReadLine();

                daftarJadwal.Add(new Jadwal(nextId++, mataKuliah, ruangan, tanggal, jamMulai, jamSelesai));
                Console.WriteLine("Jadwal berhasil ditambahkan.");
            }
            else
            {
                Console.WriteLine("Format tanggal tidak valid.");
            }
        }

        private void DaftarJadwal()
        {
            Console.WriteLine("\nDaftar Jadwal Kuliah dan Ruangan:");
            if (daftarJadwal.Count == 0)
            {
                Console.WriteLine("Tidak ada jadwal.");
                return;
            }

            foreach (var jadwal in daftarJadwal)
            {
                Console.WriteLine(jadwal);
            }
        }

        private void UbahJadwal()
        {
            Console.Write("Masukkan ID Jadwal yang Ingin Diubah: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var jadwal = daftarJadwal.Find(j => j.Id == id);
                if (jadwal != null)
                {
                    Console.Write("Masukkan Mata Kuliah Baru: ");
                    jadwal.MataKuliah = Console.ReadLine();
                    Console.Write("Masukkan Ruangan Baru: ");
                    jadwal.Ruangan = Console.ReadLine();
                    Console.Write("Masukkan Tanggal Baru (yyyy-MM-dd): ");

                    if (DateTime.TryParse(Console.ReadLine(), out DateTime tanggal))
                    {
                        jadwal.Tanggal = tanggal;
                        Console.Write("Masukkan Jam Mulai Baru (HH:mm): ");
                        jadwal.JamMulai = Console.ReadLine();
                        Console.Write("Masukkan Jam Selesai Baru (HH:mm): ");
                        jadwal.JamSelesai = Console.ReadLine();

                        Console.WriteLine("Data jadwal berhasil diubah.");
                    }
                    else
                    {
                        Console.WriteLine("Format tanggal tidak valid.");
                    }
                }
                else
                {
                    Console.WriteLine("Jadwal dengan ID tersebut tidak ditemukan.");
                }
            }
            else
            {
                Console.WriteLine("Input tidak valid. Masukkan angka untuk ID.");
            }
        }

        private void HapusJadwal()
        {
            Console.Write("Masukkan ID Jadwal yang Ingin Dihapus: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var jadwal = daftarJadwal.Find(j => j.Id == id);
                if (jadwal != null)
                {
                    daftarJadwal.Remove(jadwal);
                    Console.WriteLine("Jadwal berhasil dihapus.");
                }
                else
                {
                    Console.WriteLine("Jadwal dengan ID tersebut tidak ditemukan.");
                }
            }
            else
            {
                Console.WriteLine("Input tidak valid. Masukkan angka untuk ID.");
            }
        }
    }
}
