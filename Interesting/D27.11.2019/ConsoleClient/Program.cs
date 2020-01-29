using System;
using System.Collections.Generic;
using System.Data;
using MiniRefection;

namespace ConsoleClient
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var clients = new List<Client>
            {
                new Client {Id = 1, Name = "Joseph Albahari", BirthDate = new DateTime(1960,4, 7)},
                new Client {Id = 2, Name = "Ben Albahari", BirthDate = new DateTime(2000, 5, 5)}
            };
            
            clients.ToTableView(Console.Out);
        }
    }

    class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}