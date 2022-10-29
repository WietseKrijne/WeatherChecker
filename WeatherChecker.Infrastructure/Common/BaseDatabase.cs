using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherChecker.Infrastructure.Common
{
    public abstract class BaseDatabase : IDisposable
    {
        private IDbConnection? _con = null;

        protected IDbConnection Connection()
        {
            if (_con == null || _con.State == ConnectionState.Closed)
            {
                var c = new SqlConnection("Server=localhost;Database=weatherdb;Trusted_Connection=True;");
                c.Open();
                _con = c;
            }
            return _con;
        }

        // Not really relevent now, but this is also the place where transaction logic is stored.


        public void Dispose()
        {
            _con?.Dispose();
        }
    }
}
