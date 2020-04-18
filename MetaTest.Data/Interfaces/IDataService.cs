using System;
using System.Collections.Generic;
using System.Text;

namespace MetaTest.Data.Interfaces
{
    public interface IDataService
    {
        string GetLocationByIp(string ip);

        IEnumerable<string> GetLocationsByCity(string city);
    }
}
