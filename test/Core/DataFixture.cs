using System;
using System.IO;

namespace FluentMethods.UnitTests
{
#if NetCore
    public partial class DataFixture
    {
        private Microsoft.Data.Sqlite.SqliteConnection CreateConnection()
        {
            return new Microsoft.Data.Sqlite.SqliteConnection("Data Source=:memory:");
        }
    }
#else
    public partial class DataFixture : IDisposable
    {
        private const string DatabaseName = "FluentMethods.db";
        private System.Data.SQLite.SQLiteConnection CreateConnection()
        {
            if (!File.Exists(DatabaseName))
            {
                System.Data.SQLite.SQLiteConnection.CreateFile(DatabaseName);
            }
            return new System.Data.SQLite.SQLiteConnection($"Data Source={DatabaseName};Version=3;");
        }

        public void Dispose()
        {
            if (File.Exists(DatabaseName))
            {
                File.Delete(DatabaseName);
            }
        }
    }
#endif
}
