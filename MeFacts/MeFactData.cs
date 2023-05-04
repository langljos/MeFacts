using System;
using System.Collections.Generic;

namespace MeFacts
{
    public class MeFactData
    {
        public MeFactData()
        {
        }
        public static IEnumerable<MeFactData> All { private set; get; }
        public string TheFact { get; set; }
        public string ShortFact { get; set; }
        public string Image { get; set; }
        static MeFactData()
        {
            List<MeFactData> all = new List<MeFactData>();
            all.Add(new MeFactData()
            {
                TheFact = "I am 26 years old.",
                ShortFact = "Joe's Age",
                Image = "calendar.jpg"
            });

            all.Add(new MeFactData()
            {
                TheFact = "My name is Joseph. Named after the bibical figure.",
                ShortFact = "Joe's Name",
                Image = "joseph.jpg"
            });

            all.Add(new MeFactData()
            {
                TheFact = "I like to be called Joe instead of Joseph or Joey.",
                ShortFact = "Joe not Joey",
                Image = "joey.jpg"
            });
            all.Add(new MeFactData()
            {
                TheFact = "I like to program.",
                ShortFact = "Likes",
                Image = "programming.jpg"
            });
            all.Add(new MeFactData()
            {
                TheFact = "I didn't really like the Ewoks in Star Wars.",
                ShortFact = "Star Wars",
                Image = "ewok.jpg"
            });
            All = all;

        }
    }
}