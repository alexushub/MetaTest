using System;
using System.Collections.Generic;
using System.Text;

namespace MetaTest.Data.Models
{
    public class IpRecord
    {
        public uint Ip_from { get; set; }           // начало диапазона IP адресов
        public string Ip_from_str { get; set; }
        public uint Ip_to { get; set; }             // конец диапазона IP адресов
        public string Ip_to_str { get; set; }
        public uint Location_index { get; set; }    // индекс записи о местоположении
    }
}
