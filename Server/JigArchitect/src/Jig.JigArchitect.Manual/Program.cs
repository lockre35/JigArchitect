using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jig.JigArchitect.Manual.Seeds;

namespace Jig.JigArchitect.Manual
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Seeding database...");
            var seeder = new Seeder();
            seeder.Seed();
            Console.WriteLine("Seeding complete!");
            System.Threading.Thread.Sleep(1000);
        }
    }
}
