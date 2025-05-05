using System;
using System.Collections.Generic;

abstract class Manusia
{
    public abstract void DisplayInfo();
}

class Mahasiswa : Manusia
{
    private string nim;
    private string nama;
    private string jurusan;

    public Mahasiswa(string nim, string nama, string jurusan)
    {
        this.nim = nim;
        this.nama = nama;
        this.jurusan = jurusan;
    }

    public string NIM
    {
        get { return nim; }
        set { nim = value; }
    }

    public string Nama
    {
        get { return nama; }
        set { nama = value; }
    }

    public string Jurusan
    {
        get { return jurusan; }
        set { jurusan = value; }
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("NIM: " + nim + ", Nama: " + nama + ", Jurusan: " + jurusan);
    }
}

class Program
{
    static List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>();

    static void Main()
    {
        bool lanjut = true;
        while (lanjut)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Tambah Mahasiswa");
            Console.WriteLine("2. Lihat Mahasiswa");
            Console.WriteLine("3. Update Mahasiswa");
            Console.WriteLine("4. Hapus Mahasiswa");
            Console.WriteLine("5. Keluar");
            Console.Write("Pilih menu (1 s.d 5): ");
            string pilihan = Console.ReadLine();

            if (pilihan == "1")
            {
                TambahMahasiswa();
            }
            else if (pilihan == "2")
            {
                LihatMahasiswa();
            }
            else if (pilihan == "3")
            {
                UpdateMahasiswa();
            }
            else if (pilihan == "4")
            {
                HapusMahasiswa();
            }
            else if (pilihan == "5")
            {
                lanjut = false;
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid.");
            }
        }
    }

    static void TambahMahasiswa()
    {
        Console.Write("Masukkan NIM: ");
        string nim = Console.ReadLine();
        if (CariMahasiswa(nim) != null)
        {
            Console.WriteLine("NIM sudah digunakan.");
            return;
        }

        Console.Write("Masukkan Nama: ");
        string nama = Console.ReadLine();
        Console.Write("Masukkan Jurusan: ");
        string jurusan = Console.ReadLine();

        Mahasiswa mhs = new Mahasiswa(nim, nama, jurusan);
        daftarMahasiswa.Add(mhs);
        Console.WriteLine("Mahasiswa berhasil ditambahkan.");
    }

    static void LihatMahasiswa()
    {
        if (daftarMahasiswa.Count == 0)
        {
            Console.WriteLine("Belum ada data mahasiswa.");
            return;
        }

        Console.WriteLine("\nDaftar Mahasiswa:");
        for (int i = 0; i < daftarMahasiswa.Count; i++)
        {
            daftarMahasiswa[i].DisplayInfo();
        }
    }

    static void UpdateMahasiswa()
    {
        Console.Write("Masukkan NIM Mahasiswa yang ingin diubah: ");
        string nim = Console.ReadLine();
        Mahasiswa mhs = CariMahasiswa(nim);
        if (mhs == null)
        {
            Console.WriteLine("Mahasiswa dengan NIM tersebut tidak ditemukan.");
            return;
        }

        Console.Write("Masukkan Nama Baru: ");
        string namaBaru = Console.ReadLine();
        Console.Write("Masukkan Jurusan Baru: ");
        string jurusanBaru = Console.ReadLine();

        mhs.Nama = namaBaru;
        mhs.Jurusan = jurusanBaru;
        Console.WriteLine("Data mahasiswa berhasil diupdate.");
    }

    static void HapusMahasiswa()
    {
        Console.Write("Masukkan NIM Mahasiswa yang ingin dihapus: ");
        string nim = Console.ReadLine();
        Mahasiswa mhs = CariMahasiswa(nim);
        if (mhs == null)
        {
            Console.WriteLine("Mahasiswa dengan NIM tersebut tidak ditemukan.");
            return;
        }

        daftarMahasiswa.Remove(mhs);
        Console.WriteLine("Data mahasiswa berhasil dihapus.");
    }

    static Mahasiswa CariMahasiswa(string nim)
    {
        for (int i = 0; i < daftarMahasiswa.Count; i++)
        {
            if (daftarMahasiswa[i].NIM == nim)
            {
                return daftarMahasiswa[i];
            }
        }
        return null;
    }
}
