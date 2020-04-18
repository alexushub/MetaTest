using MetaTest.Data.Interfaces;
using System;
using System.Collections.Generic;
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
        public string GetLocationByIp(string ip)
        {
            return "location by ip";
        }

        public IEnumerable<string> GetLocationsByCity(string city)
        {
            return new List<string> { "location1", "location2" };
        }
    }
}
