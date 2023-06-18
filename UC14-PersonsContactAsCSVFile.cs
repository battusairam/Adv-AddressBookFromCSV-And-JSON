using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;

public class Person
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}

public class AddressBook
{
    private List<Person> contacts;

    public AddressBook()
    {
        contacts = new List<Person>();
    }

    public void AddContact(Person person)
    {
        contacts.Add(person);
    }

    public void SaveToFile(string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer))
        {
            csv.WriteRecords(contacts);
        }
    }

    public void LoadFromFile(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader))
        {
            contacts = new List<Person>(csv.GetRecords<Person>());
        }
    }

    public void PrintContacts()
    {
        foreach (var person in contacts)
        {
            Console.WriteLine($"Name: {person.Name}, Email: {person.Email}, Phone: {person.Phone}");
        }
    }
}

public class Program
{
    public static void Main()
    {
        var addressBook = new AddressBook();

        addressBook.AddContact(new Person { Name = "John Doe", Email = "john.doe@example.com", Phone = "123456789" });
        addressBook.AddContact(new Person { Name = "Jane Smith", Email = "jane.smith@example.com", Phone = "987654321" });

        string filePath = "addressbook.csv";
        addressBook.SaveToFile(filePath);

        addressBook = new AddressBook();

        addressBook.LoadFromFile(filePath);

        addressBook.PrintContacts();
    }
}
