using MetaTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaTest.Data.Interfaces
{
    public interface IDataService
    {
        LocationRecord GetLocationByIp(string ip);

        IEnumerable<LocationRecord> GetLocationsByCity(string city);
    }
}
