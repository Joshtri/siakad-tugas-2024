using System;
using siakad.unc.prodi;
using System.Collections.Generic;

namespace siakad.unc.mahasiswa
{
    public class Mahasiswa
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string ProgramStudi { get; set; }

        public Mahasiswa(int id, string nama, string programStudi)
        {
            Id = id;
            Nama = nama;
            ProgramStudi = programStudi;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nama: {Nama}, Program Studi: {ProgramStudi}";
        }
    }

    public class MenuProgramStudi
    {
        private List<string> daftarProgramStudi = new List<string> { "Teknik Informatika", "Sistem Informasi", "Ilmu Komputer" };

        public void TampilkanProgramStudi()
        {
            Console.WriteLine("Daftar Program Studi:");
            for (int i = 0; i < daftarProgramStudi.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {daftarProgramStudi[i]}");
            }
        }

        public string PilihProgramStudi()
        {
            TampilkanProgramStudi();
            Console.Write("Pilih Program Studi (Masukkan angka): ");
            if (int.TryParse(Console.ReadLine(), out int pilihan) && pilihan > 0 && pilihan <= daftarProgramStudi.Count)
            {
                return daftarProgramStudi[pilihan - 1];
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid. Program Studi default dipilih.");
                return daftarProgramStudi[0];
            }
        }
    }

    public class MenuMahasiswa
    {
        private List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>();
        private MenuProgramStudi menuProgramStudi;
        private int nextId = 1;

        public MenuMahasiswa(MenuProgramStudi menuProgramStudi) // Use siakad.unc.prodi.MenuProgramStudi
        {
            this.menuProgramStudi = menuProgramStudi;
        }

        public void TampilkanMenuMahasiswa()
        {
            int pilihan;
            do
            {
                Console.WriteLine("\nMenu Mahasiswa");
                Console.WriteLine("1. Tambah Mahasiswa");
                Console.WriteLine("2. Daftar Mahasiswa");
                Console.WriteLine("3. Ubah Mahasiswa");
                Console.WriteLine("4. Hapus Mahasiswa");
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
                        TambahMahasiswa();
                        break;
                    case 2:
                        DaftarMahasiswa();
                        break;
                    case 3:
                        UbahMahasiswa();
                        break;
                    case 4:
                        HapusMahasiswa();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid. Masukkan angka 1-5.");
                        break;
                }
            } while (pilihan != 5);
        }

        private void TambahMahasiswa()
        {
            Console.Write("Masukkan Nama Mahasiswa: ");
            string nama = Console.ReadLine();
            Console.WriteLine("Pilih Program Studi:");
            string programStudi = menuProgramStudi.PilihProgramStudi();

            daftarMahasiswa.Add(new Mahasiswa(nextId++, nama, programStudi));
            Console.WriteLine("Mahasiswa berhasil ditambahkan.");
        }

        private void DaftarMahasiswa()
        {
            Console.WriteLine("\nDaftar Mahasiswa:");
            if (daftarMahasiswa.Count == 0)
            {
                Console.WriteLine("Tidak ada data mahasiswa.");
                return;
            }

            foreach (var mahasiswa in daftarMahasiswa)
            {
                Console.WriteLine(mahasiswa);
            }
        }

        private void UbahMahasiswa()
        {
            Console.Write("Masukkan ID Mahasiswa yang Ingin Diubah: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var mahasiswa = daftarMahasiswa.Find(m => m.Id == id);
                if (mahasiswa != null)
                {
                    Console.Write("Masukkan Nama Baru Mahasiswa: ");
                    mahasiswa.Nama = Console.ReadLine();
                    Console.WriteLine("Pilih Program Studi Baru:");
                    mahasiswa.ProgramStudi = menuProgramStudi.PilihProgramStudi();
                    Console.WriteLine("Data mahasiswa berhasil diubah.");
                }
                else
                {
                    Console.WriteLine("Mahasiswa dengan ID tersebut tidak ditemukan.");
                }
            }
            else
            {
                Console.WriteLine("Input tidak valid. Masukkan angka untuk ID.");
            }
        }

        private void HapusMahasiswa()
        {
            Console.Write("Masukkan ID Mahasiswa yang Ingin Dihapus: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var mahasiswa = daftarMahasiswa.Find(m => m.Id == id);
                if (mahasiswa != null)
                {
                    daftarMahasiswa.Remove(mahasiswa);
                    Console.WriteLine("Mahasiswa berhasil dihapus.");
                }
                else
                {
                    Console.WriteLine("Mahasiswa dengan ID tersebut tidak ditemukan.");
                }
            }
            else
            {
                Console.WriteLine("Input tidak valid. Masukkan angka untuk ID.");
            }
        }
    }
}
