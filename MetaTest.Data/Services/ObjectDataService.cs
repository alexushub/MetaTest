using MetaTest.Data.Interfaces;
using MetaTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MetaTest.Data.Services
{
    public class ObjectDataService : IDataService
    {
        private readonly IDataStorage _dataStorage;

        public ObjectDataService(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }
        public LocationRecord GetLocationByIp(string ip)
        {
            IPAddress.TryParse(ip, out IPAddress address);
            if (address == null)
            {
                return null;
            }
            byte[] bytes = address.GetAddressBytes();

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            var ipUint = BitConverter.ToUInt32(bytes, 0);
            var ipRecord = _dataStorage.Ips.FirstOrDefault(m => m.Ip_from <= ipUint && m.Ip_to >= ipUint);
            if (ipRecord == null)
            {
                return null;
            }

            ipRecord.Ip_from_str = IPAddress.Parse(ipRecord.Ip_from.ToString()).ToString();
            ipRecord.Ip_to_str = IPAddress.Parse(ipRecord.Ip_to.ToString()).ToString();

            var location = _dataStorage.Locations.FirstOrDefault(m => m.Order == ipRecord.Location_index);

            return location;
        }

        public IEnumerable<LocationRecord> GetLocationsByCity(string city)
        {
            var locations = _dataStorage.Locations.Where(m => m.City == city);

            return locations;
        }
    }
}
