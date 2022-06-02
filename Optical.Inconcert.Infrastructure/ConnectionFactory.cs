using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Optical.Inconcert.Infrastructure
{
    public class ConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection GetConnectionECOM
        {
            get { return GetConnection("ECOM"); }
        }

        private SqlConnection GetConnection(string cs)
        {
            var cn = new SqlConnection(_configuration.GetConnectionString(cs));
            return cn;
        }
    }
}
