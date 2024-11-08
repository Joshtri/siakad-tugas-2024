using System;
using System.Threading;
using siakad.unc.mahasiswa;
using siakad.unc.jadwal;
using siakad.unc.krs;
using siakad.unc.nilai;
using siakad.unc.pembayaran;

namespace siakad_latest
{
    internal class Program
    {
        static void Main(string[] args)
        {
        opsiUtama:
            Console.WriteLine("Selamat datang di SIAKAD");
            Console.Write("Apakah Anda Admin atau Mahasiswa? (1. Admin, 2. Mahasiswa): ");

            int roleChoice;
            bool isValidInput = int.TryParse(Console.ReadLine(), out roleChoice);

            if (!isValidInput || (roleChoice != 1 && roleChoice != 2))
            {
                Console.WriteLine("Input tidak valid. Masukkan angka 1 atau 2.");
                goto opsiUtama;
            }

            ShowLoading("Memuat Menu", 10);  // Show loading after selecting a role

            switch (roleChoice)
            {
                case 1:
                    Console.WriteLine("Anda masuk sebagai Admin.");
                    TampilkanMenuAdmin();
                    break;
                case 2:
                    Console.WriteLine("Anda masuk sebagai Mahasiswa.");
                    TampilkanMenuMahasiswa();
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid.");
                    break;
            }
            Console.WriteLine("Terima kasih telah menggunakan sistem.");
        }

        public static void ShowLoading(string message, int length)
        {
            Console.Write(message + " ");
            for (int i = 0; i < length; i++)
            {
                Console.Write("=");
                Thread.Sleep(100); // Delay to create loading effect
            }
            Console.WriteLine("\nSelesai.\n");
        }

        public static void TampilkanMenuAdmin()
        {
            MenuProgramStudi menuProdi = new MenuProgramStudi();
            MenuMahasiswa menuMahasiswa = new MenuMahasiswa(menuProdi);
            MenuJadwal menuJadwal = new MenuJadwal();
            KRSManager krsManager = new KRSManager();

            int pilihan;
            do
            {
                Console.WriteLine("\nMenu Admin");
                Console.WriteLine("1. Kelola Data Mahasiswa (CRUD)");
                Console.WriteLine("2. Kelola Jadwal Kuliah dan Ruangan");
                Console.WriteLine("3. Menyediakan Informasi terkait KRS");
                Console.WriteLine("4. Kembali ke Menu Utama");
                Console.Write("Pilih Menu: ");

                if (!int.TryParse(Console.ReadLine(), out pilihan))
                {
                    Console.WriteLine("Input tidak valid. Masukkan angka 1-4.");
                    continue;
                }

                ShowLoading("Proses", 10);  // Show loading before executing the selected option

                switch (pilihan)
                {
                    case 1:
                        KelolaDataMahasiswa(menuMahasiswa);
                        break;
                    case 2:
                        menuJadwal.TampilkanMenuJadwal();
                        break;
                    case 3:
                        krsManager.TampilkanInformasiKRS();
                        break;
                    case 4:
                        Console.WriteLine("Kembali ke Menu Utama.");
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid. Masukkan angka 1-4.");
                        break;
                }
            } while (pilihan != 4);
        }

        public static void TampilkanMenuMahasiswa()
        {
            MenuProgramStudi menuProdi = new MenuProgramStudi();
            MenuMahasiswa menuMahasiswa = new MenuMahasiswa(menuProdi);
            KRSManager krsManager = new KRSManager();
            MenuNilai menuNilai = new MenuNilai();
            MenuPembayaran menuPembayaran = new MenuPembayaran();

            string namaMahasiswa = "Mahasiswa1"; // This would typically be dynamically set based on login

            int pilihan;
            do
            {
                Console.WriteLine("\nMenu Mahasiswa");
                Console.WriteLine("1. Pendaftaran dan Isi Data");
                Console.WriteLine("2. Isi KRS");
                Console.WriteLine("3. Lihat Nilai");
                Console.WriteLine("4. Lihat Data Pembayaran");
                Console.WriteLine("5. Kembali ke Menu Utama");
                Console.Write("Pilih Menu: ");

                if (!int.TryParse(Console.ReadLine(), out pilihan))
                {
                    Console.WriteLine("Input tidak valid. Masukkan angka 1-5.");
                    continue;
                }

                ShowLoading("Proses", 10);  // Show loading before executing the selected option

                switch (pilihan)
                {
                    case 1:
                        menuMahasiswa.TampilkanMenuMahasiswa();
                        break;
                    case 2:
                        krsManager.IsiKRS();
                        break;
                    case 3:
                        menuNilai.TampilkanMenuNilai(namaMahasiswa);
                        break;
                    case 4:
                        menuPembayaran.TampilkanPembayaranMahasiswa(namaMahasiswa);
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

        private static void KelolaDataMahasiswa(MenuMahasiswa menuMahasiswa)
        {
            Console.WriteLine("Mengelola data mahasiswa (CRUD).");
            menuMahasiswa.TampilkanMenuMahasiswa();
        }
    }
}
