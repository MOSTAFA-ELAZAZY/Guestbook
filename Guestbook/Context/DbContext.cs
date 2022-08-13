using System.Data;
using System.Data.SqlClient;

namespace Guestbook.Context
{
    public class DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;


        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("SqlConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionstring);
    }
}
