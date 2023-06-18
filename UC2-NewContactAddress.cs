using System;
using System.Collections.Generic;

class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Address Book Program");
        List<Contact> addressBook = new List<Contact>();

        while (true)
        {
            Console.WriteLine("Enter contact details (or 'quit' to exit):");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            if (firstName.ToLower() == "quit")
                break;

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.Write("State: ");
            string state = Console.ReadLine();

            Console.Write("ZIP: ");
            string zip = Console.ReadLine();

            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Contact contact = new Contact
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                City = city,
                State = state,
                Zip = zip,
                PhoneNumber = phoneNumber,
                Email = email
            };

            addressBook.Add(contact);

            Console.WriteLine("Contact added successfully!\n");
        }

        Console.WriteLine("\nAddress Book:");
        foreach (Contact contact in addressBook)
        {
            Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
            Console.WriteLine($"Address: {contact.Address}");
            Console.WriteLine($"City: {contact.City}");
            Console.WriteLine($"State: {contact.State}");
            Console.WriteLine($"ZIP: {contact.Zip}");
            Console.WriteLine($"Phone: {contact.PhoneNumber}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine();
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey(); 
    }
}
