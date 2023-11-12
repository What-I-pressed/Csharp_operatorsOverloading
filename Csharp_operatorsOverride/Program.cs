using System;
using System.Numerics;
using System.Security.Cryptography;

Magazine mag = new Magazine("Vogue", new DateTime(2000, 3, 23), "Smth", 200) ;
Console.WriteLine($"Number of emploees : {mag.NumberOfEmploees}");
mag.NumberOfEmploees = mag.NumberOfEmploees + 20;
Console.WriteLine($"Number of emploees : {mag.NumberOfEmploees}");
mag.NumberOfEmploees = mag.NumberOfEmploees - 40;
Console.WriteLine($"Number of emploees : {mag.NumberOfEmploees}");
Console.WriteLine($"Number of emploees = 200 : {mag.NumberOfEmploees == 200}");
Console.WriteLine($"Number of emploees != 200 : {mag.NumberOfEmploees != 200}");
Magazine mag1 = mag;
Console.WriteLine($"Equals : {mag.Equals(mag1)}\n");

Shop shop = new Shop("ATB","Stepana Bandery 30", "Shop...", 250);
Console.WriteLine($"Area : {shop.Area}");
shop.Area = shop + 50;
Console.WriteLine($"Area : {shop.Area}");
shop.Area = shop - 20;
Console.WriteLine($"Area : {shop.Area}");
Console.WriteLine($"Area == 280 : {shop == 280}");
Console.WriteLine($"Area != 260 : {shop != 260}");
Shop sh = new Shop("A", "A", "A", 0);
Console.WriteLine($"Equals : {shop.Equals(sh)}");
int i = 0;

ReadingList list = new ReadingList();
list = list + "Idk";
list = list + "Smth";
list = list + "etc";
list = list + "...";
list.Info();
Console.WriteLine();
list = list - "...";
list.Info();
Console.WriteLine($"Index of 'Smth' : {list.Find("Smth")}");
Console.WriteLine(list[1]);


class Magazine
{
    private string name;
    private DateTime yearOfFoundation;
    private string description;
    private int numberOfEmploees;


    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public DateTime YearOfFoundation
    {
        get { return yearOfFoundation; }
        set { yearOfFoundation = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public int NumberOfEmploees
    {
        get { return numberOfEmploees; }
        set { if (value >= 0) numberOfEmploees = value;
            else numberOfEmploees = 0; }
    }

    public static int operator +(Magazine m, int n)
    {
        return m.NumberOfEmploees + n;
    }

    public static int operator -(Magazine m, int n)
    {
        return m.NumberOfEmploees - n;
    }

    public static bool operator ==(Magazine m, int n)
    {
        return m.NumberOfEmploees == n;
    }

    public static bool operator !=(Magazine m, int n)
    {
        return m.NumberOfEmploees != n;
    }

    public override bool Equals(object? obj)
    {
        if(obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        Magazine mag = obj as Magazine;
        return name == mag.Name && yearOfFoundation == mag.YearOfFoundation &&
            description == mag.description && numberOfEmploees == mag.NumberOfEmploees;
    }

    public void setData(string name, DateTime yearOfFoundation, string description, int numberOfemploees)
    {
        this.name = name;
        this.yearOfFoundation = yearOfFoundation;
        this.description = description;
        this.numberOfEmploees = numberOfemploees;
    }

    public Magazine(string name, DateTime yearOfFoundation, string description, int numberOfemploees)
    {
        this.name = name;
        this.yearOfFoundation = yearOfFoundation;
        this.description = description;
        this.numberOfEmploees = numberOfemploees;
    }

    public void Info()
    {
        Console.WriteLine($"Name : {name}\nYear of foundation : {yearOfFoundation.Year}\n" +
            $"Description : {description}\n");
    }
}

class Shop
{
    private string name;
    private string address;
    private string description;
    public int Area { set; get; }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public static int operator +(Shop shop, int a)
    {
        return shop.Area + a;
    }

    public static int operator -(Shop shop, int a)
    {
        return shop.Area - a;
    }

    public static bool operator ==(Shop shop, int a)
    {
        return shop.Area == a;
    }

    public static bool operator !=(Shop shop, int a)
    {
        return shop.Area != a;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        Shop shop = obj as Shop;
        return name == shop.Name && address == shop.address &&
            description == shop.description && Area == shop.Area;
    }

    public Shop(string name, string address, string description, int area)
    {
        this.name = name;
        this.address = address;
        this.description = description;
        this.Area = area;
    }

    public void Info()
    {
        Console.WriteLine("Shop name : " + name);
        Console.WriteLine("Address: " + address);
        Console.WriteLine("Description : " + description);
    }
}

class Book
{
    public string Name { get; set; }
    
    public void Info()
    {
        Console.WriteLine($"Name : {Name}");
    }

    public static bool operator ==(Book book1, Book book2)
    {
        return book1.Name == book2.Name;
    }

    public Book(string name)
    {
        this.Name = name;
    }

    public static bool operator !=(Book book1, Book book2)
    {
        return book1.Name != book2.Name;
    }

    public static implicit operator Book(string str)
    {
        return new Book(str);
    }
}

class ReadingList
{
    public Book[] books { get; set; }

    public ReadingList(int numberOfBooks)
    {
        books = new Book[numberOfBooks];
    }

    public Book[] Delete(int index)
    {
        if(books != null)
        {
            Book[] newBooks = new Book[books.Length - 1];
            for (int i = 0, j = 0; i < books.Length; i++, j++)
            {
                if (i == index)
                {
                    j--;
                    continue;
                }
                newBooks[j] = books[i];
            }
            books = newBooks;
            return books;
        }
        return null;
    }

    public Book[] Delete(Book book)
    {
        if (books != null)
        {
            Book[] newBooks = new Book[books.Length - 1];
            for (int i = 0, j = 0; i < books.Length; i++, j++)
            {
                if (books[i] == book)
                {
                    j--;
                    continue;
                }
                newBooks[j] = books[i];
            }
            books = newBooks;
            return books;
        }
        return null;
    }

    public void Add(Book book, int index = -1)
    {
        Book[] newBooks;
        if (books == null)
        {
            books = new Book[1];
            books[0] = book;
            return;
        }
        newBooks = new Book[books.Length + 1];
        for (int i = 0, j = 0; i < books.Length; i++, j++)
        {
            if (i == index)
            {
                newBooks[j++] = book;
                continue;
            }
            newBooks[j] = books[i];
        }
        if (index == -1) newBooks[newBooks.Length - 1] = book;
        books = newBooks;
    }

    public ReadingList() { ; }

    public ReadingList(Book[] books)
    {
        this.books = books;
    }

    public int Find(Book book)
    {
        if(books != null)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] == book)
                {
                    return i;
                }
            }
        }
        return -1;
    }

    public bool Contain(Book book)
    {
        foreach(var b in books)
        {
            if(book == b)return true;
        }
        return false;
    }

    public static ReadingList operator +(ReadingList list, Book book)
    {
        ReadingList rl = new ReadingList();
        if (list.books != null)
            for (int i = 0; i < list.books.Length; i++) rl.Add(list.books[i]);
        rl.Add(book);
        return rl;
        
    }

    public static ReadingList operator -(ReadingList list, Book book)                                                     
    {
        ReadingList rl = new ReadingList();
        rl.books = list.Delete(book);
        return rl;
    }

    public string this[int index]
    {
        get { return books[index].Name; }
        set { books[index].Name = value; }
    }

    public void Info()
    {
        if(books != null)
        {
            foreach(Book book in books)
            {
                book.Info();
            }
        }
        
    }
}
