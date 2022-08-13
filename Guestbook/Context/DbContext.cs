using System.Data;
using System.Data.SqlClient;

namespace Guestbook.Context
{
    public class DbContext
    {
        //Create Private From IConfiguration
        private readonly IConfiguration _configuration;
        //Create Private From IConfiguration
        private readonly string _connectionstring;


        public DbContext(IConfiguration configuration)
        {
            //Inject Data Into Conctractor
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("SqlConnection");
        }
        //Add Connection String
        public IDbConnection CreateConnection() => new SqlConnection(_connectionstring);
    }
}
