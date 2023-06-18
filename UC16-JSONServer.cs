using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace AddressBookApp
{
    public class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    class Program
    {
        static HttpClient client = new HttpClient();
        static string apiUrl = "http://localhost:3000/addressbook";

        static void Main(string[] args)
        {
            // Reading address book from JSON server
            List<Person> addressBook = ReadAddressBook();
            Console.WriteLine("Address Book:");
            foreach (var person in addressBook)
            {
                Console.WriteLine($"Name: {person.Name}, Email: {person.Email}, Phone: {person.Phone}");
            }

            // Writing a new person to the address book
            Person newPerson = new Person
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Phone = "1234567890"
            };
            WritePerson(newPerson);

            Console.ReadLine();
        }

        static List<Person> ReadAddressBook()
        {
            string responseString = client.GetStringAsync(apiUrl).Result;
            List<Person> addressBook = JsonConvert.DeserializeObject<List<Person>>(responseString);
            return addressBook;
        }

        static void WritePerson(Person person)
        {
            var json = JsonConvert.SerializeObject(person);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync(apiUrl, content).Result;

            if (response.StatusCode == HttpStatusCode.Created)
            {
                Console.WriteLine("Person added successfully!");
            }
            else
            {
                Console.WriteLine("Failed to add person!");
            }
        }
    }
}
