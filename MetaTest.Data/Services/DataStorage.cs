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
                Header.name = ReadString(reader, 32);
                Header.timestamp = reader.ReadUInt64();
                Header.records = reader.ReadInt32();
                Header.offset_ranges = reader.ReadUInt32();
                Header.offset_cities = reader.ReadUInt32();
                Header.offset_locations = reader.ReadUInt32();

                Ips = new IpRecord[Header.records];
                Locations = new LocationRecord[Header.records];

                //get ips
                reader.BaseStream.Seek(Header.offset_ranges, SeekOrigin.Begin);
                for (int i = 0; i < Header.records; i++)
                {
                    var currentIpRecord = ReadIpRecord(reader);
                    Ips[i] = currentIpRecord;
                }

                //get locations
                reader.BaseStream.Seek(Header.offset_locations, SeekOrigin.Begin);
                for (int i = 0; i < Header.records; i++)
                {
                    var currentLocationRecord = ReadLocationRecord(reader);
                    Locations[i] = currentLocationRecord;
                }
            }

            s.Stop();

            Console.WriteLine(((double)(s.Elapsed.TotalMilliseconds)).ToString("0.00 ms"));
        }

        private LocationRecord ReadLocationRecord(BinaryReader reader)
        {
            var currentLocationRecord = new LocationRecord();

            currentLocationRecord.country = ReadString(reader, 8);
            currentLocationRecord.region = ReadString(reader, 12);
            currentLocationRecord.postal = ReadString(reader, 12);
            currentLocationRecord.city = ReadString(reader, 24);
            currentLocationRecord.organization = ReadString(reader, 32);
            currentLocationRecord.latitude = reader.ReadSingle();
            currentLocationRecord.longitude = reader.ReadSingle();

            return currentLocationRecord;
        }

        private IpRecord ReadIpRecord(BinaryReader reader)
        {
            var currentIpRecord = new IpRecord();
            currentIpRecord.ip_from = reader.ReadUInt32();
            currentIpRecord.ip_from_str = IPAddress.Parse(currentIpRecord.ip_from.ToString()).ToString();
            currentIpRecord.ip_to = reader.ReadUInt32();
            currentIpRecord.ip_to_str = IPAddress.Parse(currentIpRecord.ip_to.ToString()).ToString();
            currentIpRecord.location_index = reader.ReadUInt32();

            return currentIpRecord;
        }

        private string ReadString(BinaryReader reader, int length)
        {
            byte[] bytes = new byte[length];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = reader.ReadByte();
            }

            var str = Encoding.UTF8.GetString(bytes.Where(m => m != 0).ToArray());

            return str;
        }
    }
}
