using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siakad.unc.nilai
{
    public class Nilai
    {
        public int Id { get; set; }
        public string NamaMahasiswa { get; set; }
        public string MataKuliah { get; set; }
        public double Skor { get; set; }

        public Nilai(int id, string namaMahasiswa, string mataKuliah, double skor)
        {
            Id = id;
            NamaMahasiswa = namaMahasiswa;
            MataKuliah = mataKuliah;
            Skor = skor;
        }

        public override string ToString()
        {
            return $"Mata Kuliah: {MataKuliah}, Skor: {Skor}";
        }
    }

    public class MenuNilai
    {
        private List<Nilai> daftarNilai = new List<Nilai>();

        public MenuNilai()
        {
            // Sample data for demonstration
            daftarNilai.Add(new Nilai(1, "Mahasiswa1", "Matematika Dasar", 85.5));
            daftarNilai.Add(new Nilai(2, "Mahasiswa1", "Pemrograman", 90.0));
        }

        public void TampilkanMenuNilai(string namaMahasiswa)
        {
            Console.WriteLine($"\nNilai untuk {namaMahasiswa}:");
            foreach (var nilai in daftarNilai)
            {
                if (nilai.NamaMahasiswa == namaMahasiswa)
                {
                    Console.WriteLine(nilai);
                }
            }
        }
    }
}
