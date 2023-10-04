namespace Database
{
    public static class Constants
    {
        public const string DATABSE_FILE_NAME = "ToDoSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DATABSE_FILE_NAME);
    }
}
