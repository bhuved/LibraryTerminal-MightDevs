// See https://aka.ms/new-console-template for more information
using LibraryTerminal_MightyDevs;
using static System.Formats.Asn1.AsnWriter;

Console.WriteLine("Hello, World!");
Console.WriteLine("*******Library Terminal*******");

List<Book> bookList = new List<Book>();
try
{
    using StreamReader reader = new StreamReader("bookdetails.txt");
    {
        string line = "";
        while ((line = reader.ReadLine()) != null)
        {
            string[] parts = line.Split('|');

            if (parts.Length == 4)
            {
                var book = new Book()
                {
                    Title = parts[0],
                   Author = parts[1],
                    Status = (StatusEnum)Enum.Parse(typeof(StatusEnum),parts[2]),
                   DueDate = DateTime.Parse(parts[3])
                };
                bookList.Add(book);
            }

        }
    }
}
catch (FileNotFoundException)
{
    Console.WriteLine("File does not exist. Creating Books");
    
}
if (!File.Exists("bookdetails.txt)"))
{
    bookList = new List<Book>()
{
    new Book { Title = "Don Quixote", Author = "Miguel de Cervantes", Status = StatusEnum.OnShelf, DueDate =DateTime.Now },
    new Book { Title = "Adventures in Wonderland", Author = "Lewis Carroll ", Status = StatusEnum.OnShelf, DueDate =DateTime.Now },
    new Book { Title = "Adventures of Huckleberry Finn", Author = "Mark Twain", Status = StatusEnum.OnShelf, DueDate =DateTime.Now },
    new Book { Title = "Adventures of Tom Sawyer", Author = "Mark Twain", Status = StatusEnum.OnShelf, DueDate =DateTime.Now },
    new Book { Title = "Treasure Island", Author = "Robert Louis", Status = StatusEnum.OnShelf, DueDate =DateTime.Now },
    new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Status = StatusEnum.OnShelf, DueDate =DateTime.Now },
    new Book { Title = "Wuthering Heights", Author = "Emily Brontë ", Status = StatusEnum.OnShelf, DueDate =DateTime.Now },
    new Book { Title = "Jane Eyre", Author = "Charlotte Brontë ", Status = StatusEnum.OnShelf, DueDate =DateTime.Now },
    new Book { Title = "Macbeth", Author = "William Shakespeare", Status = StatusEnum.OnShelf, DueDate =DateTime.Now },
    new Book { Title = "Merchant of Venice", Author = "William Shakespeare ", Status = StatusEnum.OnShelf, DueDate =DateTime.Now },
    new Book { Title = "Mein Kamph", Author = "Adolf Hitler", Status = StatusEnum.OnShelf, DueDate =DateTime.Now },
    new Book { Title = "The Great Gatsby", Author = " Scott Fitzgerald ", Status = StatusEnum.OnShelf, DueDate =DateTime.Now },
};

    using StreamWriter swriter = new StreamWriter("bookdetails.txt", true);
    {
        foreach (var linetext in bookList)
        {
            swriter.WriteLine(linetext);
        }
        swriter.Close();
    }
}

Console.WriteLine("Title                         Author                           Status            Duedate");

foreach (Book bookdeatils in bookList)
{
    Console.WriteLine(bookdeatils.FormatText());
}
Console.WriteLine("-------------------------------------------------------------------------------------------------------");
Console.WriteLine("Enter number : 1-Search by Title, 2-Search by Author, 3-Checkout, 4-Return book");


