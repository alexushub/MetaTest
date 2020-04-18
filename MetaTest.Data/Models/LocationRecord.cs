using System;
using System.Collections.Generic;
using System.Text;

namespace MetaTest.Data.Models
{
    public class LocationRecord
    {
        public int Index;
        public string country;        //8 название страны (случайная строка с префиксом "cou_")
        public string region;        //12 название области (случайная строка с префиксом "reg_")
        public string postal;        //12 почтовый индекс (случайная строка с префиксом "pos_")
        public string city;          //24 название города (случайная строка с префиксом "cit_")
        public string organization;  //32 название организации (случайная строка с префиксом "org_")
        public float latitude;          // широта
        public float longitude;         // долгота
    }
}
