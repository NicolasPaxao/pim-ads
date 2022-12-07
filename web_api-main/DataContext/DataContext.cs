using System.Data;
using System.Diagnostics;

namespace web_api.Data
{
    public class DataContext : IDisposable
    {
        public IDbConnection DbConnection { get; private set; }
        public DataContext(IDbConnection dbConnection)
        {
            this.DbConnection = dbConnection;
            OpenConnectionService(this.DbConnection);
        }

        private static IDbConnection OpenConnectionService(IDbConnection conn)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return conn;
        }

        public void Dispose() => DbConnection?.Dispose();
    }
}
