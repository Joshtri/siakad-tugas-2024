using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siakad.unc.krs
{
    public class KRS
    {
        public string NamaMataKuliah { get; set; }
        public string Kelas { get; set; }
        public int SKS { get; set; }
        public string KodeMataKuliah { get; set; }

        public KRS(string namaMataKuliah, string kelas, int sks, string kodeMataKuliah)
        {
            NamaMataKuliah = namaMataKuliah;
            Kelas = kelas;
            SKS = sks;
            KodeMataKuliah = kodeMataKuliah;
        }

        public override string ToString()
        {
            return $"Mata Kuliah: {NamaMataKuliah}, Kelas: {Kelas}, SKS: {SKS}, Kode: {KodeMataKuliah}";
        }
    }

    public class KRSManager
    {
        private List<KRS> daftarKRS = new List<KRS>();

        public KRSManager()
        {
            // Sample KRS data
            daftarKRS.Add(new KRS("Matematika Dasar", "A", 3, "MAT101"));
            daftarKRS.Add(new KRS("Pemrograman", "B", 4, "PROG201"));
            daftarKRS.Add(new KRS("Fisika Dasar", "A", 3, "FIS102"));
        }

        // Method to display all available KRS information
        public void TampilkanInformasiKRS()
        {
            Console.WriteLine("\nInformasi KRS:");
            if (daftarKRS.Count == 0)
            {
                Console.WriteLine("Tidak ada informasi KRS yang tersedia.");
                return;
            }

            foreach (var krs in daftarKRS)
            {
                Console.WriteLine(krs);
            }
        }

        // Method for a Mahasiswa to choose a course from the available KRS
        public void IsiKRS()
        {
            Console.WriteLine("\nPilih Mata Kuliah yang ingin diambil:");
            for (int i = 0; i < daftarKRS.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {daftarKRS[i]}");
            }

            Console.Write("Masukkan nomor mata kuliah yang ingin diambil: ");
            if (int.TryParse(Console.ReadLine(), out int pilihan) && pilihan > 0 && pilihan <= daftarKRS.Count)
            {
                KRS selectedKRS = daftarKRS[pilihan - 1];
                Console.WriteLine($"Anda telah memilih mata kuliah: {selectedKRS.NamaMataKuliah}");
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid.");
            }
        }
    }
}
