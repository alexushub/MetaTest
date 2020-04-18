using MetaTest.Data.Interfaces;
using MetaTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaTest.Data.Services
{
    public class RawDataService : IDataService
    {
        public RawDataService()
        {

        }
        public LocationRecord GetLocationByIp(string ip)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LocationRecord> GetLocationsByCity(string city)
        {
            throw new NotImplementedException();
        }
    }
}
