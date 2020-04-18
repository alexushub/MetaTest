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

            currentLocationRecord.country = ReadString(reader, 8);
            currentLocationRecord.region = ReadString(reader, 12);
            currentLocationRecord.postal = ReadString(reader, 12);
            currentLocationRecord.city = ReadString(reader, 24);
            currentLocationRecord.organization = ReadString(reader, 32);
            currentLocationRecord.latitude = reader.ReadSingle();
            currentLocationRecord.longitude = reader.ReadSingle();

            return currentLocationRecord;
        }

        public static IpRecord ReadIpRecord(BinaryReader reader)
        {
            var currentIpRecord = new IpRecord();
            currentIpRecord.ip_from = reader.ReadUInt32();
            //currentIpRecord.ip_from_str = IPAddress.Parse(currentIpRecord.ip_from.ToString()).ToString();
            currentIpRecord.ip_to = reader.ReadUInt32();
            //currentIpRecord.ip_to_str = IPAddress.Parse(currentIpRecord.ip_to.ToString()).ToString();
            currentIpRecord.location_index = reader.ReadUInt32();

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
