using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siakad.unc.pembayaran
{
    public class Pembayaran
    {
        public string NamaMahasiswa { get; set; }
        public double JumlahPembayaran { get; set; }
        public string StatusPembayaran { get; set; }

        public Pembayaran(string namaMahasiswa, double jumlahPembayaran, string statusPembayaran)
        {
            NamaMahasiswa = namaMahasiswa;
            JumlahPembayaran = jumlahPembayaran;
            StatusPembayaran = statusPembayaran;
        }

        public override string ToString()
        {
            return $"Nama Mahasiswa: {NamaMahasiswa}, Jumlah: {JumlahPembayaran}, Status: {StatusPembayaran}";
        }
    }

    public class MenuPembayaran
    {
        private List<Pembayaran> daftarPembayaran = new List<Pembayaran>();

        public MenuPembayaran()
        {
            // Sample data for demonstration
            daftarPembayaran.Add(new Pembayaran("Mahasiswa1", 5000000, "Lunas"));
            daftarPembayaran.Add(new Pembayaran("Mahasiswa2", 4500000, "Belum Lunas"));
        }

        public void TampilkanPembayaranMahasiswa(string namaMahasiswa)
        {
            Console.WriteLine($"\nData Pembayaran untuk {namaMahasiswa}:");
            foreach (var pembayaran in daftarPembayaran)
            {
                if (pembayaran.NamaMahasiswa == namaMahasiswa)
                {
                    Console.WriteLine(pembayaran);
                }
            }
        }
    }
}
