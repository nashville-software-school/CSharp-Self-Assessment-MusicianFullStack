using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MusicianFullStack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicianFullStack.Repositories
{
    public class MusicianRepository : IMusicianRepository
    {
        private readonly string _connectionString;
        public MusicianRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }

        public List<Musician> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT id, Name FROM Musician";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Musician> musicians = new List<Musician>();

                    while (reader.Read())
                    {
                        musicians.Add(new Musician()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                        });
                    }

                    reader.Close();

                    return musicians;
                }
            }
        }
    }
}
