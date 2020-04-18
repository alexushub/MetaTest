using MetaTest.Data.Services;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new DataStorage();
            data.LoadAllFromFile("data\\geobase.dat");
            Console.ReadLine();
        }
    }
}
