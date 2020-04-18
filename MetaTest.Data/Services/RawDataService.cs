using MetaTest.Data.Interfaces;
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
        public string GetLocationByIp(string ip)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetLocationsByCity(string city)
        {
            throw new NotImplementedException();
        }
    }
}
