using System;
using System.Collections.Generic;
using SQLite;

namespace MeFacts
{
    public class MeFactData
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string TheFact { get; set; }
        public string ShortFact { get; set; }
        public string Image { get; set; }
    }
}