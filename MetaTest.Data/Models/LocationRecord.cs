using System;
using System.Collections.Generic;
using System.Text;

namespace MetaTest.Data.Models
{
    public class LocationRecord
    {
        public uint Order { get; set; }
        public string Country { get; set; }       //8 название страны (случайная строка с префиксом "cou_")
        public string Region { get; set; }       //12 название области (случайная строка с префиксом "reg_")
        public string Postal { get; set; }        //12 почтовый индекс (случайная строка с префиксом "pos_")
        public string City { get; set; }          //24 название города (случайная строка с префиксом "cit_")
        public string Organization { get; set; }  //32 название организации (случайная строка с префиксом "org_")
        public float Latitude { get; set; }          // широта
        public float Longitude { get; set; }         // долгота
    }
}
