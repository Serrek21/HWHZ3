using System;

class Piece : IDisposable
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }

    public Piece(string title, string author, string genre, int year)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Year = year;
    }

    // Деструктор
    ~Piece()
    {
        Console.WriteLine($"П'єса {Title} видалена.");
    }

    // Метод для тестування
    public void TestPiece()
    {
        Console.WriteLine($"Назва: {Title}");
        Console.WriteLine($"Автор: {Author}");
        Console.WriteLine($"Жанр: {Genre}");
        Console.WriteLine($"Рік: {Year}");
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                Console.WriteLine($"П'єса {Title} видалена.");
            }
            disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

class Shop : IDisposable
{
    // Властивості
    public string Name { get; set; }
    public string Address { get; set; }
    public string Type { get; set; }

    public Shop(string name, string address, string type)
    {
        Name = name;
        Address = address;
        Type = type;
    }

    public void TestShop()
    {
        Console.WriteLine($"Назва: {Name}");
        Console.WriteLine($"Адреса: {Address}");
        Console.WriteLine($"Тип: {Type}");
    }

    public void Dispose()
    {
        Console.WriteLine($"Магазин {Name} видалений.");
    }

    // Деструктор
    ~Shop()
    {
        Console.WriteLine($"Магазин {Name} видалений.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (Piece piece = new Piece("Ромео і Джульєтта", "Вільям Шекспір", "драма", 1597))
        {
            piece.TestPiece();
        }

        using (Shop shop = new Shop("Супермаркет 'Продукти'", "вул. Центральна, 123", "продовольчий"))
        {
            shop.TestShop();
        }
    }
}