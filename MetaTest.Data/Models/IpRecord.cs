using System;
using System.Collections.Generic;
using System.Text;

namespace MetaTest.Data.Models
{
    public class IpRecord
    {
        public uint ip_from { get; set; }           // начало диапазона IP адресов
        public string ip_from_str { get; set; }
        public uint ip_to { get; set; }             // конец диапазона IP адресов
        public string ip_to_str { get; set; }
        public uint location_index { get; set; }    // индекс записи о местоположении
        public uint LocationId { get; set; }
    }
}
