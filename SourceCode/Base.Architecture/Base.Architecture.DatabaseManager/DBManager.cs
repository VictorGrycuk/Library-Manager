using LiteDB;
using System;

namespace Base.Architecture.DatabaseManager
{
    public class DBManager : IDisposable
    {
        private readonly LiteDatabase _db;
        private bool _disposedValue; // To detect redundant calls

        public DBManager(string connectionString)
        {
            _db = new LiteDatabase(connectionString);
        }

        public TableManager<TObjectType> NewTableConnection<TObjectType>(string tableName) where TObjectType : class, new()
        {
            return new TableManager<TObjectType>(_db.GetCollection<TObjectType>(tableName));
        }

        public TableManager<TObjectType> NewTableConnection<TObjectType>() where TObjectType : class, new()
        {
            return new TableManager<TObjectType>(_db.GetCollection<TObjectType>(typeof(TObjectType).Name));
        }

        private void Dispose(bool disposing)
        {
            if (_disposedValue) return;
            if (disposing)
            {
                _db.Dispose();
            }

            _disposedValue = true;
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
    }
}