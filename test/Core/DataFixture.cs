using System;
using System.Data.SQLite;
using System.IO;

namespace FluentMethods.UnitTests
{
    public partial class DataFixture : IDisposable
    {
        private const string DatabaseName = "FluentMethods.db";
        private SQLiteConnection CreateConnection()
        {
            if (!File.Exists(DatabaseName))
            {
                SQLiteConnection.CreateFile(DatabaseName);
            }
            return new SQLiteConnection($"Data Source={DatabaseName};Version=3;");
        }

        public void Dispose()
        {
            if (File.Exists(DatabaseName))
            {
                File.Delete(DatabaseName);
            }
        }
    }
}
