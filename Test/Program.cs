using MetaTest.Data.Services;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new DataService();
            data.LoadDbFromFile("data\\geobase.dat");
            Console.ReadLine();
        }
    }
}
