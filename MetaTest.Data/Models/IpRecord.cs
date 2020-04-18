using System;
using System.Collections.Generic;
using System.Text;

namespace MetaTest.Data.Models
{
    public class IpRecord
    {
        public uint ip_from;           // начало диапазона IP адресов
        public string ip_from_str;
        public uint ip_to;             // конец диапазона IP адресов
        public string ip_to_str;
        public uint location_index;    // индекс записи о местоположении
    }
}
