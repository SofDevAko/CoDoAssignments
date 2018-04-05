using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using dojoLeague.Models;
 
namespace dojoLeague.Factory
{
    public class DojoFactory : IFactory<Dojo>
    {
        private string connectionString;
        public DojoFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=mydb;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public void AddDojo(Dojo dojo)
        {
                using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO dojos (Name, Location, Info) VALUES (@Name, @Location, @Info)";
                dbConnection.Open();
                dbConnection.Execute(query, dojo);
            }
        }
        public IEnumerable<Dojo> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM dojos");
            }
        }
        public Dojo FindByID(long id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM dojos WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
    }
}