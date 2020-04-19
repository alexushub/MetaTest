using MetaTest.Data.Helpers;
using MetaTest.Data.Interfaces;
using MetaTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MetaTest.Data.Services
{
    public class DataStorage : IDataStorage
    {
        public HeaderRecord Header { get ; set; }

        public IpRecord[] Ips { get; set; }

        public LocationRecord[] Locations { get; set; }

        public uint[] LocationsIndexes { get; set; }

        public void LoadAllFromFile(string localPath)
        {
            var basePath = Directory.GetCurrentDirectory();
            var path = Path.Combine(basePath, localPath);

            var s = Stopwatch.StartNew();

            Header = new HeaderRecord();

            using (MemoryMappedFile file = MemoryMappedFile.CreateFromFile(path))
            using (MemoryMappedViewStream stream = file.CreateViewStream())
            using (BinaryReader reader = new BinaryReader(stream))
            {
                //get header
                Header.version = reader.ReadInt32();
                Header.name = DbHelper.ReadString(reader, 32);
                Header.timestamp = reader.ReadUInt64();
                Header.records = reader.ReadInt32();
                Header.offset_ranges = reader.ReadUInt32();
                Header.offset_cities = reader.ReadUInt32();
                Header.offset_locations = reader.ReadUInt32();

                Ips = new IpRecord[Header.records];
                Locations = new LocationRecord[Header.records];
                LocationsIndexes = new uint[Header.records];

                //get ips
                reader.BaseStream.Seek(Header.offset_ranges, SeekOrigin.Begin);
                for (int i = 0; i < Header.records; i++)
                {
                    var currentIpRecord = DbHelper.ReadIpRecord(reader);
                    Ips[i] = currentIpRecord;
                }

                //get locations
                reader.BaseStream.Seek(Header.offset_locations, SeekOrigin.Begin);
                for (uint i = 0; i < Header.records; i++)
                {
                    var currentLocationRecord = DbHelper.ReadLocationRecord(reader);
                    currentLocationRecord.Order = i;
                    Locations[i] = currentLocationRecord;
                }

                //get locations indexes
                reader.BaseStream.Seek(Header.offset_cities, SeekOrigin.Begin);
                for (int i = 0; i < Header.records; i++)
                {
                    var index = reader.ReadUInt32();
                    LocationsIndexes[i] = index;
                }
            }

            s.Stop();

            Console.WriteLine("Database has been loaded in " + ((double)(s.Elapsed.TotalMilliseconds)).ToString("0.00 ms"));
        }

        
    }
}
