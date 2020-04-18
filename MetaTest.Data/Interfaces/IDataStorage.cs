using MetaTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaTest.Data.Interfaces
{
    public interface IDataStorage
    {
        HeaderRecord Header { get; set; }

        IpRecord[] Ips { get; set; }

        LocationRecord[] Locations { get; set; }

        void LoadAllFromFile(string localPath);
    }
}
