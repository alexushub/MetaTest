using System;
using System.Collections.Generic;
using System.Text;

namespace MetaTest.Data.Models
{
    public class LocationRecord
    {
        public uint Order { get; set; }
        public string country { get; set; }       //8 название страны (случайная строка с префиксом "cou_")
        public string region { get; set; }       //12 название области (случайная строка с префиксом "reg_")
        public string postal { get; set; }        //12 почтовый индекс (случайная строка с префиксом "pos_")
        public string city { get; set; }          //24 название города (случайная строка с префиксом "cit_")
        public string organization { get; set; }  //32 название организации (случайная строка с префиксом "org_")
        public float latitude { get; set; }          // широта
        public float longitude { get; set; }         // долгота
    }
}
