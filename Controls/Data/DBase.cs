using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_PagoJa.Controls.Data
{
    public static class DBase
    {
        public const string DatabaseFileName = "PagoJa.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DataBasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);
    }
}
