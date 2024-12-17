// See https://aka.ms/new-console-template for more information
using LibraryTerminal_MightyDevs;
using System.Linq.Expressions;
using static System.Formats.Asn1.AsnWriter;

//Console.WriteLine("Hello, World!");
Console.WriteLine("*******Welcome to Mighty-Devs Library Terminal*******");
string userResponse = "";
//reading the text files and split the values based on pipe symbol and store in array. then assign each part into book properties. 
//add the book into list
List<Book> bookList = new List<Book>();
List<Book> searchList = new List<Book>();
try
{   
    using StreamReader reader = new StreamReader("bookdetails.txt");
    {
        string line = "";
        while ((line = reader.ReadLine()) != null)
        {
            string[] parts = line.Split('|');

            if (parts.Length == 3)
            {
                var book = new Book()
                {
                    Title = parts[0],
                   Author = parts[1],
                    Status = (StatusEnum)Enum.Parse(typeof(StatusEnum),parts[2]),
                };
                bookList.Add(book);
            }
            if (parts.Length == 4)
            {
                var book = new Book()
                {
                    Title = parts[0],
                    Author = parts[1],
                    Status = (StatusEnum)Enum.Parse(typeof(StatusEnum), parts[2]),
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
if (!File.Exists("bookdetails.txt"))
{
    bookList = new List<Book>()
{
    new Book { Title = "Don Quixote", Author = "Miguel de Cervantes", Status = StatusEnum.OnShelf},
    new Book { Title = "Adventures in Wonderland", Author = "Lewis Carroll ", Status = StatusEnum.OnShelf},
    new Book { Title = "Adventures of Huckleberry Finn", Author = "Mark Twain", Status = StatusEnum.OnShelf},
    new Book { Title = "Adventures of Tom Sawyer", Author = "Mark Twain", Status = StatusEnum.OnShelf},
    new Book { Title = "Treasure Island", Author = "Robert Louis", Status = StatusEnum.OnShelf},
    new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Status = StatusEnum.OnShelf},
    new Book { Title = "Wuthering Heights", Author = "Emily Brontë ", Status = StatusEnum.OnShelf},
    new Book { Title = "Jane Eyre", Author = "Charlotte Brontë ", Status = StatusEnum.OnShelf},
    new Book { Title = "Macbeth", Author = "William Shakespeare", Status = StatusEnum.OnShelf},
    new Book { Title = "Merchant of Venice", Author = "William Shakespeare ", Status = StatusEnum.OnShelf},
    new Book { Title = "Mein Kamph", Author = "Adolf Hitler", Status = StatusEnum.OnShelf},
    new Book { Title = "The Great Gatsby", Author = " Scott Fitzgerald ", Status = StatusEnum.OnShelf}
};

    using StreamWriter swriter = new StreamWriter("bookdetails.txt", false);
    {
        foreach (var linetext in bookList)
        {
            swriter.WriteLine(linetext);
        }
        swriter.Close();
    }
}

//Console.WriteLine($"Title                            Author                              Status            DueDate");
Console.WriteLine($"\n\n{"Title",-35}{"Author",-30}{"Status",-15}{"Due Date",-15}");
Console.WriteLine(new string('-', 100));
//looping through book list and display the values in console application
foreach (Book bookdeatils in bookList)
{
    Console.WriteLine(bookdeatils.FormatText());
}
Console.WriteLine(new string('-', 100));
while (true)
{
    int bookIndex = 1;
    Console.WriteLine("Enter : T-Search by Title, A-Search by Author, Q-Quit");
    userResponse = Validator.IsValidString();
    if (userResponse == "t")
    {
        Console.Write("Enter the title : ");
        string userTitle = Console.ReadLine().ToLower().Trim();
        searchList = bookList.Where(x => x.Title.ToLower().StartsWith(userTitle)).ToList();

       
    }
    else if (userResponse == "a")
    {
        Console.Write("Enter the Author : ");
        string userAuthor = Console.ReadLine().ToLower().Trim();
        searchList = bookList.Where(x => x.Author.ToLower().StartsWith(userAuthor)).ToList();

        
    }
    else if(userResponse == "q")
    {
        Console.WriteLine("Exiting from the Application. Press Enter");
        Console.ReadKey();
        break;

    }

   // Console.WriteLine(" Title                         Author                           Status           ");
    Console.WriteLine($"{"Index",-6}{"Title",-35}{"Author",-30}{"Status",-15}{"Due Date",-15}");
    Console.WriteLine(new string('-', 100));
    foreach (Book book in searchList)
    {
        Console.WriteLine(bookIndex.ToString().PadRight(6) + " " + book.FormatText());
        bookIndex++;
    }
    Console.WriteLine(new string('-', 100));
    Console.WriteLine("Enter Index to Select book, S - Search Again");
        userResponse = Console.ReadLine().ToLower().Trim();
        if (userResponse == "s")
        {
            continue;
        }
        else
        {
            int userIndexNo = int.Parse(userResponse)-1;
        Console.WriteLine(new string('-', 100));
        Console.WriteLine($"{searchList[userIndexNo].Title}  {searchList[userIndexNo].Author}  {searchList[userIndexNo].Status}");
        Console.WriteLine(new string('-', 100));
        Console.Write("Enter R-Return, C-Checkout, S-Search Again :");
            userResponse = Console.ReadLine().ToLower().Trim();
            if (userResponse == "s")
            {
                continue;
            }
            else if ( userResponse == "r")
            {
                foreach(Book bookSearch in bookList)
                {
                    if (bookSearch.Title == searchList[userIndexNo].Title)
                    {
                        bookSearch.Status = StatusEnum.OnShelf;
                        bookSearch.DueDate = null;
                    Console.WriteLine($"Thank you for returning '{searchList[userIndexNo].Title}'.");
                    }
                }
            Console.WriteLine(new string('-', 100));
            //Console.WriteLine("Enter the Index No to return the book");
        }
            else if (userResponse == "c")
            {
            foreach (Book bookSearch in bookList)
            {
                if (bookSearch.Title == searchList[userIndexNo].Title)
                {
                    if (bookSearch.Status != StatusEnum.CheckedOut)
                    {
                        bookSearch.Status = StatusEnum.CheckedOut;
                        bookSearch.DueDate = DateTime.Now.AddDays(+14);
                        Console.WriteLine($"Thank you for Checking out {bookSearch.Title}, please return by {bookSearch.DueDate}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{bookSearch.Title} is already checkout. Search Again."); continue;
                    }
                }
            }
                
                
            }
            using StreamWriter swriter = new StreamWriter("bookdetails.txt", false);
            {
                foreach (var linetext in bookList)
                {
                    if (linetext.DueDate.HasValue)
                    { swriter.WriteLine($"{linetext}|{linetext.DueDate}"); }
                    else
                    {
                        swriter.WriteLine(linetext);
                    }
                }
                swriter.Close();
            }
        Console.WriteLine(new string('-', 100));
        Console.WriteLine($"{"Title",-35}{"Author",-30}{"Status",-15}{"Due Date",-15}");
        Console.WriteLine(new string('-', 100));
        foreach (Book bookdeatils in bookList)
            {
                Console.WriteLine(bookdeatils.FormatText());
            }
        Console.WriteLine(new string('-', 100));


    }


    
}

    
