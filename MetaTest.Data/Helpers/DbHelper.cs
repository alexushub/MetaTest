using MetaTest.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MetaTest.Data.Helpers
{
    public static class DbHelper
    {
        public static LocationRecord ReadLocationRecord(BinaryReader reader)
        {
            var currentLocationRecord = new LocationRecord();

            currentLocationRecord.Country = ReadString(reader, 8);
            currentLocationRecord.Region = ReadString(reader, 12);
            currentLocationRecord.Postal = ReadString(reader, 12);
            currentLocationRecord.City = ReadString(reader, 24);
            currentLocationRecord.Organization = ReadString(reader, 32);
            currentLocationRecord.Latitude = reader.ReadSingle();
            currentLocationRecord.Longitude = reader.ReadSingle();

            return currentLocationRecord;
        }

        public static IpRecord ReadIpRecord(BinaryReader reader)
        {
            var currentIpRecord = new IpRecord();
            currentIpRecord.Ip_from = reader.ReadUInt32();
            currentIpRecord.Ip_to = reader.ReadUInt32();
            currentIpRecord.Location_index = reader.ReadUInt32();

            return currentIpRecord;
        }

        public static string ReadString(BinaryReader reader, int length)
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
