using MeFacts.Data;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeFacts
{
    public partial class App : Application
    {
        static MeFactDatabase database;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        static void prefillDatabase()
        {
            database.ClearAllAsync();
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
            database.InsertList(all);

        }

        public static MeFactDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new MeFactDatabase();
                    prefillDatabase();

                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
