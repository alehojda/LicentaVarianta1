using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Licenta2.Services
{
    public static class Constants
    {
        //weather constants
        public const string OpenWeatherMapEndpoint = "https://api.openweathermap.org/data/2.5/weather";
        public const string OpenWeatherMapAPIKey = "INSERT_API_KEY_HERE";

        //db constants
        public const string DatabaseFilename = "licenta_db.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
