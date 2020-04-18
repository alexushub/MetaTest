﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MetaTest.Data.Models
{
    public class HeaderRecord
    {
        public int version;           // версия база данных
        public string name;          //32 название/префикс для базы данных
        public ulong timestamp;         // время создания базы данных
        public int records;           // общее количество записей
        public uint offset_ranges;     // смещение относительно начала файла до начала списка записей с геоинформацией
        public uint offset_cities;     // смещение относительно начала файла до начала индекса с сортировкой по названию городов
        public uint offset_locations;  // смещение относительно начала файла до начала списка записей о местоположении
    }
}
