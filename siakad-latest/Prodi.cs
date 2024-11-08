using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace siakad.unc.prodi
{
    public class ProgramStudi
    {
        public int Id { get; set; }
        public string NamaProgramStudi { get; set; }

        public ProgramStudi(int id, string namaProgramStudi)
        {
            Id = id;
            NamaProgramStudi = namaProgramStudi;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nama Program Studi: {NamaProgramStudi}";
        }
    }

    public class MenuProgramStudi
    {
        private List<ProgramStudi> daftarProgramStudi = new List<ProgramStudi>();
        private int nextId = 1;

        public void TampilkanMenu()
        {
            int pilihan;
            do
            {
                Console.WriteLine("\nMenu Program Studi");
                Console.WriteLine("1. Tambah Program Studi");
                Console.WriteLine("2. Daftar Program Studi");
                Console.WriteLine("3. Ubah Program Studi");
                Console.WriteLine("4. Hapus Program Studi");
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
                        TambahProgramStudi();
                        break;
                    case 2:
                        DaftarProgramStudi();
                        break;
                    case 3:
                        UbahProgramStudi();
                        break;
                    case 4:
                        HapusProgramStudi();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid. Masukkan angka 1-5.");
                        break;
                }
            } while (pilihan != 5);
        }

        private void TambahProgramStudi()
        {
            Console.Write("Masukkan Nama Program Studi: ");
            string nama = Console.ReadLine();
            daftarProgramStudi.Add(new ProgramStudi(nextId++, nama));
            Console.WriteLine("Program Studi berhasil ditambahkan.");
        }

        private void DaftarProgramStudi()
        {
            Console.WriteLine("\nDaftar Program Studi:");
            if (daftarProgramStudi.Count == 0)
            {
                Console.WriteLine("Tidak ada data program studi.");
                return;
            }

            foreach (var programStudi in daftarProgramStudi)
            {
                Console.WriteLine(programStudi);
            }
        }

        private void UbahProgramStudi()
        {
            Console.Write("Masukkan ID Program Studi yang Ingin Diubah: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var programStudi = daftarProgramStudi.Find(p => p.Id == id);
                if (programStudi != null)
                {
                    Console.Write("Masukkan Nama Baru Program Studi: ");
                    programStudi.NamaProgramStudi = Console.ReadLine();
                    Console.WriteLine("Program Studi berhasil diubah.");
                }
                else
                {
                    Console.WriteLine("Program Studi dengan ID tersebut tidak ditemukan.");
                }
            }
            else
            {
                Console.WriteLine("Input tidak valid. Masukkan angka untuk ID.");
            }
        }

        private void HapusProgramStudi()
        {
            Console.Write("Masukkan ID Program Studi yang Ingin Dihapus: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var programStudi = daftarProgramStudi.Find(p => p.Id == id);
                if (programStudi != null)
                {
                    daftarProgramStudi.Remove(programStudi);
                    Console.WriteLine("Program Studi berhasil dihapus.");
                }
                else
                {
                    Console.WriteLine("Program Studi dengan ID tersebut tidak ditemukan.");
                }
            }
            else
            {
                Console.WriteLine("Input tidak valid. Masukkan angka untuk ID.");
            }
        }
    }
}
