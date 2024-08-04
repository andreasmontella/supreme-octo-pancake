using System;

abstract class Vehicle
{
    private string brand;
    private int year;

    public Vehicle(string brand, int year)
    {
        this.brand = brand ?? throw new ArgumentNullException(nameof(brand)); // Periksa null
        this.year = year;
    }

    public string Brand
    {
        get { return brand; }
        set { brand = value ?? throw new ArgumentNullException(nameof(value)); } // Periksa null
    }

    public int Year
    {
        get { return year; }
        set { year = value; }
    }

    public abstract void DisplayInfo();
}

class Car : Vehicle
{
    public Car(string brand, int year) : base(brand, year)
    {
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("\nInformasi Mobil:");
        Console.WriteLine("Merek: " + Brand);
        Console.WriteLine("Tahun: " + Year);
    }
}

class Motorcycle : Vehicle
{
    private bool hasSidecar;

    public Motorcycle(string brand, int year, bool hasSidecar) : base(brand, year)
    {
        this.hasSidecar = hasSidecar;
    }

    public bool HasSidecar
    {
        get { return hasSidecar; }
        set { hasSidecar = value; }
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("\nInformasi Sepeda Motor:");
        Console.WriteLine("Merek: " + Brand);
        Console.WriteLine("Tahun: " + Year);
        Console.WriteLine("Memiliki Sidecar: " + (HasSidecar ? "Ya" : "Tidak"));
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Login
            string correctUsername = "andreasm";
            string correctPassword = "andpass123";

            Console.WriteLine("Selamat datang di Penyimpanan Data Kendaraan!");
            Console.WriteLine("Silakan login untuk melanjutkan.");
            Console.WriteLine(); // Menambahkan spasi

            Console.Write("Username: ");
            string? username = Console.ReadLine();

            Console.Write("Password: ");
            string? password = Console.ReadLine();

            if (username == correctUsername && password == correctPassword)
            {
                Console.WriteLine("Login berhasil!");
                Console.WriteLine("Silakan masukkan data kendaraanmu dan kami akan menyimpannya.");
                Console.WriteLine(); // Menambahkan spasi

                Console.Write("Masukkan jenis kendaraan (Mobil/Sepeda Motor): ");
                string? type = Console.ReadLine();

                Console.Write("Masukkan merek: ");
                string? brand = Console.ReadLine();

                Console.Write("Masukkan tahun: ");
                string? yearInput = Console.ReadLine();
                int year = int.Parse(yearInput ?? throw new ArgumentNullException(nameof(yearInput))); // Periksa null

                Console.WriteLine(); // Menambahkan spasi

                if (type != null && type.Equals("Mobil", StringComparison.OrdinalIgnoreCase))
                {
                    if (brand != null)
                    {
                        Car car = new Car(brand, year);
                        car.DisplayInfo();
                    }
                    else
                    {
                        Console.WriteLine("Merek kendaraan tidak boleh kosong.");
                    }
                }
                else if (type != null && type.Equals("Sepeda Motor", StringComparison.OrdinalIgnoreCase))
                {
                    if (brand != null)
                    {
                        Console.Write("Apakah memiliki sidecar? (true/false): ");
                        string? sidecarInput = Console.ReadLine();
                        bool hasSidecar = bool.Parse(sidecarInput ?? throw new ArgumentNullException(nameof(sidecarInput))); // Periksa null
                        Motorcycle motorcycle = new Motorcycle(brand, year, hasSidecar);
                        motorcycle.DisplayInfo();
                    }
                    else
                    {
                        Console.WriteLine("Merek kendaraan tidak boleh kosong.");
                    }
                }
                else
                {
                    Console.WriteLine("Jenis kendaraan tidak valid.");
                }

                Console.WriteLine(); // Menambahkan spasi
                Console.WriteLine("Data kendaraan Anda berhasil disimpan!");
            }
            else
            {
                Console.WriteLine("Login gagal. Username atau password salah.");
            }

            // Tambahkan baris ini untuk mencegah jendela konsol tertutup langsung
            Console.WriteLine("\nTekan Enter untuk keluar...");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Terjadi kesalahan: " + ex.Message);
            Console.WriteLine("\nTekan Enter untuk keluar...");
            Console.ReadLine();
        }
    }
}
