using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MusicianFullStack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicianFullStack.Repositories
{
    public class DifficultyRepository : IDifficultyRepository
    {
        private readonly string _connectionString;
        public DifficultyRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }

        public List<Difficulty> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Label FROM Difficulty";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Difficulty> difficulties = new List<Difficulty>();

                    while (reader.Read())
                    {
                        Difficulty difficulty = new Difficulty()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Label = reader.GetString(reader.GetOrdinal("Label"))
                        };
                        difficulties.Add(difficulty);
                    }

                    reader.Close();

                    return difficulties;
                }
            }
        }
    }
}
