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
            var ipRecord = _dataStorage.Ips.FirstOrDefault(m => m.ip_from <= ipUint && m.ip_to >= ipUint);
            if (ipRecord == null)
            {
                return null;
            }

            //var index = _dataStorage.LocationsIndexes.FirstOrDefault(m => m == ipRecord.location_index);
            //if (index == default)
            //{
            //    return null;
            //}

            var location = _dataStorage.Locations.FirstOrDefault(m => m.Order == ipRecord.location_index);

            return location;
        }

        public IEnumerable<LocationRecord> GetLocationsByCity(string city)
        {
            var locations = _dataStorage.Locations.Where(m => m.city == city);

            return locations;
        }
    }
}
