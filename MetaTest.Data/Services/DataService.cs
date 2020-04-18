using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaTest.Data.Services
{
    public class DbHeader
    {
        public int version;           // версия база данных
        public string name;          //32 название/префикс для базы данных
        public ulong timestamp;         // время создания базы данных
        public int records;           // общее количество записей
        public uint offset_ranges;     // смещение относительно начала файла до начала списка записей с геоинформацией
        public uint offset_cities;     // смещение относительно начала файла до начала индекса с сортировкой по названию городов
        public uint offset_locations;  // смещение относительно начала файла до начала списка записей о местоположении
    }

    public class IpRecord
    {
        public uint ip_from;           // начало диапазона IP адресов
        public uint ip_to;             // конец диапазона IP адресов
        public uint location_index;    // индекс записи о местоположении
    }

    public class LocationRecord
    {
        public string country;        //8 название страны (случайная строка с префиксом "cou_")
        public string region;        //12 название области (случайная строка с префиксом "reg_")
        public string postal;        //12 почтовый индекс (случайная строка с префиксом "pos_")
        public string city;          //24 название города (случайная строка с префиксом "cit_")
        public string organization;  //32 название организации (случайная строка с префиксом "org_")
        public float latitude;          // широта
        public float longitude;         // долгота
    }

    public class DataService
    {
        public void LoadDbFromFile(string path)
        {
            var basePath = Directory.GetCurrentDirectory();
            path = Path.Combine(basePath, path);
            var s1 = Stopwatch.StartNew();

            var header = new DbHeader();
            var ips = new List<IpRecord>();
            var locations = new List<LocationRecord>();

            using (MemoryMappedFile file = MemoryMappedFile.CreateFromFile(path))
            using (MemoryMappedViewStream stream = file.CreateViewStream())
            using (BinaryReader reader = new BinaryReader(stream))
            {
                //get header
                header.version = reader.ReadInt32();
                header.name = ReadString(reader, 32);
                header.timestamp = reader.ReadUInt64();
                header.records = reader.ReadInt32();
                header.offset_ranges = reader.ReadUInt32();
                header.offset_cities = reader.ReadUInt32();
                header.offset_locations = reader.ReadUInt32();

                //get ips
                reader.BaseStream.Seek(header.offset_ranges, SeekOrigin.Begin);
                for (int i = 0; i < header.records; i++)
                {
                    var currentIpRecord = ReadIpRecord(reader);
                    ips.Add(currentIpRecord);
                }

                //get locations
                reader.BaseStream.Seek(header.offset_locations, SeekOrigin.Begin);
                for (int i = 0; i < header.records; i++)
                {
                    var currentLocationRecord = ReadLocationRecord(reader);
                    locations.Add(currentLocationRecord);
                }
            }

            s1.Stop();

            Console.WriteLine(((double)(s1.Elapsed.TotalMilliseconds)).ToString("0.00 ms"));
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
            currentIpRecord.ip_to = reader.ReadUInt32();
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
